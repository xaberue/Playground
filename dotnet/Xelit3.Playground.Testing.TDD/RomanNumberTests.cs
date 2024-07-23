using FluentAssertions;

namespace Xelit3.Playground.Testing.TDD;

public class RomanNumberTests
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(11, "XI")]
    [InlineData(12, "XII")]
    [InlineData(13, "XIII")]
    [InlineData(40, "XL")]
    [InlineData(50, "L")]
    [InlineData(90, "XC")]
    [InlineData(100, "C")]
    [InlineData(400, "CD")]
    [InlineData(500, "D")]
    [InlineData(900, "CM")]
    [InlineData(1000, "M")]
    public void Given_DecimalNumber_When_ToRomanNumber_Then_CorrespondingRomanNumberRetrieved(int decimalNumber, string expectedRomanNumber)
    {
        var romanNumberResult = decimalNumber.ToRomanNumber();

        romanNumberResult.Should().Be(expectedRomanNumber);
    }
}