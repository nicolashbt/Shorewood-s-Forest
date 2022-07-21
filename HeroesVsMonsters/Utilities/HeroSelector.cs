using HeroesVsMonsters.Characters;

namespace HeroesVsMonsters.Utilities;

public static class HeroSelector
{
  private static int _numberOfChoices = 3;
  private static int _cursorPosition = 1;

  public static Hero HeroSelect()
  {
    _cursorPosition = 1;
    Console.Clear();
    Console.WriteLine("Welcome to the forest of Shorewood. Choose a Hero:");
    Console.WriteLine(">>Human");
    Console.WriteLine("  Dwarf");
    Console.WriteLine("  God (Testing only)");
    ConsoleKey keyPressed = ConsoleKey.A;
    while (keyPressed != ConsoleKey.Enter)
    {
      keyPressed = Console.ReadKey().Key;
      if (keyPressed == ConsoleKey.UpArrow && _cursorPosition > 1)
      {
        MoveCursorUp();
        ShowCursor();
      }

      if (keyPressed == ConsoleKey.DownArrow && _cursorPosition < _numberOfChoices)
      {
        MoveCursorDown();
        ShowCursor();
      }
    }

    Console.Clear();
    if (_cursorPosition == 1) return new Human();
    else if (_cursorPosition == 2) return new Dwarf();
    else return new God();
  }

  private static void ShowCursor()
  {
    UITools.WriteAt(0, _cursorPosition, ">>");
  }

  private static void MoveCursorDown()
  {
    UITools.WriteAt(0, _cursorPosition, "  ");
    _cursorPosition++;
  }

  private static void MoveCursorUp()
  {
    UITools.WriteAt(0, _cursorPosition, "  ");
    _cursorPosition--;
  }
}