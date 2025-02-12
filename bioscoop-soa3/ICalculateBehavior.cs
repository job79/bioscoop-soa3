namespace bioscoop_soa3;

public interface ICalculateBehavior
{
    double CalculatePrice(IList<MovieTicket> tickets, bool isWeekDay);
}
