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
                time = args[1];
                angleSpeed = args[2];
                temp = int.Parse(args[3]);
            }
            public string Feladat3() {
                return $"név: {code}, időpont: {int.Parse(time)/100}:{int.Parse(time)%100}, hőmérséklet: {temp}";
            }
            public string Feladat4() {
                return $"név: {code}, időpont: {int.Parse(time)/100}:{int.Parse(time)%100}";
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
            //string str = Console.ReadLine();
            //Console.WriteLine("2. feladat: " + (input.Where(x => x.code == str).Max(x => int.Parse(x.time))/100) + ":" + input.Where(x => x.code == str).Max(x => int.Parse(x.time))%100);
            Console.WriteLine("3. feladat:\n" + input.MinBy(x => x.temp).Feladat3() + '\n' + input.MaxBy(x => x.temp).Feladat3());
            Console.WriteLine($"4. feladat");
            f4(input).ForEach(Console.WriteLine);
            f6(input);

        }
    }
}