using System;
using System.Collections.Generic;
using System.Linq;
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

        #endregion
        static void Main(string[] args)
        {
            Country[] input = File.ReadAllLines("input.txt").Select(x => new Country(x.Split('\t'))).ToArray();
            List<Country> list;

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

            Console.WriteLine("12. Hány ország található az afrikai földrészen?");
            Console.WriteLine("13. Hány ország található a dél-amerikai földrészen?");
            Console.WriteLine("14. Hány ország található a közép-amerikai földrészen?");
            Console.WriteLine("15. Hány ország található az észak-amerikai földrészen?");

            Console.WriteLine($"16. Hány 5000 négyzetkilométernél nagyobb ország található az afrikai földrészen?\n{input.Where(x => x.size > 5000 && x.cont == "Afrika").Count()}");
            Console.WriteLine($"17. Hány 5000 négyzetkilométernél kisebb ország található az afrikai földrészen?\n{input.Where(x => x.size < 5000 && x.cont == "Afrika").Count()}");
            Console.WriteLine($"18. Hány 15000 négyzetkilométernél nagyobb ország található az dél-amerikai földrészen?\n{input.Where(x => x.size > 7000 && x.cont == "Dél-Amerika").Count()}");
            Console.WriteLine($"19. Hány 7000 négyzetkilométernél kisebb ország található az dél-amerikai földrészen?\n{input.Where(x => x.size < 7000 && x.cont == "Dél-Amerika").Count()}");
            Console.WriteLine($"20. Hány 7000 négyzetkilométernél nagyobb ország található az közép-amerikai földrészen?\n{input.Where(x => x.size > 7000 && x.cont == "Közép-Amerika").Count()}");
            Console.WriteLine($"21. Hány 8000 négyzetkilométernél kisebb ország található az közép-amerikai földrészen?\n{input.Where(x => x.size < 7000 && x.cont == "Közép-Amerika").Count()}");
            Console.WriteLine($"22. Hány 8000 négyzetkilométernél kisebb ország található az amerikai földrészen?\n{input.Where(x => x.size < 8000 && x.cont.Contains("Amerika")).Count()}");
            Console.WriteLine($"23. Hány 8000 négyzetkilométernél nagyobb ország található az amerikai földrészen?\n{input.Where(x => x.size > 8000 && x.cont.Contains("Amerika")).Count()}");

            Console.WriteLine("24. Hány 20 milliónál kisebb népességű ország található az amerikai földrészen?");
            Console.WriteLine("25. Hány 20 milliónál nagyobb népességű ország található az amerikai földrészen?");
            Console.WriteLine("26. Válogassa ki a 20 milliónál népesebb afrikai országokat!");
            Console.WriteLine("27. Válogassa ki a 20 milliónál népesebb dél-amerikai országokat!");
            Console.WriteLine("28. Válogassa ki a 20 milliónál népesebb közép-amerikai országokat!");
            Console.WriteLine("29. Válogassa ki a 20 milliónál népesebb észak-amerikai országokat!");
            Console.WriteLine("30. Válogassa ki a 20 milliónál népesebb amerikai országokat!");
            Console.WriteLine("31. Válogassa ki a 20 milliónál alacsonyabb népességű amerikai országokat!");
            Console.WriteLine("32. Válogassa ki a 100000 négyzetkilométernél nagyobb amerikai országokat!");
            Console.WriteLine("33. Válogassa ki a 100000 négyzetkilométernél kisebb amerikai országokat!");
            Console.WriteLine("34. Mekkora a területe a fájlban található legnagyobb országnak?");
            Console.WriteLine("35. Mekkora a területe a fájlban található legkisebb országnak?");
            Console.WriteLine("36. Mekkora a lakossága a fájlban található legnépesebb országnak?");
            Console.WriteLine("37. Mekkora a lakossága a fájlban található legkisebb népességű országnak?");
            Console.WriteLine("38. Mekkora a területe a legnagyobb afrikai országnak?");
            Console.WriteLine("39. Mekkora a területe a legnagyobb dél-amerikai országnak?");
            Console.WriteLine("40. Mekkora a területe a legnagyobb közép-amerikai országnak?");
            Console.WriteLine("41. Mekkora a területe a legnagyobb észak-amerikai országnak?");
            Console.WriteLine("42. Mekkora a területe a legnagyobb amerikai országnak?");
            Console.WriteLine("43. Mennyi a lakossága a legnépesebb afrikai országnak?");
            Console.WriteLine("44. Mennyi a lakossága a legnépesebb dél-amerikai országnak?");
            Console.WriteLine("45. Mennyi a lakossága a legnépesebb közép-amerikai országnak?");
            Console.WriteLine("46. Mennyi a lakossága a legnépesebb észak-amerikai országnak?");
            Console.WriteLine("47. Mennyi a lakossága a legnépesebb amerikai országnak?");
            Console.WriteLine("48. Mekkora a népsűrűsége a legsűrűbben lakott afrikai országnak (fő/négyzetkilométer)?");
            Console.WriteLine("49. Mekkora a népsűrűsége a legsűrűbben lakott dél-amerikai országnak (fő/négyzetkilométer)?");
            Console.WriteLine("50. Mekkora a népsűrűsége a legsűrűbben lakott közép-amerikai országnak (fő/négyzetkilométer)?");
            Console.WriteLine("51. Mekkora a népsűrűsége a legsűrűbben lakott észak-amerikai országnak (fő/négyzetkilométer)?");
            Console.WriteLine("52. Mekkora a népsűrűsége a legsűrűbben lakott amerikai országnak (fő/négyzetkilométer)?");
            Console.WriteLine("53. Milyen államformák léteznek az input fájlban? Mindegyik csak legfeljebb egyszer szerepeljen!");
            Console.WriteLine("54. Mely államformát hány ország követi?");
            Console.WriteLine("55. Mely földrészen hány ország van?");
            Console.WriteLine("56. Mely földrészen melyik államformát hány ország követi? (pl. Afrika - köztársaság: ... db \n Dél-Amerika - szövetségi köztársaság: ... db \n ... )");
            Console.WriteLine("57. Mely államformában hány lakos él összesen?");
            Console.WriteLine("58. Mennyi a különböző földrészeken található országok területösszegei? (pl.: Afrika: ...\n Dél-Amerika: ...\n ...)");
            Console.WriteLine("59. Mely kezdőbetűvel hány ország kezdődik?");
            Console.WriteLine("60. Add meg különböző államformákhoz tartozó legsűrűbben lakott országokat!");
        }
    }
}