using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class TreasureRoom : Room
    {
        private int timesSearched = 0;

        public override string RoomName => "Treasure Room";

        public override void OnRoomSearched(Player player)
        {
            if (timesSearched < 3)
            {
                Console.WriteLine("You found a valuable item!");
                player.Inventory.AddItem(new HealthPill());  // Add a HealthPill to player's inventory
                timesSearched++;
            }
            else
            {
                Console.WriteLine("You've already searched this room three times. There's nothing more to find.");
            }
        }
    }
}
