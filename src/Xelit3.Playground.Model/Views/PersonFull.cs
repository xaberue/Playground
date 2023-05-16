namespace Xelit3.Tests.Model.Views;


public class PersonFull
{
    public Guid PersonId { get; set; }
    public Guid OriginId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Guid AddressId { get; set; }
    public Guid CityId { get; set; }
    public string Line { get; set; } = string.Empty;
    public int Sequence { get; set; }
    public Guid PostId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}
