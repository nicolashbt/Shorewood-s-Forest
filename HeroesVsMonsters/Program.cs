﻿// See https://aka.ms/new-console-template for more information

using HeroesVsMonsters;
using HeroesVsMonsters.Characters;

var shorewood = new Shorewood();
var hero = new Hero();
var monster = new Monster();
shorewood.InitializeForest();
shorewood.Fight(hero,monster);
hero.Rest();


//Testing roll the dice
// int[] dices = character.RollTheDice();
// foreach (var d in dices)
// {
//   Console.WriteLine(d);
// }

