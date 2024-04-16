﻿namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator {
  private const decimal CarryOnFee = 30M;
  private const decimal FirstBagFee = 40M;
  private const decimal ExtraBagFee = 50M;
  public decimal HolidayFeePercent { get; set; } = 0.1M;

  public decimal CalculatePrice(int bags,
    int carryOn, int passengers, bool isHoliday) {
    decimal total = 0;

    if (carryOn > 0) {
      decimal fee = carryOn * CarryOnFee;
      Console.WriteLine($"Carry-on: {fee}");
      total += fee;
    }

    if (bags > 0) {
      if (bags <= passengers) {
        decimal firstBagFee = bags * FirstBagFee;
        Console.WriteLine($"Checked: {firstBagFee}");
        total += firstBagFee;
      } else {
        decimal firstBagFee = passengers * FirstBagFee;
        decimal extraBagFee = (bags - passengers) * ExtraBagFee;
        decimal checkedFee = firstBagFee +
                             extraBagFee;

        Console.WriteLine($"Checked: {checkedFee}");
        total += checkedFee;
      }
    }

    if (isHoliday) {
      decimal holidayFee = total * HolidayFeePercent;
      Console.WriteLine("Holiday Fee: " + holidayFee);

      total += holidayFee;
    }

    return total;
  }
}