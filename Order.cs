using System.Text.Json;

namespace bioscoop_soa3;

public class Order
{
    public int OrderNr { get; }

    public List<MovieTicket> Tickets { get; set;  } = new();

    public Order(int orderNr)
    {
        OrderNr = orderNr;
    }

    public void AddSeatReservation(MovieTicket ticket)
    {
        Tickets.Add(ticket);
    }

    public double CalculatePrice()
    {
        Tickets = Tickets.OrderByDescending(x => x.IsStudentOrder).ToList();
        bool isWeekDay = DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday;
        double total = 0;
        for (int  i = 0; i < Tickets.Count; i++)
        {
            if (i % 2 == 1 && (Tickets[i].IsStudentOrder || isWeekDay))
                continue;

            double discount = 0;
            if (!Tickets[i].IsStudentOrder && isWeekDay && Tickets.Count > 6)
                discount = 0.1;

            total += Tickets[i].GetPrice() * (1 - discount);
        }
        return total;
    }

    public string Export(TicketExportFormat format)
    {
        switch (format)
        {
            case TicketExportFormat.Json:
                return JsonSerializer.Serialize(this);
            case TicketExportFormat.PlainText:
                return $"Order({OrderNr}): {Export(TicketExportFormat.Json)}";
            default:
                throw new Exception($"Unknown TicketExportFormat: {format}");
        }
    }
}
