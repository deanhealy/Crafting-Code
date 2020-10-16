using CraftingCode.PaymentService;
using Moq;
using System;
using Xunit;

namespace UnitTests.PaymentServiceTests
{
    [Trait("Category", "Unit")]
    public class PaymentServiceShould
    {
        private static readonly User USER = new User();
        private static readonly PaymentDetails PAYMENT_DETAILS = new PaymentDetails();
        private static readonly PaymentDetails FRAUDULENT_PAYMENT_DETAILS = new PaymentDetails();

        [Fact]
        public void throw_exception_when_fraudservice_is_null_in_constructor()
        {
            var mockPaymentGateway = new Mock<PaymentGateway>().Object;

            var exception = Record.Exception(() => new PaymentService(null, mockPaymentGateway));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void throw_exception_when_paymentgateway_is_null_in_constructor()
        {
            var mockFraudService = new Mock<FraudService>().Object;

            var exception = Record.Exception(() => new PaymentService(mockFraudService, null));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void throw_exception_when_fraud_is_detected()
        {
            var mockFraudService = new Mock<FraudService>();
            mockFraudService.Setup(x => x.IsFraudulent(USER, FRAUDULENT_PAYMENT_DETAILS)).Returns(true);
            var mockPaymentGateway = new Mock<PaymentGateway>();
            var paymentService = new PaymentService(mockFraudService.Object, mockPaymentGateway.Object);

            Assert.Throws<FraudlentPaymentException>(() => paymentService.ProcessPayment(USER, FRAUDULENT_PAYMENT_DETAILS));
            mockFraudService.Verify(x => x.IsFraudulent(USER, FRAUDULENT_PAYMENT_DETAILS), Times.Once);
        }

        [Fact]
        public void process_payment_details_when_payment_is_legit()
        {
            var mockFraudService = new Mock<FraudService>();
            mockFraudService.Setup(x => x.IsFraudulent(USER, FRAUDULENT_PAYMENT_DETAILS)).Returns(false);
            var mockPaymentGateway = new Mock<PaymentGateway>();
            var paymentService = new PaymentService(mockFraudService.Object, mockPaymentGateway.Object);

            paymentService.ProcessPayment(USER, PAYMENT_DETAILS);
            mockPaymentGateway.Verify(x => x.PayWith(PAYMENT_DETAILS), Times.Once);
        }

        [Fact]
        public void not_process_payment_when_fraud_is_detected()
        {
            var mockFraudService = new Mock<FraudService>();
            mockFraudService.Setup(x => x.IsFraudulent(USER, FRAUDULENT_PAYMENT_DETAILS)).Returns(true);
            var mockPaymentGateway = new Mock<PaymentGateway>();
            var paymentService = new PaymentService(mockFraudService.Object, mockPaymentGateway.Object);

            Assert.Throws<FraudlentPaymentException>(() => paymentService.ProcessPayment(USER, FRAUDULENT_PAYMENT_DETAILS));
            mockPaymentGateway.Verify(x => x.PayWith(PAYMENT_DETAILS), Times.Never);
        }

    }
}
