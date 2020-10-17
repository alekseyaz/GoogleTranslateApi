﻿using Zaac.GoogleTranslate.Enums;

namespace Zaac.GoogleTranslate.Entities
{
    public class TranslationResult
    {
        public TranslationResultTypes TranslationResultTypes { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public string SourceText { get; set; }

        public string TargetText { get; set; }

        public string FailedReason { get; set; }

    }
}