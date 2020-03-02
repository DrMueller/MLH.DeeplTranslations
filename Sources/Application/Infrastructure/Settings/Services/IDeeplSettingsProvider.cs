using Mmu.Mlh.DeeplTranslations.Infrastructure.Settings.Dtos;

namespace Mmu.Mlh.DeeplTranslations.Infrastructure.Settings.Services
{
    public interface IDeeplSettingsProvider
    {
        DeeplSettingsDto Settings { get; }
    }
}