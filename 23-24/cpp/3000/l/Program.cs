﻿using System;
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
            public birthDate birth;
            public string city;
            public string country;
            public int films;
            public Actor(string name, string gender, string birth, string city, string country, string films)
            {
                this.name = name;
                this.gender = int.Parse(gender);
                this.birth = new birthDate(birth);
                this.city = city;
                this.country = country;
                this.films = int.Parse(films);
            }
        }

        struct birthDate
        {
            public int year;
            public int month;
            public int day;
            public string full;

            public birthDate(string full)
            {
                string[] parts = full.Split('.');
                year = int.Parse(parts[0]);
                month = int.Parse(parts[1]);
                day = int.Parse(parts[2]);
                this.full = full;
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

            static List<Actor> AgeFinder(List<Actor> input, bool oldest) {
                List<Actor> orderedList = new List<Actor>(), output = new List<Actor>();
                if(oldest) orderedList = input.OrderBy(x => x.birth.full).ToList(); 
                else orderedList = input.OrderByDescending(x => x.birth.full).ToList();
                int i = 0;
                while (i < input.Count() && orderedList[i].birth.full == orderedList[0].birth.full) {
                    output.Add(orderedList[i]);
                    i++;
                }
                return output;
            }

            static List<Actor> MostFilms(List<Actor> input) {
                List<Actor> orderedList = new List<Actor>(), output = new List<Actor>();
                orderedList = input.OrderBy(x => x.films).ToList(); 
                int i = 0;
                while (i < input.Count() && orderedList[i].films == orderedList[0].films) {
                    output.Add(orderedList[i]);
                    i++;
                }
                return output;
            }

            static List<Actor> SameBirthday(List<Actor> input) {
                List<Actor> output = new List<Actor>();
                var months = input.GroupBy(x => x.birth.month).Where(x => x.Count() > 1);
                foreach (var month in months) {
                    var days = month.GroupBy(x => x.birth.day).Where(x => x.Count() > 1);
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

            List<Actor> input = Beolvasás("input.txt"), actors;
            
            Console.WriteLine($"1. Írja ki a Budapesten született színészek nevét és filmjeinek a számát!");
            actors = CityChooser(input, "Budapest");             
            foreach (Actor actor in actors)
            {
                Console.WriteLine(actor.name + actor.films);
            }
            Console.WriteLine($"2. Írja ki a New Yorkban született színészek nevét és filmjeinek a számát!");
            actors = CityChooser(input, "New York");            
            foreach (Actor actor in actors)
            {
                Console.WriteLine(actor.name + actor.films);
            }
            Console.WriteLine($"3. Írja ki a Berlinben született színészek nevét és filmjeinek a számát!");
            actors = CityChooser(input, "Berlin");
            foreach (Actor actor in actors)
            {
                Console.WriteLine(actor.name + actor.films);
            }
            Console.WriteLine($"4. Írja ki a Párizsban született színészek nevét és filmjeinek a számát!");
            actors = CityChooser(input, "Párizs");
            foreach (Actor actor in actors)
            {
                Console.WriteLine(actor.name + actor.films);
            }
            Console.WriteLine($"5. Írja ki a Tokióban született színészek nevét és filmjeinek a számát!");
            actors = CityChooser(input, "Toki");
            foreach (Actor actor in actors)
            {
                Console.WriteLine(actor.name + actor.films);
            }

            Console.WriteLine($"6. Hány színész született Budapesten?\n{input.Where(x => x.city == "Budapest").Count()}");
            Console.WriteLine($"7. Hány színész született Berlinben?\n{input.Where(x => x.city == "Berlint").Count()}");
            Console.WriteLine($"8. Hány színész született New Yorkban?\n{input.Where(x => x.city == "New York").Count()}");
            
            Console.WriteLine($"9. Hány színész született USA-ban?\n{input.Where(x => x.country == "USA")}");
            Console.WriteLine($"10. Hány színész született Magyarországon?\n{input.Where(x => x.country == "Magyarország")}");
            Console.WriteLine($"11. Hány színész született Németországban?\n{input.Where(x => x.country == "Németország")}");
            Console.WriteLine($"12. Hány színész született Mexikóban?\n{input.Where(x => x.country == "Mexikó")}");
            Console.WriteLine($"13. Hány színész született az USA-ban?\n{input.Where(x => x.country == "USA")}");
            
            Console.WriteLine($"14. Hány férfi és hány női színész van az input fájlban?\n{input.Where(x => x.gender == 1)}, {input.Where(x => x.gender == 0)}");
            
            Console.WriteLine($"15. Hány női színész született Magyarországon?\n{input.Where(x => x.gender == 0 && x.country == "Magyarország").Count()}");
            Console.WriteLine($"16. Hány női színész született Angliában?\n{input.Where(x => x.gender == 0 && x.country == "Anglia").Count()}");
            Console.WriteLine($"17. Hány női színész született Skóciában?\n{input.Where(x => x.gender == 0 && x.country == "Skócia").Count()}");
            Console.WriteLine($"18. Hány női színész született Belgiumban?\n{input.Where(x => x.gender == 0 && x.country == "Belgium").Count()}");
            
            Console.WriteLine($"19. Hány férfi színész született Magyarországon?\n{input.Where(x => x.gender == 1 && x.country == "Magyarország").Count()}");
            Console.WriteLine($"20. Hány férfi színész született Kanadában?\n{input.Where(x => x.gender == 1 && x.country == "Kanada").Count()}");
            Console.WriteLine($"21. Hány férfi színész született USA-ban?\n{input.Where(x => x.gender == 1 && x.country == "USA").Count()}");
            Console.WriteLine($"22. Hány férfi színész született Olaszországban?\n{input.Where(x => x.gender == 1 && x.country == "Olaszország").Count()}");
            
            Console.WriteLine($"23. Hány női színész született Olaszországban vagy Spanyolországban?\n{input.Where(x => x.gender == 0 && (x.country == "Olaszország" || x.country == "Spanyolország")).Count()}");
            Console.WriteLine($"24. Hány női színész született Magyarországon vagy Romániában?\n{input.Where(x => x.gender == 0 && (x.country == "Mexikó" || x.country == "Románia")).Count()}");
            Console.WriteLine($"25. Hány női színész született az USA-ban vagy Mexikóban?\n{input.Where(x => x.gender == 0 && (x.country == "USA" || x.country == "Mexikó")).Count()}");
            Console.WriteLine($"26. Hány férfi színész született Skóciában vagy Angliában?\n{input.Where(x => x.gender == 1 && (x.country == "Skócia" || x.country == "Anglia")).Count()}");
            Console.WriteLine($"27. Hány férfi színész született Franciaországban vagy Németországban?\n{input.Where(x => x.gender == 1 && (x.country == "Franciaország" || x.country == "Németország")).Count()}");

            Console.WriteLine($"28. Hány színész született 1950-ben vagy 1951-ben, USA-ban vagy Kanadában?\n{input.Where(x => (x.birth.year == 1950 || x.birth.year == 1951) && (x.country == "USA" || x.country == "Kanada")).Count()}");
            Console.WriteLine($"29. Hány színész született 1955-ben vagy 1957-ben, Magyarországon vagy Kanadában?\n{input.Where(x => (x.birth.year == 1955 || x.birth.year == 1957) && (x.country == "Magyarország" || x.country == "Kanada")).Count()}");
            Console.WriteLine($"30. Hány színész született 1961-ben vagy 1962-ben, Angliában vagy Skóciában?\n{input.Where(x => (x.birth.year == 1961 || x.birth.year == 1962) && (x.country == "Anglia" || x.country == "Skócia")).Count()}");
            Console.WriteLine($"31. Hány színész született 1970-ben vagy 1971-ben, USA-ban vagy Angliában?\n{input.Where(x => (x.birth.year == 1970 || x.birth.year == 1971) && (x.country == "USA" || x.country == "Anglia")).Count()}");
            
            Console.WriteLine($"32. Hány férfi színész született 1950-ben vagy 1951-ben, USA-ban vagy Kanadában?\n{input.Where(x => (x.birth.year == 1950 || x.birth.year == 1951) && (x.country == "USA" || x.country == "Kanada") && x.gender == 1).Count()}");
            Console.WriteLine($"33. Hány női színész született 1955-ben vagy 1957-ben, Magyarországon vagy Kanadában?\n{input.Where(x => (x.birth.year == 1955 || x.birth.year == 1957) && (x.country == "Magyarország" || x.country == "Kanada") && x.gender == 0).Count()}");
            Console.WriteLine($"34. Hány férfi színész született 1961-ben vagy 1962-ben, Angliában vagy Skóciában?\n{input.Where(x => (x.birth.year == 1961 || x.birth.year == 1962) && (x.country == "Anglia" || x.country == "Skócia") && x.gender == 1).Count()}");
            Console.WriteLine($"35. Hány női színész született 1970-ben vagy 1971-ben, USA-ban vagy Angliában?\n{input.Where(x => (x.birth.year == 1970 || x.birth.year == 1971) && (x.country == "USA" || x.country == "Anglia") && x.gender == 0).Count()}");
            
            Console.WriteLine("36. Mikor született a legidősebb színész?");
            actors = AgeFinder(input, true);
            Console.WriteLine(actors[0].birth.full);
            Console.WriteLine("37. Mikor született a legfiatalabb színész?");
            actors = AgeFinder(input, false);
            Console.WriteLine(actors[0].birth.full);

            Console.WriteLine("38. Írja ki a legidősebb színész(ek) nevét és születési évét!");
            actors = AgeFinder(input, true);
            foreach (Actor actor in actors) {
                Console.WriteLine(actor.name + ": " + actor.birth.year);
            }
            Console.WriteLine("39. Írja ki a legfiatalabb színész(ek) nevét és születési évét!");
            actors = AgeFinder(input, false);
            foreach (Actor actor in actors) {
                Console.WriteLine(actor.name + ": " + actor.birth.year);
            }

            Console.WriteLine("40. Hány filmben játszott a legtöbb filmben szereplő színész?");
            actors = MostFilms(input);
            foreach (Actor actor in actors) {
                Console.WriteLine(actor.name + ": " + actor.films);
            }
            Console.WriteLine("41. Hány filmben játszott a legtöbb filmben szereplő, Magyarországon született színész?");
            actors = input.Where(a => a.country == "Magyarország").ToList();
            actors = MostFilms(input);
            foreach (Actor actor in actors) {
                Console.WriteLine(actor.name + ": " + actor.films);
            }
            Console.WriteLine("42. Hány filmben játszott a legtöbb filmben szereplő, USA-ban született színész?");
            actors = input.Where(a => a.country == "USA").ToList();
            actors = MostFilms(input);
            foreach (Actor actor in actors) {
                Console.WriteLine(actor.name + ": " + actor.films);
            }
            Console.WriteLine("43. Hány filmben játszott a legtöbb filmben szereplő, Angliában született színész?");
            actors = input.Where(a => a.country == "Anglia").ToList();
            actors = MostFilms(input);
            foreach (Actor actor in actors) {
                Console.WriteLine(actor.name + ": " + actor.films);
            }
            Console.WriteLine("44. Hány filmben játszott a legtöbb filmben szereplő, Mexikóban született színész?");
            actors = input.Where(a => a.country == "Mexikó").ToList();
            actors = MostFilms(input);
            foreach (Actor actor in actors) {
                Console.WriteLine(actor.name + ": " + actor.films);
            }
            Console.WriteLine("45. Hány filmben játszott a legtöbb filmben szereplő, Olaszországban született színész?");
            actors = input.Where(a => a.country == "Olaszország").ToList();
            actors = MostFilms(input);
            foreach (Actor actor in actors) {
                Console.WriteLine(actor.name + ": " + actor.films);
            }

            Console.WriteLine("46. Melyik évben született a legtöbb színész? Az évet és a színészek számát is írja ki!");
            var groups = input.GroupBy(x => x.birth.year).OrderBy(x => x.Count());
            Console.WriteLine(groups.Last().Key);
            Console.WriteLine("47. Melyik évben született a legkevesebb színész? Az évet és a színészek számát is írja ki!");
            Console.WriteLine(groups.First().Key);

            Console.WriteLine("48. Melyik országban született a legtöbb színész? Az országot és a színészek számát is írja ki!");
            var groups2 = input.GroupBy(x => x.country).OrderBy(x => x.Count());
            Console.WriteLine(groups.Last().Key);
            Console.WriteLine("49. Melyik országban született a legkevesebb színész? Az országot és a színészek számát is írja ki!");
            Console.WriteLine(groups.First().Key);

            Console.WriteLine("50. Vannak-e olyan színészek, akik ugyanaznap ünneplik a születésnapjukat? Írja ki a színészek nevét és születési dátumát!");
            actors = SameBirthday(input);
            foreach (Actor actor in actors)
            {
                Console.WriteLine(actor.name + ": " + actor.birth.month + "." + actor.birth.day);
            }
        }
    }
}