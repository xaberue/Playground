using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace Xelit3.Playground.Blazor.QuickGrid.Models;

public record Student(int Id, string Name, IList<Subject> Subjects);

public record Exam(DateTime Date, double Qualification);

public record Subject(int Id, string Name, string Teacher, IList<Exam> Exams)
{
    public double QualificationAverage => Exams.Average(x => x.Qualification);
    
}

public class SubjectComparer : IEqualityComparer<Subject>
{
    public bool Equals(Subject? x, Subject? y)
    {
        if (x is null || y is null)
            return false;

        if (x.Id == y.Id)
            return true;
        else
            return false;
    }

    public int GetHashCode([DisallowNull] Subject obj)
    {
        return obj.Id.GetHashCode();
    }

    public static SubjectComparer Create() => new SubjectComparer();
}