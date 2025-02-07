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

    public void Export(TicketExportFormat format)
    {
        string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Order.txt"));

        switch (format)
        {
            case TicketExportFormat.Json:
                File.WriteAllText(path, JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }));
                break;
            case TicketExportFormat.PlainText:
                File.WriteAllText(path, JsonSerializer.Serialize(this));
                break;
            default:
                throw new Exception($"Unknown TicketExportFormat: {format}");
        }
    }
}
