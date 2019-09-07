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
using System.Text.RegularExpressions;

namespace Slowa
{
    class Program
    {
        static string letters; // jakie litery
        static int lettersMin, lettersMax; // ile liter
        static string dictionaryFile = "slowa.txt"; // plik slownika
        static List<string> wordDic; // lista ze slowami
        static bool useDuplicates = false; // czy moga wystepowac duplikaty
        static int min_letters = 3;
        static bool usepatt = false;
        static string pat;

        #region Yes/No keys
        static ConsoleKey kYES = ConsoleKey.T;
        //static ConsoleKey kNO = ConsoleKey.N;
        #endregion

        static void Main(string[] args)
        {
            if (File.Exists(dictionaryFile))
            {
                wordDic = new List<string>();
                Start();
            }
            else
            {
                Console.WriteLine(string.Format(Properties.Resource.sERR_NO_DICTIONARY_FILE_FOUND, dictionaryFile));
                Console.ReadKey();
            }
        }

        static void Start()
        {
            ConsoleKeyInfo duplikaty = new ConsoleKeyInfo();
            ConsoleKeyInfo searchpatt = new ConsoleKeyInfo();

            Console.Title = "Pomocnik krzyżówkowicza.";
            Console.Clear();
            #region baner
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"\t\t Pomocnik krzyżówkowicza. ver. {Assembly.GetExecutingAssembly().GetName().Version}{Environment.NewLine}\t\t\t\t" +
                $"Słownik sjp.pl{Environment.NewLine}\t\t\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"https://github.com/sutaj {Environment.NewLine}");
            Console.ResetColor();
            #endregion

            Console.Write($" > {Properties.Resource.sWHAT_LETTERS}: \t\t\t");

            letters = Console.ReadLine();

            if (letters.Length < min_letters)
            {
                Error(String.Format(Properties.Resource.sERROR_MORE_LETTERS, letters.Length , min_letters));
            }

            if(Regex.IsMatch(letters, @"\d"))
            {
                Error(string.Format(Properties.Resource.sERR_NO_NUMBERS_ALLOWED, letters.ToUpper()));
            }

            Console.Write($" > {Properties.Resource.sUSE_SEARCH_PATTERN} ");
            searchpatt = Console.ReadKey(true);
            if (searchpatt.Key == kYES)
            {
                Console.WriteLine($"\t{Properties.Resource.sYES}");
                Console.WriteLine($"\t{Properties.Resource.sSEARCH_TIP}");
                Console.Write($" > {Properties.Resource.sSEARCH_PATTERN}:\t\t");
                Console.Write(" > ");
                pat = Console.ReadLine();
                usepatt = true;
            }
            else
            {
                Console.WriteLine($"\t{Properties.Resource.sNO}");
                usepatt = false;
            }

            Console.Write($" > {Properties.Resource.sMIN_LENGHT}: \t\t");

            if (!int.TryParse(Console.ReadLine(), out lettersMin))
            {
                Error($"{Properties.Resource.sERR_NEED_NUMBER}");
            }
            else
            {
                if (lettersMin > letters.Length)
                {
                    Error($"{Properties.Resource.sERR_TO_BIG_NUMBER}.");
                }
            }

            Console.Write($" > {Properties.Resource.sMAX_LENGHT}: \t\t\t\t");
            if (!int.TryParse(Console.ReadLine(), out lettersMax))
            {
                Error(Properties.Resource.sERR_NEED_NUMBER);
            }
            else
            {
                if (lettersMax < lettersMin)
                {
                    Error(Properties.Resource.sERR_MAX_NUMBER_TO_SMALL);
                }
            }

            Console.Write($" > {Properties.Resource.sALLOW_DUPLICATES} ");
            duplikaty = Console.ReadKey(true);

            if (duplikaty.Key == kYES)
            {
                Console.WriteLine($"\t{Properties.Resource.sYES.ToUpper()}");
                useDuplicates = true;
            }
            else
            {
                Console.WriteLine($"\t{Properties.Resource.sNO.ToUpper()}"); 
                useDuplicates = false;
            }

            Console.WriteLine($"{Environment.NewLine} ──────────────────────────────────────────────────────────{Environment.NewLine}");
            doSomeWork();
        }
        
