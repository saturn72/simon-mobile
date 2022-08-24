using System;
using System.Collections.Generic;
using System.Text;

namespace Simon.Services
{
    internal class GameManager
    {
        const int MaxLevelLength = 5;
        private static readonly Random _random = new Random();
        private static readonly string[] ColorOptions = new[] {"red", "green", "blue", "yellow"};

        private static string[] CurrentGame;
        public static void CreateGame()
        {
            CurrentGame = new string[MaxLevelLength];
            var l = ColorOptions.Length;

            for (int i = 0; i < CurrentGame.Length; i++)
            {
                var j = (_random.Next() % l);
                CurrentGame[i] = ColorOptions[j];
            }            
        }
    }
}
