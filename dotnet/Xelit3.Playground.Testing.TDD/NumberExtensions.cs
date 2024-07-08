using System.Text;

namespace Xelit3.Playground.Testing.TDD;

public static class NumberExtensions
{

    public static string ToRomanNumber(this int decimalNumber)
    {
        var romanNumberBuilder = new StringBuilder();

        if (decimalNumber >= 10)
        {
            romanNumberBuilder.Append("X");
            decimalNumber -= 10;
        }

        if (decimalNumber >= 5)
        {
            romanNumberBuilder.Append("V");
            decimalNumber -= 5;
        }

        for (int i = 0; i < decimalNumber; i++) 
        {
            romanNumberBuilder.Append("I");
        }

        return romanNumberBuilder.ToString();

    }

}
