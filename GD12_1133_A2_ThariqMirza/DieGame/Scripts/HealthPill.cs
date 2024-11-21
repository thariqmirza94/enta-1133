using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    // Concrete HealthPill class extending Item
    public class HealthPill : Item
    {
        public override string Name => "Health Pill";

        public override void Use(Player player)
        {
            player.hp = Math.Min(player.hp + 20, 100);  // Increase player's HP by 20, up to max 100
            Console.WriteLine("You used a Health Pill! Your HP is now: " + player.hp);
        }
    }
}
