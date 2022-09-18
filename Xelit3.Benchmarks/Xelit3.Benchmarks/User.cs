namespace Xelit3.Benchmarks
{
    public class User
    {
        public Guid Id { get; set; }
        public string NationalIdentifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;        
    }
}
