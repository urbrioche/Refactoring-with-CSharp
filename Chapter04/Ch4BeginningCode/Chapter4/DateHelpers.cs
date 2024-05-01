namespace Packt.CloudySkiesAir.Chapter4;

public static class DateHelpers
{
    public static string Format(DateTime time)
    {
        return time.ToString("ddd MMM dd HH:mm tt");
    }
}