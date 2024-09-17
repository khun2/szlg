using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Halmazok
{
	internal class Program
	{

		class Halmaz
		{
			public List<int> l;

			public Halmaz()
			{
				this.l = new List<int>();
			}

			public Halmaz(List<int> lista)
			{
				l = new List<int>();

				foreach (int elem in lista)
				{
					if (!Bennevan(l, elem))
					{
						l.Add(elem);
					}
				}

			}

			public bool Tartalmazza(int e)
			{
				int i = 0;
				while (i < this.l.Count && this.l[i] != e)
				{
					i++;
				}
				return i < this.l.Count;
			}

			public override string ToString()
			{
				return Stringbe(this.l, "; ", "{ ", " }");
			}

			public Halmaz Masolat()
			{
				Halmaz result = new Halmaz();
				foreach (int e in this.l)
					result.l.Add(e);
				return result;
			}

			public static Halmaz operator +(Halmaz a, Halmaz b)
			{
				Halmaz result = a.Masolat();
				foreach (int item in b.l)
					if (!result.Tartalmazza(item))
						result.l.Add(item);
				return result;
			}

            public static Halmaz operator *(Halmaz a, Halmaz b)
			{
				Halmaz result = new Halmaz();
				foreach (int item in b.l)
					if (a.Tartalmazza(item)) 
						result.l.Add(item);
				return result;
			}

            public static Halmaz operator -(Halmaz a, Halmaz b)
			{
				Halmaz result = new Halmaz();
				foreach (int item in a.l) 
					if (!b.Tartalmazza(item)) result.l.Add(item);
				return result;
			}

            public static bool operator ==(Halmaz a, Halmaz b)
			{
                if (a.l.Count != b.l.Count) return false;
                int i = 0;
                while(i < a.l.Count && b.Tartalmazza(a.l[i])) i++;
                return i == a.l.Count;
			}
            public static bool operator !=(Halmaz a, Halmaz b) => !(a==b);
            public static bool operator >=(Halmaz a, Halmaz b) => !(b.l.Except(a.l).Any());
            public static bool operator <=(Halmaz a, Halmaz b) => b>=a;
            public static bool operator >(Halmaz a, Halmaz b) => a!=b && a>=b;
            public static bool operator <(Halmaz a, Halmaz b) => b>a;
			
		}

		static bool Bennevan(List<int> l, int e)
		{
			int i = 0;
			while (i < l.Count && l[i] != e)
				i++;
			return i < l.Count;
		}
		static string Stringbe<T>(List<T> t, string separator = " ", string start = "{ ", string end = " }")
		{
			if (t.Count == 0)
				return start + end;
			string result = start;
			for (int i = 0; i < t.Count - 1; i++)
				result += $"{t[i]}" + separator;
			result += $"{t[t.Count - 1]}";
			return result + end;
		}

		static Random r = new Random();
		static List<int> Veletlenlista(int hossz, int min, int max)
		{
			List<int> result = new List<int>();
			for (int i = 0; i < hossz; i++)
				result.Add(r.Next(min, max));
			return result;
		}

		static void Main(string[] args)
		{
			Halmaz h = new Halmaz(new List<int> { 1, 2, 5, 6, 9 });
            Halmaz h2 = h.Masolat();
			Halmaz g = new Halmaz(new List<int> { 8, 6, 4, 2});
			Console.WriteLine(h);
			Console.WriteLine(h2);

			//Console.WriteLine(g.Tartalmazza(2));
			//Console.WriteLine(g.Tartalmazza(3));

            Console.WriteLine(h<=h2);
            Console.WriteLine(h<h2);

            h2 += new Halmaz(new List<int> {1, 2, 3});
            Console.WriteLine(h<=h2);
            Console.WriteLine(h<h2);

        }
	}
}