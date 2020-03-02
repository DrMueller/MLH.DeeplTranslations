using System.Collections.Generic;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Requests;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services.Implementation
{
    internal class TranslationRequestBuilder : ITranslationRequestBuilder
    {
        private readonly TranslationLanguage _targetLanguage;
        private readonly List<TextPart> _textParts = new List<TextPart>();
        private IgnoreForTranslationMarkup _ignoreMarkup;
        private TranslationLanguage _sourceLanguage;

        public TranslationRequestBuilder(TranslationLanguage targetLanguage)
        {
            _targetLanguage = targetLanguage;
        }

        public TranslationRequest Build()
        {
            var request = new TranslationRequest(
                _targetLanguage,
                Maybe.CreateFromNullable(_sourceLanguage),
                Maybe.CreateFromNullable(_ignoreMarkup),
                _textParts);

            return request;
        }

        public ITranslationRequestBuilder WithIgnoreMarkupTag(string beginTag, string endTag)
        {
            _ignoreMarkup = new IgnoreForTranslationMarkup(beginTag, endTag);
            return this;
        }

        public ITranslationRequestBuilder WithSourceLanguage(TranslationLanguage sourceLanguage)
        {
            _sourceLanguage = sourceLanguage;
            return this;
        }

        public ITranslationRequestBuilder WithTextPart(string key, string text)
        {
            _textParts.Add(new TextPart(key, text));
            return this;
        }
    }
}