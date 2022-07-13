namespace HeroesVsMonsters.Characters;

public class Character
{
  public Character()
  {
    End = RollTheDice(4, 6);
    Str = RollTheDice(4, 6);
    HP = Modify(End);
    MaxHP = HP;
    Gold = 0;
    Leather = 0;
    IsDead = false;
  }

  public int End { get; internal set; }
  public int Str { get; internal set; }
  private int _hp;

  public int HP
  {
    get { return _hp; }
    set
    {
      if (value < 0)
      {
        _hp = 0;
        IsDead = true;
      }
      else
      {
        _hp = value;
      }
    }
  }

  public int MaxHP { get; set; }

  public bool IsDead { get; set; }

  public int Gold { get; internal set; }
  public int Leather { get; internal set; }

  public static int RollTheDice(int numberDices, int numberFaces)
  {
    var rand = new Random();
    var dices = new int[numberDices];
    for (var index = 0; index < dices.Length; index++)
    {
      dices[index] = rand.Next(1, numberFaces + 1);
    }

    return dices.OrderByDescending(x => x).Take(3).Sum();
  }

  public static int Modify(int value)
  {
    if (value < 5)
    {
      return value - 1;
    }
    else if (value < 10)
    {
      return value;
    }
    else if (value < 15)
    {
      return value + 1;
    }
    else
    {
      return value + 2;
    }
  }

  public void Hit(Character target)
  {
    int damage = RollTheDice(1, 6) + Modify(Str);
    Console.WriteLine("{0} was hit by {1} and lost {2} hp.", target, this, damage);
    target.HP -= damage;
    Console.WriteLine("{0} has {1} hp left.", target, target.HP);
  }
}