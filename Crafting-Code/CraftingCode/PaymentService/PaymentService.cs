using System;

namespace CraftingCode.PaymentService
{
    public class PaymentService
    {
        private readonly IFraudService _fraudService;
        private readonly IPaymentGateway _paymentGateway;

        public PaymentService(IFraudService fraudService, IPaymentGateway paymentGateway)
        {
            _fraudService = fraudService ?? throw new ArgumentNullException(nameof(fraudService));
            _paymentGateway = paymentGateway ?? throw new ArgumentNullException(nameof(paymentGateway));
        }

        public void processPayment(User user, PaymentDetails paymentDetails)
        {

        }
    }
}
