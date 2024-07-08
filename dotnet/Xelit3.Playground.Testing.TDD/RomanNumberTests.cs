using FluentAssertions;

namespace Xelit3.Playground.Testing.TDD;

public class RomanNumberTests
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    public void Given_DecimalNumber_When_ToRomanNumber_Then_CorrespondingRomanNumberRetrieved(int decimalNumber, string expectedRomanNumber)
    {
        var romanNumberResult = decimalNumber.ToRomanNumber();

        romanNumberResult.Should().Be(expectedRomanNumber);
    }
}