using Packt.CloudySkiesAir.Chapter5.AirTravel;

namespace Packt.CloudySkiesAir.Chapter5
{
  public class PassengerFlightInfo : IFlightInfo {
    private int _passengers;
    public string Id { get; set; }
    public Airport DepartureLocation { get; set; }
    public Airport ArrivalLocation { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public TimeSpan Duration => DepartureTime - ArrivalTime;

    public void Load(int passengers) => 
      _passengers = passengers;

    public void Unload() => 
      _passengers = 0;

    public string BuildFlightIdentifier() =>
      $"{Id} {DepartureLocation.Code}-" +
      $"{ArrivalLocation.Code} carrying " +
      $"{_passengers} people";

    public override string ToString() => BuildFlightIdentifier();
  }
}