using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osztalyok_23f
{
    internal class Program
    {
        class Foci 
        {
            public int code;
            public string country;
            public int top;
            public int year;
            public int location;
            public Foci(int code, string country, int top, int year, int location)
            {
                this.code = code;
                this.country = country;
                this.top = top;
                this.year = year;
                this.location = location;
            }
        }
        static List<Foci> Beolvas(string file)
        {
            List<Foci> list = new List<Foci>();
            string[] sorok = File.ReadAllLines(file);
            foreach(string sor in sorok)
            {
                string[] sortomb = sor.Split('\t');
                Foci foci = new Foci(int.Parse(sortomb[0]), sortomb[1], int.Parse(sortomb[2]), int.Parse(sortomb[3]), int.Parse(sortomb[4]));
                list.Add(foci);
            }
            return list;
        } 
        static List<Foci> NameSelect(List<Foci> input, string name)
        {
            return (List<Foci>)input.Where(x => x.country == name);
        }
        static void Main(string[] args)
        {
            List<Foci> input = Beolvas("input.txt");
        }
    }
}