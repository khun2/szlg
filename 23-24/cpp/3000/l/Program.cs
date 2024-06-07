using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace l
{
    internal class Program
    {
        class Actor
        {
            public string name;
            public int gender;
            public DateTime birth;
            public string city;
            public string country;
            public int films;
            public Actor(string name, string gender, string birth, string city, string country, string films)
            {
                int[] dt = birth.Split('.').Select(x => int.Parse(x)).ToArray();
                this.name = name;
                this.gender = int.Parse(gender);
                this.birth = new DateTime(dt[0], dt[1], dt[2]);
                this.city = city;
                this.country = country;
                this.films = int.Parse(films);
            }
        }
        #region functions
            static List<Actor> Beolvasás(string file)
            {
                string[] rows = File.ReadAllLines(file);
                List<Actor> list = new List<Actor>();
                foreach (string row in rows)
                {
                    string[] line = row.Split('\t');
                    list.Add(new Actor(line[0], line[1], line[2], line[3], line[4], line[5]));
                }
                return list;
            }

            //not really needed
            static List<Actor> CityChooser(List<Actor> input, string s) {
                return input.Where(a => a.city == s).ToList();
            }

            static List<Actor> MaxBy(List<Actor> input, Func<Actor, Actor,int> cmp) {
                List<Actor> list = new List<Actor>();
                foreach (Actor actor in list) {
                    if (list.Count == 0) {
                        list.Add(actor);
                    }
                    else {
                        int c = cmp(list[0], actor);
                        if (c == 1) list = [actor];
                        else if (c == 0) list.Add(actor);
                    }
                }
                return list;
            }
            
            static List<Actor> SameBirthday(List<Actor> input) {
                List<Actor> output = new List<Actor>();
                var months = input.GroupBy(x => x.birth.Year).Where(x => x.Count() > 1);
                foreach (var month in months) {
                    var days = month.GroupBy(x => x.birth.Day).Where(x => x.Count() > 1);
                    foreach (var day in days) {
                        foreach(Actor actor in day)
                        {
                            output.Add(actor);
                        }
                    }
                }
                return output;
            }
        #endregion
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Actor> input = Beolvasás("input.txt");
            
            Console.WriteLine($"1. Írja ki a Budapesten született színészek nevét és filmjeinek a számát!");
            
            foreach (Actor actor in CityChooser(input, "Budapest"))
            {
                Console.WriteLine(actor.name + actor.films);
            }
            Console.WriteLine($"2. Írja ki a New Yorkban született színészek nevét és filmjeinek a számát!");
            
            foreach (Actor actor in CityChooser(input, "New York"))
            {
                Console.WriteLine(actor.name + actor.films);
            }
            Console.WriteLine($"3. Írja ki a Berlinben született színészek nevét és filmjeinek a számát!");
            
            foreach (Actor actor in CityChooser(input, "Berlin"))
            {
                Console.WriteLine(actor.name + actor.films);
            }
            Console.WriteLine($"4. Írja ki a Párizsban született színészek nevét és filmjeinek a számát!");
            
            foreach (Actor actor in CityChooser(input, "Párizs"))
            {
                Console.WriteLine(actor.name + actor.films);
            }
            Console.WriteLine($"5. Írja ki a Tokióban született színészek nevét és filmjeinek a számát!");
            
            foreach (Actor actor in CityChooser(input, "Tokió"))
            {
                Console.WriteLine(actor.name + actor.films);
            }

            Console.WriteLine($"6. Hány színész született Budapesten?\n{input.Count(x => x.city == "Budapest")}");
            Console.WriteLine($"7. Hány színész született Berlinben?\n{input.Count(x => x.city == "Berlint")}");
            Console.WriteLine($"8. Hány színész született New Yorkban?\n{input.Count(x => x.city == "New York")}");
            
            Console.WriteLine($"9. Hány színész született USA-ban?\n{input.Count(x => x.country == "USA")}");
            Console.WriteLine($"10. Hány színész született Magyarországon?\n{input.Count(x => x.country == "Magyarország")}");
            Console.WriteLine($"11. Hány színész született Németországban?\n{input.Count(x => x.country == "Németország")}");
            Console.WriteLine($"12. Hány színész született Mexikóban?\n{input.Count(x => x.country == "Mexikó")}");
            Console.WriteLine($"13. Hány színész született az USA-ban?\n{input.Count(x => x.country == "USA")}");
            
            Console.WriteLine($"14. Hány férfi és hány női színész van az input fájlban?\n{input.Count(x => x.gender == 1)}, {input.Count(x => x.gender == 0)}");
            
            Console.WriteLine($"15. Hány női színész született Magyarországon?\n{input.Count(x => x.gender == 0 && x.country == "Magyarország")}");
            Console.WriteLine($"16. Hány női színész született Angliában?\n{input.Count(x => x.gender == 0 && x.country == "Anglia")}");
            Console.WriteLine($"17. Hány női színész született Skóciában?\n{input.Count(x => x.gender == 0 && x.country == "Skócia")}");
            Console.WriteLine($"18. Hány női színész született Belgiumban?\n{input.Count(x => x.gender == 0 && x.country == "Belgium")}");
            
            Console.WriteLine($"19. Hány férfi színész született Magyarországon?\n{input.Count(x => x.gender == 1 && x.country == "Magyarország")}");
            Console.WriteLine($"20. Hány férfi színész született Kanadában?\n{input.Count(x => x.gender == 1 && x.country == "Kanada")}");
            Console.WriteLine($"21. Hány férfi színész született USA-ban?\n{input.Count(x => x.gender == 1 && x.country == "USA")}");
            Console.WriteLine($"22. Hány férfi színész született Olaszországban?\n{input.Count(x => x.gender == 1 && x.country == "Olaszország")}");
            
            Console.WriteLine($"23. Hány női színész született Olaszországban vagy Spanyolországban?\n{input.Count(x => x.gender == 0 && (x.country == "Olaszország" || x.country == "Spanyolország"))}");
            Console.WriteLine($"24. Hány női színész született Magyarországon vagy Romániában?\n{input.Count(x => x.gender == 0 && (x.country == "Mexikó" || x.country == "Románia"))}");
            Console.WriteLine($"25. Hány női színész született az USA-ban vagy Mexikóban?\n{input.Count(x => x.gender == 0 && (x.country == "USA" || x.country == "Mexikó"))}");
            Console.WriteLine($"26. Hány férfi színész született Skóciában vagy Angliában?\n{input.Count(x => x.gender == 1 && (x.country == "Skócia" || x.country == "Anglia"))}");
            Console.WriteLine($"27. Hány férfi színész született Franciaországban vagy Németországban?\n{input.Count(x => x.gender == 1 && (x.country == "Franciaország" || x.country == "Németország"))}");

            Console.WriteLine($"28. Hány színész született 1950-ben vagy 1951-ben, USA-ban vagy Kanadában?\n{input.Count(x => (x.birth.Year == 1950 || x.birth.Year == 1951) && (x.country == "USA" || x.country == "Kanada"))}");
            Console.WriteLine($"29. Hány színész született 1955-ben vagy 1957-ben, Magyarországon vagy Kanadában?\n{input.Count(x => (x.birth.Year == 1955 || x.birth.Year == 1957) && (x.country == "Magyarország" || x.country == "Kanada"))}");
            Console.WriteLine($"30. Hány színész született 1961-ben vagy 1962-ben, Angliában vagy Skóciában?\n{input.Count(x => (x.birth.Year == 1961 || x.birth.Year == 1962) && (x.country == "Anglia" || x.country == "Skócia"))}");
            Console.WriteLine($"31. Hány színész született 1970-ben vagy 1971-ben, USA-ban vagy Angliában?\n{input.Count(x => (x.birth.Year == 1970 || x.birth.Year == 1971) && (x.country == "USA" || x.country == "Anglia"))}");
            
            Console.WriteLine($"32. Hány férfi színész született 1950-ben vagy 1951-ben, USA-ban vagy Kanadában?\n{input.Count(x => (x.birth.Year == 1950 || x.birth.Year == 1951) && (x.country == "USA" || x.country == "Kanada") && x.gender == 1)}");
            Console.WriteLine($"33. Hány női színész született 1955-ben vagy 1957-ben, Magyarországon vagy Kanadában?\n{input.Count(x => (x.birth.Year == 1955 || x.birth.Year == 1957) && (x.country == "Magyarország" || x.country == "Kanada") && x.gender == 0)}");
            Console.WriteLine($"34. Hány férfi színész született 1961-ben vagy 1962-ben, Angliában vagy Skóciában?\n{input.Count(x => (x.birth.Year == 1961 || x.birth.Year == 1962) && (x.country == "Anglia" || x.country == "Skócia") && x.gender == 1)}");
            Console.WriteLine($"35. Hány női színész született 1970-ben vagy 1971-ben, USA-ban vagy Angliában?\n{input.Count(x => (x.birth.Year == 1970 || x.birth.Year == 1971) && (x.country == "USA" || x.country == "Anglia") && x.gender == 0)}");
            
            Console.WriteLine($"36. Mikor született a legidősebb színész?\n{input.Max(x => x.birth)}");
            Console.WriteLine($"37. Mikor született a legfiatalabb színész?\n{input.Min(x => x.birth)}");

            Console.WriteLine("38. Írja ki a legidősebb színész(ek) nevét és születési évét!");
            foreach (Actor actor in MaxBy(input, (a,b) => a.birth < b.birth ? 1 : a.birth == b.birth ? 0 : -1)) {
                Console.WriteLine(actor.name + ": " + actor.birth.Year);
            }
            Console.WriteLine("39. Írja ki a legfiatalabb színész(ek) nevét és születési évét!");
            foreach (Actor actor in MaxBy(input, (a,b) => a.birth > b.birth ? 1 : a.birth == b.birth ? 0 : -1)) {
                Console.WriteLine(actor.name + ": " + actor.birth.Year);
            }

            Console.WriteLine("40. Hány filmben játszott a legtöbb filmben szereplő színész?\n" + input.Max(x => x.films));

            Console.WriteLine($"41. Hány filmben játszott a legtöbb filmben szereplő, Magyarországon született színész?\n{input.Where(a => a.country == "Magyarország").Max(x => x.films)}");
            Console.WriteLine($"42. Hány filmben játszott a legtöbb filmben szereplő, USA-ban született színész?\n{input.Where(a => a.country == "USA").Max(x => x.films)}");
            Console.WriteLine($"43. Hány filmben játszott a legtöbb filmben szereplő, Angliában született színész?\n{input.Where(a => a.country == "Anglia").Max(x => x.films)}");
            Console.WriteLine($"44. Hány filmben játszott a legtöbb filmben szereplő, Mexikóban született színész?\n{input.Where(a => a.country == "Mexikó").Max(x => x.films)}");
            Console.WriteLine($"45. Hány filmben játszott a legtöbb filmben szereplő, Olaszországban született színész?\n{input.Where(a => a.country == "Olaszország").Max(x => x.films)}");
            
            Console.WriteLine("46. Melyik évben született a legtöbb színész? Az évet és a színészek számát is írja ki!");
            var groups = input.GroupBy(x => x.birth.Year).OrderBy(x => x.Count());
            Console.WriteLine(groups.Last().Key);
            Console.WriteLine("47. Melyik évben született a legkevesebb színész? Az évet és a színészek számát is írja ki!");
            Console.WriteLine(groups.First().Key);

            Console.WriteLine("48. Melyik országban született a legtöbb színész? Az országot és a színészek számát is írja ki!");
            var groups2 = input.GroupBy(x => x.country).OrderBy(x => x.Count());
            Console.WriteLine(groups.Last().Key);
            Console.WriteLine("49. Melyik országban született a legkevesebb színész? Az országot és a színészek számát is írja ki!");
            Console.WriteLine(groups.First().Key);

            Console.WriteLine("50. Vannak-e olyan színészek, akik ugyanaznap ünneplik a születésnapjukat? Írja ki a színészek nevét és születési dátumát!");
            foreach (Actor actor in SameBirthday(input))
            {
                Console.WriteLine(actor.name + ": " + actor.birth.Month + "." + actor.birth.Day);
            }
        }
    }
}