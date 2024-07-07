namespace Xelit3.Playground.Testing.TDD;

public static class NumberExtensions
{

    public static string ToRomanNumber(this int number)
    {
        if (number == 3)
            return "III";
        else if (number == 2)
            return "II";
        else
            return "I";
    }

}
