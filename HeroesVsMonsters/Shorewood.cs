using HeroesVsMonsters.Characters;

namespace HeroesVsMonsters;

public class Shorewood
{
  private Random rand = new Random();

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
    InitializeForest();
    var hero = HeroSelecter();
    while (hero.HP > 0)
    {
      var monster = MonsterSpawner();
      Fight(hero, monster);
      hero.Rest();
      Console.ReadLine();
    }

    Console.WriteLine("Game over.");
    Console.WriteLine("Hero won {0} fights", hero.winCounter);
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

  private Monster MonsterSpawner()
  {
    int MonsterNumber = rand.Next(1, 4);

    if (MonsterNumber == 1) return new Orc();
    else if (MonsterNumber == 2) return new Dragon();
    else return new Wolf();
  }
}