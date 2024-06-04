using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace o
{
    internal class Program
    {
        class Country
        {
            public string name;
            public string gov;
            public int size;
            public int pop;
            public string cont;

            public Country(string[] args)
            {
                this.name = args[0];
                this.gov = args[1];
                this.size = int.Parse(args[2]);
                this.pop = int.Parse(args[3]);
                this.cont = args[4];
            }
        }
        #region functions
        static void ArrayWriter(Country[] arr) {
            foreach (Country c in arr) {
                Console.WriteLine(c.name);
            }
        }

        static List<string> Govs(Country[] arr) {
            List<string> strings= new List<string>();
            foreach (Country c in arr) {
                if (!strings.Contains(c.gov)) strings.Add(c.gov);
            }
            return strings;
        }

        static List<Country> MaxBy(Country[] countries, Func<Country, Country, int> cmp) {
            List<Country> list = new List<Country>();
            foreach (Country x in countries) {
                if(list.Count == 0) list.Add(x);
                else {
                    int c = cmp(list[0], x);
                    if(c == 1) list = [x];
                    else if(c == 0) list.Add(x);
                }
            }
            return list;
        }
        #endregion
        static void Main(string[] args)
        {
            Country[] input = File.ReadAllLines("input.txt").Select(x => new Country(x.Split('\t'))).ToArray();

            Console.WriteLine($"1. Hány ország található az input fájlban?\n{input.Count()}");

            Console.WriteLine($"2. Határozza meg az afrikai földrész népességének a nagyságát ezer főben!\n{input.Where(x => x.cont == "Afrika").Sum(x => x.pop)}");
            Console.WriteLine($"3. Határozza meg a dél-amerikai földrész népességének a nagyságát ezer főben!\n{input.Where(x => x.cont == "Dél-Amerika").Sum(x => x.pop)}");
            Console.WriteLine($"4. Határozza meg a közép-amerikai földrész népességének a nagyságát ezer főben!\n{input.Where(x => x.cont == "Közép-Amerika").Sum(x => x.pop)}");
            Console.WriteLine($"5. Határozza meg a közép-amerikai földrész népességének a nagyságát ezer főben!\n{input.Where(x => x.cont == "Közép-Amerika").Sum(x => x.pop)}");
            Console.WriteLine($"6. Határozza meg az észak-amerikai földrész népességének a nagyságát ezer főben!\n{input.Where(x => x.cont == "Észak-Amerika").Sum(x => x.pop)}");
            Console.WriteLine($"7. Határozza meg az afrikai földrész területének a nagyságát négyzetkilométerben!\n{input.Where(x => x.cont == "Afrika").Sum(x => x.size)}");
            Console.WriteLine($"8. Határozza meg a dél-amerikai földrész területének a nagyságát négyzetkilométerben!\n{input.Where(x => x.cont == "Dél-Amerika").Sum(x => x.size)}");
            Console.WriteLine($"9. Határozza meg a közép-amerikai földrész területének a nagyságát négyzetkilométerben!\n{input.Where(x => x.cont == "Közép-Amerika").Sum(x => x.size)}");
            Console.WriteLine($"10. Határozza meg a közép-amerikai földrész területének a nagyságát négyzetkilométerben!\n{input.Where(x => x.cont == "Közép-Amerika").Sum(x => x.size)}");
            Console.WriteLine($"11. Határozza meg az észak-amerikai földrész területének a nagyságát négyzetkilométerben!\n{input.Where(x => x.cont == "Észak-Amerika").Sum(x => x.size)}");

            Console.WriteLine($"12. Hány ország található az afrikai földrészen\n{input.Count(x => x.cont == "Afrika")}?");
            Console.WriteLine($"13. Hány ország található a dél-amerikai földrészen\n{input.Count(x => x.cont == "Dél-Amerika")}?");
            Console.WriteLine($"14. Hány ország található a közép-amerikai földrészen\n{input.Count(x => x.cont == "Közép-Amerika")}?");
            Console.WriteLine($"15. Hány ország található az észak-amerikai földrészen\n{input.Count(x => x.cont == "Észak-Amerika")}?");

            Console.WriteLine($"16. Hány 5000 négyzetkilométernél nagyobb ország található az afrikai földrészen?\n{input.Count(x => x.size > 5000 && x.cont == "Afrika")}");
            Console.WriteLine($"17. Hány 5000 négyzetkilométernél kisebb ország található az afrikai földrészen?\n{input.Count(x => x.size < 5000 && x.cont == "Afrika")}");
            Console.WriteLine($"18. Hány 15000 négyzetkilométernél nagyobb ország található az dél-amerikai földrészen?\n{input.Count(x => x.size > 7000 && x.cont == "Dél-Amerika")}");
            Console.WriteLine($"19. Hány 7000 négyzetkilométernél kisebb ország található az dél-amerikai földrészen?\n{input.Count(x => x.size < 7000 && x.cont == "Dél-Amerika")}");
            Console.WriteLine($"20. Hány 7000 négyzetkilométernél nagyobb ország található az közép-amerikai földrészen?\n{input.Count(x => x.size > 7000 && x.cont == "Közép-Amerika")}");
            Console.WriteLine($"21. Hány 8000 négyzetkilométernél kisebb ország található az közép-amerikai földrészen?\n{input.Count(x => x.size < 7000 && x.cont == "Közép-Amerika")}");
            Console.WriteLine($"22. Hány 8000 négyzetkilométernél kisebb ország található az amerikai földrészen?\n{input.Count(x => x.size < 8000 && x.cont != "Afrika")}");
            Console.WriteLine($"23. Hány 8000 négyzetkilométernél nagyobb ország található az amerikai földrészen?\n{input.Count(x => x.size > 8000 && x.cont != "Afrika")}");

            Console.WriteLine($"24. Hány 20 milliónál kisebb népességű ország található az amerikai földrészen\n{input.Where(x => x.cont != "Afrika" && x.pop < 20000)}?");
            Console.WriteLine($"25. Hány 20 milliónál nagyobb népességű ország található az amerikai földrészen\n{input.Where(x => x.cont != "Afrika" && x.pop > 20000)}?");
            
            Console.WriteLine("26. Válogassa ki a 20 milliónál népesebb afrikai országokat!");
            ArrayWriter(input.Where(x => x.cont == "Afrika" && x.pop > 20000).ToArray());
            Console.WriteLine("27. Válogassa ki a 20 milliónál népesebb dél-amerikai országokat!");
            ArrayWriter(input.Where(x => x.cont == "Dél-Amerika" && x.pop > 20000).ToArray());
            Console.WriteLine("28. Válogassa ki a 20 milliónál népesebb közép-amerikai országokat!");
            ArrayWriter(input.Where(x => x.cont == "Közép-Amerika" && x.pop > 20000).ToArray());
            Console.WriteLine("29. Válogassa ki a 20 milliónál népesebb észak-amerikai országokat!");
            ArrayWriter(input.Where(x => x.cont == "Észak-Amerika" && x.pop > 20000).ToArray());
            Console.WriteLine("30. Válogassa ki a 20 milliónál népesebb amerikai országokat!");
            ArrayWriter(input.Where(x => x.cont != "Afrika" && x.pop > 20000).ToArray());
            Console.WriteLine("31. Válogassa ki a 20 milliónál alacsonyabb népességű amerikai országokat!");
            ArrayWriter(input.Where(x => x.cont != "Afrika" && x.pop < 20000).ToArray());
            Console.WriteLine("32. Válogassa ki a 100000 négyzetkilométernél nagyobb amerikai országokat!");
            ArrayWriter(input.Where(x => x.cont != "Afrika" && x.size > 100000).ToArray());
            Console.WriteLine("33. Válogassa ki a 100000 négyzetkilométernél kisebb amerikai országokat!");
            ArrayWriter(input.Where(x => x.cont != "Afrika" && x.size < 100000).ToArray());

            Console.WriteLine($"34. Mekkora a területe a fájlban található legnagyobb országnak?\n{input.Max(x => x.size)}");
            Console.WriteLine($"35. Mekkora a területe a fájlban található legkisebb országnak?\n{input.Min(x => x.size)}");
            Console.WriteLine($"36. Mekkora a lakossága a fájlban található legnépesebb országnak?\n{input.Max(x => x.pop)}");
            Console.WriteLine($"37. Mekkora a lakossága a fájlban található legkisebb népességű országnak?\n{input.Min(x => x.pop)}");

            Console.WriteLine($"38. Mekkora a területe a legnagyobb afrikai országnak?\n{input.Where(x => x.cont == "Afrika").Max(x => x.size)}");
            Console.WriteLine($"39. Mekkora a területe a legnagyobb dél-amerikai országnak?\n{input.Where(x => x.cont == "Dél-Amerika").Max(x => x.size)}");
            Console.WriteLine($"40. Mekkora a területe a legnagyobb közép-amerikai országnak?\n{input.Where(x => x.cont == "Közép-Amerika").Max(x => x.size)}");
            Console.WriteLine($"41. Mekkora a területe a legnagyobb észak-amerikai országnak?\n{input.Where(x => x.cont == "Észak-Amerika").Max(x => x.size)}");
            Console.WriteLine($"42. Mekkora a területe a legnagyobb amerikai országnak?\n{input.Where(x => x.cont != "Afrika").Max(x => x.size)}");
            Console.WriteLine($"43. Mennyi a lakossága a legnépesebb afrikai országnak?\n{input.Where(x => x.cont == "Afrika").Max(x => x.pop)}");
            Console.WriteLine($"44. Mennyi a lakossága a legnépesebb dél-amerikai országnak?\n{input.Where(x => x.cont == "Dél-Amerika").Max(x => x.pop)}");
            Console.WriteLine($"45. Mennyi a lakossága a legnépesebb közép-amerikai országnak?\n{input.Where(x => x.cont == "Közép-Amerika").Max(x => x.pop)}");
            Console.WriteLine($"46. Mennyi a lakossága a legnépesebb észak-amerikai országnak?\n{input.Where(x => x.cont == "Észak-Amerika").Max(x => x.pop)}");
            Console.WriteLine($"47. Mennyi a lakossága a legnépesebb amerikai országnak?\n{input.Where(x => x.cont != "Afrika").Max(x => x.pop)}");

            Console.WriteLine($"48. Mekkora a népsűrűsége a legsűrűbben lakott afrikai országnak (fő/négyzetkilométer)?\n{input.Where(x => x.cont == "Afrika").Max(x => x.pop * 1000 / x.size)}");
            Console.WriteLine($"49. Mekkora a népsűrűsége a legsűrűbben lakott dél-amerikai országnak (fő/négyzetkilométer)?\n{input.Where(x => x.cont == "Dél-Amerika").Max(x => x.pop * 1000 / x.size)}");
            Console.WriteLine($"50. Mekkora a népsűrűsége a legsűrűbben lakott közép-amerikai országnak (fő/négyzetkilométer)?\n{input.Where(x => x.cont == "Közép-Amerika").Max(x => x.pop * 1000 / x.size)}");
            Console.WriteLine($"51. Mekkora a népsűrűsége a legsűrűbben lakott észak-amerikai országnak (fő/négyzetkilométer)?\n{input.Where(x => x.cont == "Észak-Amerika").Max(x => x.pop * 1000 / x.size)}");
            Console.WriteLine($"52. Mekkora a népsűrűsége a legsűrűbben lakott amerikai országnak (fő/négyzetkilométer)?\n{input.Where(x => x.cont != "Afrika").Max(x => x.pop * 1000 / x.size)}");

            Console.WriteLine("53. Milyen államformák léteznek az input fájlban? Mindegyik csak legfeljebb egyszer szerepeljen!");
            List<string> govs = Govs(input);
            foreach (string s in govs) Console.WriteLine(s);
            Console.WriteLine("54. Mely államformát hány ország követi?");
            var groups = input.GroupBy(x => x.gov);
            foreach (var group in groups) Console.WriteLine(group.Key + ": " + group.Count());
            Console.WriteLine("55. Mely földrészen hány ország van?");
            groups = input.GroupBy(x => x.cont);
            foreach (var group in groups) Console.WriteLine(group.Key + ": " + group.Count());

            Console.WriteLine("56. Mely földrészen melyik államformát hány ország követi? (pl. Afrika - köztársaság: ... db \n Dél-Amerika - szövetségi köztársaság: ... db \n ... )");
            foreach (var group in groups) {
                var asd = group.GroupBy(x => x.gov);
                foreach (var asd2 in asd) Console.WriteLine(group.Key + " - " + asd2.Key + ": " + asd2.Count());
            }
            Console.WriteLine("57. Mely államformában hány lakos él összesen?");
            groups = input.GroupBy(x => x.gov);
            foreach (var group in groups) Console.WriteLine (group.Key + ": " + group.Sum(x => x.pop) * 1000);
            Console.WriteLine("58. Mennyi a különböző földrészeken található országok területösszegei? (pl.: Afrika: ...\n Dél-Amerika: ...\n ...)");
            groups = input.GroupBy(x => x.cont);
            foreach (var group in groups) Console.WriteLine (group.Key + ": " + group.Sum(x => x.size));
            Console.WriteLine("59. Mely kezdőbetűvel hány ország kezdődik?");
            var charGroups = input.GroupBy(x => x.name[0]);
            foreach (var group in charGroups) Console.WriteLine(group.Key + ": " + group.Count());
            Console.WriteLine("60. Add meg különböző államformákhoz tartozó legsűrűbben lakott országokat!");
            groups = input.GroupBy(x => x.gov);
            foreach (var group in groups) {
                List<Country> l = MaxBy(group.ToArray(), (a,b) => a.pop * 1000 / a.size < b.pop * 1000 / b.size ? 1 : a.pop * 1000 / a.size == b.pop * 1000 / b.size ? 0 : -1);
                foreach (Country country in l) Console.WriteLine(group.Key + ": " + country.name);
            }
        }
    }
}