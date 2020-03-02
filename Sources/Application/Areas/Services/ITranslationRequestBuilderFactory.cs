using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services
{
    public interface ITranslationRequestBuilderFactory
    {
        ITranslationRequestBuilder StartBuilding(TranslationLanguage targetLanguage);
    }
}