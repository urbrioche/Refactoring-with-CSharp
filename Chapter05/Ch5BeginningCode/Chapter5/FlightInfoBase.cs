namespace Packt.CloudySkiesAir.Chapter5
{
  public class FlightInfoBase: IFlightInfo
  {
    public string Id { get; set; }
    public Airport DepartureLocation { get; set; }
    public Airport ArrivalLocation { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public TimeSpan Duration => DepartureTime - ArrivalTime;
  }
}