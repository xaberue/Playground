namespace Xelit3.Tests.Model;

public class Country<TId> : ModelBase<TId>
{
    public string Name { get; set; } = string.Empty;

    public ICollection<City<TId>> Cities { get; set; }
    public ICollection<Person<TId>> Citizens { get; set; }
}



public class CountryDefault : Country<Guid> { }