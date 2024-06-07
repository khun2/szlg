using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            return new DateTime(year,month,day,23,59,0);
        }
        static int napokszama(int e1, int h1, int n1, int e2, int h2, int n2) {
            h1 = (h1 + 9) % 12;
	        e1 = e1 - h1 / 10;
	        int d1= 365*e1 + e1 / 4 - e1 / 100 + e1 / 400 + (h1*306 + 5) / 10 + n1 - 1;
	        h2 = (h2 + 9) % 12;
	        e2 = e2 - h2 / 10;
	        int d2= 365*e2 + e2 / 4 - e2 / 100 + e2 / 400 + (h2*306 + 5) / 10 + n2 - 1;
            return d2-d1;
        }
        static void figyelmztetes(Data[] input) {
            input = input.Where(x => x.date <= x.expiry && napokszama(x.date.Year,x.date.Month,x.date.Day, x.expiry.Year,x.expiry.Month,x.expiry.Day) <= 3 ).ToArray();
            using (StreamWriter s = new StreamWriter("figyelmeztetes.txt")) {
                foreach(Data data in input) {
                    Console.WriteLine(data.date.ToString() +' ' + data.expiry.ToString());
                    s.WriteLine(data.id + ' ' + data.expiry.Year + '-' + data.expiry.Month+ '-' + data.expiry.Day);
                }
            }
        }

        static void Main(string[] args) {
            Data[] input = File.ReadLines("utasadat.txt").Select(x => new Data(x.Split(' '))).ToArray();
            Console.WriteLine("2. feladat:" +  input.Count());
            Console.WriteLine("3. feladat:" +  input.Count(x => x.tickets == 0 || x.date > x.expiry));
            Console.WriteLine("4. feladat:" +  input.GroupBy(x => x.station).MaxBy(x => x.Count()).Key);
            // maga a feladat nem írta hogy az kell hogy mennyien száltak fel csak a  példában volt úgy kiírva
            Console.WriteLine("5. feladat:\n kevezményes:" + input.Count(x => (x.date <= x.expiry) && (x.type == "TAB" || x.type == "NYB")) + "\n ingyenes: " + input.Count(x => (x.date <= x.expiry) && (x.type == "RVS" || x.type == "NYP" || x.type == "GYK")));
            figyelmztetes(input);
        }
    }
}