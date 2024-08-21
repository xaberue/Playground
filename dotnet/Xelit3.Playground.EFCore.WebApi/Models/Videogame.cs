namespace Xelit3.Playground.EFCore.WebApi.Models;

public class Videogame
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public int YearReleased { get; set; }
    public Genre Genre { get; set; }

}


public enum Genre 
{
    RTS,
    FPS,
    TPS
}