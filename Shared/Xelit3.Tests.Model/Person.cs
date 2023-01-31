﻿namespace Xelit3.Tests.Model;

public class Person<TId> : ModelBase<TId>
{
    public Guid OriginId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public Country<TId> Origin { get; set; }
    public ICollection<Address<TId>> Addresses { get; set; }
    public ICollection<Post<TId>> Posts { get; set; }
}
