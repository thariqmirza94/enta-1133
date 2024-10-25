using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class PuzzleRoom : Room
    {
        private bool puzzleSolved = false;

        public override string RoomName => "Puzzle Room";

        public override void OnRoomSearched(Player player)
        {
            if (!puzzleSolved)
            {
                Console.WriteLine("Solve the puzzle: What has keys but can't open locks?");
                string? answer = Console.ReadLine();  // Nullable string input

                if (answer != null && answer.ToLower() == "piano")
                {
                    Console.WriteLine("Correct! You may continue.");
                    puzzleSolved = true;
                }
                else
                {
                    Console.WriteLine("Incorrect answer. Try again.");
                }
            }
            else
            {
                Console.WriteLine("You've already solved the puzzle.");
            }
        }
    }
}
