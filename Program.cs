using bioscoop_soa3;

Movie movie = new("Bliep bloep");
MovieScreening movieScreening = new(movie, DateTime.MinValue, 10);

Order order = new(321);
order.AddSeatReservation(new MovieTicket(movieScreening, true, false, 12, 12));
order.AddSeatReservation(new MovieTicket(movieScreening, true, false, 12, 12));

order.AddSeatReservation(new MovieTicket(movieScreening, true, false, 12, 12));
order.AddSeatReservation(new MovieTicket(movieScreening, true, false, 12, 12));

Console.WriteLine(order.CalculatePrice());
order.Export(TicketExportFormat.Json);
