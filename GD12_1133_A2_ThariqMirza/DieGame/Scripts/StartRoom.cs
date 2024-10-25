using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class StartRoom : Room
    {
        public override string RoomName => "Start Room";

        public override void OnRoomSearched(Player player)
        {
            Console.WriteLine("This is the starting room, there's nothing to search here.");
        }
    }
}
