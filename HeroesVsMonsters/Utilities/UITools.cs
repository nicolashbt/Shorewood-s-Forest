namespace HeroesVsMonsters.Utilities;

public static class UITools
{
    public static void WriteAt(int x, int y, string s)
    {
        try
        {
            Console.SetCursorPosition(2 * x, y);
        }
        catch (Exception e)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine(e.Message);
        }
        Console.Write(s);
        Console.SetCursorPosition(0, 0);
    }
}