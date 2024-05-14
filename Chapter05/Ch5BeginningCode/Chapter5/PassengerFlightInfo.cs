namespace Packt.CloudySkiesAir.Chapter5
{
  public class PassengerFlightInfo : FlightInfoBase {
    private int _passengers;

    public void Load(int passengers) => 
      _passengers = passengers;

    public void Unload() => 
      _passengers = 0;

    protected override string BuildFlightIdentifier() =>
      $"{Id} {DepartureLocation}-" +
      $"{ArrivalLocation} carrying " +
      $"{_passengers} people";

  }
}