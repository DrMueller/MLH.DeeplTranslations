using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.DeeplTranslations.Areas.Models.Results
{
    public class TextTranslation
    {
        public TranslationLanguage DetectedSourceLanguage { get; }
        public TextPart TextPart { get; }

        internal TextTranslation(TranslationLanguage detectedSourceLanguage, TextPart textPart)
        {
            Guard.ObjectNotNull(() => detectedSourceLanguage);
            Guard.ObjectNotNull(() => textPart);

            DetectedSourceLanguage = detectedSourceLanguage;
            TextPart = textPart;
        }
    }
}