using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.DeeplTranslations.Areas.Dtos;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Requests;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Results;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services.Servants.Implementation
{
    internal class TranslationResultAdapter : ITranslationResultAdapter
    {
        public TranslationResult Adapt(TranslationRequest request, TranslationResultDto resultDto)
        {
            var translations = new List<TextTranslation>();

            for (var i = 0; i < resultDto.Translations.Count; i++)
            {
                var translationDto = resultDto.Translations.ElementAt(i);
                var detectedSourceLanguage = TranslationLanguage.CreateByCode(translationDto.Detected_source_language);
                var textKey = request.TextParts.ElementAt(i).Key;
                var text = translationDto.Text;

                request.IgnoreMarkup.Evaluate(
                    markup =>
                    {
                        text = text.Replace(IgnoreForTranslationMarkup.DeeplIgnoreBeginTag, markup.BeginTag);
                        text = text.Replace(IgnoreForTranslationMarkup.DeeplIgnoreEndTag, markup.EndTag);
                    });

                var identifiableText = new TextPart(textKey, text);
                translations.Add(new TextTranslation(detectedSourceLanguage, identifiableText));
            }

            return new TranslationResult(translations);
        }
    }
}