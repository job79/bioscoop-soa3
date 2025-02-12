namespace bioscoop_soa3;

public class MovieTicket
{
    public int RowNr { get; }
    public int SeatNr { get; }
    public MovieScreening MovieScreening { get; }
    public bool IsPremium { get; }

    public MovieTicket(
        MovieScreening movieScreening,
        int rowNr,
        int seatNr,
        bool isPremium
    )
    {
        this.RowNr = rowNr;
        this.SeatNr = seatNr;
        this.MovieScreening = movieScreening;
        this.IsPremium = isPremium;
    }

    public double GetPrice()
    {
        return this.MovieScreening.PricePerSeat;
    }
}
