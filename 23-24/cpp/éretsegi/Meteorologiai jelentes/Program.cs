using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MeteorologiaiJelentes {

    internal class Program {
        public class Jelentes {
            public string code;
            public string time;
            public string angleSpeed;
            public int temp;
            public Jelentes(string[] args) {
                code = args[0];
                time = args[1];
                angleSpeed = args[2];
                temp = int.Parse(args[3]);
            }
        }

         static void Main(string[] args) {
            Jelentes[] jelentesek = File.ReadAllLines("tavirathu13.txt").Select(x => new Jelentes(x.Split(' '))).ToArray();
            string str = Console.ReadLine();
            Console.WriteLine("2. feladat : " + (int.Parse(jelentesek.Where(x => x.code == str).Max(x => x.time))/100) + ":" + (int.Parse(jelentesek.Where(x => x.code == str).Max(x => x.time))%100));
            
        }
    }
}