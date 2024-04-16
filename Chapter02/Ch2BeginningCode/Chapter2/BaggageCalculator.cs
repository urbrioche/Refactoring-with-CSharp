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
        decimal firstBagFee = bags * 40M;
        Console.WriteLine($"Checked: {firstBagFee}");
        total += firstBagFee;
      } else {
        decimal firstBagFee = passengers * 40M;
        decimal extraBagFee = (bags - passengers) * 50M;
        decimal checkedFee = firstBagFee +
                             extraBagFee;

        Console.WriteLine($"Checked: {checkedFee}");
        total += checkedFee;
      }
    }

    if (travelTime.Month >= 11 || travelTime.Month <= 2) {
      decimal holidayFee = total * HolidayFeePercent;
      Console.WriteLine("Holiday Fee: " + holidayFee);

      total += holidayFee;
    }

    return total;
  }

  private decimal CalculatePriceFlat(int numBags) {
    decimal total = 0;

    return 100M;

    return numBags * 50M;
  }
}