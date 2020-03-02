using System.Threading.Tasks;
using Mmu.Mlh.DeeplTranslations.Areas.Dtos;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Requests;
using Mmu.Mlh.RestExtensions.Areas.Models;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services.Servants
{
    internal interface ITranslationRequestSender
    {
        Task<RestCallResult<TranslationResultDto>> SendRequestAsync(TranslationRequest request);
    }
}