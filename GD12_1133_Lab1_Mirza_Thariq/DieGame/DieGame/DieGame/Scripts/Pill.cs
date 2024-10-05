using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class Pill
    {
        private Random random = new Random();
        private int[] pillLevels = { 0, 10, 20, 30, 50 };
        public int ComputerPoisonLevel { get; set; } = 0;

        public int GetRandomPill()
        {
            return pillLevels[random.Next(pillLevels.Length)];
        }
    }
}