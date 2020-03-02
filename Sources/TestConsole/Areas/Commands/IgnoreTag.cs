using System;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;
using Mmu.Mlh.DeeplTranslations.Areas.Services;

namespace Mmu.Mlh.DeeplTranslations.TestConsole.Areas.Commands
{
    public class IgnoreTag : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IDeeplTranslator _deeplTranslator;
        private readonly ITranslationRequestBuilderFactory _requestBuilderFactory;

        public string Description { get; } = "Translate with ignore tags";
        public ConsoleKey Key { get; } = ConsoleKey.F2;

        public IgnoreTag(
            IConsoleWriter consoleWriter,
            IDeeplTranslator deeplTranslator,
            ITranslationRequestBuilderFactory requestBuilderFactory)
        {
            _consoleWriter = consoleWriter;
            _deeplTranslator = deeplTranslator;
            _requestBuilderFactory = requestBuilderFactory;
        }

        public async Task ExecuteAsync()
        {
            var request = _requestBuilderFactory
                .StartBuilding(TranslationLanguage.English)
                .WithSourceLanguage(TranslationLanguage.German)
                .WithTextPart("Tra", "Hallo Welt {{ Dieser Text hier wird nicht übersetzt }}. Dieser hier aber schon.")
                .WithIgnoreMarkupTag("{{", "}}")
                .Build();

            var translation = await _deeplTranslator.TranslateAsync(request);
            var translatedText = translation.TranslatedTexts.Single();

            _consoleWriter.WriteLine($"Text: {translatedText.TextPart.Text}");
        }
    }
}