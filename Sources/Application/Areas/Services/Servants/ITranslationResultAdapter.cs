using Mmu.Mlh.DeeplTranslations.Areas.Dtos;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Requests;
using Mmu.Mlh.DeeplTranslations.Areas.Models.Results;

namespace Mmu.Mlh.DeeplTranslations.Areas.Services.Servants
{
    internal interface ITranslationResultAdapter
    {
        TranslationResult Adapt(TranslationRequest request, TranslationResultDto resultDto);
    }
}