        static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"\t {msg}.{Environment.NewLine}");
            Console.ResetColor();
            Console.WriteLine($"\t {Properties.Resource.sPRESSKEY}");
            Console.ReadKey(true);
            Start();
        }

        static string liter(int ile)
        {
            string _ret;

            if(ile == 1)
            {
                _ret = Properties.Resource.sLETTER1;
            }
            else if(ile > 1 && ile <5)
            {
                _ret = Properties.Resource.sLETTER2;
            }
            else
            {
                _ret = Properties.Resource.sLETTER3;
            }

            return _ret;
        }

        static void doSomeWork()
        {
            ConsoleKeyInfo doAgain = new ConsoleKeyInfo();
            
            Console.Write($"  > {Properties.Resource.sCREATING_DICTIONARY}... ");
            int counter = 0;

            if (wordDic.Count < 1)
            {
                try
                {
                    foreach (string item in File.ReadAllLines(dictionaryFile))
                    {
                        wordDic.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Error(string.Format(Properties.Resource.sERR_DIC_LOAD, ex.Message));
                }
            }

            Console.Write($"{wordDic.Count} {Properties.Resource.sWORDS_IN_DICTIONARY}.");

            #region Debug
#if DEBUG
            var watch = System.Diagnostics.Stopwatch.StartNew();
#endif
            #endregion

            for (int i = lettersMin; i <= lettersMax; i++)
            {
                int row = 0;
                int cnt = 0;
                Console.Write($"{Environment.NewLine}{Environment.NewLine} [{i} {liter(i)}]:{Environment.NewLine}");

                if (!usepatt)
                {
                    #region normal search
                    foreach (string item in wordDic)
                    {
                        if (item.Length == i)
                        {
                            if (CheckIt(letters.ToLower(), item.ToLower(), useDuplicates))
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
                    #endregion
                }
                else
                {
                    #region search with pattern
                    string pattern = string.Empty;
                    Match m;
                    pattern = $"\\b{pat.Replace("*", "\\w")}\\b"; //"\ba\w*\b";    

                    foreach (string item in wordDic)
                    {
                        m = Regex.Match(item, pattern, RegexOptions.IgnoreCase);
                        if (item.Length == i)
                        {
                            if (CheckIt(letters.ToLower(), item.ToLower(), useDuplicates) && m.Success)
                            {
                                counter++;
                                if (row < 6)
                                {
                                    Console.Write($"{item}\t");
                                    row++;
                                    cnt++;
                                }
                                else
                                {

                                    Console.Write($"{item}{Environment.NewLine}");
                                    row = 0;
                                    cnt++;
                                }
                            }
                        }
                    }
                    #endregion
                }

                #region counter is 0
                if (cnt < 1)
                {
                    Console.Write($"\t={Properties.Resource.sEMPTY}=");
                }
                #endregion
            }

            #region Debug
#if DEBUG
            watch.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\t\t");
            Console.WriteLine($"{Environment.NewLine}\t\t{TimeSpan.FromTicks(watch.ElapsedTicks).Minutes} : {TimeSpan.FromTicks(watch.ElapsedTicks).Seconds} . {TimeSpan.FromTicks(watch.ElapsedTicks).Milliseconds}");
            Console.ResetColor();
#endif
            #endregion

            Console.WriteLine(string.Format(Environment.NewLine + Properties.Resource.sWORDS_FOUND, counter, Environment.NewLine));

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine} \t {Properties.Resource.sAGAIN}? ");            

            doAgain = Console.ReadKey();
            if (doAgain.Key == kYES)
            {
                Start();
            }
            
        }

        static bool CheckIt(string string1, string string2, bool allowDuplicateLetters)
        {
            if (allowDuplicateLetters == true)
            {
                var chars = new HashSet<char>(string1);
                return string2.All(x => chars.Contains(x));
            }
            else
            {
                var chars = string1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
                return string2.GroupBy(x => x).All(g => chars.ContainsKey(g.Key) && chars[g.Key] >= g.Count());
            }

        }

    }
}
