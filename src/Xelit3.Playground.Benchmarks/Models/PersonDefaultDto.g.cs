using System;
using System.Collections.Generic;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Benchmarks.Generated
{
    public partial class PersonDefaultDto
    {
        public Guid OriginId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Country<Guid> Origin { get; set; }
        public ICollection<Address<Guid>> Addresses { get; set; }
        public ICollection<Post<Guid>> Posts { get; set; }
        public Guid Id { get; set; }
    }
}