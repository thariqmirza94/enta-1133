using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();  // List to store player's items

        // Add an item to the player's inventory
        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"Added {item.Name} to your inventory.");
        }

        // Show the player's inventory
        public void ShowInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("Inventory:");
                foreach (Item item in items)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        // Find an item by name in the inventory
        public Item? FindItemByName(string name)
        {
            return items.FirstOrDefault(i => i.Name == name);
        }
    }
}
