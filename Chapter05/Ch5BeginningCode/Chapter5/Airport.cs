namespace Packt.CloudySkiesAir.Chapter5;

public class Airport {

  public string Country { get; set; }
  public string Code { get; set; }
  public string Name { get; set; }

  protected bool Equals(Airport other) {
    return Country == other.Country && Code == other.Code;
  }

  public override bool Equals(object? obj) {
    if (ReferenceEquals(null, obj)) {
      return false;
    }

    if (ReferenceEquals(this, obj)) {
      return true;
    }

    if (obj.GetType() != this.GetType()) {
      return false;
    }

    return Equals((Airport)obj);
  }

  public override int GetHashCode() {
    return HashCode.Combine(Country, Code);
  }

  public override string ToString() => Code;
}