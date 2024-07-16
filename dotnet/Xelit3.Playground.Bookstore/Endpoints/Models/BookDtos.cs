﻿namespace Xelit3.Playground.Bookstore.Endpoints.Models;

public record BookDto(int Id, string Isbn, string Title, string Author);

public record BookCreationDto(string Isbn, string Title, string Author);

public record BookLendDto(string[] IsbnNumbers, int ClientId);