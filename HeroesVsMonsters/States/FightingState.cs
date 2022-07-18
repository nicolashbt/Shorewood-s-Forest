using HeroesVsMonsters.Characters;

namespace HeroesVsMonsters.States;

public class FightingState
{
  private Random rand = new Random();

  private Monster MonsterSpawner()
  {
    int monsterNumber = rand.Next(1, 4);

    if (monsterNumber == 1) return new Orc();
    else if (monsterNumber == 2) return new Dragon();
    else return new Wolf();
  }

  public void Fighting(Hero hero)
  {
    var monster = MonsterSpawner();
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