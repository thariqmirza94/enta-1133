using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    class Room
    {
        public int roomNumber;
        public Enemy enemy;
        public bool isSearched = false;

        public Room(int number, string difficulty)
        {
            roomNumber = number;
            enemy = new Enemy(difficulty);
        }

        public List<Item> SearchRoom()
        {
            if (!isSearched)
            {
                isSearched = true;
                return GetRandomItems(2);  // Player finds 2 random items
            }
            else
            {
                Console.WriteLine("Room already searched.");
                return new List<Item>();  // Room already searched
            }
        }

        private List<Item> GetRandomItems(int numberOfItems)
        {
            List<Item> items = new List<Item> {
            new Item("Detox Pill", (player) => {
                player.poisonMeter = Math.Max(0, player.poisonMeter - 20);
                Console.WriteLine("Detox Pill used. Poison meter reduced by 20%.");
            }),
            new Item("Expired Cigarette", (player) => {
                player.poisonMeter = Math.Max(0, player.poisonMeter - 10);
                player.hp = Math.Max(0, player.hp - (int)(player.hp * 0.10)); // Reduce HP by 10%
                Console.WriteLine("Expired Cigarette used. Poison meter reduced by 10%, but lost 10% HP.");
            }),
            new Item("Blade", (player) => {
                player.poisonMeter = 0;
                player.hp = Math.Max(0, player.hp - (int)(player.hp * 0.50)); // Reduce HP by 50%
                Console.WriteLine("Blade used. Poison meter reset to 0, but lost 50% HP.");
            }),
            new Item("Small Health Pill", (player) => {
                player.hp = Math.Min(100, player.hp + (int)(player.hp * 0.20)); // Increase HP by 20%
                Console.WriteLine("Small Health Pill used. HP increased by 20%.");
                })
            };
            return items.OrderBy(x => new Random().Next()).Take(numberOfItems).ToList();
        }
    }
}
