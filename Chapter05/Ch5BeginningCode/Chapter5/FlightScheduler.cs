namespace Packt.CloudySkiesAir.Chapter5;

public class FlightSearch
{
  public FlightSearch(Airport? depart, Airport? arrive, DateTime? minDepartTime, DateTime? maxDepartTime, DateTime? minArriveTime, DateTime? maxArriveTime, TimeSpan? minLength, TimeSpan? maxLength) {
    Depart = depart;
    Arrive = arrive;
    MinDepartTime = minDepartTime;
    MaxDepartTime = maxDepartTime;
    MinArriveTime = minArriveTime;
    MaxArriveTime = maxArriveTime;
    MinLength = minLength;
    MaxLength = maxLength;
  }

  public Airport? Depart { get; private set; }
  public Airport? Arrive { get; private set; }
  public DateTime? MinDepartTime { get; private set; }
  public DateTime? MaxDepartTime { get; private set; }
  public DateTime? MinArriveTime { get; private set; }
  public DateTime? MaxArriveTime { get; private set; }
  public TimeSpan? MinLength { get; private set; }
  public TimeSpan? MaxLength { get; private set; }
}
public class FlightScheduler {
  private readonly List<IFlightInfo> _flights = new();

  public void ScheduleFlight(string id, Airport depart, Airport arrive, DateTime departTime, DateTime arriveTime, int passengers) {
    PassengerFlightInfo flight = new() {
      Id = id,
      ArrivalLocation = arrive,
      ArrivalTime = arriveTime,
      DepartureLocation = depart,
      DepartureTime = departTime,
    };
    flight.Load(passengers);

    _flights.Add(flight);

    Console.WriteLine($"Scheduled Flight {flight}");
  }

  public void ScheduleFlight(IFlightInfo flight) {
    _flights.Add(flight);

    Console.WriteLine($"Scheduled Flight {flight}");
  }

  public void RemoveFlight(IFlightInfo flight) {
    _flights.Remove(flight);
  }

  public IEnumerable<IFlightInfo> GetAllFlights() {
    return _flights.AsReadOnly();
  }

  public IEnumerable<IFlightInfo> Search(
    FlightSearch flightSearch) {

    IEnumerable<IFlightInfo> results = _flights;

    if (flightSearch.Depart != null) {
      results = results.Where(f => f.DepartureLocation == flightSearch.Depart);
    }

    if (flightSearch.Arrive != null) {
      results = results.Where(f => f.ArrivalLocation == flightSearch.Arrive);
    }

    if (flightSearch.MinDepartTime != null) {
      results = results.Where(f => f.DepartureTime >= flightSearch.MinDepartTime);
    }

    if (flightSearch.MaxDepartTime != null) {
      results = results.Where(f => f.DepartureTime <= flightSearch.MaxDepartTime);
    }

    if (flightSearch.MinArriveTime != null) {
      results = results.Where(f => f.ArrivalTime >= flightSearch.MinArriveTime);
    }

    if (flightSearch.MaxArriveTime != null) {
      results = results.Where(f => f.ArrivalTime <= flightSearch.MaxArriveTime);
    }

    if (flightSearch.MinLength != null) {
      results = results.Where(f => f.Duration >= flightSearch.MinLength);
    }

    if (flightSearch.MaxLength != null) {
      results = results.Where(f => f.Duration <= flightSearch.MaxLength);
    }

    return results;
  }
}