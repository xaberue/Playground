namespace Xelit3.Playground.BlazorWasm.Shared
{
    public record UserDto
        (
            Guid Id,
            string FullName,
            string Origin,
            DateTime BirthDate
        );
}