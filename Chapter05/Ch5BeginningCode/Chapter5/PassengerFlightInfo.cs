namespace Packt.CloudySkiesAir.Chapter5 {
  public class PassengerFlightInfo : FlightInfoBase {
    public int Passengers { get; private set; }

    public void Load(int passengers) =>
      Passengers = passengers;

    public void Unload() =>
      Passengers = 0;

    protected override string BuildFlightIdentifier() =>
      base.BuildFlightIdentifier() +
      $"{Arrival.Location} carrying " +
      $"{Passengers} people";

  }
}