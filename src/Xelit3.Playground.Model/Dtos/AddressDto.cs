namespace Xelit3.Tests.Model.Dtos;

public class AddressDto
{
    public Guid Id { get; set; } 
    public Guid CityId { get; set; }
    public string Line { get; set; }
    public int Sequence { get; set; }
}
