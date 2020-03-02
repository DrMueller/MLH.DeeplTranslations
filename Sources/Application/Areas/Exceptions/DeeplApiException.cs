using System;
using System.Runtime.Serialization;

namespace Mmu.Mlh.DeeplTranslations.Areas.Exceptions
{
    [Serializable]
    public class DeeplApiException : Exception
    {
        public DeeplApiException()
        {
        }

        public DeeplApiException(string message)
            : base(message)
        {
        }

        public DeeplApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DeeplApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}