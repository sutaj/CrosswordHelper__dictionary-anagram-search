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
namespace Slowa_GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lnkGithub = new System.Windows.Forms.LinkLabel();
            this.blVer = new System.Windows.Forms.Label();
            this._cPattTip = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this._cDupl = new System.Windows.Forms.CheckBox();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this._cPatt = new System.Windows.Forms.Label();
            this.nMaxLetters = new System.Windows.Forms.NumericUpDown();
            this._cMax = new System.Windows.Forms.Label();
            this.nMinLetters = new System.Windows.Forms.NumericUpDown();
            this._cMin = new System.Windows.Forms.Label();
            this.txtLetters = new System.Windows.Forms.TextBox();
            this._cLetters = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.WebBrowser();
            this.mnuCont = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCounter = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.sep = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinLetters)).BeginInit();
            this.mnuCont.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.Window;
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.lnkGithub);
            this.panelTop.Controls.Add(this.blVer);
            this.panelTop.Controls.Add(this._cPattTip);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this._cDupl);
            this.panelTop.Controls.Add(this.txtPattern);
            this.panelTop.Controls.Add(this._cPatt);
            this.panelTop.Controls.Add(this.nMaxLetters);
            this.panelTop.Controls.Add(this._cMax);
            this.panelTop.Controls.Add(this.nMinLetters);
            this.panelTop.Controls.Add(this._cMin);
            this.panelTop.Controls.Add(this.txtLetters);
            this.panelTop.Controls.Add(this._cLetters);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(714, 164);
            this.panelTop.TabIndex = 0;
            // 
            // lnkGithub
            // 
            this.lnkGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkGithub.Image = global::Slowa_GUI.Properties.Resources.iGitHub;
            this.lnkGithub.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lnkGithub.Location = new System.Drawing.Point(15, 137);
            this.lnkGithub.Name = "lnkGithub";
            this.lnkGithub.Size = new System.Drawing.Size(156, 16);
            this.lnkGithub.TabIndex = 12;
            this.lnkGithub.TabStop = true;
            this.lnkGithub.Text = "https://github.com/sutaj/";
            this.lnkGithub.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tTip.SetToolTip(this.lnkGithub, global::Slowa_GUI.Properties.Resources.sGUI_OPEN_GH_TIP);
            this.lnkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGithub_LinkClicked);
            // 
            // blVer
            // 
            this.blVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.blVer.AutoSize = true;
            this.blVer.Location = new System.Drawing.Point(15, 117);
            this.blVer.Name = "blVer";
            this.blVer.Size = new System.Drawing.Size(58, 13);
            this.blVer.TabIndex = 11;
            this.blVer.Text = "ver.0.0.0.0";
            // 
            // _cPattTip
            // 
            this._cPattTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cPattTip.AutoSize = true;
            this._cPattTip.Location = new System.Drawing.Point(592, 92);
            this._cPattTip.Name = "_cPattTip";
            this._cPattTip.Size = new System.Drawing.Size(105, 26);
            this._cPattTip.TabIndex = 10;
            this._cPattTip.Text = "* jako nieznana litera\r\nnp. kw**t";
            this._cPattTip.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(622, 123);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "_SEARCH_";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // _cDupl
            // 
            this._cDupl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cDupl.AutoSize = true;
            this._cDupl.Location = new System.Drawing.Point(548, 47);
            this._cDupl.Name = "_cDupl";
            this._cDupl.Size = new System.Drawing.Size(149, 17);
            this._cDupl.TabIndex = 8;
            this._cDupl.Text = "_ALLOW_DUPLICATES_";
            this._cDupl.UseVisualStyleBackColor = true;
            // 
            // txtPattern
            // 
            this.txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPattern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPattern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPattern.Location = new System.Drawing.Point(115, 69);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(583, 20);
            this.txtPattern.TabIndex = 7;
            this.tTip.SetToolTip(this.txtPattern, "* jako nieznana litera\r\nnp. kw**t");
            this.txtPattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPattern_KeyDown);
            this.txtPattern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPattern_KeyPress);
            // 
            // _cPatt
            // 
            this._cPatt.AutoSize = true;
            this._cPatt.Location = new System.Drawing.Point(12, 72);
            this._cPatt.Name = "_cPatt";
            this._cPatt.Size = new System.Drawing.Size(70, 13);
            this._cPatt.TabIndex = 6;
            this._cPatt.Text = "_PATTERN_";
            // 
            // nMaxLetters
            // 
            this.nMaxLetters.Location = new System.Drawing.Point(279, 44);
            this.nMaxLetters.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nMaxLetters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nMaxLetters.Name = "nMaxLetters";
            this.nMaxLetters.Size = new System.Drawing.Size(43, 20);
            this.nMaxLetters.TabIndex = 5;
            this.nMaxLetters.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nMaxLetters.ValueChanged += new System.EventHandler(this.NMaxLetters_ValueChanged);
            this.nMaxLetters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NMaxLetters_KeyDown);
            // 
            // _cMax
            // 
            this._cMax.AutoSize = true;
            this._cMax.Location = new System.Drawing.Point(164, 45);
            this._cMax.Name = "_cMax";
            this._cMax.Size = new System.Drawing.Size(97, 13);
            this._cMax.TabIndex = 4;
            this._cMax.Text = "_MAX_LETTERS_";
            // 
            // nMinLetters
            // 
            this.nMinLetters.Location = new System.Drawing.Point(115, 43);
            this.nMinLetters.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nMinLetters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nMinLetters.Name = "nMinLetters";
            this.nMinLetters.Size = new System.Drawing.Size(43, 20);
            this.nMinLetters.TabIndex = 3;
            this.nMinLetters.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nMinLetters.ValueChanged += new System.EventHandler(this.NMinLetters_ValueChanged);
            this.nMinLetters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NMinLetters_KeyDown);
            // 
            // _cMin
            // 
            this._cMin.AutoSize = true;
            this._cMin.Location = new System.Drawing.Point(12, 46);
            this._cMin.Name = "_cMin";
            this._cMin.Size = new System.Drawing.Size(94, 13);
            this._cMin.TabIndex = 2;
            this._cMin.Text = "_MIN_LETTERS_";
            // 
            // txtLetters
            // 
            this.txtLetters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetters.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLetters.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLetters.Location = new System.Drawing.Point(115, 17);
            this.txtLetters.Name = "txtLetters";
            this.txtLetters.Size = new System.Drawing.Size(582, 20);
            this.txtLetters.TabIndex = 1;
            this.txtLetters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLetters_KeyDown);
            this.txtLetters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLetters_KeyPress);
            // 
            // _cLetters
            // 
            this._cLetters.AutoSize = true;
            this._cLetters.Location = new System.Drawing.Point(12, 20);
            this._cLetters.Name = "_cLetters";
            this._cLetters.Size = new System.Drawing.Size(95, 13);
            this._cLetters.TabIndex = 0;
            this._cLetters.Text = "_LETTERS_SET_";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.ContextMenuStrip = this.mnuCont;
            this.txtOutput.IsWebBrowserContextMenuEnabled = false;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScriptErrorsSuppressed = true;
            this.txtOutput.Size = new System.Drawing.Size(709, 384);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.txtOutput.WebBrowserShortcutsEnabled = false;
            // 
            // mnuCont
            // 
            this.mnuCont.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExport});
            this.mnuCont.Name = "mnuCont";
            this.mnuCont.Size = new System.Drawing.Size(124, 26);
            // 
            // mnuExport
            // 
            this.mnuExport.Enabled = false;
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(123, 22);
            this.mnuExport.Text = global::Slowa_GUI.Properties.Resources.sGUI_MNU_EXPORT;
            this.mnuExport.ToolTipText = "Zapisuje wyniki jako\r\ndokument html - jak widoczny w oknie\r\nlub\r\ndokument tekstow" +
    "y - formatowany tabulacją.";
            this.mnuExport.Click += new System.EventHandler(this.MnuExport_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtOutput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 411);
            this.panel1.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.lblCounter);
            this.panelBottom.Controls.Add(this.pBar);
            this.panelBottom.Controls.Add(this.sep);
            this.panelBottom.Controls.Add(this.lblTime);
            this.panelBottom.Location = new System.Drawing.Point(0, 550);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelBottom.Size = new System.Drawing.Size(714, 25);
            this.panelBottom.TabIndex = 3;
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(3, 5);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(16, 13);
            this.lblCounter.TabIndex = 0;
            this.lblCounter.Text = "   ";
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(25, 8);
            this.pBar.MarqueeAnimationSpeed = 25;
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(250, 10);
            this.pBar.Step = 2;
            this.pBar.TabIndex = 1;
            this.pBar.Visible = false;
            // 
            // sep
            // 
            this.sep.AutoSize = true;
            this.sep.Location = new System.Drawing.Point(281, 5);
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(21, 13);
            this.sep.TabIndex = 2;
            this.sep.Text = "  |  ";
            this.sep.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(308, 5);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 3;
            // 
            // tTip
            // 
            this.tTip.IsBalloon = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 575);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(525, 350);
            this.Name = "frmMain";
            this.Text = "_PROGRAM_TITLE_";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxLetters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinLetters)).EndInit();
            this.mnuCont.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.NumericUpDown nMaxLetters;
        private System.Windows.Forms.Label _cMax;
        private System.Windows.Forms.NumericUpDown nMinLetters;
        private System.Windows.Forms.Label _cMin;
        private System.Windows.Forms.TextBox txtLetters;
        private System.Windows.Forms.Label _cLetters;
        private System.Windows.Forms.Label _cPattTip;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox _cDupl;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label _cPatt;
        private System.Windows.Forms.WebBrowser txtOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.LinkLabel lnkGithub;
        private System.Windows.Forms.Label blVer;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label sep;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ContextMenuStrip mnuCont;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
    }
}

