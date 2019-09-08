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
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static Slowa_GUI.Code;

namespace Slowa_GUI
{
    public partial class frmMain : Form
    {
        System.Windows.Forms.Timer ticker = new System.Windows.Forms.Timer();

        #region form setup
        public frmMain()
        {
            InitializeComponent();
            OutputWB = txtOutput;
            #region [  Events  ]
            txtOutput.DocumentCompleted += prepOutput;
            ticker.Interval = 200;
            ticker.Tick += Tick;
            #endregion
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadGuiStrings();
            
            ticker.Start();

            if (File.Exists(dictionaryFile))
            {
                wordDic = new List<string>();
            }
            else
            {
                DialogResult _d = ShowFindDictionaryWindow();
                dictionaryFile = opnDialog.FileName;
                MessageBox.Show($"{dictionaryFile}");
                if (_d != DialogResult.OK || !File.Exists(dictionaryFile))
                {
                    MessageBox.Show(string.Format(Properties.Resources.sERROR_NO_DICTIONARY, dictionaryFile, Environment.NewLine),Properties.Resources.sERROR_NO_DIC_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    wordDic = new List<string>();
                }
            }

            PrintWord(string.Format($"<pre>{Properties.Resources.sPROGRAM_READY_OUT}</pre>", Properties.Resources.sPROGRAM_TITLE));
        }
        #endregion

        #region thread start / stop
        private void StartThreadJob()
        {
            this.Invoke((Action)delegate
            {
                DisableElements();
            });

            counter = 0;

            LoadDictionary();

            bgThread = new Thread(new ThreadStart(PerformSearch));
            StartThread();
        }

        private void JobDone()
        {
            this.Invoke((Action)delegate {
                EnableElements();
            });
        }
        #endregion

        #region Main search function
        private void PerformSearch()
        {
            _c = 0; // track progress for progressbar
            this.Invoke((Action)delegate
            {
                pBar.Maximum = wordDic.Count * (_LettTo + 1 - _LettFrom);
            });

            Stopwatch watch = Stopwatch.StartNew();

            for (int i = _LettFrom; i <= _LettTo; i++)
            {
                int row = 0;
                int cnt = 0;
                if (i == _LettFrom)
                {
                    Thread.Sleep(250); // thread catch up on 1st run
                }
                PrintWord($"<pre>[{i} {Code.LetterVariant(i)}]:{Environment.NewLine}</pre>");

                if (_Pattern.Length < 2) // no pattern search
                {
                    #region normal search
                    foreach (string item in wordDic)
                    {
                        _c++;
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
                                    PrintWord($"<div>{item}</div><!--nl-->");
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
                    pattern = $"\\b{_Pattern.ToLower().Replace("*", "\\w")}\\b";  

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
                                    PrintWord($"<div>{item}</div><!--nl-->");
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
                    PrintWord($"<pre>{Properties.Resources.sNONE}</pre>");
                }
                #endregion   
            }

            #region execution time
            watch.Stop();
            this.Invoke((Action)delegate
            {
                sep.Visible = true;

                lblTime.Text = string.Format(Properties.Resources.sEXECUTION_TIME, 
                    TimeSpan.FromTicks(watch.ElapsedTicks).Minutes,
                    TimeSpan.FromTicks(watch.ElapsedTicks).Seconds,
                    TimeSpan.FromTicks(watch.ElapsedTicks).Milliseconds);
            });
            #endregion

            JobDone();
        }
        #endregion

        private void PrintWord(string word)
        {
            try
            {
                this.Invoke((Action)delegate
                {
                    PW(word);
                });
            }
            catch { }
        }

        #region Junk Code
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text != Properties.Resources.sBTN_STOP)
            {
                if (txtLetters.Text.Length < 2)
                {
                    MessageBox.Show(Properties.Resources.sERROR_SMALL_LETTER_COUNT);
                }
                else
                {
                    DialogResult mb = DialogResult.OK;
                    if(txtLetters.Text.Length < (int)nMaxLetters.Value && !_cDupl.Checked)
                    {
                        mb = MessageBox.Show(string.Format(Properties.Resources.sLETTER_WARNING, Environment.NewLine), Properties.Resources.sLETTER_WARNING_TITLE,
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    if (mb == DialogResult.OK)
                    {
                        // assign some varibles
                        txtOutput.Navigate("about:blank");
                        _Letters = txtLetters.Text.ToLower();
                        _Pattern = txtPattern.Text; // can be empty - if empty don't use pattern
                        _Duplicates = _cDupl.Checked;
                        _LettFrom = (int)nMinLetters.Value;
                        _LettTo = (int)nMaxLetters.Value;
                        txtLetters.AutoCompleteCustomSource.Add(_Letters); // add to autocomplete
                        txtPattern.AutoCompleteCustomSource.Add(_Pattern); // add to autocomplete
                        StartThreadJob();
                    }
                }
            }
            else
            {
                bgThread.Abort();
                txtOutput.Navigate("about:blank");
            }
        }

        private void DisableElements()
        {
            txtLetters.Enabled = false;
            txtPattern.Enabled = false;
            nMaxLetters.Enabled = false;
            nMinLetters.Enabled = false;
            _cDupl.Enabled = false;
            mnuExport.Enabled = false;
            btnSearch.Text = Properties.Resources.sBTN_STOP;
            pBar.Visible = true;
        }

        private void EnableElements()
        {
            txtLetters.Enabled = true;
            txtPattern.Enabled = true;
            nMaxLetters.Enabled = true;
            nMinLetters.Enabled = true;
            _cDupl.Enabled = true;
            mnuExport.Enabled = true;
            btnSearch.Text = Properties.Resources.sBTN_SEARCH;
            pBar.Visible = false;
            lblCounter.Text = string.Format(Properties.Resources.sWORD_COUNTER, counter, WordVariant(counter));
            txtLetters.Focus();
        }

        private void Tick(object sender, EventArgs e)
        {
            if (bgThread != null && bgThread.ThreadState == System.Threading.ThreadState.Aborted)
            {
                JobDone();
            }
            if (bgThread != null && bgThread.ThreadState == System.Threading.ThreadState.Running)
            {
                try
                {
                    pBar.Value = _c;
                }
                catch { }

                if (lblCounter.Text != string.Format(Properties.Resources.sWORD_COUNTER, counter, WordVariant(counter)))
                {
                    lblCounter.Text = string.Format(Properties.Resources.sWORD_COUNTER, counter, WordVariant(counter));
                }
            }
        }

        private void prepOutput(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            PrintWord(cssStyle);
        }

        private void LnkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            opnGitHubUrl();
        }

        private void TxtLetters_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zĄĆĘŁŃÓŚŹŻA-Ząćęłńóśźż]+$") && e.KeyChar != '\b') // Letters ONLY!... and backspace
            {
                e.Handled = true;
            }
        }

