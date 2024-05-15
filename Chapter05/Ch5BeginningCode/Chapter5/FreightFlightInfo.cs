namespace Packt.CloudySkiesAir.Chapter5 {
  public class FreightFlightInfo : FlightInfoBase {
    public string CharterCompany { get; set; }
    public string Cargo { get; set; }

    protected override string BuildFlightIdentifier() =>
      base.BuildFlightIdentifier() +
      $"{Arrival.Location.Code} carrying " +
      $"{Cargo} for {CharterCompany}";
  }
}