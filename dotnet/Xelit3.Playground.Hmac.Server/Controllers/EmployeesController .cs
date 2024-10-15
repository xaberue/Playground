using Microsoft.AspNetCore.Mvc;
using Xelit3.Playground.Hmac.Server.Models;

namespace Xelit3.Playground.Hmac.Server.Controllers;


[Route("api/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{

    private static List<Employee> Employees { get; set; } =
    [
        new(1, "Alice Smith", "Manager", 75000),
        new(2, "Bob Johnson", "Developer", 60000),
        new(3, "Carol White", "Designer", 55000)
    ];


    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        return Employees;
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployee(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return NotFound();
        }

        return employee;
    }

    [HttpPost]
    public ActionResult<Employee> PostEmployee(EmployeeCreation employeeCreation)
    {
        var id = Employees.Max(e => e.Id) + 1;
        var employee = new Employee(id, employeeCreation.Name, employeeCreation.Position, employeeCreation.Salary);
        Employees.Add(employee);

        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    public IActionResult PutEmployee(int id, EmployeeEdition employeeEdition)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound();
        }

        employee.Update(employeeEdition.Name, employeeEdition.Position, employeeEdition.Salary);

        return NoContent();
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound();
        }

        Employees.Remove(employee);
        return NoContent();
    }
}