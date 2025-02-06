namespace bioscoop_soa3;

public class MovieScreening
{
    public DateTime DateAndTime { get; }
    public double PricePerSeat { get; }
    public List<Movie> Movies { get; } = new();

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        Movies.Add(movie);
        DateAndTime = dateAndTime;
        PricePerSeat = pricePerSeat;
    }
    

    public override string ToString()
    {
        return "MovieScreening: " + DateAndTime + " Price: " + PricePerSeat;
    }
}