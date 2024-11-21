using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class Player
    {
        public int hp = 100;  // Player health points
        public int poisonMeter = 0;  // Poison meter starts at 0%
        public Inventory Inventory { get; } = new Inventory();  // Player's inventory

        // Method to allow the player to take a pill
        public void TakePill()
        {
            Console.WriteLine("You take a pill...");
            poisonMeter = Math.Min(100, poisonMeter + new Random().Next(5, 15));  // Randomly increase poison meter between 5% and 15%
            Console.WriteLine($"Poison meter: {poisonMeter}%");

            if (poisonMeter >= 100)
            {
                Console.WriteLine("Your mind snaps as the poison takes over...");
            }
        }

        // Apply damage to the player
        public void TakeDamage(int damage)
        {
            hp = Math.Max(0, hp - damage);
            Console.WriteLine($"You took {damage} damage. Your HP is now {hp}.");
        }

        // Display the player's current status (HP and poison meter)
        public void CheckStatus()
        {
            Console.WriteLine($"HP: {hp}, Poison Meter: {poisonMeter}%");
        }
    }
}
