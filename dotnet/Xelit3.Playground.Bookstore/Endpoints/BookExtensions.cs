using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints.Models;

namespace Xelit3.Playground.Bookstore.Endpoints;

public static class BookExtensions
{

    public static BookDto ToDto(this Book entity)
        => new BookDto(entity.Id, entity.Isbn, entity.Title, entity.Author);
    
}
