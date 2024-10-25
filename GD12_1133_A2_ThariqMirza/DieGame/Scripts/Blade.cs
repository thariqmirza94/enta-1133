using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    // Concrete Blade class extending Item
    public class Blade : Item
    {
        public override string Name => "Blade";

        public override void Use(Player player)
        {
            player.TakeDamage(50);  // Decrease player's HP by 50 using TakeDamage method
            player.poisonMeter = 0;  // Reset poison meter to 0
            Console.WriteLine("You used a Blade! Your HP is now: " + player.hp + " and poison meter reset to 0.");
        }
    }
}
