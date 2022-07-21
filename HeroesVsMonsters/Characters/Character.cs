namespace HeroesVsMonsters.Characters;

public class Character
{
  public Character()
  {
    End = RollTheDice(6, 3);
    Str = RollTheDice(6, 3);
    HP = End + Modify(End);
    MaxHP = HP;
    Gold = 0;
    Leather = 0;
  }

  public int WinCounter { get; set; }
  public int End { get; internal set; }
  public int Str { get; internal set; }

  private int _hp;

  public int HP
  {
    get { return _hp; }
    set { _hp = value < 0 ? 0 : value; }
  }

  public int MaxHP { get; internal set; }
  public int Gold { get; internal set; }
  public int Leather { get; internal set; }

  public static int RollTheDice(int dicesTotal = 1, int dicesTaken = 1, int numberFaces = 6)
  {
    var rand = new Random();
    var dices = new int[dicesTotal];
    for (var index = 0; index < dices.Length; index++)
    {
      dices[index] = rand.Next(1, numberFaces + 1);
    }

    return dices.OrderByDescending(x => x).Take(dicesTaken).Sum();
  }

  private static int Modify(int value)
  {
    if (value < 5) return -1;
    else if (value < 10) return 0;
    else if (value < 15) return 1;
    else if (value < 99) return 2;
    else return 99;
  }

  public void Hit(Character target)
  {
    int damage = RollTheDice(1, 1, 4) + Modify(Str) + WinCounter / 3;
    target.HP -= damage;
    Console.WriteLine("{0} deals {2} damage(s) to {1}. {0} has {3} hp(s) left.", this, target, damage, target.HP);
  }

  public void Status()
  {
    Console.WriteLine("{0}: Endurance: {1}. Strength: {2}. HP: {3}.", this, this.End,
      this.Str, this.HP);
    if (this.ToString() == "Hero")
    {
      Console.WriteLine("{0} has {1} gold and {2} leather.", this, this.Gold, this.Leather);
    }
  }
}