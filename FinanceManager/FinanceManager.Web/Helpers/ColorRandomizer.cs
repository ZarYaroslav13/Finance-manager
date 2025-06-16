namespace FinanceManager.Web.Helpers;

public static class ColorRandomizer
{
    private static Random _random = new();

    public static string GetRandomColor()
    {

        // Generate random R,G,B bytes
        byte r = (byte)_random.Next(0, 256);
        byte g = (byte)_random.Next(0, 256);
        byte b = (byte)_random.Next(0, 256);

        // Return hex color string like "#A1B2C3"
        return $"#{r:X2}{g:X2}{b:X2}";
    }

    public static string GetRandomRedColor()
    {
        byte r = 200; // Strong red
        byte g = (byte)_random.Next(0, 100);  // Keep green low
        byte b = (byte)_random.Next(0, 100);  // Keep blue low

        return $"#{r:X2}{g:X2}{b:X2}";
    }
    public static string GetRandomGreenColor()
    {
        byte r = (byte)_random.Next(0, 100);  // Keep red low
        byte g = (byte)_random.Next(180, 256); // Strong green
        byte b = (byte)_random.Next(0, 100);  // Keep blue low

        return $"#{r:X2}{g:X2}{b:X2}";
    }
}
