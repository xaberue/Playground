using System.ComponentModel.DataAnnotations;

namespace Xelit3.Playground.BlazorWasm.Shared;

public record UserDto
    (
        Guid Id,
        string FullName,
        string Origin,
        DateTime BirthDate
    );


public record UserCreationDto
{
    [Required]
    public Guid OriginId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Surname { get; set; } = null!;
    [Required]
    public DateTime BirthDate { get; set; }

    public UserCreationDto(){ }

    public UserCreationDto(Guid originId, string name, string surname, DateTime birthDate)
    {
        OriginId = originId;
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
    }
}