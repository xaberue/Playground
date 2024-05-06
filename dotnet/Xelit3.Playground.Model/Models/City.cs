namespace Xelit3.Tests.Model.Models;

public class City<TId> : ModelBase<TId>
{
    public TId CountryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }

    public Country<TId> Country { get; set; }
    public ICollection<Address<TId>> Addresses { get; set; }
}



public class CityDefault : City<Guid> { }