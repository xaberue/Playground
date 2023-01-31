namespace Xelit3.Tests.Model;

public class Post<TId> : ModelBase<TId>
{
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public Person<TId> Author { get; set; }

}
