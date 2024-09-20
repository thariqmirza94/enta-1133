using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab1_Mirza_Thariq.Scripts
{
    internal class DieRoller
    {
        public int total = 0;
        public void Roll()
        {
            Random randomNumber = new Random();
            int roll = randomNumber.Next(1, 7);
            Console.WriteLine(roll);
            total += roll;
        }
    }
}
