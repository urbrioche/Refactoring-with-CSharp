namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator {
  public decimal HolidayFeePercent { get; set; } = 0.1M;

  public decimal CalculatePrice(int bags, 
    int carryOn, int passengers, DateTime travelTime) {

    decimal total = 0;

    if (carryOn > 0) {
      decimal fee = carryOn * 30M;
      Console.WriteLine($"Carry-on: {fee}");
      total += fee;
    }

    if (bags > 0) {
      if (bags <= passengers) {
        Console.WriteLine($"Checked: {bags * 40M}");
        total += bags * 40M;
      } else {
        decimal checkedFee = (passengers * 40M) + 
          ((bags - passengers) * 50M);

        Console.WriteLine($"Checked: {checkedFee}");
        total += checkedFee;
      }
    }

    if (travelTime.Month >= 11 || travelTime.Month <= 2) {
      Console.WriteLine("Holiday Fee: " + 
        (total * HolidayFeePercent));

      total += total * HolidayFeePercent;
    }

    return total;
  }
  private decimal CalculatePriceFlat(int numBags) {
    decimal total = 0;

    return 100M;

    return numBags * 50M;
  }
}
