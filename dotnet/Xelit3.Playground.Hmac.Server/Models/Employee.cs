
namespace Xelit3.Playground.Hmac.Server.Models;

public record Employee
{

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Position { get; private set; }
    public decimal Salary { get; private set; }


    public Employee(int id, string name, string position, decimal salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    internal void Update(string name, string position, decimal salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }
}

public record EmployeeCreation(string Name, string Position, decimal Salary);

public record EmployeeEdition(string Name, string Position, decimal Salary);
