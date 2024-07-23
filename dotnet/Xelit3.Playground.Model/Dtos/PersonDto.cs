namespace Xelit3.Tests.Model.Dtos;

public class PersonDto
{
    public Guid Id { get; set; }
    public Guid OriginId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public IEnumerable<AddressDto> Addresses { get; set; } = Enumerable.Empty<AddressDto>();
    public IEnumerable<PostDto> Posts { get; set; } = Enumerable.Empty<PostDto>();
}