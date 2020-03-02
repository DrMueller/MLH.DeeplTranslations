using System.Collections.Generic;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.DeeplTranslations.Areas.Models.Requests
{
    public class TranslationRequest
    {
        public const int MaxTextParts = 50;

        public Maybe<IgnoreForTranslationMarkup> IgnoreMarkup { get; }
        public Maybe<TranslationLanguage> SourceLanguage { get; }
        public TranslationLanguage TargetLanguage { get; }
        public IReadOnlyCollection<TextPart> TextParts { get; }

        public TranslationRequest(
            TranslationLanguage targetLanguage,
            Maybe<TranslationLanguage> sourceLanguage,
            Maybe<IgnoreForTranslationMarkup> ignoreMarkup,
            IReadOnlyCollection<TextPart> textParts)
        {
            Guard.ObjectNotNull(() => targetLanguage);
            Guard.ObjectNotNull(() => sourceLanguage);
            Guard.ObjectNotNull(() => ignoreMarkup);
            Guard.ObjectNotNull(() => textParts);

            Guard.That(() => textParts.Count > 0, "At least one text part to translate is required.");
            Guard.That(() => textParts.Count <= MaxTextParts, "Only up to 50 text parameters can be submitted in one request.");

            TargetLanguage = targetLanguage;
            SourceLanguage = sourceLanguage;
            IgnoreMarkup = ignoreMarkup;
            TextParts = textParts;
        }
    }
}