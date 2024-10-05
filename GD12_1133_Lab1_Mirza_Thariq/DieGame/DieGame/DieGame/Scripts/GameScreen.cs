using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class GameScreen
    {
        public static void DrawMenuScreen()
        {
            Console.Clear();
            Console.WriteLine("____________________________");
            Console.WriteLine("|                          |");
            Console.WriteLine("|      Welcome to the      |");
            Console.WriteLine("|   Psychological Horror   |");
            Console.WriteLine("| A Game of Poisoned Minds |");
            Console.WriteLine("|                          |");
            Console.WriteLine("____________________________");
        }

        public static void DrawGameScreen(int playerPoisonLevel, int computerPoisonLevel)
        {
            Console.Clear();
            Console.WriteLine("_________________");
            Console.WriteLine("|               |");
            Console.WriteLine($"|   You: {playerPoisonLevel}%   |");
            Console.WriteLine($"|  Computer: {computerPoisonLevel}%. |");
            Console.WriteLine("_________________");
            Console.WriteLine("|               |");
        }

        public static void DrawGameOverScreen()
        {
            Console.Clear();
            Console.WriteLine("________________________");
            Console.WriteLine("|                      |");
            Console.WriteLine("|      GAME OVER       |");
            Console.WriteLine("|                      |");
            Console.WriteLine("|    The pills have    |");
            Console.WriteLine("|  consumed your mind. |");
            Console.WriteLine("|                      |");
            Console.WriteLine("________________________");
        }

        public static void DrawCreditsScreen()
        {
            Console.Clear();
            Console.WriteLine("___________________________");
            Console.WriteLine("|                         |");
            Console.WriteLine("|  Thank you for playing  |");
            Console.WriteLine("|       the game!         |");
            Console.WriteLine("|    Please come back     |");
            Console.WriteLine("|   and play again soon.  |");
            Console.WriteLine("|                         |");
            Console.WriteLine("___________________________");
        }
        public static void DrawVictoryScreen()
        {
            Console.Clear();
            Console.WriteLine("_________________________");
            Console.WriteLine("|                       |");
            Console.WriteLine("|    Congratulations!   |");
            Console.WriteLine("|  You've won the game. |");
            Console.WriteLine("|   But at what cost?   |");
            Console.WriteLine("|    The poison has     |");
            Console.WriteLine("|   ravaged your mind,  |");
            Console.WriteLine("|  and you'll never be  |");
            Console.WriteLine("|   the same again...   |");
            Console.WriteLine("|                       |");
            Console.WriteLine("_________________________");
        }
    }
}
