using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.DeeplTranslations.Areas.Models.Requests
{
    public class IgnoreForTranslationMarkup
    {
        public const string DeeplIgnoreTag = "x";
        public static readonly string DeeplIgnoreBeginTag = $"<{DeeplIgnoreTag}>";
        public static readonly string DeeplIgnoreEndTag = $"</{DeeplIgnoreTag}>";
        public string CustomBeginTag { get; }
        public string CustomEndTag { get; }

        public IgnoreForTranslationMarkup(string customBeginTag, string customEndTag)
        {
            Guard.StringNotNullOrEmpty(() => customBeginTag);
            Guard.StringNotNullOrEmpty(() => customEndTag);

            CustomBeginTag = customBeginTag;
            CustomEndTag = customEndTag;
        }
    }
}