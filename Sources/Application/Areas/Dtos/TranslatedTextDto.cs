using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.DeeplTranslations.Areas.Dtos
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "REST binding")]
    internal class TranslatedTextDto
    {
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Defined by Deepl API")]
        public string Detected_source_language { get; set; }

        public string Text { get; set; }
    }
}