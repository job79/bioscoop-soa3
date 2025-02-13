namespace bioscoop_soa3;

public class StandardCalculation : ICalculateBehavior
{
    public double CalculatePrice(IList<MovieTicket> tickets, bool isWeekDay)
    {
        double total = 0;
        for (int i = 0; i < tickets.Count; i++)
        {
            if (isWeekDay && i % 2 == 1)
                continue;
            
            total += tickets[i].GetPrice();
            if (tickets[i].IsPremium)
                total += 3;
        }
        
        if (!isWeekDay && tickets.Count >= 6)
            total *= 0.9;
        
        return total;
    }
}
