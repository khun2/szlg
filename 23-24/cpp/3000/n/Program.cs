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
        }
        public class KeyVal<Val,Key>
        {
            public Val Text { get; set; }        
            public Key Id { get; set; }
            public KeyVal(Val val, Key key)
            {
                this.Text = val;
                this.Id = key;
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

        static Offer PriceMax(List<Offer> input, bool largest) {
            Offer offer = input[0];
            for (int i = 1; i < input.Count; i++) {
                if (largest && input[i].price > offer.price) offer = input[i];
                else if (!largest && input[i].price < offer.price) offer = input[i];
            }
            return offer;
        }
        static Offer CountMax(List<Offer> input, bool largest) {
            Offer offer = input[0];
            for (int i = 1; i < input.Count; i++) {
                if (largest && input[i].count > offer.count) offer = input[i];
                else if (!largest && input[i].count < offer.count) offer = input[i];
            }
            return offer;
        } 
        static Offer GoingMax(List<Offer> input, bool largest) {
            Offer offer = input[0];
            for (int i = 1; i < input.Count; i++) {
                if (largest && input[i].going > offer.going) offer = input[i];
                else if (!largest && input[i].going < offer.going) offer = input[i];
            }
            return offer;
        } 
        static Offer LengthMax(List<Offer> input, bool largest) {
            Offer offer = input[0];
            for (int i = 1; i < input.Count; i++) {
                if (largest && input[i].length > offer.length) offer = input[i];
                else if (!largest && input[i].length < offer.length) offer = input[i];
            }
            return offer;
        } 
        static int Locations(List<Offer> input) {
            List<string> list = new List<string>();
            foreach (Offer offer in input) {
                if (!list.Contains(offer.location)) list.Add(offer.location);
            }
            return list.Count;
        }

        static Dictionary<string, int> GoingGroups(List<Offer> input){
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Offer offer in input) {
                if(dict.ContainsKey(offer.location)) dict[offer.location] += offer.going;
                else dict[offer.location] = offer.going;
            }
            return dict;
        }
        static Dictionary<string, long > MoneyGroups(List<Offer> input){
            Dictionary<string, long > dict = new Dictionary<string, long>();
            foreach (Offer offer in input) {
                if(dict.ContainsKey(offer.location)) dict[offer.location] += (long)offer.going * (long)offer.price;
                else dict[offer.location] = (long)offer.going * (long)offer.price;
            }
            return dict;
        }
        static Dictionary<string, int> SpaceGroups(List<Offer> input){
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Offer offer in input) {
                if(dict.ContainsKey(offer.location)) dict[offer.location] += offer.count - offer.going;
                else dict[offer.location] = offer.count - offer.going;
            }
            return dict;
        }
        static void DictWriter(Dictionary<string, int> dict) {
            foreach (var group in dict) {
                Console.WriteLine(group.Key + ": " + group.Value);
            }
        }
        static void ListWriter(List<Offer> input) {
            foreach(Offer offer in input) {
                Console.WriteLine('\t'+offer.location + " tájegységben, " + offer.month + " hónapban, " + offer.length + $" éjszakás, {(offer.family ? "családos" : "egyéni")} út, ahol {offer.count} helyből {offer.going} foglat emiatt {offer.count - offer.going} szabad hely van "+ offer.price + "Ft/fő árral");
            }
        }
        static List<Offer> MaxBy(List<Offer> offers, Func<Offer, Offer, int> func) {
            List<Offer> list = new List<Offer>();
            foreach(Offer offer in offers) {
                if(list.Count == 0) list.Add(offer);
                else {
                    int c = func(list[0], offer);
                    if(c == 1) list = [offer];
                    else if(c == 0) list.Add(offer);
                    else if (c < -1 || c > 1) {
                        throw new Exception("szar a function");
                    }
                }
            }

            return list;
        }
        #endregion
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Offer> input = Beolvasás("input.txt"), list = new List<Offer>();


            string[] winter = ["December", "Január", "Február"], spring = ["Márcus", "Április", "Május"], summer = ["Június", "Július", "Augusztus"], fall = ["Szeptember", "Október", "November"]; 

            Console.WriteLine($"1. Hány ajánlat található az input fájlban?\n{input.Count}");
            Console.WriteLine($"2. Hány mátrai tájegységre vonatozó ajánlat található az input fájlban?\n{input.Where(x => x.location == "Mátra").Count()}");
            Console.WriteLine($"3. Hány mecseki tájegységre vonatozó ajánlat található az input fájlban?\n{input.Where(x => x.location == "Mecsek").Count()}");
            Console.WriteLine($"4. Hány bakonyi tájegységre vonatozó ajánlat található az input fájlban?\n{input.Where(x => x.location == "Bakony").Count()}");
            Console.WriteLine($"5. Hány hortobágyi tájegységre vonatozó ajánlat található az input fájlban?\n{input.Where(x => x.location == "Hortobágy").Count()}");
            Console.WriteLine($"6. Hány őrségi tájegységre vonatozó ajánlat található az input fájlban?\n{input.Where(x => x.location == "Őrség").Count()}");

            Console.WriteLine($"7. Hány mátrai tájegységre vonatozó, családos ajánlat található az input fájlban?\n{input.Where(x => x.location == "Mátra" && x.family == true).Count()}");
            Console.WriteLine($"8. Hány mecseki tájegységre vonatozó, egyéni ajánlat található az input fájlban?\n{input.Where(x => x.location == "Mecsek" && x.family == false).Count()}");
            Console.WriteLine($"9. Hány bakonyi tájegységre vonatozó, májusi ajánlat található az input fájlban?\n{input.Where(x => x.location == "Bakony" && x.month == "Május").Count()}");
            Console.WriteLine($"10. Hány hortobágyi tájegységre vonatozó, júliusi ajánlat található az input fájlban?\n{input.Where(x => x.location == "Hortobágy" && x.month == "Július").Count()}");
            Console.WriteLine($"11. Hány őrségi tájegységre vonatozó, októberi ajánlat található az input fájlban?\n{input.Where(x => x.location == "Őrség" && x.month == "Október").Count()}");

            Console.WriteLine($"12. Hány mátrai tájegységre vonatozó, családos, öt napnál hosszabb ajánlat található az input fájlban?\n{input.Where(x => x.location == "Mátra" && x.family == true && x.length > 5).Count()}");
            Console.WriteLine($"13. Hány mecseki tájegységre vonatozó, egyéni, 3 napnál rövidebb ajánlat található az input fájlban?\n{input.Where(x => x.location == "Mecsek" && x.family == false&& x.length < 3).Count()}");
            Console.WriteLine($"14. Hány bakonyi tájegységre vonatozó, májusi, egy hétnél hosszabb ajánlat található az input fájlban?\n{input.Where(x => x.location == "Bakony" && x.month == "Május" && x.length > 7).Count()}");
            Console.WriteLine($"15. Hány hortobágyi tájegységre vonatozó, júliusi, egy hetes ajánlat található az input fájlban?\n{input.Where(x => x.location == "Hortobágy" && x.month == "Július" && x.length == 7).Count()}");
            Console.WriteLine($"16. Hány őrségi tájegységre vonatozó, októberi, öt napos ajánlat található az input fájlban?\n{input.Where(x => x.location == "Őrség" && x.month == "Október" && x.length == 5).Count()}");

            Console.WriteLine($"17. Hány mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Where(x => x.location == "Mátra" && x.family == true && x.count != x.going).Count()}");
            Console.WriteLine($"18. Hány mecseki tájegységre vonatozó, egyéni, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Where(x => x.location == "Mecsek" && x.family == false && x.count != x.going).Count()}");
            Console.WriteLine($"19. Hány bakonyi tájegységre vonatozó, májusi, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Where(x => x.location == "Bakony" && x.month == "Május" && x.count != x.going).Count()}");
            Console.WriteLine($"20. Hány hortobágyi tájegységre vonatozó, júliusi, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Where(x => x.location == "Hortobágy" && x.month == "Július" && x.count != x.going).Count()}");
            Console.WriteLine($"21. Hány őrségi tájegységre vonatozó, októberi, még szabad hellyel rendelkező ajánlat található az input fájlban?\n{input.Where(x => x.location == "Őrség" && x.month == "Október" && x.count != x.going).Count()}");
            
            Console.WriteLine("22. Válogassuk ki a mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Mátra" && x.going != x.count && x.family == true).ToList();
            Console.WriteLine("23. Válogassuk ki a bükki tájegységre vonatozó, májusi, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Bükk" && x.going != x.count && x.month == "Május").ToList();
            Console.WriteLine("24. Válogassuk ki a zempléni tájegységre vonatozó, egyéni, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Zemplén" && x.going != x.count && x.family == false).ToList();
            Console.WriteLine("25. Válogassuk ki a mecseki tájegységre vonatozó, júniusi, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Mecsek" && x.going != x.count && x.month == "Június").ToList();
            Console.WriteLine("26. Válogassuk ki a balatoni tájegységre vonatozó, augusztusi, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Balaton" && x.going != x.count && x.month == "Augusztus").ToList();

            Console.WriteLine("27. Válogassuk ki a mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező, 20000 Ft alatti ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Mátra" && x.going != x.count && x.family == true && x.price < 20000).ToList();
            Console.WriteLine("28. Válogassuk ki a bükki tájegységre vonatozó, májusi, még szabad hellyel rendelkező, 50000 Ft alatti ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Bükk" && x.going != x.count && x.month == "Május" && x.price < 50000).ToList();
            Console.WriteLine("29. Válogassuk ki a zempléni tájegységre vonatozó, egyéni, még szabad hellyel rendelkező, 60000 Ft alatti ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Zemplén" && x.going != x.count && x.family == false && x.price < 60000).ToList();
            Console.WriteLine("30. Válogassuk ki a mecseki tájegységre vonatozó, júniusi, még szabad hellyel rendelkező, 30000 Ft alatti ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Mecsek" && x.going != x.count && x.month == "Június" && x.price < 0000).ToList();
            Console.WriteLine("31. Válogassuk ki a balatoni tájegységre vonatozó, augusztusi, még szabad hellyel rendelkező, 40000 Ft alatti ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Balaton" && x.going != x.count && x.month == "Augusztus" && x.price < 40000).ToList();

            Console.WriteLine("32. Válogassuk ki a mátrai tájegységre vonatozó, nyári, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Mátra" && x.going != x.count && summer.Contains(x.month)).ToList();
            Console.WriteLine("33. Válogassuk ki a bükki tájegységre vonatozó, nyári, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Bükk" && x.going != x.count && summer.Contains(x.month)).ToList();
            Console.WriteLine("34. Válogassuk ki a zempléni tájegységre vonatozó, téli, még szabad hellyel rendelkező!");
            ListWriter(list);
            list = input.Where(x => x.location == "Zemplén" && x.going != x.count && winter.Contains(x.month)).ToList();
            Console.WriteLine("35. Válogassuk ki a mecseki tájegységre vonatozó, tavaszi, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Mecsek" && x.going != x.count && spring.Contains(x.month)).ToList();
            Console.WriteLine("36. Válogassuk ki a balatoni tájegységre vonatozó, őszi, még szabad hellyel rendelkező ajánlatokat!");
            ListWriter(list);
            list = input.Where(x => x.location == "Balaton" && x.going != x.count && fall.Contains(x.month)).ToList();

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
            
            Console.WriteLine($"54. Hány forintba kerül a legdrágább ajánlat?\n{PriceMax(input, true).price}");
            Console.WriteLine($"55. Hány forintba kerül a legolcsóbb ajánlat?\n{PriceMax(input, false).price}");
            
            Console.WriteLine($"56. Hány napos a leghosszabb ajánlat?\n{LengthMax(input, true).length}");
            Console.WriteLine($"57. Hány napos a legrövidebb ajánlat?\n{LengthMax(input, false).length}");

            Console.WriteLine($"58. Hány fős a legnagyobb maximális létszámú ajánlat?\n{CountMax(input, true).count}");
            Console.WriteLine($"59. Hány fős a legkisebb maximális létszámú ajánlat?\n{CountMax(input, false).count}");
            
            Console.WriteLine($"60. Hány fős a legtöbb jelentkezéssel bíró ajánlat?\n{GoingMax(input, true).going}");
            Console.WriteLine($"61. Hány fős a legkisebb jelentkezéssel bíró ajánlat?\n{GoingMax(input, false).going}");
            
            Console.WriteLine("62. Válogassuk ki a mecseki utak közül azokat, melyekre minden hely elkelt.");
            list = input.Where(x => x.location == "Mecsek" && x.going == x.count).ToList();
            ListWriter(list);
            Console.WriteLine("63. Válogassuk ki a zempléni utak közül azokat, melyekre minden hely elkelt.");
            list = input.Where(x => x.location == "Zemplén" && x.going == x.count).ToList();
            ListWriter(list);
            Console.WriteLine("64. Válogassuk ki az őrségi utak közül azokat, melyekre minden hely elkelt.");
            list = input.Where(x => x.location == "Őrség" && x.going == x.count).ToList();
            ListWriter(list);
            Console.WriteLine("65. Válogassuk ki a balatoni utak közül azokat, melyekre minden hely elkelt.");
            list = input.Where(x => x.location == "Balaton" && x.going == x.count).ToList();
            ListWriter(list);


            Console.WriteLine("66. Válogassuk ki a legdrágább ajánlatokat?");
            list = MaxBy(input, (a,b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("67. Válogassuk ki a legolcsóbb ajánlatokat?");
            list = MaxBy(input, (a,b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("68. Válogassuk ki a leghosszabb ajánlatokat?");
            list = MaxBy(input, (a,b) => a.length < b.length ? 1 : a.length == b.length ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("69. Válogassuk ki a legrövidebb ajánlatokat?");
            list = MaxBy(input, (a,b) => a.length > b.length ? 1 : a.length == b.length ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("70. Válogassuk ki a legnagyobb maximális létszámú ajánlatokat?");
            list = MaxBy(input, (a,b) => a.count < b.count ? 1 : a.count == b.count ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("71. Válogassuk ki a legkisebb maximális létszámú ajánlatokat?");
            list = MaxBy(input, (a,b) => a.count > b.count ? 1 : a.count == b.count ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("72. Válogassuk ki a legtöbb jelentkezéssel bíró ajánlatokat?");
            list = MaxBy(input, (a,b) => a.going < b.going ? 1 : a.going == b.going ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("73. Válogassuk ki a legkisebb jelentkezéssel bíró ajánlatokat?");
            list = MaxBy(input, (a,b) => a.going > b.going ? 1 : a.going == b.going ? 0 : -1);
            ListWriter(list);

            Console.WriteLine("74. Válogassuk ki a nyári, legalább 5 napos ajánlatok közül a legolcsóbbakat!");
            list = MaxBy(input.Where(x => summer.Contains(x.month) && x.length >= 5).ToList(), (a,b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("75. Válogassuk ki az őszi, legfeljebb 5 napos ajánlatok közül a legdrágábbakat!");
            list = MaxBy(input.Where(x => fall.Contains(x.month) && x.length <= 5).ToList(), (a,b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("76. Válogassuk ki a tavaszi, legalább 2 napos ajánlatok közül a legolcsóbbakat!");
            list = MaxBy(input.Where(x => spring.Contains(x.month) && x.length >= 2).ToList(), (a,b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("77. Válogassuk ki a nyári, legfeljebb egy hetes ajánlatok közül a legdrágábbakat!");
            list = MaxBy(input.Where(x => summer.Contains(x.month) && x.length <= 7).ToList(), (a,b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("78. Válogassuk ki az őszi, legalább egy hetes ajánlatok közül a legolcsóbbakat!");
            list = MaxBy(input.Where(x => fall.Contains(x.month) && x.length >= 7).ToList(), (a,b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("79. Válogassuk ki a téli, legfeljebb 5 napos ajánlatok közül a legdrágábbakat!");
            list = MaxBy(input.Where(x => winter.Contains(x.month) && x.length <= 5).ToList(), (a,b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);

            Console.WriteLine("80. Válogassuk ki az őszi, legalább egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            list = MaxBy(input.Where(x => fall.Contains(x.month) && x.length >= 7 && x.count - x.going != 0).ToList(), (a, b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("81. Válogassuk ki az mátrai, legalább 3 napos, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            list = MaxBy(input.Where(x => winter.Contains(x.month) && x.length >= 3 && x.count - x.going != 0).ToList(), (a, b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("82. Válogassuk ki az őszi, legfeljebb egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            list = MaxBy(input.Where(x => fall.Contains(x.month) && x.length <= 7 && x.count - x.going != 0).ToList(), (a, b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("83. Válogassuk ki az mátrai, vagy bükki, legalább egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            list = MaxBy(input.Where(x => (x.location == "Bükk" || x.location == "Mátra") && x.length >= 7 && x.count - x.going != 0).ToList(), (a, b) => a.price > b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            Console.WriteLine("84. Válogassuk ki az nyári, legfeljebb egy hetes, szabad hellyel rendelkező ajánlatok közül a legdrágábbakat!");
            list = MaxBy(input.Where(x => summer.Contains(x.month) && x.length <= 7 && x.count - x.going != 0).ToList(), (a, b) => a.price < b.price ? 1 : a.price == b.price ? 0 : -1);
            ListWriter(list);
            

            
            Console.WriteLine($"85. Hány különböző tájegységre szervez az iroda utazásokat?\n{Locations(input)}");            
            Console.WriteLine("86. Készíts kimutatást, hogy az 1, 2, ..., 7 éjszakás utakra hány foglalás történt!");
            var groups = input.GroupBy(x => x.length);
            foreach (var group in groups) {
                Console.WriteLine(group.Key + ": " + group.Count());
            }
            Console.WriteLine("87. Mely hónapban hány jelentkező van?");
            DictWriter(GoingGroups(input));
            Console.WriteLine("88. Mely tájegység mennyi pénzt hoz az irodának?");
            var lgroups = MoneyGroups(input);
            foreach (var group in lgroups) {
                Console.WriteLine(group.Key + ": " + group.Value);
            }
            Console.WriteLine("89. Mely tájegységre mennyi hely vehető még ki?");
            var dict = SpaceGroups(input);
            DictWriter(dict);
            Console.WriteLine("90. Mely tájegységre van még a legtöbb szabad hely?");
            KeyVal<string, int> offer = new KeyVal<string, int>(dict.First().Key,dict.First().Value);
            //way too overcomplicated
            foreach (var group in dict) {
                if (offer.Id < group.Value) {
                    offer.Id = group.Value;
                }
            }
            Console.WriteLine(offer.Text + ": " + offer.Id);
        }
    }
}