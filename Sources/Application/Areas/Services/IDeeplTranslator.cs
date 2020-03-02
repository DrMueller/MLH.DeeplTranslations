using System.Threading.Tasks;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Requests;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Results;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services
{
    public interface IDeeplTranslator
    {
        Task<TranslationResult> TranslateAsync(TranslationRequest request);
    }
}