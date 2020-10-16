using System;

namespace CraftingCode.PaymentService
{
    public class PaymentService
    {
        private readonly FraudService _fraudService;
        private readonly PaymentGateway _paymentGateway;

        public PaymentService(FraudService fraudService, PaymentGateway paymentGateway)
        {
            _fraudService = fraudService ?? throw new ArgumentNullException(nameof(fraudService));
            _paymentGateway = paymentGateway ?? throw new ArgumentNullException(nameof(paymentGateway));
        }

        public void ProcessPayment(User user, PaymentDetails paymentDetails)
        {
            if (_fraudService.IsFraudulent(user, paymentDetails))
            {
                throw new FraudlentPaymentException();
            }
            _paymentGateway.PayWith(paymentDetails);
        }
    }
}
