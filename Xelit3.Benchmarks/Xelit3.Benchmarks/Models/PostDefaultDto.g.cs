using System;
using Xelit3.Tests.Model;

namespace Xelit3.Benchmarks.Generated
{
    public partial class PostDefaultDto
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Person<Guid> Author { get; set; }
        public Guid Id { get; set; }
    }
}