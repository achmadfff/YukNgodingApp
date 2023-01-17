namespace YukNgoding_Livecode.Utils;

public abstract class Utility
{
    public static string InputString(string info, Func<string, bool> validate)
    {
        while (true)
        {
            Console.Write($"{info} : ");
            var input = Console.ReadLine();
            if (Validation.NonNullValidation(input) || !validate(input)) continue;
            return input;
        }
    }
    public static string InputEmail(string info, Func<string, bool> validate)
    {
        while (true)
        {
            Console.Write($"{info} : ");
            var input = Console.ReadLine();
            if (input is null or "" || !validate(input) || !Validation.EmailValidation(input)) continue;
            return input;
        }
    }

    public static string InputString(string info)
    {
        Console.Write($"{info} : ");
        var input = Console.ReadLine();
        return input;
    }
    public static int InputInt(string info, Func<string, bool> validate)
    {
        while (true)
        {
            try
            {
                Console.Write($"{info} : ");
                var input = int.Parse(Console.ReadLine());
                if(!Validation.IntValidation($"{input}")) continue;
                return input;
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}