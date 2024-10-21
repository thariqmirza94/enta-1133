using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    class Inventory
    {
        public List<Item> items = new List<Item>();  // Change to public

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"You received: {item.name}");
        }

        public void UseItem(string itemName, Player player)
        {
            Item item = items.FirstOrDefault(i => i.name == itemName);
            if (item != null)
            {
                item.Use(player);
                items.Remove(item);
                Console.WriteLine($"You used: {item.name}");
            }
            else
            {
                Console.WriteLine("Item not found in inventory.");
            }
        }

        public void ShowInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                Console.WriteLine("Inventory: " + string.Join(", ", items.Select(i => i.name)));
            }
        }
    }
}
