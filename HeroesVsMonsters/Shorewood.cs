using HeroesVsMonsters.Characters;
using HeroesVsMonsters.States;
using HeroesVsMonsters.Utilities;

namespace HeroesVsMonsters;

public class Shorewood
{
  private readonly FightingState _fightingState = new FightingState();
  private readonly MapState _mapState = new MapState();

  public void StartGame()
  {
    var hero = HeroSelector.HeroSelect();
    _mapState.InitMap();
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
    Console.WriteLine(hero.WinCounter == 10 ? "You won." : "You loose.");
    Console.WriteLine("{0} won {1} fight(s)", hero, hero.WinCounter);
    Console.WriteLine("{0} had {1} gold(s) and {2} leather(s).", hero, hero.Gold, hero.Leather);
    Console.WriteLine();
  }

  private void MainLoop(Hero hero)
  {
    while (hero.HP != 0)
    {
      _mapState.Moving();
      _fightingState.Fighting(hero,_mapState.NextMonsterType);
      if (hero.WinCounter == _mapState.MonsterNumber)
      {
        break;
      }
    }
  }
}