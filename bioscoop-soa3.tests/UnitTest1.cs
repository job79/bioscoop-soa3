using NUnit.Framework;
using System;
using System.Collections.Generic;
using bioscoop_soa3;

namespace bioscoop_soa3.tests
{
    public class OrderTests
    {
        [Test]
        public void CalculatePrice_NoTickets_ShouldReturnZero()
        {
            // Arrange
            Order order = new(321);

            // Act
            double totalPrice = order.CalculatePrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(0));
        }

        [Test]
        public void CalculatePrice_OnlyStudentTickets_ShouldReturnCorrectTotal()
        {
            // Arrange
            Movie movie = new("Bliep bloep");
            MovieScreening movieScreening = new(movie, DateTime.MinValue, 10);
            Order order = new(321);

            order.AddSeatReservation(new MovieTicket(movieScreening, true, false, 12, 12));
            order.AddSeatReservation(new MovieTicket(movieScreening, true, false, 12, 12));

            // Act
            double totalPrice = order.CalculatePrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(10));
        }

        [Test]
        public void CalculatePrice_OnlyNonStudentTickets_ShouldReturnCorrectTotal()
        {
            // Arrange
            Movie movie = new("Bliep bloep");
            MovieScreening movieScreening = new(movie, DateTime.MinValue, 10);
            Order order = new(321);

            order.AddSeatReservation(new MovieTicket(movieScreening, false, false, 12, 12));
            order.AddSeatReservation(new MovieTicket(movieScreening, false, false, 12, 12));

            // Act
            double totalPrice = order.CalculatePrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(10));
        }

        [Test]
        public void CalculatePrice_MixOfStudentAndNonStudentTickets_ShouldReturnCorrectTotal()
        {
            // Arrange
            Movie movie = new("Bliep bloep");
            MovieScreening movieScreening = new(movie, DateTime.MinValue, 10);
            Order order = new(321);

            order.AddSeatReservation(new MovieTicket(movieScreening, true, false, 12, 12));
            order.AddSeatReservation(new MovieTicket(movieScreening, false, false, 12, 12));

            // Act
            double totalPrice = order.CalculatePrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(10));
        }

        [Test]
        public void CalculatePrice_MoreThanSixNonStudentTicketsOnWeekday_ShouldApplyDiscount()
        {
            // Arrange
            Movie movie = new("Bliep bloep");
            MovieScreening movieScreening = new(movie, DateTime.MinValue, 10);
            Order order = new(321);

            for (int i = 0; i < 7; i++)
            {
                order.AddSeatReservation(new MovieTicket(movieScreening, false, false, 12, 12));
            }

            // Act
            double totalPrice = order.CalculatePrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(36));
        }
    }
}