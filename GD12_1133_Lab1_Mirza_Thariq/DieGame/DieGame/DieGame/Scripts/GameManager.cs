using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    internal class GameManager
    {
        private bool gameOver = false;
        private Player player;
        private Pill pills;
        private int turnCounter = 0;
        private string currentPlayerName;

        public void PlayGame()
        {
            GameScreen.DrawMenuScreen();

            // Welcome and setup
            Console.WriteLine();
            Console.WriteLine("You find yourself in a dark, abandoned asylum. The walls are covered in cobwebs, and the air is thick with the scent of rotting flesh.");
            Console.WriteLine("The only sound you hear is your own heartbeat pounding in your chest. You're not sure how much longer you can keep this up.");

            string playerName = GetPlayerName();
            currentPlayerName = playerName;
            Console.WriteLine($"You're not sure what's real and what's just a product of your own paranoia. Your name is {playerName}, and you're about to take a pill that will change everything.");
            Console.WriteLine("The pills have varying amounts of poison: 0%, 10%, 20%, 30%, and 50%.");
            Console.WriteLine("But be warned, the more poison you ingest, the more your grip on reality begins to slip.");

            Console.Write("Are you ready to begin? (yes/no): ");
            string input = Console.ReadLine().ToLower();
            if (input == "yes")
            {
                // Initialize players and pills
                player = new Player(playerName);
                pills = new Pill();

                // Start game loop
                while (!gameOver)
                {
                    bool isPlayersTurn = turnCounter % 2 == 0;
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine(); // Pause the game loop for a moment

                    if (isPlayersTurn)
                    {
                        currentPlayerName = "You";
                        int playerPillLevel = pills.GetRandomPill();
                        player.TakePill(playerPillLevel);
                        GameScreen.DrawGameScreen(player.PoisonLevel, pills.ComputerPoisonLevel);
                        Console.WriteLine("The madness is creeping in. You can feel your grip on reality slipping away...");
                        if (player.PoisonLevel >= 100)
                        {
                            gameOver = true;
                            GameScreen.DrawGameOverScreen();
                            Console.WriteLine("You've lost all touch with reality. The game is over.");
                        }
                    }
                    else
                    {
                        currentPlayerName = "Computer";
                        int computerPillLevel = pills.GetRandomPill();
                        pills.ComputerPoisonLevel += computerPillLevel;
                        GameScreen.DrawGameScreen(player.PoisonLevel, pills.ComputerPoisonLevel);
                        Console.WriteLine("The computer is closing in on you. You can feel its cold, calculating logic creeping into your mind...");
                        if (pills.ComputerPoisonLevel >= 100)
                        {
                            gameOver = true;
                            GameScreen.DrawVictoryScreen();
                            Console.WriteLine("You've been consumed by the computer's madness. The game is over.");
                            Console.WriteLine("The last thing you saw was the computer's glowing screen, and then everything went black...");
                        }
                    }

                    turnCounter++;
                }

                // Game summary and score
                Console.WriteLine("Game Over!");
                Console.WriteLine($"Final Score - You: {player.PoisonLevel}%, Computer: {pills.ComputerPoisonLevel}%");
                Console.Write("Would you like to play again? (yes/no): ");
                string inputAgain = Console.ReadLine().ToLower();
                if (inputAgain == "yes")
                {
                    PlayGame(); // Start game loop again
                }
                else
                {
                    GameScreen.DrawCreditsScreen();
                    Console.WriteLine("Thank you for playing. Maybe next time...");
                }
            }
            else
            {
                GameScreen.DrawGameOverScreen();
                Console.WriteLine("The pills have consumed your mind. You've lost the game.");
            }
        }
        private string GetPlayerName()
        {
            Console.Write("Enter your name: ");
            return Console.ReadLine();
        }

        public Player GetPlayer() => player;
    }
}
