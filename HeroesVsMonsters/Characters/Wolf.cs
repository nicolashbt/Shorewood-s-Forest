namespace HeroesVsMonsters.Characters;

public class Wolf : Monster
{
  public Wolf()
  {
    //Drops only Leather
    Gold = 0;
  }

  public override string ToString()
  {
    return "Wolf";
  }
}