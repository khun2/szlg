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
				while (i < a.l.Count && b.Tartalmazza(a.l[i])) i++;
				return i == a.l.Count;
			}
			public static bool operator !=(Halmaz a, Halmaz b) => !(a == b);
			public static bool operator >=(Halmaz a, Halmaz b) => !(b.l.Except(a.l).Any());
			public static bool operator <=(Halmaz a, Halmaz b) => b >= a;
			public static bool operator >(Halmaz a, Halmaz b) => a != b && a >= b;
			public static bool operator <(Halmaz a, Halmaz b) => b > a;

		}
		class HalmazRendezessel<T>
		{
			List<T> lista;
			Func<T, T, int> comparator;

			public HalmazRendezessel(Func<T, T, int> comparator)
			{
				this.lista = new List<T>();
				this.comparator = comparator;

			}

			public HalmazRendezessel(List<T> lista, Func<T, T, int> comparator)
			{
				this.lista = new List<T>(lista);
				Beszuró_rendezés(this.lista, comparator);
				this.comparator = comparator;
			}

			static void Csere<T>(List<T> lista, int i, int j)
			{
				T temp = lista[i];
			  	lista[i] = lista[j];
				lista[j] = temp;
			}
			public static void Beszuró_rendezés(List<T> lista, Func<T, T, int> comparator)
			{
				for (int i = 1; i < lista.Count; i++)
				{
					Süllyesztés(lista, i, comparator);
				}
			}

			public static void Süllyesztés(List<T> lista, int i, Func<T, T, int> comparator)
			{
				while (0 < i && comparator(lista[i - 1], lista[i]) == 1)
				{
					Csere(lista, i - 1, i);
					i--;
				}
			}
			public bool Tartalmazza(T e)
			{
				throw new NotImplementedException();
			}

			public static HalmazRendezessel<T> operator -(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static HalmazRendezessel<T> operator +(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}

			public static HalmazRendezessel<T> operator *(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}

			public static bool operator <(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator <=(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator >(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator >=(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator ==(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator !=(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
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
		static int szokasos(int a, int b)
		{
			if (a < b)
				return -1;
			if (a > b)
				return 1;
			return 0;
		}

		static void Main(string[] args)
		{
			HalmazRendezessel<int> h = new HalmazRendezessel<int>(new List<int> { 3, 7, 1, 2, 6, 1, 2 }, szokasos);
		}
	}
}
