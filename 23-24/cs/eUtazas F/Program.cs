using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utazas
{
    internal class Program {
        class Data {
            public int station;
            public DateTime date;
            public string id;
            public string type;
            public int tickets;
            public DateTime expiry;
            public Data(string[] args ){
                station = int.Parse(args[0]);
                date = dateProcessor(args[1]);
                id = args[2];
                type = args[3];
                if (int.Parse(args[4]) < 11 ) {
                    tickets = int.Parse(args[4]);
                    expiry = DateTime.MaxValue;
                }
                else {
                    tickets = 11;
                    expiry = dateProcessor(args[4]);
                }
            }
        }

        static DateTime dateProcessor(string input) {
            int year = int.Parse(input.Substring(0, 4));
            int month = int.Parse(input.Substring(4, 2));
            int day = int.Parse(input.Substring(6, 2));
            if (input.Length == 13) {
                int hour = int.Parse(input.Substring(9, 2));
                int minute = int.Parse(input.Substring(11, 2));
                return new DateTime(year, month, day, hour, minute,0);
            }
            return new DateTime(year,month,day);
        }

        static void Main(string[] args) {
            Data[] input = File.ReadLines("utasadat.txt").Select(x => new Data(x.Split(' '))).ToArray();
            Console.WriteLine("2. feladat:" +  input.Count());
            Console.WriteLine("3. feladat:" +  input.Count(x => x.tickets == 0 || x.date >= x.expiry));
        }
    }
}