using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace osztalyok_23f
{
    internal class Program
    {
        class Tanulo
        {
            public int tanulokod;
            public string nev;
            public string matinfo;
            public string angol;
            public string nyelv2;
            public string nem;
            public int egyuttlakoszam;
            public int testverszam;
            public Tanulo(int tanulokod, string nev, string matinfo, string angol, string nyelv2, string nem, int egyuttlakoszam, int testverszam)
            {
                this.tanulokod = tanulokod;
                this.nev = nev;
                this.matinfo = matinfo;
                this.angol = angol;
                this.nyelv2 = nyelv2;
                this.nem = nem;
                this.egyuttlakoszam = egyuttlakoszam;
                this.testverszam = testverszam;
            }
        }
        static List<Tanulo> Beolvas(string fajlnev)
        {
            List<Tanulo> lista = new List<Tanulo>();
            string[] sorok = File.ReadAllLines(fajlnev);
            foreach (string sor in sorok)
            {
                string[] sortomb = sor.Split(';');
                Tanulo tanulo = new Tanulo(int.Parse(sortomb[0]), sortomb[1], sortomb[2], sortomb[3], sortomb[4], sortomb[5], int.Parse(sortomb[6]), int.Parse(sortomb[7]));
                lista.Add(tanulo);
            }
            return lista;
        }
        static int Adott_nemu_tanulok_szama(List<Tanulo> lista, string nem)
        {
            int result = 0;
            foreach (Tanulo tanulo in lista)
            {
                if (tanulo.nem == nem)
                {
                    result++;
                }
            }
            return result;
        }
        static int TöbbMintxTestvérNum(List<Tanulo> l, int x)
        {

            int result = 0;
            foreach (Tanulo tanulo in l)
            {
                if (tanulo.testverszam > x)
                {
                    result++;
                }
            }
            return result;
        }
        static List<string> TöbbMintxTestvérList(List<Tanulo> l, int x)
        {
            List<string> r = new List<string>();
            foreach (Tanulo tanulo in l) {
                if (tanulo.testverszam > x) {
                    r.Add(tanulo.nev);
                }
            }
            return r;
        }
        
        static void Main(string[] args)
        {
            List<Tanulo> lista = Beolvas("input.txt");
            Console.WriteLine("1. Hány diák tanul az osztályban?");
            Console.WriteLine(lista.Count);
            Console.WriteLine("2. Hány fiú tanul az osztályban?");
            Console.WriteLine(Adott_nemu_tanulok_szama(lista, "F"));
            Console.WriteLine("3. Hány lány tanul az osztályban?");
            Console.WriteLine(Adott_nemu_tanulok_szama(lista, "L"));
            Console.WriteLine("4. Hány olyan diák van, akiknek több mint 1 testvére van?");
            Console.WriteLine(TöbbMintxTestvérNum, 1);
            Console.WriteLine("5. Gyűjtse ki azon diákok nevét, akiknek több mint 1 testvérük van!");
            List<string> f3 = TöbbMintxTestvérList(lista, 1);
            foreach (string x in f3)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("6. Hány olyan diák van, akiknek több mint 2 testvére van?");
            Console.WriteLine(TöbbMintxTestvérNum, 2);
            Console.WriteLine("7. Gyűjtse ki azon diákok nevét, akiknek több mint 1 testvérük van!");
            List<string> f7 = TöbbMintxTestvérList(lista, 2);
            foreach (string x in f7)
            {
                Console.WriteLine(x);
            }
            
        }
    }
}