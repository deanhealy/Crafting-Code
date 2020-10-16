using System;
using System.Runtime.Serialization;

namespace CraftingCode.PaymentService
{
    [Serializable]
    public class FraudlentPaymentException : Exception
    {
        public FraudlentPaymentException()
        {
        }

        public FraudlentPaymentException(string message) : base(message)
        {
        }

        public FraudlentPaymentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FraudlentPaymentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}