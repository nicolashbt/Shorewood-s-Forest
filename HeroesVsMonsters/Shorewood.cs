using HeroesVsMonsters.Characters;

namespace HeroesVsMonsters;

public class Shorewood
{
  public void Fight(Character att, Character def)
  {
    Console.WriteLine("{0} attacks {1} !", att, def);
    Console.WriteLine("Attacker's stats:");
    Status(att);
    Console.WriteLine("Defender's stats:");
    Status(def);
    while (att.HP > 0 && def.HP > 0)
    {
      att.Hit(def);
      if (def.HP < 0) def.Hit(att);
    }

    Console.WriteLine("The fight is finished !");


    if (att.IsDead)
    {
      Console.WriteLine("{0} is dead !",att);
    }

    if (def.IsDead)
    {
      Console.WriteLine("{0} is dead !",def);
    }
  }

  public void Status(Character ch)
  {
    Console.WriteLine("{0}: Endurance: {1}. Strength: {2}. HP: {3}.", ch, ch.End,
      ch.Str, ch.HP);
  }

  public void InitializeForest()
  {
    Console.WriteLine("Welcome to the forest of Shorewood.");
  }
}