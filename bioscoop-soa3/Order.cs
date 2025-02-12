namespace bioscoop_soa3;

public class Order
{
    public int OrderNr { get; }
    public List<MovieTicket> Tickets { get; } = new();
    private ICalculateBehavior calculateBehavior;

    public Order(int orderNr, ICalculateBehavior calculateBehavior)
    {
        OrderNr = orderNr;
        this.calculateBehavior = calculateBehavior;
    }

    public void AddSeatReservation(MovieTicket ticket)
    {
        Tickets.Add(ticket);
    }

    public double CalculatePrice(bool isWeekDay)
    {
        return calculateBehavior.CalculatePrice(Tickets, isWeekDay);
    }

    public void Export(IExportBehavior behavior, string path)
    {
        behavior.Export(this, path);
    }
}
