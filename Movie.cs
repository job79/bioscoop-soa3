namespace bioscoop_soa3;

public class Movie
{
    public string Title { get; }
    public List<MovieScreening> Screenings { get; } = new();

    public Movie(string title)
    {
        Title = title;
    }
    
    public void AddScreening(MovieScreening screening)
    {
        Screenings.Add(screening);
    }
}