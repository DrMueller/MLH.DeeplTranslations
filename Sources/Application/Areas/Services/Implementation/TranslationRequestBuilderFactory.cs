using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services.Implementation
{
    internal class TranslationRequestBuilderFactory : ITranslationRequestBuilderFactory
    {
        public ITranslationRequestBuilder StartBuilding(TranslationLanguage targetLanguage)
        {
            return new TranslationRequestBuilder(targetLanguage);
        }
    }
}