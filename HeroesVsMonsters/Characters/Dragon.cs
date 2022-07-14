namespace HeroesVsMonsters.Characters;

public class Dragon : Monster
{
  public Dragon()
  {
    End += 1;
    Gold += 1;
    Leather += 1;
  }
  
  public override string ToString()
  {
    return "Dragon";
  }
}