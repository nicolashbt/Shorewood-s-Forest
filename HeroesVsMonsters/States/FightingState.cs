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

  private void Attack(Hero hero, Monster monster)
  {
    Console.WriteLine("{0} attacks {1} !", hero, monster);
    // att.Status();
    // def.Status();
    Console.WriteLine();
    while (hero.HP > 0 && monster.HP > 0)
    {
      hero.Hit(monster);
      if (monster.HP > 0) monster.Hit(hero);
    }

    FightEnding(hero, monster);
  }

  private void FightEnding(Hero hero, Monster monster)
  {
    Console.WriteLine();
    Console.WriteLine("The fight is finished !");
    if (monster.HP <= 0)
    {
      hero.WinCounter += 1;
      Console.WriteLine("{0} is dead !", monster);
      Console.WriteLine("{0} grew stronger !", hero);
      Looting(hero, monster);
    }
  }

  private void Looting(Hero hero, Monster monster)
  {
    if (monster.Gold > 0)
    {
      hero.Gold += monster.Gold;
      Console.WriteLine("Hero received {0} gold(s).", monster.Gold);
    }

    if (monster.Leather > 0)
    {
      hero.Leather += monster.Leather;
      Console.WriteLine("Hero received {0} leather(s).", monster.Leather);
    }
  }
}