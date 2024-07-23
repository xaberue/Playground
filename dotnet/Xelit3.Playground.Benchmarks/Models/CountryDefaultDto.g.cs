using System;
using System.Collections.Generic;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Benchmarks.Generated
{
    public partial class CountryDefaultDto
    {
        public string Name { get; set; }
        public ICollection<City<Guid>> Cities { get; set; }
        public ICollection<Person<Guid>> Citizens { get; set; }
        public Guid Id { get; set; }
    }
}