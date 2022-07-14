namespace HeroesVsMonsters.Characters;

public class Monster : Character
{
  public Monster()
  {
    Gold = RollTheDice();
    Leather = RollTheDice(1, 1, 4);
  }

  public override string ToString()
  {
    return "Monster";
  }
}