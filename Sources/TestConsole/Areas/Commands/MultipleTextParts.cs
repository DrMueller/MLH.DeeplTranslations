using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Common;
using Mmu.Mlh.DeeplTranslations.Areas.Services;

namespace Mmu.Mlh.DeeplTranslations.TestConsole.Areas.Commands
{
    public class MultipleTextParts : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IDeeplTranslator _deeplTranslator;
        private readonly ITranslationRequestBuilderFactory _requestBuilderFactory;

        public string Description { get; } = "Translate multiple text parts";
        public ConsoleKey Key { get; } = ConsoleKey.F3;

        public MultipleTextParts(
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
                .StartBuilding(TranslationLanguage.German)
                .WithSourceLanguage(TranslationLanguage.English)
                .WithTextPart("Text1", "Hello world")
                .WithTextPart("Text2", "This is a sentence to verify the translation")
                .Build();

            var translation = await _deeplTranslator.TranslateAsync(request);

            _consoleWriter.WriteLine($"Text1: {translation["Text1"].TextPart.Text}");
            _consoleWriter.WriteLine($"Text2: {translation["Text2"].TextPart.Text}");
        }
    }
}