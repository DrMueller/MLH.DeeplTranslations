using System.Threading.Tasks;
using Mmu.Mlh.DeeplTranslations.Areas.Exceptions;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Requests;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Results;
using Mmu.Mlh.DeeplTranslations.Areas.Services.Servants;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services.Implementation
{
    internal class DeeplTranslator : IDeeplTranslator
    {
        private readonly ITranslationResultAdapter _resultAdapter;
        private readonly ITranslationRequestSender _sender;

        public DeeplTranslator(
            ITranslationResultAdapter resultAdapter,
            ITranslationRequestSender sender)
        {
            _resultAdapter = resultAdapter;
            _sender = sender;
        }

        public async Task<TranslationResult> TranslateAsync(TranslationRequest request)
        {
            var response = await _sender.SendRequestAsync(request);

            if (!response.WasSuccess)
            {
                var msg = $"The Deepl API returned with code {response.StatusCode} and message '{response.ReturnMessage}'.";
                throw new DeeplTranslationException(msg);
            }

            var result = _resultAdapter.Adapt(request, response.Content);
            return result;
        }
    }
}