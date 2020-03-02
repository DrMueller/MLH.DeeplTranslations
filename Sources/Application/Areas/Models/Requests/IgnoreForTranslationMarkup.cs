using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.DeeplTranslations.Areas.Models.Requests
{
    public class IgnoreForTranslationMarkup
    {
        internal const string DeeplIgnoreTag = "x";
        internal static readonly string DeeplIgnoreBeginTag = $"<{DeeplIgnoreTag}>";
        internal static readonly string DeeplIgnoreEndTag = $"</{DeeplIgnoreTag}>";
        public string BeginTag { get; }
        public string EndTag { get; }

        public IgnoreForTranslationMarkup(string beginTag, string endTag)
        {
            Guard.StringNotNullOrEmpty(() => beginTag);
            Guard.StringNotNullOrEmpty(() => endTag);

            BeginTag = beginTag;
            EndTag = endTag;
        }
    }
}