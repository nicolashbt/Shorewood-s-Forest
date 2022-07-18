namespace HeroesVsMonsters.Characters;

public class God : Hero
{
  public God()
  {
    End += 99;
    Str += 99;
  }
  public override string ToString()
  {
    return "God.exe";
  }
}