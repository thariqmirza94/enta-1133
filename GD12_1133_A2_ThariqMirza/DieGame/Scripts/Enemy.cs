using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class Enemy
    {
        public int hp = 50;  // Initial enemy health
        private static Random random = new Random();  // Shared random instance

        // Method to check if the enemy is still alive
        public bool IsAlive()
        {
            return hp > 0;
        }

        // Method for the enemy to roll a dice (random d4, d6, d8, or d10)
        public int RollDice()
        {
            int[] diceSides = { 4, 6, 8, 10 };  // Available dice types
            int diceType = diceSides[random.Next(diceSides.Length)];
            return random.Next(1, diceType + 1);  // Roll the dice and return the result
        }

        // Method to apply damage to the enemy
        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Console.WriteLine("The enemy has been defeated!");
            }
            else
            {
                Console.WriteLine($"The enemy has {hp} HP remaining.");
            }
        }

        // Enemy attacks the player
        public void Attack(Player player)
        {
            Console.WriteLine("The enemy attacks!");
            int damage = RollDice();  // Use a random dice roll for the attack
            player.TakeDamage(damage);  // Apply damage to the player
        }

        // The enemy takes a pill, which could affect them in some way
        public void TakePill()
        {
            Console.WriteLine("The enemy takes a pill...");
            // Add custom logic for pill effects on the enemy, if needed
        }
    }
}
