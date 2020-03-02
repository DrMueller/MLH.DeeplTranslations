using System;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;
using Mmu.Mlh.DeeplTranslations.Areas.Services;

namespace Mmu.Mlh.DeeplTranslations.TestConsole.Areas.Commands
{
    public class AutoDetect : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IDeeplTranslator _deeplTranslator;
        private readonly ITranslationRequestBuilderFactory _requestBuilderFactory;

        public string Description { get; } = "Translate some parts";
        public ConsoleKey Key { get; } = ConsoleKey.F1;

        public AutoDetect(
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
                .WithTextPart("Tra", "Hallo Welt")
                .Build();

            var translation = await _deeplTranslator.TranslateAsync(request);
            var translatedText = translation.TranslatedTexts.Single();

            _consoleWriter.WriteLine($"Detected source language: {translatedText.DetectedSourceLanguage}");
            _consoleWriter.WriteLine($"Text: {translatedText.TextPart.Text}");
        }
    }
}