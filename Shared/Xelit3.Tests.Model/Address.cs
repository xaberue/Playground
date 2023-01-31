namespace Xelit3.Tests.Model;

public class Address<TId> : ModelBase<TId>
{
    public Guid PersonId { get; set; }
    public Guid CityId { get; set; }
    public string Line { get; set; } = string.Empty;
    public int Sequence { get; set; }


    public City<TId> City { get; set; }
    public Person<TId> Person { get; set; }

}
