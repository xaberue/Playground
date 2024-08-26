using Xelit3.Playground.Videogames.WebApi.Models;

namespace Xelit3.Playground.Videogames.WebApi.Dtos;

public record VideogameCreationDto(string Name, string Publisher, int YearReleased, Genre Genre);
