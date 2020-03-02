using System;
using System.Runtime.Serialization;

namespace Mmu.Mlh.DeeplTranslations.Areas.Exceptions
{
    [Serializable]
    public class DeeplTranslationException : Exception
    {
        public DeeplTranslationException()
        {
        }

        public DeeplTranslationException(string message)
            : base(message)
        {
        }

        public DeeplTranslationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DeeplTranslationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}