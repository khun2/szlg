using System;
using System.Collections;
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
                StringBuilder sb = new StringBuilder();
                sb.Append(args[1][0]);
                sb.Append(args[1][1]);
                sb.Append(':');
                sb.Append(args[1][2]);
                sb.Append(args[1][3]);

                time = sb.ToString();
                angleSpeed = args[2];
                temp = int.Parse(args[3]);
            }
            public string Feladat3() {
                return $"{code} {time} {temp} fok";
            }
            public string Feladat4() {
                return $"{code} {time}";
            }
        }

        static List<string> f4(Jelentes[] input ) {
            List<string> list = new List<string>();
            foreach ( Jelentes jelentes in input) {
                if (jelentes.angleSpeed == "00000") {
                    list.Add(jelentes.Feladat4());
                }
            }
            if (list.Count == 0) 
                list.Add("Nem volt szélcsen a mérések idején");
            return list;
        }

        static List<string> f5(Jelentes[] input ) {
            List<string> strings= new List<string>();
            var groups = input.GroupBy(x => x.code);
            foreach(var group in groups) {
                StringBuilder sb = new StringBuilder(group.Key);
                if(group.Any(x => x.time[0] == '0' && x.time[1] == '1') && group.Any(x => x.time[0] == '0' && x.time[1] == '7') && group.Any(x => x.time[0] == '1' && x.time[1] == '3') && group.Any(x => x.time[0] == '1' && x.time[1] == '9')) {
                    
                    sb.Append($" Középhőmérséklet: {Math.Round(group.Where(x => (x.time[0] == '0' && x.time[1] == '1') ||
                    (x.time[0] == '0' && x.time[1] == '7') || (x.time[0] == '1' && x.time[1] == '3') ||
                    (x.time[0] == '1' && x.time[1] == '9')).Average(x => x.temp))}");
                    //god is dead and my horrid code killed him
                }
                else sb.Append(" NA");
                sb.Append($"; Hőmérséklet-ingadozás: {group.Max(x => x.temp) - group.Min(x => x.temp)}");
                strings.Add(sb.ToString());
            }
            return strings;
        }

        static void f6 (Jelentes[] input) {
            foreach(var group in input.GroupBy(x => x.code)) {
                using (StreamWriter writer = new StreamWriter($"{group.Key}.txt")){
                    writer.WriteLine(group.Key); 
                    foreach (var item in group) {
                        int asd = (item.angleSpeed[3] - '0') * 10 + (item.angleSpeed[4] - '0');
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < asd; i++) {
                            sb.Append('#');
                        }
                        writer.WriteLine(item.time + ": " + sb.ToString());
                    }
                }
            }
            Console.WriteLine("A fájlok elkészültek.");
        }

        static void Main(string[] args) {
            Jelentes[] input = File.ReadAllLines("tavirathu13.txt").Select(x => new Jelentes(x.Split(' '))).ToArray();
            string str = Console.ReadLine();
            Console.WriteLine("2. feladat: " + input.Where(x => x.code == str).Max(x => x.time));
            Console.WriteLine("3. feladat:\nA legalacsonyabb hőmérséklet: " + input.MinBy(x => x.temp).Feladat3() + "\nA legmagasabb hőmérséklet: " + input.MaxBy(x => x.temp).Feladat3());
            Console.WriteLine($"4. feladat");
            f4(input).ForEach(Console.WriteLine);
            f5(input).ForEach(Console.WriteLine);
            f6(input);
            
        }
    }
}