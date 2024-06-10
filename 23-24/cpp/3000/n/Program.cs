using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n
{
    internal class Program
    {
        class Offer
        {
            public string location;
            public int length;
            public bool family;
            public string month;
            public int count;
            public int going;
            public int price;

            public Offer(string location, int length, bool family, string month, int count,int going, int price)
            {
                this.location = location;
                this.length = length;
                this.family = family;
                this.month = month;
                this.count = count;
                this.going = going;
                this.price = price;
            }
            public override string ToString() {
                return $"\t{location}  tájegységben,  {month}  hónapban,  {length}  éjszakás, {(family ? "családos" : "egyéni")} út, ahol {count} helyből {going} foglat emiatt {count - going} szabad hely van  {price} Ft/fő árral";
            }
        }

        #region  functions
        static List<Offer> Beolvasás(string file)
        {
            string[] rows = File.ReadAllLines(file);
            List<Offer> list = new List<Offer>();
            foreach (string row in rows)
            {
                string[] line = row.Split('\t');
                list.Add(new Offer(line[0], int.Parse(line[1]), bool.Parse(line[2]), line[3], int.Parse(line[4]), int.Parse(line[5]), int.Parse(line[6])));
            }
            return list;
        }
        static int Locations(List<Offer> input) {
            HashSet<string> list = new HashSet<string>();
            foreach (Offer offer in input) {
                list.Add(offer.location);
            }
            return list.Count;
        }
        static List<Offer> MaxBy(List<Offer> offers, Func<Offer, Offer, int> cmp) {
            List<Offer> list = new List<Offer>();
            foreach(Offer offer in offers) {
                if(list.Count == 0) list.Add(offer);
                else {
                    int c = cmp(list[0], offer);
                    if(c == 1) list = [offer];
                    else if(c == 0) list.Add(offer);

                }
            }

            return list;
        }
        #endregion
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Offer> input = Beolvasás("input.txt");


            string[] winter = ["December", "Január", "Február"], spring = ["Márcus", "Április", "Május"], summer = ["Június", "Július", "Augusztus"], fall = ["Szeptember", "Október", "November"]; 

            Console.WriteLine($"1. Hány ajánlat található az input fájlban?\n{input.Count}");
            Console.WriteLine($"2. Hány mátrai tájegységre vonatozó ajánlat található az input fájlban?\n{input.Count(x => x.location == "Mátra")}");
            Console.WriteLine($"3. Hány mecseki tájegységre vonatozó ajánlat található az input fájlban?\n{input.Count(x => x.location == "Mecsek")}");
            Console.WriteLine($"4. Hány bakonyi tájegységre vonatozó ajánlat található az input fájlban?\n{input.Count(x => x.location == "Bakony")}");
            Console.WriteLine($"5. Hány hortobágyi tájegységre vonatozó ajánlat található az input fájlban?\n{input.Count(x => x.location == "Hortobágy")}");
            Console.WriteLine($"6. Hány őrségi tájegységre vonatozó ajánlat található az input fájlban?\n{input.Count(x => x.location == "Őrség")}");

            Console.WriteLine($"7. Hány mátrai tájegységre vonatozó, családos ajánlat található az input fájlban?\n{input.Count(x => x.location == "Mátra" && x.family == true)}");
            Console.WriteLine($"8. Hány mecseki tájegységre vonatozó, egyéni ajánlat található az input fájlban?\n{input.Count(x => x.location == "Mecsek" && x.family == false)}");
            Console.WriteLine($"9. Hány bakonyi tájegységre vonatozó, májusi ajánlat található az input fájlban?\n{input.Count(x => x.location == "Bakony" && x.month == "Május")}");
            Console.WriteLine($"10. Hány hortobágyi tájegységre vonatozó, júliusi ajánlat található az input fájlban?\n{input.Count(x => x.location == "Hortobágy" && x.month == "Július")}");
            Console.WriteLine($"11. Hány őrségi tájegységre vonatozó, októberi ajánlat található az input fájlban?\n{input.Count(x => x.location == "Őrség" && x.month == "Október")}");

            Console.WriteLine($"12. Hány mátrai tájegységre vonatozó, családos, öt napnál hosszabb ajánlat található az input fájlban?\n{input.Count(x => x.location == "Mátra" && x.family == true && x.length > 5)}");
            Console.WriteLine($"13. Hány mecseki tájegységre vonatozó, egyéni, 3 napnál rövidebb ajánlat található az input fájlban?\n{input.Count(x => x.location == "Mecsek" && x.family == false&& x.length < 3)}");
            Console.WriteLine($"14. Hány bakonyi tájegységre vonatozó, májusi, egy hétnél hosszabb ajánlat található az input fájlban?\n{input.Count(x => x.location == "Bakony" && x.month == "Május" && x.length > 7)}");
            Console.WriteLine($"15. Hány hortobágyi tájegységre vonatozó, júliusi, egy hetes ajánlat található az input fájlban?\n{input.Count(x => x.location == "Hortobágy" && x.month == "Július" && x.length == 7)}");
            Console.WriteLine($"16. Hány őrségi tájegységre vonatozó, októberi, öt napos ajánlat található az input fájlban?\n{input.Count(x => x.location == "Őrség" && x.month == "Október" && x.length == 5)}");

            Console.WriteLine($"17. Hány mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Count(x => x.location == "Mátra" && x.family == true && x.count != x.going)}");
            Console.WriteLine($"18. Hány mecseki tájegységre vonatozó, egyéni, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Count(x => x.location == "Mecsek" && x.family == false && x.count != x.going)}");
            Console.WriteLine($"19. Hány bakonyi tájegységre vonatozó, májusi, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Count(x => x.location == "Bakony" && x.month == "Május" && x.count != x.going)}");
            Console.WriteLine($"20. Hány hortobágyi tájegységre vonatozó, júliusi, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Count(x => x.location == "Hortobágy" && x.month == "Július" && x.count != x.going)}");
            Console.WriteLine($"21. Hány őrségi tájegységre vonatozó, októberi, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Count(x => x.location == "Őrség" && x.month == "Október" && x.count != x.going)}");
            
            Console.WriteLine("22. Válogassuk ki a mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Mátra" && x.going != x.count && x.family == true).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("23. Válogassuk ki a bükki tájegységre vonatozó, májusi, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Bükk" && x.going != x.count && x.month == "Május").Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("24. Válogassuk ki a zempléni tájegységre vonatozó, egyéni, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Zemplén" && x.going != x.count && x.family == false).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("25. Válogassuk ki a mecseki tájegységre vonatozó, júniusi, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Mecsek" && x.going != x.count && x.month == "Június").Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("26. Válogassuk ki a balatoni tájegységre vonatozó, augusztusi, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Balaton" && x.going != x.count && x.month == "Augusztus").Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("27. Válogassuk ki a mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező, 20000 Ft alatti ajánlatokat!");
            input.Where(x => x.location == "Mátra" && x.going != x.count && x.family == true && x.price < 20000).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("28. Válogassuk ki a bükki tájegységre vonatozó, májusi, még szabad hellyel rendelkező, 50000 Ft alatti ajánlatokat!");
            input.Where(x => x.location == "Bükk" && x.going != x.count && x.month == "Május" && x.price < 50000).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("29. Válogassuk ki a zempléni tájegységre vonatozó, egyéni, még szabad hellyel rendelkező, 60000 Ft alatti ajánlatokat!");
            input.Where(x => x.location == "Zemplén" && x.going != x.count && x.family == false && x.price < 60000).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("30. Válogassuk ki a mecseki tájegységre vonatozó, júniusi, még szabad hellyel rendelkező, 30000 Ft alatti ajánlatokat!");
            input.Where(x => x.location == "Mecsek" && x.going != x.count && x.month == "Június" && x.price < 0000).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("31. Válogassuk ki a balatoni tájegységre vonatozó, augusztusi, még szabad hellyel rendelkező, 40000 Ft alatti ajánlatokat!");
            input.Where(x => x.location == "Balaton" && x.going != x.count && x.month == "Augusztus" && x.price < 40000).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("32. Válogassuk ki a mátrai tájegységre vonatozó, nyári, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Mátra" && x.going != x.count && summer.Contains(x.month)).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("33. Válogassuk ki a bükki tájegységre vonatozó, nyári, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Bükk" && x.going != x.count && summer.Contains(x.month)).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("34. Válogassuk ki a zempléni tájegységre vonatozó, téli, még szabad hellyel rendelkező!");
            input.Where(x => x.location == "Zemplén" && x.going != x.count && winter.Contains(x.month)).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("35. Válogassuk ki a mecseki tájegységre vonatozó, tavaszi, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Mecsek" && x.going != x.count && spring.Contains(x.month)).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("36. Válogassuk ki a balatoni tájegységre vonatozó, őszi, még szabad hellyel rendelkező ajánlatokat!");
            input.Where(x => x.location == "Balaton" && x.going != x.count && fall.Contains(x.month)).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);

            Console.WriteLine($"37. Van-e az irodának téli, balatoni ajánlata?\n{input.Any(x => winter.Contains(x.month) && x.location == "Balaton")}");
            Console.WriteLine($"38. Van-e az irodának őszi, balatoni ajánlata?\n{input.Any(x => fall.Contains(x.month) && x.location == "Balaton")}");
            Console.WriteLine($"39. Van-e az irodának tavaszi, hortobágyi ajánlata?\n{input.Any(x => spring.Contains(x.month) && x.location == "Hortobágy")}");
            Console.WriteLine($"40. Van-e az irodának téli, bakonyi ajánlata?\n{input.Any(x => winter.Contains(x.month) && x.location == "Bakony")}");
            Console.WriteLine($"41. Van-e az irodának őszi, bükki ajánlata?\n{input.Any(x => fall.Contains(x.month) && x.location == "Bükk")}");
            Console.WriteLine($"42. Van-e az irodának nyári, pilisi ajánlata?\n{input.Any(x => summer.Contains(x.month) && x.location == "Pilis")}");
            Console.WriteLine($"43. Van-e az irodának téli, őrségi ajánlata?\n{input.Any(x => winter.Contains(x.month) && x.location == "Őrség")}");
            Console.WriteLine($"44. Igaz-e, hogy az minden ajánlat legalább 3 napos?\n{input.All(x => x.length > 3)}");
            Console.WriteLine($"45. Igaz-e, hogy az minden ajánlat legalább 5 napos?\n{input.All(x => x.length > 5)}");
            Console.WriteLine($"46. Igaz-e, hogy az minden ajánlat legalább 2 napos?\n{input.All(x => x.length > 2)}");
            Console.WriteLine($"47. Igaz-e, hogy az minden ajánlat legalább 10000 Ft-ba kerül?\n{input.All(x => x.price > 10000)}");
            Console.WriteLine($"48. Igaz-e, hogy az minden ajánlat legalább 5000 Ft-ba kerül?\n{input.All(x => x.price > 5000)}");
            Console.WriteLine($"49. Igaz-e, hogy az minden ajánlat legalább 1000 Ft-ba kerül?\n{input.All(x => x.price > 1000)}");
            Console.WriteLine($"50. Igaz-e, hogy az minden ajánlat tavaszi, és maximális létszáma legalább 20 fő?\n{input.All(x => spring.Contains(x.month) && x.count > 20)}");
            Console.WriteLine($"51. Igaz-e, hogy az minden ajánlat nyári, és maximális létszáma legalább 5 fő?\n{input.All(x => summer.Contains(x.month) && x.count > 5)}");
            Console.WriteLine($"52. Igaz-e, hogy az minden ajánlat téli, és maximális létszáma legalább 30 fő?\n{input.All(x => winter.Contains(x.month) && x.count > 30)}");
            Console.WriteLine($"53. Igaz-e, hogy az minden ajánlat őszi, és maximális létszáma legalább 15 fő?\n{input.All(x => fall.Contains(x.month) && x.count > 15)}");
            
            Console.WriteLine($"54. Hány forintba kerül a legdrágább ajánlat?\n{input.Max(x => x.price)}");
            Console.WriteLine($"55. Hány forintba kerül a legolcsóbb ajánlat?\n{input.Min(x => x.price)}");
            
            Console.WriteLine($"56. Hány napos a leghosszabb ajánlat?\n{input.Max(x => x.length)}");
            Console.WriteLine($"57. Hány napos a legrövidebb ajánlat?\n{input.Min(x => x.length)}");

            Console.WriteLine($"58. Hány fős a legnagyobb maximális létszámú ajánlat?\n{input.Max(x => x.count)}");
            Console.WriteLine($"59. Hány fős a legkisebb maximális létszámú ajánlat?\n{input.Min(x => x.count)}");
            
            Console.WriteLine($"60. Hány fős a legtöbb jelentkezéssel bíró ajánlat?\n{input.Max(x => x.going)}");
            Console.WriteLine($"61. Hány fős a legkisebb jelentkezéssel bíró ajánlat?\n{input.Min(x => x.going)}");
            
            Console.WriteLine("62. Válogassuk ki a mecseki utak közül azokat, melyekre minden hely elkelt.");
            input.Where(x => x.location == "Mecsek" && x.going == x.count).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("63. Válogassuk ki a zempléni utak közül azokat, melyekre minden hely elkelt.");
            input.Where(x => x.location == "Zemplén" && x.going == x.count).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("64. Válogassuk ki az őrségi utak közül azokat, melyekre minden hely elkelt.");
            input.Where(x => x.location == "Őrség" && x.going == x.count).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("65. Válogassuk ki a balatoni utak közül azokat, melyekre minden hely elkelt.");
            input.Where(x => x.location == "Balaton" && x.going == x.count).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);


            Console.WriteLine("66. Válogassuk ki a legdrágább ajánlatokat?");
            MaxBy(input, (a,b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("67. Válogassuk ki a legolcsóbb ajánlatokat?");
            MaxBy(input, (a,b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("68. Válogassuk ki a leghosszabb ajánlatokat?");
            MaxBy(input, (a,b) => a.length < b.length ? 1 : a.length == b.length ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("69. Válogassuk ki a legrövidebb ajánlatokat?");
            MaxBy(input, (a,b) => a.length > b.length ? 1 : a.length == b.length ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("70. Válogassuk ki a legnagyobb maximális létszámú ajánlatokat?");
            MaxBy(input, (a,b) => a.count < b.count ? 1 : a.count == b.count ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("71. Válogassuk ki a legkisebb maximális létszámú ajánlatokat?");
            MaxBy(input, (a,b) => a.count > b.count ? 1 : a.count == b.count ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("72. Válogassuk ki a legtöbb jelentkezéssel bíró ajánlatokat?");
            MaxBy(input, (a,b) => a.going < b.going ? 1 : a.going == b.going ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("73. Válogassuk ki a legkisebb jelentkezéssel bíró ajánlatokat?");
            MaxBy(input, (a,b) => a.going > b.going ? 1 : a.going == b.going ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("74. Válogassuk ki a nyári, legalább 5 napos ajánlatok közül a legolcsóbbakat!");
            MaxBy(input.Where(x => summer.Contains(x.month) && x.length >= 5).ToList(), (a,b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("75. Válogassuk ki az őszi, legfeljebb 5 napos ajánlatok közül a legdrágábbakat!");
            MaxBy(input.Where(x => fall.Contains(x.month) && x.length <= 5).ToList(), (a,b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("76. Válogassuk ki a tavaszi, legalább 2 napos ajánlatok közül a legolcsóbbakat!");
            MaxBy(input.Where(x => spring.Contains(x.month) && x.length >= 2).ToList(), (a,b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("77. Válogassuk ki a nyári, legfeljebb egy hetes ajánlatok közül a legdrágábbakat!");
            MaxBy(input.Where(x => summer.Contains(x.month) && x.length <= 7).ToList(), (a,b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("78. Válogassuk ki az őszi, legalább egy hetes ajánlatok közül a legolcsóbbakat!");
            MaxBy(input.Where(x => fall.Contains(x.month) && x.length >= 7).ToList(), (a,b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("79. Válogassuk ki a téli, legfeljebb 5 napos ajánlatok közül a legdrágábbakat!");
            MaxBy(input.Where(x => winter.Contains(x.month) && x.length <= 5).ToList(), (a,b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("80. Válogassuk ki az őszi, legalább egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            MaxBy(input.Where(x => fall.Contains(x.month) && x.length >= 7 && x.count - x.going != 0).ToList(), (a, b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("81. Válogassuk ki az mátrai, legalább 3 napos, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            MaxBy(input.Where(x => winter.Contains(x.month) && x.length >= 3 && x.count - x.going != 0).ToList(), (a, b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("82. Válogassuk ki az őszi, legfeljebb egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            MaxBy(input.Where(x => fall.Contains(x.month) && x.length <= 7 && x.count - x.going != 0).ToList(), (a, b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("83. Válogassuk ki az mátrai, vagy bükki, legalább egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            MaxBy(input.Where(x => (x.location == "Bükk" || x.location == "Mátra") && x.length >= 7 && x.count - x.going != 0).ToList(), (a, b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("84. Válogassuk ki az nyári, legfeljebb egy hetes, szabad hellyel rendelkező ajánlatok közül a legdrágábbakat!");
            MaxBy(input.Where(x => summer.Contains(x.month) && x.length <= 7 && x.count - x.going != 0).ToList(), (a, b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1).Select(x => x.ToString()).ToList().ForEach(Console.WriteLine);
            

            
            Console.WriteLine($"85. Hány különböző tájegységre szervez az iroda utazásokat?\n{Locations(input)}");            
            Console.WriteLine("86. Készíts kimutatást, hogy az 1, 2, ..., 7 éjszakás utakra hány foglalás történt!");
            foreach (var group in input.GroupBy(x => x.length)) {
                Console.WriteLine(group.Key + ": " + group.Count());
            }
            Console.WriteLine("87. Mely hónapban hány jelentkező van?");
            foreach (var group in input.GroupBy(x => x.month)) {
                Console.WriteLine(group.Key + ": " + group.Count());
            }
            Console.WriteLine("88. Mely tájegység mennyi pénzt hoz az irodának?");
            foreach (var group in input.GroupBy(x => x.location)) {
                Console.WriteLine(group.Key + ": " + group.Sum(x => x.going * x.price));
            }
            Console.WriteLine("89. Mely tájegységre mennyi hely vehető még ki?");
            foreach (var group in input.GroupBy(x => x.location)) {
                Console.WriteLine(group.Key + ": " + group.Sum(x => x.count - x.going));
            }
            Console.WriteLine($"90. Mely tájegységre van még a legtöbb szabad hely?\n{input.GroupBy(x => x.location).MaxBy(x => x.Sum(x => x.count - x.going)).Key}");
        }
    }
}