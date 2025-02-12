namespace bioscoop_soa3;

public interface CalculateBehavior
{
    double CalculatePrice(IList<MovieTicket> tickets, bool isWeekDay);
}
