namespace bioscoop_soa3.tests;

public class OrderTests
{
    [Test]
    public void SecondTicketFreeForStudentTickets()
    {
        // Arrange
        Movie movie = new("Bliep bloep");
        MovieScreening movieScreening = new(movie, DateTime.MinValue, 10);
        Order order = new(321, new StudentCalculation());
        order.AddSeatReservation(new MovieTicket(movieScreening, 12, 12, false));
        order.AddSeatReservation(new MovieTicket(movieScreening, 12, 12, false));

        // Act
        double totalPrice = order.CalculatePrice(false);

        // Assert
        Assert.That(totalPrice, Is.EqualTo(10));
    }
}

