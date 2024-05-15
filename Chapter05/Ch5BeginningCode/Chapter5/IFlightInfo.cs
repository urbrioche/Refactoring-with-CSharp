namespace Packt.CloudySkiesAir.Chapter5;

public interface IFlightInfo {
  string Id { get; }
  TimeSpan Duration { get; }
  AirportEvent Arrival { get; set; }
  AirportEvent Departure { get; set; }
}