namespace YukNgoding_Livecode.Extensions;

public static class MyExtensions
{
    public static string Repeat(this char value, int count) =>  new string(value, count);
    
    public static DateTime AddBusinessDays(this DateTime current, int days)
    {
        var sign = Math.Sign(days);
        var unsignedDays = Math.Abs(days);
        for (var i = 0; i < unsignedDays; i++)
        {
            do
            {
                current = current.AddDays(sign);
            } while (current.DayOfWeek == DayOfWeek.Saturday ||
                     current.DayOfWeek == DayOfWeek.Sunday);
        }
        return current;
    }
}