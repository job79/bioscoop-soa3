using bioscoop_soa3;

Movie movie = new("Bliep bloep");
MovieScreening movieScreening = new(movie, DateTime.MinValue, 10);

Order order = new(321, new StudentCalculation());
order.AddSeatReservation(new MovieTicket(movieScreening, 12, 12, true));
order.AddSeatReservation(new MovieTicket(movieScreening, 12, 12, false));
order.AddSeatReservation(new MovieTicket(movieScreening, 12, 12, true));
order.AddSeatReservation(new MovieTicket(movieScreening, 12, 12, false));

Console.WriteLine(order.CalculatePrice(true));
order.Export(new JsonExport(), AppDomain.CurrentDomain.BaseDirectory + "../../../Export.txt");
