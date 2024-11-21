using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    // Base Room class
    public abstract class Room
    {
        public abstract string RoomName { get; }

        // Abstract method for searching the room
        public abstract void OnRoomSearched(Player player);

        // Virtual method for when the player enters the room
        public virtual void OnRoomEntered()
        {
            Console.WriteLine($"You enter the {RoomName}.");
        }
    }
}
