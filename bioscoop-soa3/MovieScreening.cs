namespace bioscoop_soa3;

public class MovieScreening
{
    public DateTime DateAndTime { get; }
    public double PricePerSeat { get; }
    public Movie Movie { get; }

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        DateAndTime = dateAndTime;
        PricePerSeat = pricePerSeat;
        Movie = movie;
    }
}

