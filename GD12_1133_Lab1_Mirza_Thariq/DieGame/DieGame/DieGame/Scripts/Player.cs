using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class Player
    {
        private string name;
        private int poisonLevel;

        public Player(string name)
        {
            this.name = name;
        }

        public void TakePill(int pillLevel)
        {
            poisonLevel += pillLevel;
        }

        public int PoisonLevel => poisonLevel;

        public string Name => name;
    }
}
