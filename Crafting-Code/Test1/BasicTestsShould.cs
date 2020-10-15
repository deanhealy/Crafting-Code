using Xunit;

namespace UnitTests
{
    [Trait("Category", "Unit")]
    public class BasicTestsShould
    {
        [Fact]
        public void AssertTrue_IsTrue()
        {
            Assert.True(true);
        }
    }
}
