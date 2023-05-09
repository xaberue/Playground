namespace Xelit3.Playground.BlazorWasm.Shared
{
    public record UserDto
        (
            Guid Id,
            string FullName,
            string Origin,
            DateTime BirthDate
        );


    public record UserCreationDto
        (            
            Guid OriginId,
            string Name,
            string Surname,
            DateTime BirthDate
        );
}