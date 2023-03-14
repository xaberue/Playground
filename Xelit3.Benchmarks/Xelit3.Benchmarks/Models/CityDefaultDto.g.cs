using System;
using System.Collections.Generic;
using Xelit3.Tests.Model;

namespace Xelit3.Benchmarks.Generated
{
    public partial class CityDefaultDto
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public Country<Guid> Country { get; set; }
        public ICollection<Address<Guid>> Addresses { get; set; }
        public Guid Id { get; set; }
    }
}