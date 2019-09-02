/***
 *     ▄▄▄       ██ ▄█▀ ██▓ ██▓    
 *    ▒████▄     ██▄█▒ ▓██▒▓██▒    
 *    ▒██  ▀█▄  ▓███▄░ ▒██▒▒██░    
 *    ░██▄▄▄▄██ ▓██ █▄ ░██░▒██░    
 *     ▓█   ▓██▒▒██▒ █▄░██░░██████▒
 *     ▒▒   ▓▒█░▒ ▒▒ ▓▒░▓  ░ ▒░▓  ░
 *      ▒   ▒▒ ░░ ░▒ ▒░ ▒ ░░ ░ ▒  ░
 *      ░   ▒   ░ ░░ ░  ▒ ░  ░ ░   
 *          ░  ░░  ░    ░      ░  ░
 *          
 *     For code updates visit repository on https://github.com/sutaj
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Slowa
{
    class Program
    {
        static string litery; // jakie litery
        static int ileOD, ileDO; // ile liter
        static string slownik = "slowa.txt"; // plik slownika
        static List<string> slowa; // lista ze slowami
        static bool dupl = false; // czy moga wystepowac duplikaty

        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            ConsoleKeyInfo duplikaty = new ConsoleKeyInfo();

            Console.Clear();
            Console.WriteLine($"\t\t Pomocnik krzyżówkowicza. ver. {Assembly.GetExecutingAssembly().GetName().Version}{Environment.NewLine}\t\t\t\tSłownik sjp.pl{Environment.NewLine}\t\t\thttps://github.com/sutaj{Environment.NewLine}");
            Console.Write("Z jakich liter?: \t\t");
            litery = Console.ReadLine();

            if (litery.Length < 2)
            {
                Blad($"Za mało znaków ({litery.Length}). Minimum to 3.");
            }

            Console.Write("Ilość znaków między [od]: \t");

            if (!int.TryParse(Console.ReadLine(), out ileOD))
            {
                Blad("To musi być liczba.");
            }
            else
            {
                if (ileOD > litery.Length)
                {
                    Blad("Nie może być większa niż liczba liter.");
                }
            }

            Console.Write("a [do]: \t\t\t");
            if (!int.TryParse(Console.ReadLine(), out ileDO))
            {
                Blad("To musi być liczba.");
            }
            else
            {
                if (ileDO < ileOD)
                {
                    Blad("Maksymalna ilość znaków nie może być mniejsza niż minimalna.");
                }
            }

            Console.Write("Pozwolić na duplikaty znaków [T/N]? ");
            duplikaty = Console.ReadKey(true);

            if (duplikaty.Key == ConsoleKey.T)
            {
                Console.WriteLine("\t TAK");
                dupl = true;
            }
            else
            {
                Console.WriteLine("\t NIE");
                dupl = false;
            }

            Console.WriteLine($"{Environment.NewLine}---------------------------------------------------------");
            RobSwoje();
        }
        
        static void Blad(string msg)
        {
            Console.WriteLine($"\t {msg}.{Environment.NewLine}\t Dowolny klawisz by zacząć od nowa.");
            Console.ReadKey(true);
            Start();
        }

        static string liter(int ile)
        {
            string _ret;
            if(ile == 1)
            {
                _ret = "litera";
            }
            else if(ile > 1 && ile <5)
            {
                _ret = "litery";
            }
            else
            {
                _ret = "liter";
            }

            return _ret;
        }

        static void RobSwoje()
        {
            ConsoleKeyInfo jeszczeraz = new ConsoleKeyInfo();
            
            slowa = new List<string>();
            List<string> match = new List<string>();
            Console.Write("  > Tworzę słownik... ");
            int counter = 0;

            foreach (string item in File.ReadAllLines(slownik))
            {
                slowa.Add(item);
            }

            Console.Write($"{slowa.Count} słów w słowniku.");

            for (int i = ileOD; i <= ileDO; i++)
            {
                int row = 0;
                int cnt = 0;

                Console.Write($"{Environment.NewLine}{Environment.NewLine} [{i} {liter(i)}]:{Environment.NewLine}");

                foreach (string item in slowa)
                {
                    if (SprawdzTo(litery.ToLower(), item.ToLower(), dupl))
                    {
                        if (item.Length == i)
                        {
                            counter++;
                            if (row < 6)
                            {
                                Console.Write($" {item}\t");
                                row++;
                                cnt++;
                            }
                            else
                            {
                                Console.Write($" {item}{Environment.NewLine}");
                                row = 0;
                                cnt++;
                            }
                        }
                    }
                }

                if (cnt < 1)
                {
                    Console.Write("\t=brak=");
                }
            }

            Console.WriteLine($"{Environment.NewLine}  > Znaleziono {counter} słów.");

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine} \t Jeszcze raz [T/N]? ");
            jeszczeraz = Console.ReadKey();
            if (jeszczeraz.Key == ConsoleKey.T)
            {
                Start();
            }
            
        }


        static bool SprawdzTo(string slowo1, string slowo2)
        {
            var chars = new HashSet<char>(slowo1);
            return slowo2.All(x => chars.Contains(x));
        }

        static bool SprawdzTo(string slowo1, string slowo2, bool DuplikatyLiter)
        {
            if (DuplikatyLiter == true)
            {
                var chars = new HashSet<char>(slowo1);
                return slowo2.All(x => chars.Contains(x));
            }
            else
            {
                var chars = slowo1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
                return slowo2.GroupBy(x => x).All(g => chars.ContainsKey(g.Key) && chars[g.Key] >= g.Count());
            }
        }


    }
}
