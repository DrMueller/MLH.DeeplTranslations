using Mmu.Mlh.DeeplTranslations.Areas.Services;
using Mmu.Mlh.DeeplTranslations.Areas.Services.Implementation;
using Mmu.Mlh.DeeplTranslations.Areas.Services.Servants;
using Mmu.Mlh.DeeplTranslations.Areas.Services.Servants.Implementation;
using StructureMap;

namespace Mmu.Mlh.DeeplTranslations.Infrastructure.DependencyInjection
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            For<ITranslationRequestBuilderFactory>().Use<TranslationRequestBuilderFactory>().Singleton();
            For<ITranslationRequestSender>().Use<TranslationRequestSender>().Singleton();
            For<ITranslationResultAdapter>().Use<TranslationResultAdapter>().Singleton();
            For<IDeeplTranslator>().Use<DeeplTranslator>().Singleton();
        }
    }
}