using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    class Item
    {
        public string name;
        public Action<Player> effect;  // The effect the item has when used

        public Item(string name, Action<Player> effect)
        {
            this.name = name;
            this.effect = effect;
        }

        public void Use(Player player)
        {
            effect(player);
        }
    }
}
