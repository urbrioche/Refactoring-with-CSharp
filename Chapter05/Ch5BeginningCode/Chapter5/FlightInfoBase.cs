namespace Packt.CloudySkiesAir.Chapter5 {

  public abstract class FlightInfoBase : IFlightInfo {
    public AirportEvent Arrival { get; set; }

    public AirportEvent Departure { get; set; }
    public string Id { get; set; }

    public TimeSpan Duration => Departure.Time - Arrival.Time;

    protected virtual string BuildFlightIdentifier() => $"{Id} {Departure.Location}-{Arrival.Location}";

    public override string ToString() => BuildFlightIdentifier();
  }
}