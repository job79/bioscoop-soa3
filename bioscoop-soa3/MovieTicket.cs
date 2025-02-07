namespace bioscoop_soa3;

public class MovieTicket
{
    public int RowNr { get; set; }
    public int SeatNr { get; set; }
    public bool IsPremium { get; set; }
    public bool IsStudentOrder { get; set; }
    public MovieScreening MovieScreening   { get; set; }

    public MovieTicket(MovieScreening movieScreening, bool isStudentOrder, bool isPremium, int rowNr, int seatNr)
    {
        RowNr = rowNr;
        SeatNr = seatNr;
        IsPremium = isPremium;
        IsStudentOrder = isStudentOrder;
        MovieScreening = movieScreening;
    }

    public double GetPrice()
    {
        double price = MovieScreening.PricePerSeat;
        if (IsPremium)
            return IsStudentOrder ? price + 2 : price + 3;
        return price; 
    }
}