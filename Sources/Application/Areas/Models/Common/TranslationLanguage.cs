﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.DeeplTranslations.Areas.Models.Common
{
    public class TranslationLanguage
    {
        private static readonly Lazy<IReadOnlyCollection<TranslationLanguage>> _lazyAll = new Lazy<IReadOnlyCollection<TranslationLanguage>>(
            () => new List<TranslationLanguage>
            {
                Dutch,
                English,
                French,
                German,
                Italian,
                Polish,
                Portuguese,
                Spanish
            });

        [SuppressMessage("ReSharper", "ReturnTypeCanBeEnumerable.Global", Justification = "Indicates inmemory list")]
        public static IReadOnlyCollection<TranslationLanguage> All => _lazyAll.Value;

        public static TranslationLanguage Dutch { get; } = new TranslationLanguage("NL", "Dutch");
        public static TranslationLanguage English { get; } = new TranslationLanguage("EN", "English");
        public static TranslationLanguage French { get; } = new TranslationLanguage("FR", "French");
        public static TranslationLanguage German { get; } = new TranslationLanguage("DE", "German");
        public static TranslationLanguage Italian { get; } = new TranslationLanguage("IT", "Italian");
        public static TranslationLanguage Polish { get; } = new TranslationLanguage("PL", "Polish");
        public static TranslationLanguage Portuguese { get; } = new TranslationLanguage("PT", "Portuguese");
        public static TranslationLanguage Spanish { get; } = new TranslationLanguage("ES", "Spanish");

        public string Code { get; }

        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "Easier for clients")]
        public string Description { get; }

        private TranslationLanguage(string code, string description)
        {
            Guard.StringNotNullOrEmpty(() => code);
            Guard.StringNotNullOrEmpty(() => description);

            Code = code;
            Description = description;
        }

        public static TranslationLanguage CreateByCode(string code)
        {
            return All.Single(f => f.Code == code);
        }
    }
}