using HeroesVsMonsters.Characters;
using HeroesVsMonsters.States;
using HeroesVsMonsters.Utilities;

namespace HeroesVsMonsters;

public class Shorewood
{
  private readonly FightingState _fightingState;
  private readonly MapState _mapState;
  private readonly HeroSelector _selector;

  public Shorewood(FightingState fightingState, MapState mapState, HeroSelector selector)
  {
    _fightingState = fightingState;
    _mapState = mapState;
    _selector = selector;
  }


  public void StartGame()
  {
    var hero = _selector.HeroSelect();
    _mapState.InitMap();
    MainLoop(hero);
    GameOver(hero);
    PlayAgain(hero);
  }

  private void PlayAgain(Hero hero)
  {
    string playAgain = "";
    while (playAgain != "no")
    {
      Console.WriteLine("Do you want to play again? Yes or press Enter/No");
      playAgain = Console.ReadLine().ToLower();
      if (playAgain == "yes" || playAgain == "")
      {
        hero.WinCounter = 0;
        StartGame();
        return;
      }
    }
  }

  private void GameOver(Hero hero)
  {
    Console.WriteLine(hero.WinCounter == _mapState.MonsterNumber ? "You won." : "Game Over. You loose.");
    Console.WriteLine("{0} won {1} fight(s)", hero, hero.WinCounter);
    Console.WriteLine("{0} had {1} gold(s) and {2} leather(s).", hero, hero.Gold, hero.Leather);
    Console.WriteLine();
  }

  private void MainLoop(Hero hero)
  {
    while (hero.HP != 0)
    {
      _mapState.Moving();
      _fightingState.Fighting(hero, _mapState.NextMonsterType);
      if (hero.WinCounter >= _mapState.MonsterNumber) return;
    }
  }
}