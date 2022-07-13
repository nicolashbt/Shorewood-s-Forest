// See https://aka.ms/new-console-template for more information

using HeroesVsMonsters.Characters;

var hero = new Hero();
var monster = new Monster();
Console.WriteLine("Hero:");
Status(hero);
Console.WriteLine("Monster:");
Status(monster);
hero.Hit(monster);
Status(monster);


//Testing roll the dice
// int[] dices = character.RollTheDice();
// foreach (var d in dices)
// {
//   Console.WriteLine(d);
// }

void Status(Character ch)
{
  Console.WriteLine("Character: Endurance: {0}. Strength: {1}. HP: {2}", ch.End,
    ch.Str, ch.HP);
}