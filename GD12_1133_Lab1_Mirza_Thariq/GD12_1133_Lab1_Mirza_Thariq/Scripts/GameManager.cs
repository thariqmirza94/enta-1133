using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab1_Mirza_Thariq.Scripts
{
    internal class GameManager
    {
        public void Play()
        {
            Console.WriteLine("Welcome to Hell in Programing Thariq on 19/09/2024");
            DieRoller diceInstance = new DieRoller();
            diceInstance.Roll();
            diceInstance.Roll();
            diceInstance.Roll();
            diceInstance.Roll();
            Console.WriteLine("Your total score is = " + diceInstance.total);
            Console.WriteLine("Goodbye Hell");
        }
    }
}
