using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public abstract class Item
    {
        public abstract string Name { get; }  // Each item will have a name
        public abstract void Use(Player player);  // Abstract method to use the item
    }
}
