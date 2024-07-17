namespace Xelit3.Playground.Bookstore.Books;

public static class BookExtensions
{

    public static BookDto ToDto(this Book entity)
        => new BookDto(entity.Id, entity.Isbn, entity.Title, entity.Author);

}
