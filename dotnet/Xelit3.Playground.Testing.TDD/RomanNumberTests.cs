using FluentAssertions;

namespace Xelit3.Playground.Testing.TDD;

public class RomanNumberTests
{
    [Fact]
    public void Given_1_When_ToRomanNumber_Then_IRetrieved()
    {
        var romanNumberResult = 1.ToRomanNumber();

        romanNumberResult.Should().Be("I");
    }
}