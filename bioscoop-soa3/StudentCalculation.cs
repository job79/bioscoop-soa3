namespace bioscoop_soa3;

public class StudentCalculation : ICalculateBehavior
{
    public double CalculatePrice(IList<MovieTicket> tickets, bool isWeekDay)
    {
        double total = 0;
        for (int i = 0; i < tickets.Count; i+=2)
        {
            total += tickets[i].GetPrice();
            if (tickets[i].IsPremium)
                total += 2;
        }
        return total;
    }
}