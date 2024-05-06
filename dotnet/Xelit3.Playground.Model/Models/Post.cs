namespace Xelit3.Tests.Model.Models;

public class Post<TId> : ModelBase<TId>
{
    public TId AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public Person<TId> Author { get; set; }

}



public class PostDefault : Post<Guid> { }