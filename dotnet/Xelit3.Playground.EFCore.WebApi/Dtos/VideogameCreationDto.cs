using Xelit3.Playground.EFCore.WebApi.Models;

namespace Xelit3.Playground.EFCore.WebApi.Dtos;

public record VideogameCreationDto(string Name, string Publisher, int YearReleased, Genre Genre);
