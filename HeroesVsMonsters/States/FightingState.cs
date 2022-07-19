using HeroesVsMonsters.Characters;

namespace HeroesVsMonsters.States;

public class FightingState
{
  private readonly Random _rand = new Random();

  private Monster MonsterSpawner(int monsterType)
  {
    if (monsterType == 0) return new Wolf();
    else if (monsterType == 1) return new Orc();
    else if (monsterType == 2) return new Dragon();
    else return new Monster();
  }

  public void Fighting(Hero hero, int monsterType)
  {
    Console.Clear();
    var monster = MonsterSpawner(monsterType);
    Attack(hero, monster);
    hero.Rest();
    Console.ReadLine();
    Console.Clear();
  }

  private void Attack(Character att, Character def)
  {
    Console.WriteLine("{0} attacks {1} !", att, def);
    // att.Status();
    // def.Status();
    Console.WriteLine();
    while (att.HP > 0 && def.HP > 0)
    {
      att.Hit(def);
      if (def.HP > 0) def.Hit(att);
    }

    FightEding(att, def);
  }

  private void FightEding(Character att, Character def)
  {
    Console.WriteLine("The fight is finished !");

    if (att.IsDead)
    {
      Console.WriteLine("{0} is dead !", att);
      if (def is Hero)
      {
        Looting(def, att);
        def.WinCounter += 1;
      }
    }

    if (def.IsDead)
    {
      Console.WriteLine("{0} is dead !", def);
      if (att is Hero)
      {
        Looting(att, def);
        att.WinCounter += 1;
      }
    }
  }

  private void Looting(Character winner, Character looser)
  {
    if (looser.Gold > 0)
    {
      winner.Gold += looser.Gold;
      Console.WriteLine("Hero received {0} gold(s).", looser.Gold);
    }

    if (looser.Leather > 0)
    {
      winner.Leather += looser.Leather;
      Console.WriteLine("Hero received {0} leather(s).", looser.Leather);
    }
  }
}