using HeroesVsMonsters;
using HeroesVsMonsters.States;
using HeroesVsMonsters.Utilities;

Random random = new Random();

FightingState fightingState = new FightingState();
MapState mapState = new MapState(random);
HeroSelector selector = new HeroSelector();

var shorewood = new Shorewood(fightingState, mapState, selector);
shorewood.StartGame();

//Testing roll the dice
// var ch = new Character();
// int[] dices = ch.RollTheDice();
// foreach (var d in dices)
// {
//   Console.WriteLine(d);
// }