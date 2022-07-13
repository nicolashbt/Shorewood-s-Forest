namespace HeroesVsMonsters.Characters;

public class Hero : Character
{
  public Hero()
  {
  }

  public override string ToString()
  {
    return "Hero";
  }

  public void Rest()
  {
    if (base.HP > 0)
    {
      Console.WriteLine("Hero rested and regained their health.");
      base.HP = base.MaxHP;
    }
    else
    {
      Console.WriteLine("Hero is dead and can´t be revived.");
    }
  }
}