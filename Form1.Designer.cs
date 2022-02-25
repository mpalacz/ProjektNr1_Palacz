
namespace ProjektNr1_Palacz
{
    partial class ProjektNr1_Palacz
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
            this.tcZakladki = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWyplata = new System.Windows.Forms.Button();
            this.btnKupno = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRodzajWaluty = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbUstawienieDomyslne = new System.Windows.Forms.RadioButton();
            this.rdbUstawienieKontrolowane = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LiczbaNominalow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WartoscNominalu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RodzajNominalu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RodzajWaluty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcZakladki.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcZakladki
            // 
            this.tcZakladki.Controls.Add(this.tabPage1);
            this.tcZakladki.Controls.Add(this.tabPage2);
            this.tcZakladki.Controls.Add(this.tabPage3);
            this.tcZakladki.Location = new System.Drawing.Point(13, 13);
            this.tcZakladki.Name = "tcZakladki";
            this.tcZakladki.SelectedIndex = 0;
            this.tcZakladki.Size = new System.Drawing.Size(1279, 593);
            this.tcZakladki.TabIndex = 0;
            this.tcZakladki.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcZakladki_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage1.Controls.Add(this.btnKupno);
            this.tabPage1.Controls.Add(this.btnWyplata);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1271, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pulpit";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.cmbRodzajWaluty);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1271, 561);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bankomat";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1271, 561);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Automat vendingowy";
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
            // btnWyplata
            // 
            this.btnWyplata.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWyplata.Location = new System.Drawing.Point(302, 222);
            this.btnWyplata.Name = "btnWyplata";
            this.btnWyplata.Size = new System.Drawing.Size(273, 43);
            this.btnWyplata.TabIndex = 1;
            this.btnWyplata.Text = "Wypłata środków pieniężnych";
            this.btnWyplata.UseVisualStyleBackColor = true;
            this.btnWyplata.Click += new System.EventHandler(this.btnWyplata_Click);
            // 
            // btnKupno
            // 
            this.btnKupno.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKupno.Location = new System.Drawing.Point(728, 222);
            this.btnKupno.Name = "btnKupno";
            this.btnKupno.Size = new System.Drawing.Size(258, 43);
            this.btnKupno.TabIndex = 2;
            this.btnKupno.Text = "Kupno naszych smakołyków";
            this.btnKupno.UseVisualStyleBackColor = true;
            this.btnKupno.Click += new System.EventHandler(this.btnKupno_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(414, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "(umożliwaia wypłatę środków pieniężnych w różnych walutach)";
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
            // cmbRodzajWaluty
            // 
            this.cmbRodzajWaluty.FormattingEnabled = true;
            this.cmbRodzajWaluty.Items.AddRange(new object[] {
            "PLN",
            "USD",
            "GBP",
            "EUR"});
            this.cmbRodzajWaluty.Location = new System.Drawing.Point(94, 211);
            this.cmbRodzajWaluty.Name = "cmbRodzajWaluty";
            this.cmbRodzajWaluty.Size = new System.Drawing.Size(121, 27);
            this.cmbRodzajWaluty.TabIndex = 3;
            this.cmbRodzajWaluty.Text = "Lista walut";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbUstawienieKontrolowane);
            this.groupBox1.Controls.Add(this.rdbUstawienieDomyslne);
            this.groupBox1.Location = new System.Drawing.Point(412, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ustalenie liczności nominałów w pojemnikach bankomatu";
            // 
            // rdbUstawienieDomyslne
            // 
            this.rdbUstawienieDomyslne.AutoSize = true;
            this.rdbUstawienieDomyslne.Checked = true;
            this.rdbUstawienieDomyslne.Location = new System.Drawing.Point(62, 46);
            this.rdbUstawienieDomyslne.Name = "rdbUstawienieDomyslne";
            this.rdbUstawienieDomyslne.Size = new System.Drawing.Size(163, 23);
            this.rdbUstawienieDomyslne.TabIndex = 0;
            this.rdbUstawienieDomyslne.TabStop = true;
            this.rdbUstawienieDomyslne.Text = "Ustawienie domyślne";
            this.rdbUstawienieDomyslne.UseVisualStyleBackColor = true;
            // 
            // rdbUstawienieKontrolowane
            // 
            this.rdbUstawienieKontrolowane.AutoSize = true;
            this.rdbUstawienieKontrolowane.Location = new System.Drawing.Point(244, 36);
            this.rdbUstawienieKontrolowane.Name = "rdbUstawienieKontrolowane";
            this.rdbUstawienieKontrolowane.Size = new System.Drawing.Size(237, 42);
            this.rdbUstawienieKontrolowane.TabIndex = 1;
            this.rdbUstawienieKontrolowane.Text = "Ustawienie kontrolowane\r\n(w podanym przedziale liczności)";
            this.rdbUstawienieKontrolowane.UseVisualStyleBackColor = true;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LiczbaNominalow,
            this.WartoscNominalu,
            this.RodzajNominalu,
            this.RodzajWaluty});
            this.dataGridView1.Location = new System.Drawing.Point(412, 374);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 150);
            this.dataGridView1.TabIndex = 6;
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
            // ProjektNr1_Palacz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 618);
            this.Controls.Add(this.tcZakladki);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProjektNr1_Palacz";
            this.Text = "Obsługa Bankomatu i Automatu vendingowego";
            this.tcZakladki.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcZakladki;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnKupno;
        private System.Windows.Forms.Button btnWyplata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cmbRodzajWaluty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LiczbaNominalow;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartoscNominalu;
        private System.Windows.Forms.DataGridViewTextBoxColumn RodzajNominalu;
        private System.Windows.Forms.DataGridViewTextBoxColumn RodzajWaluty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbUstawienieKontrolowane;
        private System.Windows.Forms.RadioButton rdbUstawienieDomyslne;
    }
}

