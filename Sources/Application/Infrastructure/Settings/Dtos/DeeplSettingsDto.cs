using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.DeeplTranslations.Infrastructure.Settings.Dtos
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "Automatic binding")]
    public class DeeplSettingsDto
    {
        public string DeeplApiKey { get; set; }
    }
}