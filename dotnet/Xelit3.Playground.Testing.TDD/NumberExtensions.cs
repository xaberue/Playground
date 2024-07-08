using System.Text;

namespace Xelit3.Playground.Testing.TDD;

public static class NumberExtensions
{

    private static List<(int Decimal, string Roman)> Equivalences = new List<(int Decimal, string Roman)>
    {
        (10, "X"),
        (5, "V"),
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
