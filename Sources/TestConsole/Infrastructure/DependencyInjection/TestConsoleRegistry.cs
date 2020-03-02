using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.DeeplTranslations.Infrastructure.Settings.Services;
using Mmu.Mlh.DeeplTranslations.TestConsole.Infrastructure.Settings;
using StructureMap;

namespace Mmu.Mlh.DeeplTranslations.TestConsole.Infrastructure.DependencyInjection
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestConsoleRegistry>();
                    scanner.AddAllTypesOf<IConsoleCommand>();
                });

            For<IDeeplSettingsProvider>().Use<DeeplSettingsProvider>().Singleton();
        }
    }
}