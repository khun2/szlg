using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beolvasás
{
    internal class Program
    {
        static void Main(string[] args)
            { Console.Write("szám1:");
            double szam1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("az első szám:" + szam1);
            Console.Write("szam2:");
            double szam2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("a második szám:" + szam2);
            Console.WriteLine("összeg: " + szam1 + szam2);
            Console.WriteLine("szorzat: " + szam1 * szam2);
            Console.WriteLine("modulo: " + szam1 % szam2);
            Console.ReadLine();

        }
    }
}
