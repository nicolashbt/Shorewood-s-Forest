using HeroesVsMonsters.Utilities;

namespace HeroesVsMonsters.States;

public class MapState
{
  private readonly Random _random = new Random();
  private int _heroX = 0;
  private int _heroY = 0;
  private static readonly int _sizeX = 15;
  private static readonly int _sizeY = 15;
  private static int _monsterNumber = 10;
  private readonly string[,] _mapArray = new string[_sizeX, _sizeY];
  private readonly int[,] _monsterCoordinates = new int[_monsterNumber, 2];

  public int MonsterNumber = _monsterNumber;

  private void PopulateMap()
  {
    for (int i = 0; i < _sizeX; i++)
    {
      for (int j = 0; j < _sizeY; j++)
      {
        _mapArray[i, j] = ".";
      }
    }
  }

  public void Moving()
  {
    ShowArray(_mapArray);
    ShowHero();
    ShowMonsters();
    MovementListener();
  }

  public void InitMap()
  {
    _heroX = 0;
    _heroY = 0;
    Console.Clear();
    PopulateMap();
    GenerateMonstersCoordinates();
  }

  private void MovementListener()
  {
    bool fightTrigger = false;
    while (!fightTrigger)
    {
      ConsoleKey keyPressed = Console.ReadKey().Key;

      if (keyPressed == ConsoleKey.UpArrow && _heroY > 0) MoveUp();
      if (keyPressed == ConsoleKey.DownArrow && _heroY < _sizeY - 1) MoveDown();
      if (keyPressed == ConsoleKey.RightArrow && _heroX < _sizeX - 1) MoveRight();
      if (keyPressed == ConsoleKey.LeftArrow && _heroX > 0) MoveLeft();
      ShowHero();
      for (int i = 0; i < _monsterNumber; i++)
      {
        if (_heroX == _monsterCoordinates[i, 0] && _heroY == _monsterCoordinates[i, 1])
        {
          fightTrigger = true;
          //moves the monster out of the map to avoid respawning
          _monsterCoordinates[i, 0] = 99;
          _monsterCoordinates[i, 1] = 99;
          break;
        }
      }
    }
  }

  private void GenerateMonstersCoordinates()
  {
    for (int i = 0; i < _monsterNumber; i++)
    {
      _monsterCoordinates[i, 0] = _random.Next(0, _sizeX);
      _monsterCoordinates[i, 1] = _random.Next(0, _sizeY);
    }
  }

  private void ShowMonsters()
  {
    for (int i = 0; i < _monsterNumber; i++)
    {
      int monsterX = _monsterCoordinates[i, 0];
      int monsterY = _monsterCoordinates[i, 1];
      UITools.WriteAt(monsterX, monsterY, "M");
    }
  }

  private void MoveDown()
  {
    int previousY = _heroY;
    _heroY++;
    UITools.WriteAt(_heroX, previousY, ".");
  }

  private void MoveUp()
  {
    int previousY = _heroY;
    _heroY--;
    UITools.WriteAt(_heroX, previousY, ".");
  }

  private void MoveLeft()
  {
    int previousX = _heroX;
    _heroX--;
    UITools.WriteAt(previousX, _heroY, ".");
  }

  private void MoveRight()
  {
    int previousX = _heroX;
    _heroX++;
    UITools.WriteAt(previousX, _heroY, ".");
  }

  private void ShowArray(string[,] mapArray)
  {
    for (int i = 0; i < mapArray.GetLength(0); i++)
    {
      for (int j = 0; j < mapArray.GetLength(1); j++)
      {
        Console.Write(mapArray[i, j]);
        Console.Write(" ");
      }

      Console.WriteLine();
    }
  }

  private void ShowHero()
  {
    UITools.WriteAt(_heroX, _heroY, "H");
  }
}