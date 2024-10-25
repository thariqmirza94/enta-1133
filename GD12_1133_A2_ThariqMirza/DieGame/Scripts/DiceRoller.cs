using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class DiceRoller
    {
        private static Random random = new Random();  // Static Random instance to avoid reseeding issues

        // Roll a dice with a given number of sides
        public static int Roll(int numberOfSides)
        {
            return random.Next(1, numberOfSides + 1);  // Returns a random number between 1 and numberOfSides
        }
    }
}
