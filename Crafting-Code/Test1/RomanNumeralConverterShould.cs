using CraftingCode;
using Xunit;

namespace UnitTests
{
    [Trait("Category", "Unit")]
    public class RomanNumeralConverterShould
    {
        [Theory]
        [InlineData(493, "CDXCIII")]
        [InlineData(11, "XI")]
        [InlineData(6, "VI")]
        [InlineData(5, "V")]
        [InlineData(4, "IV")]
        [InlineData(3, "III")]
        [InlineData(2, "II")]
        [InlineData(1, "I")]
        public void convert_number_to_roman_numerical_correctly(int number, string numerical)
        {
            var romanNumeralConverter = new RomanNumeralConverter();
            var result = romanNumeralConverter.Convert(number);
            Assert.Equal(numerical, result);
        }
    }
}
