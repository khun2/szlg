using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace n
{
    internal class Program
    {
        class Offer
        {
            public string region;
            public int nights;
            public bool family;
            public string month;
            public int maxDays;
            public int price;

            public Offer(string region, int nights, bool family, string month, int maxDays, int price)
            {
                this.region = region;
                this.nights = nights;
                this.family = family;
                this.month = month;
                this.maxDays = maxDays;
                this.price = price;
            }
        }

        #region functions
        static List<Offer> Beolvasás(string file)
        {
            string[] rows = File.ReadAllLines(file);
            List<Offer> list = new List<Offer>();
            foreach (string row in rows)
            {
                string[] line = row.Split('\t');
                list.Add(new Offer(line[0], line[1], line[2], line[3], line[4], line[5]));
            }
            return list;
        }

        #endregion
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;


        }
    }
}