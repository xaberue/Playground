namespace Xelit3.Playground.Bookstore.Domain.Base;

public abstract class ModelBase
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastModificationDate { get; set; }
    public int IsDeleted { get; set; }
}
