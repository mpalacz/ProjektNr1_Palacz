
namespace ProjektNr1_Palacz
{
    partial class ProjektNr1_Palacz53262
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
            this.mpTCZakladki = new System.Windows.Forms.TabControl();
            this.mpTabPage1 = new System.Windows.Forms.TabPage();
            this.mpBTNKupno = new System.Windows.Forms.Button();
            this.mpBTNWyplata = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mpTabPage2 = new System.Windows.Forms.TabPage();
            this.mpDataGridView1 = new System.Windows.Forms.DataGridView();
            this.LiczbaNominalow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WartoscNominalu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RodzajNominalu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RodzajWaluty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mpRDBUstawienieKontrolowane = new System.Windows.Forms.RadioButton();
            this.mpRDBUstawienieDomyslne = new System.Windows.Forms.RadioButton();
            this.mpCMBRodzajWaluty = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mpTabPage3 = new System.Windows.Forms.TabPage();
            this.mpBTNZamknij = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.mpTCZakladki.SuspendLayout();
            this.mpTabPage1.SuspendLayout();
            this.mpTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mpDataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.mpTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mpTCZakladki
            // 
            this.mpTCZakladki.Controls.Add(this.mpTabPage1);
            this.mpTCZakladki.Controls.Add(this.mpTabPage2);
            this.mpTCZakladki.Controls.Add(this.mpTabPage3);
            this.mpTCZakladki.Location = new System.Drawing.Point(13, 13);
            this.mpTCZakladki.Name = "mpTCZakladki";
            this.mpTCZakladki.SelectedIndex = 0;
            this.mpTCZakladki.Size = new System.Drawing.Size(1279, 593);
            this.mpTCZakladki.TabIndex = 0;
            this.mpTCZakladki.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcZakladki_Selecting);
            // 
            // mpTabPage1
            // 
            this.mpTabPage1.BackColor = System.Drawing.Color.Tomato;
            this.mpTabPage1.Controls.Add(this.mpBTNZamknij);
            this.mpTabPage1.Controls.Add(this.mpBTNKupno);
            this.mpTabPage1.Controls.Add(this.mpBTNWyplata);
            this.mpTabPage1.Controls.Add(this.label1);
            this.mpTabPage1.Location = new System.Drawing.Point(4, 28);
            this.mpTabPage1.Name = "mpTabPage1";
            this.mpTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.mpTabPage1.Size = new System.Drawing.Size(1271, 561);
            this.mpTabPage1.TabIndex = 0;
            this.mpTabPage1.Text = "Pulpit";
            // 
            // mpBTNKupno
            // 
            this.mpBTNKupno.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mpBTNKupno.Location = new System.Drawing.Point(786, 222);
            this.mpBTNKupno.Name = "mpBTNKupno";
            this.mpBTNKupno.Size = new System.Drawing.Size(200, 43);
            this.mpBTNKupno.TabIndex = 2;
            this.mpBTNKupno.Text = "Automat vendingowy";
            this.mpBTNKupno.UseVisualStyleBackColor = true;
            this.mpBTNKupno.Click += new System.EventHandler(this.btnKupno_Click);
            // 
            // mpBTNWyplata
            // 
            this.mpBTNWyplata.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mpBTNWyplata.Location = new System.Drawing.Point(302, 222);
            this.mpBTNWyplata.Name = "mpBTNWyplata";
            this.mpBTNWyplata.Size = new System.Drawing.Size(200, 43);
            this.mpBTNWyplata.TabIndex = 1;
            this.mpBTNWyplata.Text = "Bankomat";
            this.mpBTNWyplata.UseVisualStyleBackColor = true;
            this.mpBTNWyplata.Click += new System.EventHandler(this.btnWyplata_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(295, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(691, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "                      Witamy serdecznie\r\ni zapraszamy do skorzystania z naszych u" +
    "sług";
            // 
            // mpTabPage2
            // 
            this.mpTabPage2.BackColor = System.Drawing.Color.YellowGreen;
            this.mpTabPage2.Controls.Add(this.mpDataGridView1);
            this.mpTabPage2.Controls.Add(this.label5);
            this.mpTabPage2.Controls.Add(this.groupBox1);
            this.mpTabPage2.Controls.Add(this.mpCMBRodzajWaluty);
            this.mpTabPage2.Controls.Add(this.label4);
            this.mpTabPage2.Controls.Add(this.label3);
            this.mpTabPage2.Controls.Add(this.label2);
            this.mpTabPage2.Location = new System.Drawing.Point(4, 28);
            this.mpTabPage2.Name = "mpTabPage2";
            this.mpTabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.mpTabPage2.Size = new System.Drawing.Size(1271, 561);
            this.mpTabPage2.TabIndex = 1;
            this.mpTabPage2.Text = "Bankomat";
            // 
            // mpDataGridView1
            // 
            this.mpDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mpDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LiczbaNominalow,
            this.WartoscNominalu,
            this.RodzajNominalu,
            this.RodzajWaluty});
            this.mpDataGridView1.Location = new System.Drawing.Point(412, 374);
            this.mpDataGridView1.Name = "mpDataGridView1";
            this.mpDataGridView1.Size = new System.Drawing.Size(560, 150);
            this.mpDataGridView1.TabIndex = 6;
            // 
            // LiczbaNominalow
            // 
            this.LiczbaNominalow.HeaderText = "Liczba nominałów";
            this.LiczbaNominalow.Name = "LiczbaNominalow";
            // 
            // WartoscNominalu
            // 
            this.WartoscNominalu.HeaderText = "Wartość nominału";
            this.WartoscNominalu.Name = "WartoscNominalu";
            // 
            // RodzajNominalu
            // 
            this.RodzajNominalu.HeaderText = "Rodzaj nominału ";
            this.RodzajNominalu.Name = "RodzajNominalu";
            // 
            // RodzajWaluty
            // 
            this.RodzajWaluty.HeaderText = "Rodzaj waluty";
            this.RodzajWaluty.Name = "RodzajWaluty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(441, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(443, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Zawartość pojemników bankomatu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mpRDBUstawienieKontrolowane);
            this.groupBox1.Controls.Add(this.mpRDBUstawienieDomyslne);
            this.groupBox1.Location = new System.Drawing.Point(412, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ustalenie liczności nominałów w pojemnikach bankomatu";
            // 
            // mpRDBUstawienieKontrolowane
            // 
            this.mpRDBUstawienieKontrolowane.AutoSize = true;
            this.mpRDBUstawienieKontrolowane.Location = new System.Drawing.Point(244, 36);
            this.mpRDBUstawienieKontrolowane.Name = "mpRDBUstawienieKontrolowane";
            this.mpRDBUstawienieKontrolowane.Size = new System.Drawing.Size(237, 42);
            this.mpRDBUstawienieKontrolowane.TabIndex = 1;
            this.mpRDBUstawienieKontrolowane.Text = "Ustawienie kontrolowane\r\n(w podanym przedziale liczności)";
            this.mpRDBUstawienieKontrolowane.UseVisualStyleBackColor = true;
            // 
            // mpRDBUstawienieDomyslne
            // 
            this.mpRDBUstawienieDomyslne.AutoSize = true;
            this.mpRDBUstawienieDomyslne.Checked = true;
            this.mpRDBUstawienieDomyslne.Location = new System.Drawing.Point(62, 46);
            this.mpRDBUstawienieDomyslne.Name = "mpRDBUstawienieDomyslne";
            this.mpRDBUstawienieDomyslne.Size = new System.Drawing.Size(163, 23);
            this.mpRDBUstawienieDomyslne.TabIndex = 0;
            this.mpRDBUstawienieDomyslne.TabStop = true;
            this.mpRDBUstawienieDomyslne.Text = "Ustawienie domyślne";
            this.mpRDBUstawienieDomyslne.UseVisualStyleBackColor = true;
            // 
            // mpCMBRodzajWaluty
            // 
            this.mpCMBRodzajWaluty.FormattingEnabled = true;
            this.mpCMBRodzajWaluty.Items.AddRange(new object[] {
            "PLN",
            "USD",
            "GBP",
            "EUR"});
            this.mpCMBRodzajWaluty.Location = new System.Drawing.Point(94, 211);
            this.mpCMBRodzajWaluty.Name = "mpCMBRodzajWaluty";
            this.mpCMBRodzajWaluty.Size = new System.Drawing.Size(121, 27);
            this.mpCMBRodzajWaluty.TabIndex = 3;
            this.mpCMBRodzajWaluty.Text = "Lista walut";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Wybierz rodzaj waluty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(414, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "(umożliwaia wypłatę środków pieniężnych w różnych walutach)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(499, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "BANKOMAT";
            // 
            // mpTabPage3
            // 
            this.mpTabPage3.BackColor = System.Drawing.Color.HotPink;
            this.mpTabPage3.Controls.Add(this.label6);
            this.mpTabPage3.Location = new System.Drawing.Point(4, 28);
            this.mpTabPage3.Name = "mpTabPage3";
            this.mpTabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.mpTabPage3.Size = new System.Drawing.Size(1271, 561);
            this.mpTabPage3.TabIndex = 2;
            this.mpTabPage3.Text = "Automat vendingowy";
            // 
            // mpBTNZamknij
            // 
            this.mpBTNZamknij.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mpBTNZamknij.Location = new System.Drawing.Point(549, 410);
            this.mpBTNZamknij.Name = "mpBTNZamknij";
            this.mpBTNZamknij.Size = new System.Drawing.Size(200, 43);
            this.mpBTNZamknij.TabIndex = 3;
            this.mpBTNZamknij.Text = "Zamknij";
            this.mpBTNZamknij.UseVisualStyleBackColor = true;
            this.mpBTNZamknij.Click += new System.EventHandler(this.mpBTNZamknij_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(482, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(271, 66);
            this.label6.TabIndex = 0;
            this.label6.Text = "Maszyna Vendingowa\r\nAutor: Michał Palacz\r\nKarta studencka (numer): 53262";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProjektNr1_Palacz53262
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 618);
            this.Controls.Add(this.mpTCZakladki);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProjektNr1_Palacz53262";
            this.Text = "Obsługa Bankomatu i Automatu vendingowego";
            this.mpTCZakladki.ResumeLayout(false);
            this.mpTabPage1.ResumeLayout(false);
            this.mpTabPage1.PerformLayout();
            this.mpTabPage2.ResumeLayout(false);
            this.mpTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mpDataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mpTabPage3.ResumeLayout(false);
            this.mpTabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mpTCZakladki;
        private System.Windows.Forms.TabPage mpTabPage1;
        private System.Windows.Forms.Button mpBTNKupno;
        private System.Windows.Forms.Button mpBTNWyplata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage mpTabPage2;
        private System.Windows.Forms.TabPage mpTabPage3;
        private System.Windows.Forms.ComboBox mpCMBRodzajWaluty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView mpDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LiczbaNominalow;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartoscNominalu;
        private System.Windows.Forms.DataGridViewTextBoxColumn RodzajNominalu;
        private System.Windows.Forms.DataGridViewTextBoxColumn RodzajWaluty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton mpRDBUstawienieKontrolowane;
        private System.Windows.Forms.RadioButton mpRDBUstawienieDomyslne;
        private System.Windows.Forms.Button mpBTNZamknij;
        private System.Windows.Forms.Label label6;
    }
}

