namespace HeroesVsMonsters.Characters;

public class Character
{
  public Character()
  {
    End = RollTheDice(4);
    Str = RollTheDice(4);
    HP = Modify(End);
  }

  public int End { get; private set; }
  public int Str { get; private set; }
  private int _hp;

  public int HP
  {
    get { return _hp; }
    set { _hp = (value < 0) ? 0 : value; }
  }

  public int Gold { get; set; }
  public int Leather { get; set; }
  public static int RollTheDice(int numberDices)
  {
    var rand = new Random();
    var dices = new int[numberDices];
    for (var index = 0; index < dices.Length; index++)
    {
      dices[index] = rand.Next(1, 7);
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
    int damage = RollTheDice(1) + Modify(Str);
    Console.WriteLine("{0} was hit by {1} and lost {2} hp.", target, this, damage);
    target.HP -= damage;
  }
}