namespace HeroesVsMonsters.Characters;

public class Orc : Monster
{
  public Orc()
  {
    Str += 1;
    //Drops only Gold
    Leather = 0;
  }
}