using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.DeeplTranslations.Areas.Models.Results
{
    public class TranslationResult
    {
        public TextTranslation this[string textPartKey] => TranslatedTexts.Single(f => f.TextPart.Key == textPartKey);

        public IReadOnlyCollection<TextTranslation> TranslatedTexts { get; }

        internal TranslationResult(IReadOnlyCollection<TextTranslation> translatedTexts)
        {
            Guard.ObjectNotNull(() => translatedTexts);

            TranslatedTexts = translatedTexts;
        }
    }
}