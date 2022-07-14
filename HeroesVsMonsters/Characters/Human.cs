namespace HeroesVsMonsters.Characters;

public class Human : Hero
{
  public Human()
  {
    Str += 1;
    End += 1;
  }
  
  public override string ToString()
  {
    return "Human hero";
  }
}