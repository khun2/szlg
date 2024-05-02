using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace j
{
    internal class Program
    {
        class Tanulo
        {
            public int code;
            public string name;
            public string csop;
            public int english;
            public string lang2;
            public char gender;
            public int family;
            public int siblingum;
            public Tanulo(int code, string name, string csop, int english, string lang2, char gender, int family, int siblingum)
            {
                this.code = code;
                this.name = name;
                this.csop = csop;
                this.english = english;
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
            return input.Where(x => x.gender == gender && (x.english == eng1 || x.english == eng2)).Select(x => x.name).ToArray();
        }
        static string[] SameEnglish (List<Tanulo> input, string n)
        {
            int eng = input.First(x => x.name == n).english;
            return input.Where(x => x.english == eng).Select(x => x.name).ToArray();
        }
        static void Main(string[] args)
        {
            
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
            strings = GenderAndLang2Arr(input, 'g', "német");
            foreach (string x in strings)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"10. Hány diák tanul az egyes angol csoportban?\n{input.Count(x => x.english== 1)}");
            Console.WriteLine($"11. Hány diák tanul a kettes angol csoportban?\n{input.Count(x => x.english== 2)}");
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
            strings = input.Where(x => x.gender == 'F' && (x.english == 3 || x.english == 4) && (x.siblingum == 0 || x.siblingum == 2)).Select(x => x.name).ToArray();
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
            
        }
    }
}