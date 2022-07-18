using HeroesVsMonsters.Characters;
using HeroesVsMonsters.States;

namespace HeroesVsMonsters;

public class Shorewood
{
  private readonly FightingState _fightingState = new FightingState();

  public void StartGame()
  {
    InitializeForest();
    var hero = HeroSelecter();
    MainLoop(hero);
    GameOver(hero);
    PlayAgain();
  }

  private void PlayAgain()
  {
    string playAgain = "";
    while (playAgain != "no")
    {
      Console.WriteLine("Do you want to play again? Yes/No");
      playAgain = Console.ReadLine().ToLower();
      if (playAgain == "yes")
      {
        StartGame();
        break;
      }
    }
  }

  private void GameOver(Hero hero)
  {
    Console.WriteLine("Game over.");
    Console.WriteLine("Hero won {0} fight(s)", hero.WinCounter);
    Console.WriteLine("Hero had {0} gold(s) and {1} leather(s).", hero.Gold, hero.Leather);
    Console.WriteLine();
  }

  private void MainLoop(Hero hero)
  {
    while (hero.HP != 0)
    {
      _fightingState.Fighting(hero);
    }
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

    Console.Clear();
    if (heroNumber == 1) return new Human();
    else if (heroNumber == 2) return new Dwarf();
    else return new Hero();
  }

  private void InitializeForest()
  {
    Console.Clear();
    Console.WriteLine("Welcome to the forest of Shorewood.");
  }
}