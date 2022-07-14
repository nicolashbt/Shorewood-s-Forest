namespace HeroesVsMonsters.Characters;

public class Dwarf : Hero
{
  public Dwarf()
  {
    End += 2;
  }

  public override string ToString()
  {
    return "Dwarf hero";
  }
}