﻿namespace Xelit3.Tests.Model;

public class City<TId> : ModelBase<TId>
{
    public Guid CountryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }

    public Country<TId> Country { get; set; }
    public ICollection<Address<TId>> Addresses { get; set; }
}