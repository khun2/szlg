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
            public int placement;
            public int year;
            public string location;
            public Foci(string code, string country, string placement, string year, string location)
            {
                this.code = int.Parse(code);
                this.country = country;
                this.placement = int.Parse(placement);
                this.year = int.Parse(year);
                this.location = location;
            }
        }
        static List<Foci> Beolvas(string file)
        {
            List<Foci> list = new List<Foci>();
            string[] sorok = File.ReadAllLines(file, Encoding.UTF8);
            foreach(string sor in sorok)
            {
                string[] sortomb = sor.Split('\t');
                Foci foci = new Foci(sortomb[0], sortomb[1], sortomb[2], sortomb[3], sortomb[4]);
                list.Add(foci);
            }
            return list;
        }
        #region functions
        static Dictionary<string,int> CountryCount(List<Foci> input)
        {
            Dictionary<string,int> dict = new Dictionary<string,int>();
            foreach(Foci foci in input)
            {
                if(dict.ContainsKey(foci.country)) dict[foci.country]++;
                else dict[foci.country] = 1;
                if(dict.ContainsKey(foci.location)) dict[foci.location]++;
                else dict[foci.location] = 1;
            }
            return (Dictionary<string, int>)dict.OrderByDescending(x => x.Value);
        }
        static List<string> Locations(List<Foci> input)
        {
            List<string> list = new List<string>();
            foreach(Foci foci in input)
            {
                if(!list.Contains(foci.location)) {list.Add(foci.location);
                    Console.WriteLine(foci.location);
                }
            }
            return list;
        }
        static List<string> Countries(List<Foci> input)
        {
            List<string> list = new List<string>();
            foreach(Foci foci in input)
            {
                if(!list.Contains(foci.country)) list.Add(foci.country);
            }
            return list;
        }
        #endregion
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<Foci> input = Beolvas("input.txt");

            Console.WriteLine("1. Írja ki Magyarország által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is!");
            Foci[] task = input.Where(x => x.country == "Magyarország").ToArray();
            foreach (Foci foci in task)
            {
                Console.WriteLine($"{foci.year}, {foci.location}: {foci.placement}");
            } 
            Console.WriteLine("2. Írja ki Anglia által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is!");
            task = input.Where(x => x.country == "Anglia").ToArray();
            foreach (Foci foci in task)
            {
                Console.WriteLine($"{foci.year}, {foci.location}: {foci.placement}");
            } 
            Console.WriteLine("3. Írja ki Chile által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is!");
            task = input.Where(x => x.country == "Chile").ToArray();
            foreach (Foci foci in task)
            {
                Console.WriteLine($"{foci.year}, {foci.location}: {foci.placement}");
            } 
            Console.WriteLine("4. Írja ki Peru által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is!");
            task = input.Where(x => x.country == "Peru").ToArray();
            foreach (Foci foci in task)
            {
                Console.WriteLine($"{foci.year}, {foci.location}: {foci.placement}");
            } 
            Console.WriteLine("5. Írja ki Mongólia által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is!");
            task = input.Where(x => x.country == "Mongólia").ToArray();
            foreach (Foci foci in task)
            {
                Console.WriteLine($"{foci.year}, {foci.location}: {foci.placement}");
            } 
            Console.WriteLine("6. A program olvasson be egy csapat nevet és írja ki a csapat álta elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is!");
            string? s = Console.ReadLine();
            task = input.Where(x => x.country == s).ToArray();
            foreach (Foci foci in task)
            {
                Console.WriteLine($"{foci.year}, {foci.location}: {foci.placement}");
            }
            
            Console.WriteLine("7. A program írja ki, hogy az '30-as években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is!");
            task = input.Where(x => x.year >= 1930 && x.year < 1940).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine(foci.year + ": " + foci.country);
            Console.WriteLine("8. A program írja ki, hogy az '40-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is!");
            task = input.Where(x => x.year >= 1940 && x.year < 1950).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine(foci.year + ": " + foci.country);
            Console.WriteLine("9. A program írja ki, hogy az '50-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is!");
            task = input.Where(x => x.year >= 1950 && x.year < 1960).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine(foci.year + ": " + foci.country);
            Console.WriteLine("10. A program írja ki, hogy az '60-as években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is!");
            task = input.Where(x => x.year >= 1960 && x.year < 1970).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine(foci.year + ": " + foci.country);
            Console.WriteLine("11. A program írja ki, hogy az '70-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is!");
            task = input.Where(x => x.year >= 1970 && x.year < 1980).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine(foci.year + ": " + foci.country);
            Console.WriteLine("12. A program írja ki, hogy az '80-as években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is!");
            task = input.Where(x => x.year >= 1980 && x.year < 1990).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine(foci.year + ": " + foci.country);
            
            Console.WriteLine($"13. Írja ki Magyarország hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!\n{input.Where(x => x.country == "Magyarország").Count()}");
            Console.WriteLine($"14. Írja ki Anglia hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!\n{input.Where(x => x.country == "Anglia").Count()}");
            Console.WriteLine($"15. Írja ki Chile hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!\n{input.Where(x => x.country == "Chile").Count()}");
            Console.WriteLine($"16. Írja ki Peru hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!\n{input.Where(x => x.country == "Peru").Count()}");
            Console.WriteLine($"17. Írja ki Mongólia hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!\n{input.Where(x => x.country == "Mongólia").Count()}");
            Console.WriteLine("18. A program olvasson be egy csapat nevet és írja ki, a csapat hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!");
            s = Console.ReadLine();
            Console.WriteLine(input.Where(x => x.country == s).Count());

            Console.WriteLine($"19. Melyik csapat nyert 1930-ban?");
            Foci? nullFoci = input.Where(x => x.year == 1930).SingleOrDefault(x => x.placement == 1);
            if (nullFoci != null) Console.WriteLine(nullFoci.country);
            else Console.WriteLine("Nem volt az évben vb vagy Nem volt nyertese");
            Console.WriteLine($"20. Melyik csapat nyert 1940-ben?");
            nullFoci = input.Where(x => x.year == 1940).SingleOrDefault(x => x.placement == 1);
            if (nullFoci != null) Console.WriteLine(nullFoci.country);
            else Console.WriteLine("Nem volt az évben vb vagy Nem volt nyertese");
            Console.WriteLine($"21. Melyik csapat nyert 1950-ben?");
            nullFoci = input.Where(x => x.year == 1950).SingleOrDefault(x => x.placement == 1);
            if (nullFoci != null) Console.WriteLine(nullFoci.country);
            else Console.WriteLine("Nem volt az évben vb vagy Nem volt nyertese");
            Console.WriteLine($"22. Melyik csapat nyert 1960-ban?");
            nullFoci = input.Where(x => x.year == 1960).SingleOrDefault(x => x.placement == 1);
            if (nullFoci != null) Console.WriteLine(nullFoci.country);
            else Console.WriteLine("Nem volt az évben vb vagy Nem volt nyertese");
            Console.WriteLine($"23. Melyik csapat nyert 1970-ben?");
            nullFoci = input.Where(x => x.year == 1970).SingleOrDefault(x => x.placement == 1);
            if (nullFoci != null) Console.WriteLine(nullFoci.country);
            else Console.WriteLine("Nem volt az évben vb vagy Nem volt nyertese");
            
            Console.WriteLine($"24. Hányszor kapott ki a döntőben Magyarország?\n{input.Where(x => x.country == "Magyarország" && x.placement == 2).Count()}");
            Console.WriteLine($"25. Hányszor kapott ki a döntőben Mongólia?\n{input.Where(x => x.country == "Mongólia" && x.placement == 2).Count()}");
            Console.WriteLine($"26. Hányszor kapott ki a döntőben Svájc?\n{input.Where(x => x.country == "Svájc" && x.placement == 2).Count()}");
            Console.WriteLine($"27. Hányszor kapott ki a döntőben Brazília?\n{input.Where(x => x.country == "Brazília" && x.placement == 2).Count()}");
            Console.WriteLine($"28. Hányszor kapott ki a döntőben Németország?\n{input.Where(x => x.country == "Németország" && x.placement == 2).Count()}");
            Console.WriteLine($"29. Hányszor kapott ki a döntőben Argentína?\n{input.Where(x => x.country == "Argentína" && x.placement == 2).Count()}");
            
            Console.WriteLine("30. A programm olvasson be évszámot és írja ki, hogy melyik csapat nyert az adott évben!");
            int yr = int.Parse(Console.ReadLine());
            nullFoci = input.Where(x => x.year == yr).SingleOrDefault(x => x.placement == 1);
            if (nullFoci != null) Console.WriteLine(nullFoci.country);
            else Console.WriteLine("Nem volt az évben vb vagy Nem volt nyertese");

            Console.WriteLine($"31. Az adatfájl szerint mikor volt a legkorábbi vb?\n{input.OrderBy(x => x.year).Last().year}");
            Console.WriteLine($"32. Magyarország hányszor nyert vb-t?\n{input.Where(x => x.country == "Magyarország" && x.placement == 1).Count()}");
            Console.WriteLine($"33. Anglia hányszor nyert vb-t?\n{input.Where(x => x.country == "Anglia" && x.placement == 1).Count()}");
            Console.WriteLine($"34. Chile hányszor nyert vb-t?\n{input.Where(x => x.country == "Chile" && x.placement == 1).Count()}");
            Console.WriteLine($"35. Peru hányszor nyert vb-t?\n{input.Where(x => x.country == "Peru" && x.placement == 1).Count()}");
            Console.WriteLine($"36. Mongólia hányszor nyert vb-t?\n{input.Where(x => x.country == "Mongólia" && x.placement == 1).Count()}");

            Console.WriteLine($"37. Írd ki Magyarország vb-n elért legjobb helyezését!");
            nullFoci = input.Where(x => x.country == "Magyarország").OrderByDescending(x => x.placement).FirstOrDefault();
            if (nullFoci != null) Console.WriteLine(nullFoci.placement);
            else Console.WriteLine("Az ország nem vett részt egyetlen vb-n sem.");
            Console.WriteLine($"38. Írd ki Anglia vb-n elért legjobb helyezését!");
            nullFoci = input.Where(x => x.country == "Anglia").OrderByDescending(x => x.placement).FirstOrDefault();
            if (nullFoci != null) Console.WriteLine(nullFoci.placement);
            else Console.WriteLine("Az ország nem vett részt egyetlen vb-n sem.");
            Console.WriteLine($"39. Írd ki Chile vb-n elért legjobb helyezését!");
            nullFoci = input.Where(x => x.country == "Chile").OrderByDescending(x => x.placement).FirstOrDefault();
            if (nullFoci != null) Console.WriteLine(nullFoci.placement);
            else Console.WriteLine("Az ország nem vett részt egyetlen vb-n sem.");
            Console.WriteLine($"40. Írd ki Peru vb-n elért legjobb helyezését!");
            nullFoci = input.Where(x => x.country == "Peru").OrderByDescending(x => x.placement).FirstOrDefault();
            if (nullFoci != null) Console.WriteLine(nullFoci.placement);
            else Console.WriteLine("Az ország nem vett részt egyetlen vb-n sem.");
            Console.WriteLine($"41. Írd ki Mongólia vb-n elért legjobb helyezését!");
            nullFoci = input.Where(x => x.country == "Mongólia").OrderByDescending(x => x.placement).FirstOrDefault();
            if (nullFoci != null) Console.WriteLine(nullFoci.placement);
            else Console.WriteLine("Az ország nem vett részt egyetlen vb-n sem.");
            Console.WriteLine("42. A program olvasson be egy csapat nevet és írja ki, a csapat vb-n elért legjobb helyezését");
            s = Console.ReadLine();
            nullFoci = input.Where(x => x.country == s).OrderByDescending(x => x.placement).FirstOrDefault();
            if (nullFoci != null) Console.WriteLine(nullFoci.placement);
            else Console.WriteLine("Az ország nem vett részt egyetlen vb-n sem.");
            Console.WriteLine("43. A program olvasson be egy csapat nevet és írja ki, a csapat hányszor nyert vb-t!");
            s = Console.ReadLine();
            Console.WriteLine(input.Where(x => x.country == s && x.placement == 1).Count());

            Console.WriteLine("44. Melyik csapatok nyertek az Angiában rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            task = input.Where(x => x.location == "Anglia" && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}, {foci.country}: {foci.placement}");
            Console.WriteLine("45. Melyik csapatok nyertek a Magyarországon rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            task = input.Where(x => x.location == "Magyarország" && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}, {foci.country}: {foci.placement}");
            Console.WriteLine("46. Melyik csapatok nyertek a Németországban rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            task = input.Where(x => x.location == "Németország" && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}, {foci.country}: {foci.placement}");
            Console.WriteLine("47. Melyik csapatok nyertek az Brazíliában rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            task = input.Where(x => x.location == "Brazília" && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}, {foci.country}: {foci.placement}");
            Console.WriteLine("48. Melyik csapatok nyertek az Egyesült Államok rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            task = input.Where(x => x.location == "Egyesült Államok" && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}, {foci.country}: {foci.placement}");
            Console.WriteLine("49. A program olvasson be egy ország nevet és írja ki, melyik csapatok nyertek az adott helyszínen! A csapatok neve mellett az évszámot is írja ki!");
            s = Console.ReadLine();
            task = input.Where(x => x.location == s && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}, {foci.country}: {foci.placement}");
            
            Console.WriteLine("50. Melyik csapat nyerte a vb-t, amikor Magyarország dobogós helyzést ért el? A győzetes csapatok neve mellett az évszámot is írja ki!");
            int[] years =  input.Where(x => x.country == "Magyarország" && x.placement >= 3).Select(x => x.year).ToArray();
            task = input.Where(x => years.Contains(x.year) && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}: {foci.country}");  
            Console.WriteLine("51. Melyik csapat nyerte a vb-t, amikor Brazília dobogós helyzést ért el? A győzetes csapatok neve mellett az évszámot is írja ki!");
            years =  input.Where(x => x.country == "Brazília" && x.placement >= 3).Select(x => x.year).ToArray();
            task = input.Where(x => years.Contains(x.year) && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}: {foci.country}");  
            Console.WriteLine("52. Melyik csapat nyerte a vb-t, amikor Argentína dobogós helyzést ért el? A győzetes csapatok neve mellett az évszámot is írja ki!");
            years =  input.Where(x => x.country == "Argentína" && x.placement >= 3).Select(x => x.year).ToArray();
            task = input.Where(x => years.Contains(x.year) && x.placement == 1).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}: {foci.country}");  
            
            Console.WriteLine("53. Kikkel játszott döntőt Magyarország? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            years =  input.Where(x => x.country == "Magyarország" && x.placement >= 2).Select(x => x.year).ToArray();
            task = input.Where(x => years.Contains(x.year) && x.placement >= 2 && x.country != "Magyarország").ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}: {foci.country}");  
            Console.WriteLine("54. Kikkel játszott döntőt Mongólia? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            years =  input.Where(x => x.country == "Mongólia" && x.placement >= 2).Select(x => x.year).ToArray();
            task = input.Where(x => years.Contains(x.year) && x.placement >= 2 && x.country != "Mongólia").ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}: {foci.country}");  
            Console.WriteLine("55. Kikkel játszott döntőt Svájc? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            years =  input.Where(x => x.country == "Svájc" && x.placement >= 2).Select(x => x.year).ToArray();
            task = input.Where(x => years.Contains(x.year) && x.placement >= 2 && x.country != "Svájc").ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}: {foci.country}");  
            Console.WriteLine("56. Kikkel játszott döntőt Barzília? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            years =  input.Where(x => x.country == "Brazília" && x.placement >= 2).Select(x => x.year).ToArray();
            task = input.Where(x => years.Contains(x.year) && x.placement >= 2 && x.country != "Brazília").ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}: {foci.country}");  
            Console.WriteLine("57. A program olvasson be egy ország nevet és írja ki, kikkel játszott döntőt az illető csapat? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            s = Console.ReadLine();
            years =  input.Where(x => x.country == s && x.placement >= 2).Select(x => x.year).ToArray();
            task = input.Where(x => years.Contains(x.year) && x.placement >= 2 && x.country != s).ToArray();
            foreach (Foci foci in task)
                Console.WriteLine($"{foci.year}: {foci.country}"); 

            Console.WriteLine("58. Mely csapat nyert többször is vb-t?");
            var groups = input.Where(x => x.placement == 1).GroupBy(x => x.country).Where(x => x.Count() > 1);
            foreach (var group in groups)
            {
                //extra infónak kiírja hogy hányszor nyertek
                Console.WriteLine(group.First().country + ": " + group.Count());
            }
            Console.WriteLine("59. Mely országban rendeztek többször is vb-t?");
            groups = input.GroupBy(x => x.location).Where(x => x.Count() > 1);
            foreach (var group in groups)
            {
                Console.WriteLine(group.First().location + ": " + group.Count());
            }

            Console.WriteLine("60. Mely csapat(ok) nyert(ek) a legtöbbször vb-t? A csapat neve mellett a vb gyözelmmek számát is írja ki!");
            var t60 = input.Where(x => x.placement == 1).GroupBy(x => x.country).OrderByDescending(x => x.Count()).ToArray();
            Console.WriteLine(t60[0].Key + ": " + t60[0].Count());
            int i = 1;
            while (i < t60.Length && t60[i].Count() == t60[0].Count())
            {
                Console.WriteLine(t60[i].Key + ": " + t60[i].Count());
                i++;
            }
            Console.WriteLine("61. Mely ország(ok) rendezett/rendeztek legtöbbször vb-t? A csapat neve mellett a vb-k számát is írja ki!");
            // TODO: fix this
            /*
            t60 = input.GroupBy(x => x.location).OrderByDescending(x => x.Count()).ToArray();
            Console.WriteLine(t60[0].Key + ": " + t60[0].Count());
            i = 1;
            while (i < t60.Length && t60[i].Count() == t60[0].Count())
            {
                Console.WriteLine(t60[i].Key + ": " + t60[i].Count());
                i++;
            }
            */
            Console.WriteLine("62. Mely csapat(ok) kapott ki a legtöbbször a döntőben? A csapat neve mellett a vereségek számát is írja ki!");
            t60 = input.Where(x => x.placement == 2).GroupBy(x => x.country).OrderByDescending(x => x.Count()).ToArray();
            Console.WriteLine(t60[0].Key + ": " + t60[0].Count());
            i = 1;
            while (i < t60.Length && t60[i].Count() == t60[0].Count())
            {
                Console.WriteLine(t60[i].Key + ": " + t60[i].Count());
                i++;
            }

            Console.WriteLine("63. Mely ország hányszor szerepel az input fájlban?");
            var t63 = CountryCount(input);
            foreach (var group in t63) 
                Console.WriteLine(group.Key +  ": " + group.Value);

            Console.WriteLine("64. Add meg a különböző helyszíneket, ahol világbajnokság zajlott!");
            List<string> t64 = Locations(input);
            foreach (string str in t64)
                Console.WriteLine(str);
            Console.WriteLine("65. Add meg a különböző országokat, akik az input fájl szerint mérkőzéseket játszottak!");
            t64 = Countries(input);
            foreach (string str in t64)
                Console.WriteLine(str);
                
            Console.WriteLine($"66. Melyik évből származik a legtöbb adat az adatok között, a legelső évszámtól napjainkig?\n{input.GroupBy(x => x.year).OrderByDescending(x => x.Count()).First().First().year}");
            Console.WriteLine("67. Melyik évtizedből származik a legtöbb adat az adatok között, a 30-as évektől napjainkig? (30-as évek, 40-es évek, stb.)");

            Console.WriteLine("68. Add meg, hogy a lehetséges helyezések közül melyikhez hány adat kapcsolódik az input fájlban? (1. helyezésből ... db, 2. helyezésből ... db, stb.) A kiírás legyen helyezés szerint növekvő sorrendben!");
            
            Console.WriteLine("69. A különböző országok pontversenyeznek is: Az első helyezés 6 pontot ér, a második 5-öt, ... , az hatodik 1 pontot, minden további helyezés pedig 0 pontot ér. Add meg, hogy mely országnak hány pontja van így!");
            Console.WriteLine("70. Mely országnak van a legtöbb pontja a fent leírt pontversenyben?");
            
        }
    }
}