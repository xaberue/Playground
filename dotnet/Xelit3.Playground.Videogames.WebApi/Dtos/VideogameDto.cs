using Xelit3.Playground.Videogames.WebApi.Models;

namespace Xelit3.Playground.Videogames.WebApi.Dtos;

public record VideogameDto(int Id, string Name, string Publisher, int YearReleased, Genre Genre);


public static class VideogameMapper
{
    public static VideogameDto ToDto(this Videogame entity)
        => new(entity.Id, entity.Name, entity.Publisher, entity.YearReleased, entity.Genre);
}