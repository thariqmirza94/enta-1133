using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab1_Mirza_Thariq.Scripts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            manager.Play();
            Console.WriteLine("arithemetic operator - is used to substract the value of one variable from another");
            Console.WriteLine("arithemetic operator / is used to divide the value of one variable from another");
            Console.WriteLine("arithemetic operator * is used to multiply the value of two variables");
            Console.WriteLine("arithemetic operator ++ is used to add 1 to the value of the variable");
            Console.WriteLine("arithemetic operator -- is used to substract 1 from the value of the variable");
            Console.WriteLine("arithemetic operator % is used to Returns the division remainder of two variables");
        }
    }
}
