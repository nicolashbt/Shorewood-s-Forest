namespace HeroesVsMonsters.Characters;

public class Monster : Character
{
  public Monster()
  {
    Gold = RollTheDice(1, 6);
    Leather = RollTheDice(1, 4);
  }

  public override string ToString()
  {
    return "Monster";
  }
}