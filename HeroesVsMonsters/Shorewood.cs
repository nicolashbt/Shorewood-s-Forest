using HeroesVsMonsters.Characters;

namespace HeroesVsMonsters;

public class Shorewood
{
  private void Fight(Character att, Character def)
  {
    Console.WriteLine("{0} attacks {1} !", att, def);
    Console.WriteLine("Attacker's stats:");
    att.Status();
    Console.WriteLine("Defender's stats:");
    def.Status();
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
      def.winCounter += 1;
    }

    if (def.IsDead)
    {
      Console.WriteLine("{0} is dead !", def);
      att.winCounter += 1;
    }

    Console.WriteLine();
  }

  private void InitializeForest()
  {
    Console.WriteLine("Welcome to the forest of Shorewood.");
  }

  public void StartGame()
  {
    var hero = new Hero();
    InitializeForest();

    while (!hero.IsDead)
    {
      var monster = new Monster();
      Fight(hero, monster);
      hero.Rest();
      // Console.ReadLine();
    }

    Console.WriteLine("Game over.");
    Console.WriteLine("Hero won {0} fights", hero.winCounter);
  }
}