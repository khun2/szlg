using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beolvasas_hazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("kérek egy oldalt! ");
            double oldal1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("kérek mégegy oldalt! ");
            double oldal2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine((oldal1 + oldal2) * 2);
            if (oldal1 == oldal2){
                Console.WriteLine("a téglalap egy négyzet");
                   }
            else {
                Console.WriteLine("a téglalap nem egy négyzet");
                    }

            Console.Write("kérek egy másik számot ");
            double szam = Convert.ToDouble(Console.ReadLine());
            if (szam % 7 == 0){
                Console.WriteLine("a szám osztható héttel");
            }
            else {
                Console.WriteLine("a szám nem osztható héttel");
                    }
            Console.ReadLine();



        }
    }
}
