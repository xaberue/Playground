namespace Xelit3.Playground.Videogames.WebApi.Models;

public class Videogame
{

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Publisher { get; private set; }
    public int YearReleased { get; private set; }
    public Genre Genre { get; private set; }


    public Videogame(int id, string name, string publisher, int yearReleased, Genre genre)
        : this(name, publisher, yearReleased, genre)
    {
        Id = id;
    }

    public Videogame(string name, string publisher, int yearReleased, Genre genre)
    {
        Name = name;
        Publisher = publisher;
        YearReleased = yearReleased;
        Genre = genre;
    }


    public void Update(string name, string publisher, int yearReleased, Genre genre)
    {
        Name = name;
        Publisher = publisher;
        YearReleased = yearReleased;
        Genre = genre;
    }

}


public enum Genre
{
    RTS,
    FPS,
    TPS
}