using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    // CombatRoom class: A room where the player faces an enemy in a pill dice game
    public class CombatRoom : Room
    {
        public Enemy Enemy { get; } = new Enemy();

        public override string RoomName => "Combat Room";

        public override void OnRoomSearched(Player player)
        {
            Console.WriteLine("This room has an enemy. Prepare for combat!");
        }
    }
}
