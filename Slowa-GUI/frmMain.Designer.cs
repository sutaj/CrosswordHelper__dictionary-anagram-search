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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lnkGithub = new System.Windows.Forms.LinkLabel();
            this.blVer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkDuplicates = new System.Windows.Forms.CheckBox();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nMaxLetters = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nMinLetters = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLetters = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCounter = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxLetters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinLetters)).BeginInit();
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
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.chkDuplicates);
            this.panelTop.Controls.Add(this.txtPattern);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.nMaxLetters);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.nMinLetters);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.txtLetters);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(714, 164);
            this.panelTop.TabIndex = 0;
            // 
            // lnkGithub
            // 
            this.lnkGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkGithub.Image = global::Slowa_GUI.Properties.Resources.iconfinder_logo_github_298818;
            this.lnkGithub.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lnkGithub.Location = new System.Drawing.Point(15, 137);
            this.lnkGithub.Name = "lnkGithub";
            this.lnkGithub.Size = new System.Drawing.Size(150, 16);
            this.lnkGithub.TabIndex = 12;
            this.lnkGithub.TabStop = true;
            this.lnkGithub.Text = "https://github.com/sutaj";
            this.lnkGithub.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tTip.SetToolTip(this.lnkGithub, "Otwórz adres GitHub");
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
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "* jako nieznana litera\r\nnp. kw**t";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(625, 123);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Szukaj";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // chkDuplicates
            // 
            this.chkDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDuplicates.AutoSize = true;
            this.chkDuplicates.Location = new System.Drawing.Point(561, 47);
            this.chkDuplicates.Name = "chkDuplicates";
            this.chkDuplicates.Size = new System.Drawing.Size(139, 17);
            this.chkDuplicates.TabIndex = 8;
            this.chkDuplicates.Text = "Zezwól na duplikaty liter";
            this.chkDuplicates.UseVisualStyleBackColor = true;
            // 
            // txtPattern
            // 
            this.txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPattern.Location = new System.Drawing.Point(100, 69);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(601, 20);
            this.txtPattern.TabIndex = 7;
            this.tTip.SetToolTip(this.txtPattern, "Wpisz * jako nieznany znak \r\nnp. Kw**t*k");
            this.txtPattern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPattern_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Wzorzec";
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
            3,
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Maksymalna ilość liter";
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
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minimalna ilość liter";
            // 
            // txtLetters
            // 
            this.txtLetters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetters.Location = new System.Drawing.Point(100, 17);
            this.txtLetters.Name = "txtLetters";
            this.txtLetters.Size = new System.Drawing.Size(600, 20);
            this.txtLetters.TabIndex = 1;
            this.txtLetters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLetters_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zestaw znaków";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.IsWebBrowserContextMenuEnabled = false;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScriptErrorsSuppressed = true;
            this.txtOutput.Size = new System.Drawing.Size(712, 384);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.txtOutput.WebBrowserShortcutsEnabled = false;
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
            this.pBar.Size = new System.Drawing.Size(297, 10);
            this.pBar.Step = 2;
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pBar.TabIndex = 1;
            this.pBar.Visible = false;
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
            this.MinimumSize = new System.Drawing.Size(525, 350);
            this.Name = "frmMain";
            this.Text = "Pomocnik Krzyżówkowicza";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaxLetters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMinLetters)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.NumericUpDown nMaxLetters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nMinLetters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLetters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkDuplicates;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser txtOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.LinkLabel lnkGithub;
        private System.Windows.Forms.Label blVer;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.ProgressBar pBar;
    }
}

