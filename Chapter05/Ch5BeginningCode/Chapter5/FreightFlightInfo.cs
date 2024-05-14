namespace Packt.CloudySkiesAir.Chapter5
{
  public class FreightFlightInfo : FlightInfoBase {
    public string CharterCompany { get; set; }
    public string Cargo { get; set; }

    public string BuildFlightIdentifier() =>
      $"{Id} {DepartureLocation.Code}-" +
      $"{ArrivalLocation.Code} carrying " +
      $"{Cargo} for {CharterCompany}";

    public override string ToString() => BuildFlightIdentifier();
  }
}