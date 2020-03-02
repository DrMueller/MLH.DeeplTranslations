using System;
using System.Threading.Tasks;
using Mmu.Mlh.DeeplTranslations.Areas.Dtos;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Requests;
using Mmu.Mlh.DeeplTranslations.Infrastructure.Settings.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.RestExtensions.Areas.Models;
using Mmu.Mlh.RestExtensions.Areas.QueryParamBuilding;
using Mmu.Mlh.RestExtensions.Areas.RestCallBuilding;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services.Servants.Implementation
{
    internal class TranslationRequestSender : ITranslationRequestSender
    {
        private static readonly Uri _deeplApiUrl = new Uri("https://api.deepl.com/v2/translate");
        private readonly IRestCallBuilderFactory _restCallBuilderFactory;
        private readonly IRestProxy _restProxy;
        private readonly IDeeplSettingsProvider _settingsProvider;

        public TranslationRequestSender(
            IDeeplSettingsProvider settingsProvider,
            IRestCallBuilderFactory restCallBuilderFactory,
            IRestProxy restProxy)
        {
            _settingsProvider = settingsProvider;
            _restCallBuilderFactory = restCallBuilderFactory;
            _restProxy = restProxy;
        }

        public async Task<RestCallResult<TranslationResultDto>> SendRequestAsync(TranslationRequest request)
        {
            var restCall = BuildRestCall(request);
            var response = await _restProxy.PerformCallAsync<TranslationResultDto>(restCall);

            return response;
        }

        private RestCall BuildRestCall(TranslationRequest request)
        {
            var builder = _restCallBuilderFactory
                .StartBuilding(_deeplApiUrl, RestCallMethodType.Post);

            var queryParamBuilder = builder.WithQueryParameters()
                .WithQueryParameter("auth_key", _settingsProvider.Settings.DeeplApiKey)
                .WithQueryParameter("target_lang", request.TargetLanguage.Code);

            ApplySourceLanguage(request, queryParamBuilder);
            ApplyTextParts(request, queryParamBuilder);
            ApplyIgnoreMarkup(request, queryParamBuilder);

            builder = queryParamBuilder.BuildQueryParameters();
            return builder.Build();
        }

        private static void ApplyIgnoreMarkup(TranslationRequest request, IRestQueryParameterBuilder queryParamBuilder)
        {
            request.IgnoreMarkup.Evaluate(
                markup =>
                {
                    queryParamBuilder
                        .WithQueryParameter("tag_handling", "xml")
                        .WithQueryParameter("ignore_tags", IgnoreForTranslationMarkup.DeeplIgnoreTag);
                });
        }

        private static void ApplyTextParts(TranslationRequest request, IRestQueryParameterBuilder queryParamBuilder)
        {
            request.TextParts.ForEach(
                tp =>
                {
                    var textToSend = request.IgnoreMarkup.Evaluate(
                        markup => tp.Text
                            .Replace(markup.EndTag, IgnoreForTranslationMarkup.DeeplIgnoreEndTag)
                            .Replace(markup.BeginTag, IgnoreForTranslationMarkup.DeeplIgnoreBeginTag),
                        () => tp.Text);

                    queryParamBuilder.WithQueryParameter("text", textToSend);
                });
        }

        private static void ApplySourceLanguage(TranslationRequest request, IRestQueryParameterBuilder queryParamBuilder)
        {
            request.SourceLanguage.Evaluate(
                language =>
                {
                    queryParamBuilder.WithQueryParameter("source_lang", language.Code);
                });
        }
    }
}