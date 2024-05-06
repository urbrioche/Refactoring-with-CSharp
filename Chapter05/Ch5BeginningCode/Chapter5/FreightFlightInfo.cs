namespace Packt.CloudySkiesAir.Chapter5
{
  public class FreightFlightInfo : IFlightInfo {
    public string Id { get; set; }
    public Airport DepartureLocation { get; set; }
    public Airport ArrivalLocation { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public TimeSpan Duration => DepartureTime - ArrivalTime;
    public string CharterCompany { get; set; }
    public string Cargo { get; set; }

    public string BuildFlightIdentifier() =>
      $"{Id} {DepartureLocation.Code}-" +
      $"{ArrivalLocation.Code} carrying " +
      $"{Cargo} for {CharterCompany}";

    public override string ToString() => BuildFlightIdentifier();
  }
}