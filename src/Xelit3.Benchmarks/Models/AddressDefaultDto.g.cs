using System;
using Xelit3.Tests.Model;

namespace Xelit3.Benchmarks.Generated
{
    public partial class AddressDefaultDto
    {
        public Guid PersonId { get; set; }
        public Guid CityId { get; set; }
        public string Line { get; set; }
        public int Sequence { get; set; }
        public City<Guid> City { get; set; }
        public Person<Guid> Person { get; set; }
        public Guid Id { get; set; }
    }
}