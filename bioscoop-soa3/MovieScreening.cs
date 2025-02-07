namespace bioscoop_soa3;

public class MovieScreening
{
    public DateTime DateAndTime { get; set; }
    public double PricePerSeat { get; }
    public Movie Movie { get; set; }

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        DateAndTime = dateAndTime;
        PricePerSeat = pricePerSeat;
        Movie = movie;
    }
}