using System.Text;

namespace Xelit3.Playground.Testing.TDD;

public static class NumberExtensions
{

    private static List<(int Decimal, string Roman)> Equivalences = new List<(int Decimal, string Roman)>
    {
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I"),
    };


    public static string ToRomanNumber(this int decimalNumber)
    {
        var romanNumberBuilder = new StringBuilder();

        foreach (var equivalence in Equivalences)
        {
            while (decimalNumber >= equivalence.Decimal)
            {
                romanNumberBuilder.Append(equivalence.Roman);
                decimalNumber -= equivalence.Decimal;
            }
        }

        return romanNumberBuilder.ToString();

    }

}
