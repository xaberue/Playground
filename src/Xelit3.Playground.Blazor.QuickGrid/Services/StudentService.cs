using Xelit3.Playground.Blazor.QuickGrid.Models;

namespace Xelit3.Playground.Blazor.QuickGrid.Services;

public class StudentService
{
    
    private IEnumerable<Student> _students = new List<Student>
        {
            new Student(1, "Ruth Fernández", new List<Subject>{ 
                new Subject(1, "Maths", "Jorge Prado", new List<Exam> { 
                    new Exam(new DateTime(2023, 10, 4), 7), new Exam(new DateTime(2023, 12, 5), 8) }),
                new Subject(2, "Literature", "Jorge Prado", new List<Exam> {
                    new Exam(new DateTime(2023, 9, 20), 5), new Exam(new DateTime(2023, 12, 10), 8), new Exam(new DateTime(2023, 11, 6), 8) }), 
            }),
            new Student(2, "Manuel González", new List<Subject>{
                new Subject(1, "Maths", "Jorge Prado", new List<Exam> {
                    new Exam(new DateTime(2023, 10, 4), 5), new Exam(new DateTime(2023, 12, 5), 4) }) }),
        }.AsQueryable();


    public IEnumerable<Student> GetAll() => _students;
    
}
