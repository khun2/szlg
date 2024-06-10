using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m
{
    internal class Program
    {
        class Telep {
            public int code;
            public string name;
            public string rank;
            public string type;
            public int size;
            public int pop;
            public int houses;
            public Telep(int code, string name, string rank, string type, int size, int pop, int houses) {
                this.code = code;
                this.name = name;
                this.rank = rank;
                this.type = type;
                this.size = size;
                this.pop = pop;
                this.houses = houses;
            }
        }

        static List<Telep> Beolvas(string s) {
            List<Telep> list = new List<Telep>();
            string[] lines = File.ReadAllLines(s);
            foreach (string line in lines) {
                string[] parts = line.Split('\t');
                list.Add(new Telep(int.Parse(parts[4]), parts[1], parts[2], parts[3], int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
            }
            return list;
        }
        /*
        static List<Telep> PopSort(List<Telep> input, bool largest) {
            List<Telep> orderedList = new List<Telep>(), output = new List<Telep>();
            if(largest) orderedList = input.Max(x => x.pop)
            else orderedList = input.MaxDescending(x => x.p
            int i = 0;
            while (i < input.Count() && orderedList[i].pop == orderedList[0].pop) {
                output.Add(orderedList[i]);
                i++;
            }
            return output;
        }

        static List<Telep> SizeSort(List<Telep> input, bool largest) {
            List<Telep> orderedList = new List<Telep>(), output = new List<Telep>();
            if(largest) orderedList = input.Max(x => x.size)
            else orderedList = input.MaxDescending(x => x.s
            int i = 0;
            while (i < input.Count() && orderedList[i].size == orderedList[0].size) {
                output.Add(orderedList[i]);
                i++;
            }
            return output;
        }
        */

        static List<Telep> MaxBy(List<Telep> input, Func<Telep, Telep, int> func) {
            List<Telep> list = new List<Telep>();
            foreach(Telep t in input) {
                if(list.Count == 0) list.Add(t);
                else {
                    int cmp = func(list[0],t);
                    if(cmp == 1) list = [t];
                    else if (cmp == 0) list.Add(t);
                }
            }
            return list;
        }

        static void Main(string[] args) {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<Telep> input = Beolvas("input.txt");
            Console.WriteLine($"1. Hány település található az input fájlban?\n{input.Count()}");
            Console.WriteLine($"2. Hány község rangú település található?\n{input.Count(x => x.rank == "község")}");
            Console.WriteLine($"3. Hány város rangú település található?\n{input.Count(x => x.rank == "város")}");

            Console.WriteLine($"4. Van-e falu rangú település?{input.Any(x => x.rank == "falu")}");
            
            Console.WriteLine($"5. Hány község rangú település található a Makói kistérségben?\n{input.Count(x => x.rank == "község" && x.type == "Makói")}");
            Console.WriteLine($"6. Hány község rangú település található a Szegedi kistérségben?\n{input.Count(x => x.rank == "község" && x.type == "Szegedi")}");
            Console.WriteLine($"7. Hány község rangú település található a Szentesi kistérségben?\n{input.Count(x => x.rank == "község" && x.type == "Szentesi")}");
            Console.WriteLine($"8. Hány város rangú település található a Makói kistérségben?\n{input.Count(x => x.rank == "város" && x.type == "Makói")}");
            Console.WriteLine($"9. Hány város rangú település található a Szegedi kistérségben?\n{input.Count(x => x.rank == "város" && x.type == "Szegedi")}");
            Console.WriteLine($"10. Hány város rangú település található a Szentesi kistérségben?\n{input.Count(x => x.rank == "város" && x.type == "Szentesi")}");
            
            Console.WriteLine("11. Írja ki a község rangú települések közül az 1000 főnél népesebb települések nevét és népességét!");
            foreach (Telep telep in input.Where(x => x.rank == "község" && x.pop > 1000).ToList()) {
                Console.WriteLine(telep.name + ": " + telep.pop);
            }
            Console.WriteLine("12. Írja ki a város rangú települések közül az 10000 főnél népesebb települések nevét és népességét!");
            foreach (Telep telep in input.Where(x => x.rank == "város" && x.pop > 10000).ToList()) {
                Console.WriteLine(telep.name + ": " + telep.pop);
            }
            Console.WriteLine("13. Írja ki a község rangú települések közül az 1000 főnél alacsonyabb népességű települések nevét és népességét!");
            foreach (Telep telep in input.Where(x => x.rank == "község" && x.pop < 1000).ToList()) {
                Console.WriteLine(telep.name + ": " + telep.pop);
            }
            Console.WriteLine("14. Írja ki a város rangú települések közül az 5000 főnél alacsonyabb népességű települések nevét és népességét!");
            foreach (Telep telep in input.Where(x => x.rank == "város" && x.pop < 5000).ToList()) {
                Console.WriteLine(telep.name + ": " + telep.pop);
            }


            Console.WriteLine($"15. Mennyi a legnépesebb település lélekszáma?\n{input.Max(x => x.pop)}");
            Console.WriteLine($"16. Mennyi a legalacsonyabb népességű település lélekszáma?\n{input.Max(x => x.pop)}");

            Console.WriteLine($"17. Melyik a legnépesebb település? Írja ki a település nevét és lélekszámát!\n{input.MaxBy(x => x.pop).name}: {input.MaxBy(x => x.pop).pop}");
            Console.WriteLine($"18. Melyik a legalacsonyabb népességű település? Írja ki a település nevét és lélekszámát!\n{input.MinBy(x => x.pop).name}: {input.MinBy(x => x.pop).pop}");

            Console.WriteLine("19. Melyik a Makói kistérség legkisebb területű települése(i)?");
            foreach (Telep telep in MaxBy(input.Where(x => x.type == "Makói").ToList(), (a,b) => a.size > b.size ? 1 : a.size == b.size ? 0 : -1 )) {
                Console.WriteLine(telep.name);
            }
            Console.WriteLine("20. Melyik a Szegedi kistérség legkisebb területű települése(i)?");
            foreach (Telep telep in MaxBy(input.Where(x => x.type == "Szegedi").ToList(), (a,b) => a.size > b.size ? 1 : a.size == b.size ? 0 : -1 )) {
                Console.WriteLine(telep.name);
            }
            Console.WriteLine("21. Melyik a Szentesi kistérség legkisebb területű települése(i)?");
            foreach (Telep telep in MaxBy(input.Where(x => x.type == "Szentesi").ToList(), (a,b) => a.size > b.size ? 1 : a.size == b.size ? 0 : -1 )) {
                Console.WriteLine(telep.name);
            }
            Console.WriteLine("22. Melyik a Makói kistérség legnépesebb települése(i)?");
            foreach (Telep telep in MaxBy(input.Where(x => x.type == "Makói").ToList(), (a,b) => a.pop < b.pop ? 1 : a.pop == b.pop ? 0 : -1 )) {
                Console.WriteLine(telep.name);
            }
            Console.WriteLine("23. Melyik a Szegedi kistérség legnépesebb települése(i)?");
            foreach (Telep telep in MaxBy(input.Where(x => x.type == "Szegedi").ToList(), (a,b) => a.pop < b.pop ? 1 : a.pop == b.pop ? 0 : -1 )) {
                Console.WriteLine(telep.name);
            }
            Console.WriteLine("24. Melyik a Szentesi kistérség legnépesebb települése(i)?");
            foreach (Telep telep in MaxBy(input.Where(x => x.type == "Szentesi").ToList(), (a,b) => a.pop < b.pop ? 1 : a.pop == b.pop ? 0 : -1 )) {
                Console.WriteLine(telep.name);
            }

            Console.WriteLine("25. Írja ki a Makói kistérség településeinek népsűrűségét!");
            foreach (Telep telep in input.Where(x => x.type == "Makói").ToList()) {
                Console.WriteLine(telep.name + ": népsűrűsége " + (double)telep.pop / telep.size + " ember / hektár");
            }
            Console.WriteLine("26. Írja ki a Szegedi kistérség településeinek népsűrűségét!");
            foreach (Telep telep in input.Where(x => x.type == "Szegedi").ToList()) {
                Console.WriteLine(telep.name + ": népsűrűsége " + (double)telep.pop / telep.size + " ember / hektár");
            }
            Console.WriteLine("27. Írja ki a Szentesi kistérség településeinek népsűrűségét!");
            foreach (Telep telep in input.Where(x => x.type == "Szentesi").ToList()) {
                Console.WriteLine(telep.name + ": népsűrűsége " + (double)telep.pop / telep.size + " ember / hektár");
            }
            Console.WriteLine("28. Írja ki a Kisteleki kistérség településeinek népsűrűségét!");
            foreach (Telep telep in input.Where(x => x.type == "Kisteleki").ToList()) {
                Console.WriteLine(telep.name + ": népsűrűsége " + (double)telep.pop / telep.size + " ember / hektár");
            }

            Console.WriteLine($"29. Igaz-e, hogy minden Makói kistérségű település lélekszáma nagyobb, mint 1000?\n{input.Where(x => x.type == "Makói").All(x => x.pop > 1000)}");
            Console.WriteLine($"30. Igaz-e, hogy minden Szentesi kistérségű település lélekszáma kisebb, mint 10000?\n{input.Where(x => x.type == "Szentes").All(x => x.pop < 10000)}");
            Console.WriteLine($"31. Igaz-e, hogy minden Szegedi kistérségű település lélekszáma nagyobb, mint 2000?\n{input.Where(x => x.type == "Szegedi").All(x => x.pop > 2000)}");
            Console.WriteLine($"32. Igaz-e, hogy minden Kisteleki kistérségű település lélekszáma kisebb, mint 10000?\n{input.Where(x => x.type == "Kisteleki").All(x => x.pop < 10000)}");
            
            Console.WriteLine("33. Írja ki a Makói kistérség településeinek egy lakásra jutó népesség számát!");
            foreach (Telep telep in input.Where(x => x.type == "Makói").ToList()) {
                Console.WriteLine(telep.name + ": " + (double)telep.houses / telep.pop + " lakás / ember");
            }
            Console.WriteLine("34. Írja ki a Szentesi kistérség településeinek egy lakásra jutó népesség számát!");
            foreach (Telep telep in input.Where(x => x.type == "Szegedi").ToList()) {
                Console.WriteLine(telep.name + ": " + (double)telep.houses / telep.pop + " lakás / ember");
            }
            Console.WriteLine("35. Írja ki a Szegedi kistérség településeinek egy lakásra jutó népesség számát!");
            foreach (Telep telep in input.Where(x => x.type == "Szentesi").ToList()) {
                Console.WriteLine(telep.name + ": " + (double)telep.houses / telep.pop + " lakás / ember");
            }
            Console.WriteLine("36. Írja ki a Kisteleki kistérség településeinek egy lakásra jutó népesség számát!");
            foreach (Telep telep in input.Where(x => x.type == "Kisteleki").ToList()) {
                Console.WriteLine(telep.name + ": " + (double)telep.houses / telep.pop + " lakás / ember");
            }

            Console.WriteLine($"37. Melyik településen a legrosszabb a lakáshelyzet? (Egy lakásra a legtöbb lakos jut.)\n{input.MaxBy(x => (double)x.houses / x.pop).name}");
            
            Console.WriteLine("38. Készítsen kimutatást kistérségi bontásban, amelyben megadja az egyes kistérségek településeinek a számát!");
            foreach (var x in input.GroupBy(x => x.type)) {
                Console.WriteLine(x.Key + ": " + x.Count());
            }
            Console.WriteLine("39. Készítsen kimutatást kistérségi bontásban, amelyben megadja az egyes kistérségek összlakosságának a számát!");
            foreach (var x in input.GroupBy(x => x.type)) {
                Console.WriteLine(x.Key + ": " + x.Sum(x => x.pop));
            }
            Console.WriteLine("40. Készítsen kimutatást kistérségi bontásban, amelyben megadja az egyes kistérségek összterületének a nagyságát!");
            foreach (var x in input.GroupBy(x => x.type)) {
                Console.WriteLine(x.Key + ": " + x.Sum(x => x.size) + "hektár");
            }
        }
    }
}
