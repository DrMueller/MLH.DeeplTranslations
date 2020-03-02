using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.DeeplTranslations.Areas.Models.Common
{
    public class TextPart
    {
        public string Key { get; }
        public string Text { get; }

        public TextPart(string key, string text)
        {
            Guard.StringNotNullOrEmpty(() => key);
            Guard.StringNotNullOrEmpty(() => text);

            Key = key;
            Text = text;
        }
    }
}