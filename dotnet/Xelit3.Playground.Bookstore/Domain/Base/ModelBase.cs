namespace Xelit3.Playground.Bookstore.Domain.Base;

public abstract class ModelBase
{
    public int Id { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime? LastModificationDate { get; init; }
    public bool IsDeleted { get; init; }


    protected ModelBase()
    {
        CreationDate = DateTime.Now;
    }

    protected ModelBase(int id, DateTime creationDate, DateTime? lastModificationDate, bool isDeleted)
    {
        Id = id;
        CreationDate = creationDate;
        LastModificationDate = lastModificationDate;
        IsDeleted = isDeleted;
    }
}
