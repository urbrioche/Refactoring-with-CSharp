namespace Packt.CloudySkiesAir.Chapter4;

public class FlightTracker
{
    private readonly List<Flight> _flights = [];

    public Flight ScheduleNewFlight(string id, string dest, DateTime depart)
    {
        Flight flight = new(id, dest, depart)
        {
            Status = FlightStatus.Inbound
        };
        return ScheduleNewFlight(flight);
    }

    private Flight ScheduleNewFlight(Flight flight)
    {
        _flights.Add(flight);
        return flight;
    }

    public void DisplayFlights()
    {
        foreach (var f in _flights)
        {
            Console.WriteLine($"{f.Id,-9} {f.Destination,-5} {Format(f.DepartureTime),-21} {f.Gate,-5} {f.Status}");
        }
    }

    public Flight? MarkFlightDelayed(string id, DateTime newDepartureTime)
    {
        return UpdateFlight(id, flight =>
        {
            flight.DepartureTime = newDepartureTime;
            flight.Status = FlightStatus.Delayed;
            Console.WriteLine($"{id} delayed until {Format(newDepartureTime)}");
        });
    }

    private Flight? UpdateFlight(string id, Action<Flight> updateAction)
    {
        var flight = FindFlightById(id);

        if (flight != null)
        {
            updateAction(flight);
        }
        else
        {
            Console.WriteLine($"{id} could not be found");
        }

        return flight;
    }

    public Flight? MarkFlightArrived(string id, DateTime arrivalTime)
    {
        return UpdateFlight(id, flight =>
        {
            flight.ArrivalTime = arrivalTime;
            flight.Status = FlightStatus.OnTime;
            Console.WriteLine($"{id} arrived at {Format(arrivalTime)}.");
        });
    }

    public Flight? MarkFlightDeparted(string id, DateTime departureTime)
    {
        return UpdateFlight(id, flight =>
        {
            flight.DepartureTime = departureTime;
            flight.Status = FlightStatus.Departed;
            Console.WriteLine($"{id} departed at {Format(departureTime)}.");
        });
    }

    private Flight? FindFlightById(string id) => _flights.FirstOrDefault(f => f.Id == id);

    private static string Format(DateTime time)
    {
        return time.ToString("ddd MMM dd HH:mm tt");
    }
}