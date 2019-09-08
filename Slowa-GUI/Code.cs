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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slowa_GUI
{
    /// <summary>
    /// Moved code... It's a mess, don't look :P
    /// </summary>
    static class Code
    {

        /// <summary>
        /// "Letter" variants
        /// </summary>
        /// <param name="ile">give me a number</param>
        /// <returns>variant</returns>
        internal static string LetterVariant(int ile)
        {
            string _ret;
            switch (ile)
            {
                case 1:
                    _ret = Properties.Resources.sLETT_VARIANT_ONE;
                    break;
                case 2:
                case 3:
                case 4:
                    _ret = Properties.Resources.sLETT_VARIANT_FOUR;
                    break;
                default:
                    _ret = Properties.Resources.sLETT_VARIANT_DEF;
                    break;
            }
            return _ret;
        }

        /// <summary>
        /// "Letter" variants
        /// </summary>
        /// <param name="ile">give me a number</param>
        /// <returns>variant</returns>
        internal static string WordVariant(int ile)
        {
            string _ret;
            switch (ile)
            {
                case 1:
                    _ret = Properties.Resources.sWORD_VARIANT_ONE;
                    break;
                case 2:
                case 3:
                case 4:
                    _ret = Properties.Resources.sWORD_VARIANT_FOUR;
                    break;
                default:
                    _ret = Properties.Resources.sWORD_VARIANT_DEF;
                    break;
            }
            return _ret;
        }

        /// <summary>
        /// Open GitHub profile page
        /// </summary>
        internal static void opnGitHubUrl()
        {
            Process ghLink = new Process();
            ghLink.StartInfo.FileName = Properties.Resources.sGH_LINK;
            ghLink.StartInfo.UseShellExecute = true;
            ghLink.Start();
        }

        /// <summary>
        /// Performe check...
        /// </summary>
        /// <param name="string1">Letters</param>
        /// <param name="string2">Word from dictionary</param>
        /// <param name="allowDuplicateLetters">Allow to use letters duplicates?</param>
        /// <returns>true if fit</returns>
        internal static bool CheckIt(string string1, string string2, bool allowDuplicateLetters)
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

        internal static DialogResult ShowFindDictionaryWindow(bool CloseOnCancel)
        {
            opnDialog.Filter = "Txt files (*.txt)|*.txt|Dictionary files (*.dic)|*.dic|All files|*.*";
            opnDialog.FileName = dictionaryFile;
            opnDialog.CheckFileExists = true;
            opnDialog.CheckPathExists = true;
            opnDialog.Multiselect = false;
            opnDialog.Title = Properties.Resources.sOPN_DIC_TITLE;
            return opnDialog.ShowDialog();
        }

        internal static DialogResult ShowFindDictionaryWindow()
        {
            return ShowFindDictionaryWindow(true);
        }

        internal static void PW(string word)
        {
            OutputWB.Document.Write($"{word}");
            try
            {
                if (OutputWB.Document.Body.All.Count > 0)
                {
                    OutputWB.Document.Body.All[OutputWB.Document.Body.All.Count - 1].ScrollIntoView(false);
                }
            }
            catch { }
        }

        internal static void LoadDictionary()
        {
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
                    PW($"<pre> {Properties.Resources.sERROR}: {ex.Message}</pre>");
                }
            }
        }

        internal static void StartThread()
        {
            bgThread.Priority = ThreadPriority.Highest;
            bgThread.IsBackground = false;
            bgThread.Start();
        }

        /// <summary>
        /// Save file...
        /// </summary>
        internal static void SaveOutputAsFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = $"{Properties.Resources.sSAVE_EXT_TXT}|*.txt|{Properties.Resources.sSAVE_EXT_HTML}|*.html";
            if (_savePath == string.Empty)
            {
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                saveFile.InitialDirectory = _savePath;
            }

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string _pat = _Pattern;
                string _opt = string.Empty;
                if(_pat.Length < 2)
                {
                    _pat = Properties.Resources.sSAVE_PATT;
                }
                if (_Duplicates)
                {
                    _opt = $"{Environment.NewLine}{Properties.Resources.sSAVE_OPTION_DUPLIACATES}";
                }

                string ext = Path.GetExtension(saveFile.FileName);
                // as txt file with tabulation
                if (ext == ".txt")
                {
                    string doc = $"\t{Properties.Resources.sSAVE_GEN_BY} {Properties.Resources.sPROGRAM_TITLE} v.{Program.Version}{Environment.NewLine}" +
                        $"\t{Properties.Resources.sGH_LINK}{Environment.NewLine}{Environment.NewLine}" +
                        string.Format(Properties.Resources.sSAVE_SEARCH_INFO, _Letters, _LettFrom, _LettTo) +
                        $"{Environment.NewLine}{Properties.Resources.sSAVE_USED_SEARCH_PATTERN}: {_pat}{_opt}" +
                        $"{Environment.NewLine}{Sep()}{Environment.NewLine}" +
                        $"{OutputWB.DocumentText} {Environment.NewLine}{Environment.NewLine}" +
                        string.Format(Properties.Resources.sSAVE_COUNTER, counter) +
                        $"{Environment.NewLine}{Environment.NewLine}{Properties.Resources.sSAVE_GEN_BY} {Properties.Resources.sPROGRAM_TITLE} " +
                        $"v.{Program.Version}{Environment.NewLine}" +
                        $"\t{Properties.Resources.sGH_LINK}";

                    doc = doc.Replace(cssStyle, string.Empty)
                        .Replace("<div>", "\t")
                        .Replace("</div>", string.Empty)
                        .Replace("<pre>", $"{Environment.NewLine}{Environment.NewLine}  ")
                        .Replace("</pre>", string.Empty)
                        .Replace("<!--nl-->", Environment.NewLine);
                    File.WriteAllText(saveFile.FileName, doc);
                }
                else
                {
                    // as normal html...
                    File.WriteAllText(saveFile.FileName, $"<!-- {Environment.NewLine}{Properties.Resources.sSAVE_GEN_BY_PROGRAM.ToUpper()} " +
                        $"{Properties.Resources.sPROGRAM_TITLE.ToUpper()} v.{Program.Version}{Environment.NewLine}{Environment.NewLine}-->" +
                        $"<p><a href=\"{Properties.Resources.sGH_LINK}\">{Properties.Resources.sGH_LINK}</a></p>" +
                        string.Format(Properties.Resources.sSAVE_HTML_SEARCH_INFO, _Letters, _LettFrom, _LettTo) +
                        $"<br/>{Properties.Resources.sSAVE_USED_SEARCH_PATTERN}: <b>{_pat}</b><hr></p><br/>" +
                        $"{OutputWB.DocumentText.Replace("<!--nl-->", "<br/><br/>")}<p>" +
                        string.Format(Properties.Resources.sSAVE_HTML_COUNTER, counter) +
                        $"<br/></p><p><br/><a href=\"{Properties.Resources.sGH_LINK}\">{Properties.Resources.sGH_LINK}</a></p>");
                }
                _savePath = Path.GetDirectoryName(saveFile.FileName);
                MessageBox.Show(string.Format(Properties.Resources.sSAVE_SAVED_AS, saveFile.FileName));
            }
        }

        static string Sep()
        {
            string _s = string.Empty;

            for (int i = 0; i < 70; i++)
            {
                _s = $"{_s}-";
            }

            return _s;
        }

        static string _savePath = string.Empty;
        internal static List<string> wordDic;
        internal static string dictionaryFile = "slowa.txt";
        internal static int counter = 0;
        internal static string _Letters, _Pattern;
        internal static int _LettFrom, _LettTo;
        internal static bool _Duplicates;
        internal static OpenFileDialog opnDialog = new OpenFileDialog();
        internal static Thread bgThread;
        internal static WebBrowser OutputWB;
        internal static int _c = 0;
        internal static string cssStyle = "<style>div {border: 1px #ccc solid; width: 150px; position: relative; display: inline; padding:5px; margin: 5px; text-align=center} body {font-size: 17px;font-family:Roboto; }</style>";
    }
}
