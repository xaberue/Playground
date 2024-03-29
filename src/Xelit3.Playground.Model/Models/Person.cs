﻿namespace Xelit3.Tests.Model.Models;

public class Person<TId> : ModelBase<TId>
{
    public TId OriginId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public Country<TId> Origin { get; set; }
    public ICollection<Address<TId>> Addresses { get; set; }
    public ICollection<Post<TId>> Posts { get; set; }    
}



public class PersonDefault : Person<Guid> { }