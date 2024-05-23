using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace j
{
    internal class Program
    {
        class Tanulo
        {
            public int code;
            public string name;
            public string csop;
            public int eng;
            public string lang2;
            public char gender;
            public int family;
            public int siblingum;
            public Tanulo(int code, string name, string csop, int eng, string lang2, char gender, int family, int siblingum)
            {
                this.code = code;
                this.name = name;
                this.csop = csop;
                this.eng = eng;
                this.lang2 = lang2;
                this.gender = gender;
                this.family = family;
                this.siblingum = siblingum;
            }
        }
        static List<Tanulo> Input(string fajlnev)
        {
            List<Tanulo> input = new List<Tanulo>();
            string[] lines = File.ReadAllLines(fajlnev);
            foreach (string line in lines)
            {
                string[] sortomb = line.Split(';');
                Tanulo tanulo = new Tanulo(int.Parse(sortomb[0]), sortomb[1], sortomb[2], sortomb[3][0] - '0', sortomb[4], sortomb[5][0], int.Parse(sortomb[6]), int.Parse(sortomb[7]));
                input.Add(tanulo);
            }
            return input;
        }
        static int Count(List<Tanulo> l)
        {
            return l.Count;
        }
        static int GenderCount (List<Tanulo> l, char gender)
        {
            return l.Count(x => x.gender == gender);
        }
        static int MoreThanXSiblingsNum (List<Tanulo> l, int num)
        {
            return l.Count(x => num < x.siblingum);
        }
        static string[] MoreThanXSiblingsArr (List<Tanulo> l, int num) 
        {
            return l.Where(x => num < x.siblingum).Select(x => x.name).ToArray();
        }
        static int Lang2Count (List<Tanulo> l, string lang) 
        {
            return l.Count(x => x.lang2 == lang);
        }
        static string[] GenderAndLang2Arr (List<Tanulo> l, char gender, string lang)
        {
            return l.Where(x => x.gender == gender && x.lang2 == lang).Select(x => x.name).ToArray();
        }
        static string BiggestFamilyName (List<Tanulo> l)
        {
            int n = l.Select(x => x.family).ToArray().Max();  
            return l.First(x => x.family == n).name;
        }
        static string[] GenderAndEngArr (List<Tanulo> input, char gender, int eng1, int eng2)
        {
            return input.Where(x => x.gender == gender && (x.eng == eng1 || x.eng == eng2)).Select(x => x.name).ToArray();
        }
        static string[] SameEnglish (List<Tanulo> input, string n)
        {
            int eng = input.First(x => x.name == n).eng;
            return input.Where(x => x.eng == eng).Select(x => x.name).ToArray();
        }
        static string Lang2Comparison (List<Tanulo> input, string l1, string l2) 
        {
            int n = 0, m = 0;
            foreach (Tanulo tanulo in input)
            {
                if (tanulo.lang2 == l1) n++;
                else if (tanulo.lang2 == l2) m++;
            }
            if (n == m) return "Egyenlő számú tanulója van a két nyelvnek";
            return n > m ? l1 : l2;
        }
        static string[] SameLang2 (List<Tanulo> input, string n)
        {
            return input.Where(x => x.lang2 == n).Select(x => x.name).ToArray();
        }
        static int SecondLangs (List<Tanulo> input)
        {
            List <string> langs = new List<string>();
            foreach (Tanulo tanulo in input)
            {
                if (!langs.Contains(tanulo.lang2))
                {
                    langs.Add(tanulo.lang2);
                }
            }
            return langs.Count();
        }
        static IEnumerable<IGrouping<string, Tanulo>> MathGroups(List<Tanulo> input) 
        {
            var groups = input.GroupBy(x => x.csop);  
            return groups;
        }
        static IEnumerable<IGrouping<int, Tanulo>> EngGroups(List<Tanulo> input) 
        {
            var groups = input.GroupBy(x => x.eng);  
            return groups;
        }
        static IEnumerable<IGrouping<int, Tanulo>> FamGroups(List<Tanulo> input) 
        {
            var groups = input.GroupBy(x => x.family);  
            return groups;
        }
        //i give up on giving good names to my functions as i am running out of time and am tired <- things said moments before i gave up on submitting in time
        static Dictionary<int, int> Task38(List<Tanulo> input)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>(); 
            foreach (Tanulo tanulo in input)
            {
                if (dict.ContainsKey(tanulo.eng))
                {
                    dict[tanulo.eng]+=tanulo.siblingum;
                }
                else
                {
                    dict[tanulo.eng] = tanulo.siblingum;
                }
            }
            return dict;
        }
        static List<Tuple<string, double>> Task39(List<Tanulo> input)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            List<Tuple<string, double>> Out = new List<Tuple<string, double>>(); 

            foreach (Tanulo tanulo in input)
            {
                if (dict.ContainsKey(tanulo.lang2))
                {
                    dict[tanulo.lang2].Add(tanulo.siblingum);
                }
                else
                {
                    dict[tanulo.lang2] = new List<int> { tanulo.siblingum };
                }
            }
            foreach (var asd in dict)
            {
                string lang2 = asd.Key;
                List<int> siblingCounts = asd.Value;
                Out.Add(new Tuple<string, double>(lang2, siblingCounts.Average()));
            }
            return Out;
        }
        static List<Tuple<Tanulo, Tanulo>> Task40(List<Tanulo> input) 
        {
            List<Tuple<Tanulo,Tanulo>> FirstnLast = new List<Tuple<Tanulo, Tanulo>>();
            var grouped = input.GroupBy(x => x.eng);
            foreach (var group in grouped)
            {
                group.OrderBy(x => x.eng);
                FirstnLast.Add(new Tuple<Tanulo, Tanulo>(group.First(), group.Last()));
            }
            return FirstnLast;
            //after procrasinating for 5 days i did it in 10 minutes lol
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Tanulo> input = Input("input.txt");
            Console.WriteLine("1. Hány diák tanul az osztályban?");
            Console.WriteLine(Count(input));
            Console.WriteLine("2. Hány fiú tanul az osztályban?");
            Console.WriteLine(GenderCount(input, 'F'));
            Console.WriteLine("3. Hány lány tanul az osztályban?");
            Console.WriteLine(GenderCount(input, 'L'));
            Console.WriteLine("4. Hány olyan diák van, akiknek több mint 1 testvére van?");
            Console.WriteLine(MoreThanXSiblingsNum(input, 1));
            Console.WriteLine("5. Gyűjtse ki azon diákok nevét, akiknek több mint 1 testvérük van!");
            string[] strings = MoreThanXSiblingsArr(input, 1);
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("6. Hány olyan diák van, akiknek több mint 2 testvére van?");
            Console.WriteLine(MoreThanXSiblingsNum(input, 2));
            Console.WriteLine("7. Gyűjtse ki azon diákok nevét, akiknek több mint 1 testvérük van!");
            strings = MoreThanXSiblingsArr(input, 2);
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"8. Hány olyan diák van, akik a 2. idegen nyelvként a németet tanulják? \n {Lang2Count(input, "német")}");
            Console.WriteLine($"9. Gyűjtse ki azon fiú diákok nevét, akik a 2. idegen nyelvként a németet tanulják!");
            strings = GenderAndLang2Arr(input, 'F', "német");
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"10. Hány diák tanul az egyes angol csoportban?\n{input.Count(x => x.eng== 1)}");
            Console.WriteLine($"11. Hány diák tanul a kettes angol csoportban?\n{input.Count(x => x.eng== 2)}");
            Console.WriteLine($"12. Hány diák tanul az alfa matematika csoportban?\n{input.Count(x => x.csop == "alfa")}");
            Console.WriteLine($"13. Hány diák tanul az beta matematika csoportban?\n{input.Count(x => x.csop == "beta")}");
            Console.WriteLine($"14. Hány lány tanul az alfa matematika csoportban?\n{input.Count(x => x.csop == "alfa" && x.gender == 'L')}");
            Console.WriteLine($"15. Hány lány tanul az beta matematika csoportban?\n{input.Count(x => x.csop == "beta" && x.gender == 'L')}");
            Console.WriteLine($"16. Hány fiú tanul az alfa matematika csoportban?\n{input.Count(x => x.csop == "alfa" && x.gender == 'F')}");
            Console.WriteLine($"17. Hány fiú tanul az beta matematika csoportban?\n{input.Count(x => x.csop == "beta" && x.gender == 'F')}");
            Console.WriteLine($"18. Van-e olyan diák, aki a 2. idegen nyelvként oroszt tanul?\n{input.Any(x => x.lang2 == "orosz")}");
            Console.WriteLine($"19. Van-e olyan diák, aki a 2. idegen nyelvként olaszt tanul?\n{input.Any(x => x.lang2 == "olasz")}");
            Console.WriteLine($"20. Van-e olyan diák, aki a 2. idegen nyelvként spanyol tanul?\n{input.Any(x => x.lang2 == "spanyol")}");
            Console.WriteLine($"21. Mekkora a legnagyobb család az osztályban?\n{input.Select(x => x.family).ToArray().Max()}");
            Console.WriteLine($"22 Írjuk ki az egyik olyan diák nevét akinek e legtöbb testvére van!\n{BiggestFamilyName(input)}");
            Console.WriteLine($"23. Gyűjtse ki azon lány diákok nevét, akik az egyes vagy kettes angol csoportban vannak!");
            strings = GenderAndEngArr(input, 'L', 1, 2);
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"24. Gyűjtse ki azon fiú diákok nevét, akik a hármas vagy négyes angol csoportban vannak és 0 vagy 2 testvérük van!");
            strings = input.Where(x => x.gender == 'F' && (x.eng == 3 || x.eng == 4) && (x.siblingum == 0 || x.siblingum == 2)).Select(x => x.name).ToArray();
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"25. Viszonylag kevés azon családok száma, ahol az együttlakók száma és a testvérek száma között nem három a különbség. Adja meg a számukat!");
            string[] f25 = input.Where(x => x.family - x.siblingum != 3).Select(x => x.name).ToArray();
            foreach (string x in f25)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"26. Dári Dóra hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak.");
            strings = SameEnglish(input, "Dári Dóra");
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"27. Avon Mór hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak.");
            strings = SameEnglish(input, "Avon Mór");
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"28. Zúz Mara hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak.");
            strings = SameEnglish(input, "Zúz Mara");
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"29. Citad Ella hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak.");
            strings = SameEnglish(input, "Citad Ella");
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"30. Hát Izsák hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak.");
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"31. A spanyol vagy a német nyelvet tanulják-e többben az osztáyban?\n{Lang2Comparison(input, "német", "spanyol")}");
            Console.WriteLine($"32. Kérjen be a felhasználótól egy nyelvet és írja ki, az adott nyelvet tanulók névsorát!");
            string f32;
            f32 = Console.ReadLine();
            strings = SameLang2(input, f32);
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"33. Hány különböző második idegen nyelvet lehet tanulni?\n{SecondLangs(input)}");
            Console.WriteLine($"34. Add meg a különböző matematika/informatika szerinti csoportbontások neveit!");
            var matGroups = MathGroups(input).Select(x =>x.Key);
            foreach (var group in matGroups)
            {
                Console.WriteLine(group);
            } 
            Console.WriteLine($"35. Melyik angol nyelvi csoportba hányan járnak?");
            var engGroups = EngGroups(input);
            foreach (var group in engGroups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
            Console.WriteLine($"36. Csoportosítsuk az együttlakók száma szerint a diákokat! Melyik csoportban hányan vannak?");
            var famGroups = FamGroups(input);
            foreach (var group in famGroups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
            Console.WriteLine($"37. Melyik a leggyakrabban előforduló testvérszám?\n{input.GroupBy(x => x.siblingum).OrderByDescending(x => x.Count()).First().Key}");
            Console.WriteLine($"38. Add meg angolcsoportonként, hogy melyik csoportban hány testvére van összesen az oda járó embereknek!");
            Dictionary<int, int> t38 = Task38(input);
            foreach (var group in t38)
            {
                Console.WriteLine($"{group.Key}: {group.Value}");
            }
            Console.WriteLine($"39. Add meg második nyelvi csoportonként, hogy melyik csoportban átlagosan hány testvére van az oda járó embereknek!");
            List<Tuple<string, double>> t39 = Task39(input);
            foreach (Tuple<string,double> asd in t39)
            {
                Console.WriteLine($"{asd.Item1}: {asd.Item2}");
            }
            Console.WriteLine($"40. Add meg angolcsoportonként a névsorban első és utolsó diák nevét!");
            List<Tuple<Tanulo, Tanulo>> t40 = Task40(input);
            foreach (Tuple<Tanulo, Tanulo> x in t40)
            {
                Console.WriteLine($"{x.Item1.eng}: {x.Item1.name}, {x.Item2.name}");
            }
        }
    }
}