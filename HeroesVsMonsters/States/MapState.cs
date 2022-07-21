using HeroesVsMonsters.Utilities;

namespace HeroesVsMonsters.States;

public class MapState
{
  private readonly Random _random;
  private int _heroX = 0;
  private int _heroY = 0;
  private static readonly int _sizeX = 15;
  private static readonly int _sizeY = 15;
  private static int _monsterNumber = 10;
  private readonly string[,] _mapArray = new string[_sizeX, _sizeY];
  private readonly int[,] _monsterCoordinates = new int[_monsterNumber, 3];
  public int NextMonsterType = -1;

  public int MonsterNumber = _monsterNumber;

  public MapState(Random random)
  {
    _random = random;
  }

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
    NextMonsterType = -1;
    bool fightTrigger = false;
    while (!fightTrigger)
    {
      ConsoleKey keyPressed = Console.ReadKey().Key;

      if (keyPressed == ConsoleKey.DownArrow) MoveDown();
      else if (keyPressed == ConsoleKey.UpArrow) MoveUp();
      else if (keyPressed == ConsoleKey.LeftArrow) MoveLeft();
      else if (keyPressed == ConsoleKey.RightArrow) MoveRight();
      ShowHero();
      fightTrigger = DistanceChecker();
    }
  }

  private bool DistanceChecker()
  {
    for (int i = 0; i < _monsterNumber; i++)
    {
      if (Math.Abs(_heroX - _monsterCoordinates[i, 0]) + Math.Abs(_heroY - _monsterCoordinates[i, 1]) <= 1)
      {
        NextMonsterType = _monsterCoordinates[i, 2];
        //moves the monster out of the map to avoid respawning
        _monsterCoordinates[i, 0] = 99;
        _monsterCoordinates[i, 1] = 99;
        return true;
      }
    }

    return false;
  }

  private void GenerateMonstersCoordinates()
  {
    for (int i = 0; i < _monsterNumber; i++)
    {
      _monsterCoordinates[i, 0] = _random.Next(0, _sizeX);
      _monsterCoordinates[i, 1] = _random.Next(0, _sizeY);
      //monster type 0 = wolf, 1 = orc, 2 = dragon
      _monsterCoordinates[i, 2] = _random.Next(0, 3);
    }
  }

  private void ShowMonsters()
  {
    for (int i = 0; i < _monsterNumber; i++)
    {
      int monsterX = _monsterCoordinates[i, 0];
      int monsterY = _monsterCoordinates[i, 1];
      if (_monsterCoordinates[i, 2] == 0) UITools.WriteAt(monsterX, monsterY, "W");
      else if (_monsterCoordinates[i, 2] == 1) UITools.WriteAt(monsterX, monsterY, "O");
      else if (_monsterCoordinates[i, 2] == 2) UITools.WriteAt(monsterX, monsterY, "D");
      else UITools.WriteAt(monsterX, monsterY, "M");
    }
  }

  private void MoveDown()
  {
    if (_heroY < _sizeY - 1)
    {
      ResetHeroPos();
      _heroY++;
    }
  }

  private void MoveUp()
  {
    if (_heroY > 0)
    {
      ResetHeroPos();
      _heroY--;
    }
  }

  private void MoveLeft()
  {
    if (_heroX > 0)
    {
      ResetHeroPos();
      _heroX--;
    }
  }

  private void MoveRight()
  {
    if (_heroX < _sizeX - 1)
    {
      ResetHeroPos();
      _heroX++;
    }
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

  private void ResetHeroPos()
  {
    UITools.WriteAt(_heroX, _heroY, ".");
  }
}