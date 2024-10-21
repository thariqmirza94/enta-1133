using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    class Player
    {
        public int hp = 100;
        public int poisonMeter = 0;
        public Inventory inventory = new Inventory();  // Add Inventory property

        public void TakePill()
        {
            poisonMeter = Math.Min(100, poisonMeter + 10);  // Pill adds 10 poison by default
            Console.WriteLine($"You took a pill. Poison meter: {poisonMeter}%.");
            if (poisonMeter > 50)
            {
                Console.WriteLine("Despair thoughts: Your sanity is fading...");
            }
            if (poisonMeter >= 100)
            {
                Console.WriteLine("You lost your mind!");
            }
        }

        public void CheckHealth()
        {
            Console.WriteLine($"Player HP: {hp}, Poison Meter: {poisonMeter}%");
            if (hp <= 0)
            {
                Console.WriteLine("You died.");
            }
        }

        // Add AddItem method to Player class
        public void AddItem(Item item)
        {
            player.inventory.AddItem(item);
        }
    }
}
