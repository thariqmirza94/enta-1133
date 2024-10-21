using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame.Scripts
{
    public class DiceRoller
    {
        public int NumberOfSides = 6;

        // Creating instances
        Random random = new Random(); // random Instance

        // Creating the variable Roll that will generate a random number every time
        public int Roll()
        {
            int randomRoll = random.Next(1, NumberOfSides + 1);
            return randomRoll;
        }

        // Creating the function RollScore that add variable Score + variable Roll
        public void RollScore(ref int playerScore)
        {
            playerScore += Roll();
        }
    }
}
