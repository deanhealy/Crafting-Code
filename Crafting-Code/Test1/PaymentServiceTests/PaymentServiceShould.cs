using CraftingCode.PaymentService;
using Moq;
using System;
using Xunit;

namespace UnitTests.PaymentServiceTests
{
    [Trait("Category", "Unit")]
    public class PaymentServiceShould
    {
        [Fact]
        public void throw_exception_when_fraudservice_is_null_in_constructor()
        {
            var mockPaymentGateway = new Mock<IPaymentGateway>().Object;

            var exception = Record.Exception(() => new PaymentService(null, mockPaymentGateway));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void throw_exception_when_paymentgateway_is_null_in_constructor()
        {
            var mockFraudService = new Mock<IFraudService>().Object;

            var exception = Record.Exception(() => new PaymentService(mockFraudService, null));

            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}
