using HeroesVsMonsters.Characters;
using HeroesVsMonsters.States;

namespace HeroesVsMonsters;

public class Shorewood
{
  private FightingState _fightingState = new FightingState();
  public void StartGame()
  {
    Console.Clear();
    InitializeForest();
    var hero = HeroSelecter();
    Console.Clear();
    _fightingState.Fighting(hero);
    if (hero.HP == 0)
    {
      Console.WriteLine("Game over.");
      Console.WriteLine("Hero won {0} fight(s)", hero.WinCounter);
      Console.WriteLine("Hero had {0} gold(s) and {1} leather(s).", hero.Gold, hero.Leather);
      Console.WriteLine();
    }
    // Console.WriteLine("Do you want to play again? Y/N");
    // string playAgain = Console.ReadLine();
  }

  private void InitializeForest()
  {
    Console.Clear();
    Console.WriteLine("Welcome to the forest of Shorewood.");
  }

  private Hero HeroSelecter()
  {
    string str = "a";
    int heroNumber = -1;
    while (!int.TryParse(str, out heroNumber))
    {
      Console.WriteLine("Choose a Hero. (1 for Human, 2 for Dwarf, any number for a Hero)");
      str = Console.ReadLine();
    }

    if (heroNumber == 1) return new Human();
    else if (heroNumber == 2) return new Dwarf();
    else return new Hero();
  }
}