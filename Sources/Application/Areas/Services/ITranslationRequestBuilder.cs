using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Requests;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services
{
    public interface ITranslationRequestBuilder
    {
        TranslationRequest Build();

        ITranslationRequestBuilder WithIgnoreMarkupTag(string beginTag, string endTag);

        ITranslationRequestBuilder WithSourceLanguage(TranslationLanguage sourceLanguage);

        ITranslationRequestBuilder WithTextPart(string key, string text);
    }
}