        private void TxtPattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zĄĆĘŁŃÓŚŹŻA<*>-Ząćęłńóśźż<*>]+$") && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void NMaxLetters_ValueChanged(object sender, EventArgs e)
        {
            if(nMaxLetters.Value < nMinLetters.Value)
            {
                nMaxLetters.Value = nMinLetters.Value;
            }
        }

        private void NMinLetters_ValueChanged(object sender, EventArgs e)
        {
            if (nMaxLetters.Value < nMinLetters.Value)
            {
                nMaxLetters.Value = nMinLetters.Value;
            }
        }

        private void TxtLetters_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }

        private void NMinLetters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }

        private void NMaxLetters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }

        private void TxtPattern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }

        private void MnuExport_Click(object sender, EventArgs e)
        {
            SaveOutputAsFile();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgThread != null && bgThread.ThreadState == System.Threading.ThreadState.Running)
            {
                bgThread.Abort();
            }
        }

        private void LoadGuiStrings()
        {
            this.Text = Properties.Resources.sPROGRAM_TITLE;
            blVer.Text = $"ver.{Application.ProductVersion}";
            _cDupl.Text = Properties.Resources.sGUI_ALLOW_DUPLICATES;
            _cLetters.Text = Properties.Resources.sGUI_LETTERS;
            _cMax.Text = Properties.Resources.sGUI_MAX_LETTERS;
            _cMin.Text = Properties.Resources.sGUI_MIN_LETTERS;
            _cPatt.Text = Properties.Resources.sGUI_PATTERN;
            _cPattTip.Text = string.Format(Properties.Resources.sGUI_PATTERN_INFO, "\r\n");
            btnSearch.Text = Properties.Resources.sBTN_SEARCH;
            // load tooltips
            tTip.SetToolTip(txtPattern, string.Format(Properties.Resources.sGUI_PATTERN_INFO,"\r\n"));
            tTip.SetToolTip(lnkGithub, Properties.Resources.sGUI_OPEN_GH_TIP);
            mnuExport.ToolTipText = string.Format(Properties.Resources.sGUI_MNU_EXPORT_TIP, Environment.NewLine);
        }

        #endregion
    }

}
