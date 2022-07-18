namespace HeroesVsMonsters.Utilities;

public static class UITools
{
  public static void WriteAt(int x, int y, string s)
  {
    Console.SetCursorPosition(2 * x, y);
    Console.Write(s);
    Console.SetCursorPosition(0, 0);
  }
}