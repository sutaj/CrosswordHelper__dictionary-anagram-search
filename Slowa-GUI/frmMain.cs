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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Slowa_GUI
{
    public partial class frmMain : Form
    {
        List<string> wordDic;
        string dictionaryFile = "slowa.txt";
        int counter = 0;
        Thread bgThread;
        System.Windows.Forms.Timer ticker = new System.Windows.Forms.Timer();

        string _Letters, _Pattern;
        int _LettFrom, _LettTo;
        bool _Duplicates;

        public frmMain()
        {
            InitializeComponent();
            #region [  Events  ]
            txtOutput.DocumentCompleted += prepOutput;
            ticker.Interval = 200;
            ticker.Tick += Tick;
            #endregion
        }

        #region [  Background Work  ]

        private void StartThreadJob()
        {
            this.Invoke((Action)delegate
            {
                btnSearch.Text = "Stop";
                pBar.Visible = true;
            });

            counter = 0;

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
                    PrintWord($"<pre> Błąd: {ex.Message}</pre>");
                }
            }

            bgThread = new Thread(new ThreadStart(DoWork));
            bgThread.Priority = ThreadPriority.Highest;
            bgThread.IsBackground = false;
            bgThread.Start();
        }

        private void JobDone()
        {
            this.Invoke((Action)delegate {
                btnSearch.Text = "Szukaj";
                pBar.Visible = false;
                lblCounter.Text = $"Znaleziono {counter} {liter(counter)}.";
            });
        }

        private void DoWork()
        {
            #region debug
#if DEBUG
            Stopwatch watch = Stopwatch.StartNew();
#endif
            #endregion
            for (int i = _LettFrom; i <= _LettTo; i++)
            {
                int row = 0;
                int cnt = 0;
                if (i == _LettFrom)
                {
                    Thread.Sleep(250); // thread catch up on 1st run
                }
                PrintWord($"<pre>[{i} {liter(i)}]:{Environment.NewLine}</pre>");

                if (_Pattern.Length < 2) // no pattern search
                {
                    #region normal search
                    foreach (string item in wordDic)
                    {
                        if (item.Length == i)
                        {
                            if (CheckIt(_Letters, item.ToLower(), _Duplicates))
                            {
                                counter++;
                                if (row < 6)
                                {
                                    PrintWord($"<div>{item}</div>");
                                    row++;
                                    cnt++;
                                }
                                else
                                {
                                    PrintWord($"<div>{item}</div>");
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
                    pattern = $"\\b{_Pattern.ToLower().Replace("*", "\\w")}\\b"; //"\ba\w*\b";    

                    foreach (string item in wordDic)
                    {
                        if (item.Length == i)
                        {
                            m = Regex.Match(item, pattern, RegexOptions.IgnoreCase);
                            if (CheckIt(_Letters, item.ToLower(), _Duplicates) && m.Success)
                            {
                                counter++;
                                if (row < 6)
                                {
                                    PrintWord($"<div>{item}</div>");
                                    row++;
                                    cnt++;
                                }
                                else
                                {
                                    PrintWord($"<div>{item}</div>");
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
                    PrintWord("<pre>=brak=</pre>");
                }
                #endregion   
            }
            #region debug
#if DEBUG
            watch.Stop();
            long exectime = watch.ElapsedMilliseconds;
            Debug.WriteLine(exectime);
#endif
            #endregion
            JobDone();
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            blVer.Text = $"ver.{Application.ProductVersion}";
            ticker.Start();

            if (File.Exists(dictionaryFile))
            {
                wordDic = new List<string>();
            }
            else
            {
                PrintWord("<h2>Plik słownika nie został znaleziony!</h2>");
            }

            PrintWord($"<pre>{this.Text} Gotowy.</pre>");
        }

        private void PrintWord(string word)
        {
            this.Invoke((Action)delegate
            {
                txtOutput.Document.Write($"{word}");
                try
                {
                    if (txtOutput.Document.Body.All.Count > 0)
                    {
                        txtOutput.Document.Body.All[txtOutput.Document.Body.All.Count - 1].ScrollIntoView(false);
                    }
                }
                catch { }
            });
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text != "Stop")
            {
                // assign some varibles
                if (txtLetters.Text.Length < 2)
                {
                    MessageBox.Show("Za mało liter. Wypełnij pola poprawnie");
                }
                else
                {
                    txtOutput.Navigate("about:blank");
                    _Letters = txtLetters.Text.ToLower();
                    _Pattern = txtPattern.Text; // can be empty
                    _Duplicates = chkDuplicates.Checked;
                    _LettFrom = (int)nMinLetters.Value;
                    _LettTo = (int)nMaxLetters.Value;
                    StartThreadJob();
                }
            }
            else
            {
                bgThread.Abort();
                txtOutput.Navigate("about:blank");
            }
        }


        bool CheckIt(string string1, string string2, bool allowDuplicateLetters)
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

        #region Junk Code

        string liter(int ile)
        {
            string _ret;
            switch (ile)
            {
                case 1:
                    _ret = "litera";
                    break;
                case 2:
                case 3:
                case 4:
                    _ret = "litery";
                    break;
                default:
                    _ret = "liter";
                    break;
            }

            return _ret;
        }

        private void LnkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process ghLink = new Process();
            ghLink.StartInfo.FileName = "https://github.com/sutaj";
            ghLink.StartInfo.UseShellExecute = true;
            ghLink.Start();
        }

        private void TxtLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), @"\d"))
            {
                e.Handled = true;
            }
        }

        private void TxtPattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), @"\d"))
            {
                e.Handled = true;
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            if (bgThread != null && bgThread.ThreadState == System.Threading.ThreadState.Aborted)
            {
                JobDone();
            }
            if (bgThread != null && bgThread.ThreadState == System.Threading.ThreadState.Running)
            {
                if (lblCounter.Text != $"Znaleziono {counter} {liter(counter)}.")
                {
                    lblCounter.Text = $"Znaleziono {counter} {liter(counter)}.";
                }
            }
        }

        private void prepOutput(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            PrintWord("<style>div {border: 1px #ccc solid; width: 150px; position: relative; display: inline; padding:5px; margin: 5px; text-align=center} body {font-size: 17px;font-family:Roboto; }</style>");
        }

        #endregion
    }
}
