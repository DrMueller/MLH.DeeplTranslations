using System;
using Mmu.Mlh.DeeplTranslations.Infrastructure.Settings.Dtos;
using Mmu.Mlh.DeeplTranslations.Infrastructure.Settings.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;
using Mmu.Mlh.SettingsProvisioning.Areas.Models;

namespace Mmu.Mlh.DeeplTranslations.TestConsole.Infrastructure.Settings
{
    public class DeeplSettingsProvider : IDeeplSettingsProvider
    {
        public DeeplSettingsDto Settings { get; }

        public DeeplSettingsProvider(ISettingsFactory settingsFactory)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new SettingsConfiguration(
                "AppSettings",
                environmentName,
                typeof(DeeplSettingsProvider).Assembly.GetBasePath(),
                "Apps/DeeplTranslations");

            Settings = settingsFactory.CreateSettings<DeeplSettingsDto>(config);
        }
    }
}