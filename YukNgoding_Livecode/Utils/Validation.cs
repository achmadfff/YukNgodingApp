using System.Text.RegularExpressions;

namespace YukNgoding_Livecode.Utils;

public abstract class Validation
{
    public static bool NonNullValidation(string? input) => input == null || input == "";
    public static bool EmailValidation(string? email)
    {
        var regex = new Regex("[a-z0-9]+@[a-z]+\\.[a-z]{2,3}");
        var isMatch = regex.Match(email);
        return isMatch.Success;
    }

    public static bool IntValidation(string? input)
    {
        try
        {
            var result = int.TryParse(input, out _);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}