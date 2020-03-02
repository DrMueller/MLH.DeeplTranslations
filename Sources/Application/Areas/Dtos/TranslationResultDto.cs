using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.DeeplTranslations.Areas.Dtos
{
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Global", Justification = "REST binding")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "REST binding")]
    internal class TranslationResultDto
    {
        public List<TranslatedTextDto> Translations { get; set; }
    }
}