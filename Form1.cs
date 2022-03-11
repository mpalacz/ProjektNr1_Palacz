using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr1_Palacz
{
    public partial class ProjektNr1_Palacz53262 : Form
    {
        // deklaracje i utworzenie egzemplarzy kontrolek, które będą umieszczone na formularzu
        Label mpLBLEtykietaDolnejGranicyPrzedzialu = new Label();
        Label mpLBLEtykietaGornejGranicyPrzedzialu = new Label();
        TextBox mpTXTDolnaGranicaPrzedzialu = new TextBox();
        TextBox mpTXTGornaGranicaPrzedzialu = new TextBox();
        // deklaracja stałych
        const ushort mpMaxLicznoscNominalow = 100;
        float[] mpWartoscNominalow = { 200, 100, 50, 20, 10, 5, 2, 1, 0.5f, 0.2f, 0.1f };
        // deklaracja struktury (rekordu) opisującego element tablicy PojemnikNominalow
        struct mpNominaly
        {
            public float mpWartosc;
            public ushort mpLicznosc;
        }
        //deklaracja zmiennej tablicowej (referencyjnej) pojemnik nominałów
        mpNominaly[] mpPojemnikNominalow;
        public ProjektNr1_Palacz53262()
        {
            InitializeComponent();
            // ustawienie aktywnej zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
            mpBTNWyplata.Click += mpBTNWyplata_Click;
            mpBTNKupno.Click += mpBTNKupno_Click;

            // utworzenie egzemplarza pojemnika nominałów
            mpPojemnikNominalow = new mpNominaly[mpWartoscNominalow.Length];
        }
        private void mpBTNWyplata_Click(object sender, EventArgs e)
        {  
            // otworzenie zakładki Bankomat
            mpTCZakladki.SelectedTab = mpTabPage2;
        }
        private void mpBTNKupno_Click(object sender, EventArgs e)
        {
            // otworzenie zakładki Automat vendingowy
            mpTCZakladki.SelectedTab = mpTabPage3;
        }
        private void mpBTNZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mpBTNPowrot1_Click(object sender, EventArgs e)
        {
            // ustawienie stanu braku aktywności dla zakładki Bankomat
            //StanTabPage[1] = false;
            // ustawnienie stanu aktywności dla zakładki Pulpit
            //StanTabPage[0] = true;
            // przejście do zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
        }

        private void mpRDBUstawieniePrzedziałuLiczności_CheckedChanged(object sender, EventArgs e)
        {
            // sprawdzanie, czy została wybrana waluta
            if (mpCMBRodzajWaluty.SelectedIndex < 0)
            {
                mpErrorProvider1.SetError(mpCMBRodzajWaluty, "ERROR: musisz wybrać walutę");
                return;
            }
            /* 
             * sprawdzenie, czy zdarzenie mpRDBUstawieniePrzedziałuLiczności_CheckedChanged zostało wywołane (wygenerowane) 
             * przez metode obsługi przycisku poleceń RESETUJ
             */
            if (!mpRDBUstawieniePrzedziałuLiczności.Checked)
                // nic nie robimy
                return;
            // sformatowanie kontrolek, które zamierzamy umieścić na formularzu
            mpLBLEtykietaDolnejGranicyPrzedzialu.Text = "Dolna granica przedziału liczności nominałów";
            // ustawienie fontu
            mpLBLEtykietaDolnejGranicyPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
            // ustalenie położenia (lokalizacji) kontrolki na formularzu
            mpLBLEtykietaDolnejGranicyPrzedzialu.Location = new Point(250, 180);
            mpLBLEtykietaDolnejGranicyPrzedzialu.Height = 90;
            mpLBLEtykietaDolnejGranicyPrzedzialu.Width = 150;
            // ustawienie kolorów
            mpLBLEtykietaDolnejGranicyPrzedzialu.BackColor = mpTCZakladki.TabPages[1].BackColor;
            mpLBLEtykietaDolnejGranicyPrzedzialu.ForeColor = mpTCZakladki.TabPages[1].ForeColor;
            mpLBLEtykietaDolnejGranicyPrzedzialu.Visible = true;
            mpTCZakladki.TabPages[1].Controls.Add(mpLBLEtykietaDolnejGranicyPrzedzialu);
            // sformatowanie kontrolki textbox
            mpTXTDolnaGranicaPrzedzialu.BackColor = Color.White;
            mpTXTDolnaGranicaPrzedzialu.ForeColor = Color.Black;
            mpTXTDolnaGranicaPrzedzialu.Text = "";
            mpTXTDolnaGranicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 12.25F, FontStyle.Bold);
            mpTXTDolnaGranicaPrzedzialu.TextAlign = HorizontalAlignment.Center;
            // lokalizacja kontrolki
            mpTXTDolnaGranicaPrzedzialu.Location = new Point(400, 190);
            // dodanie kontrolki do kolekcji Controls zakładki Bankomat
            mpTCZakladki.TabPages[1].Controls.Add(mpTXTDolnaGranicaPrzedzialu);
            // sformatowanie kontrolek dla górnej granicy przedziału liczności
            mpLBLEtykietaGornejGranicyPrzedzialu.Text = "Górna granica przedziału liczności nominałów";
            mpLBLEtykietaGornejGranicyPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
            mpLBLEtykietaGornejGranicyPrzedzialu.Location = new Point(510, 180);
            mpLBLEtykietaGornejGranicyPrzedzialu.Height = 60;
            mpLBLEtykietaGornejGranicyPrzedzialu.Width = 150;
            mpLBLEtykietaGornejGranicyPrzedzialu.BackColor = mpTCZakladki.TabPages[1].BackColor;
            mpLBLEtykietaGornejGranicyPrzedzialu.ForeColor = mpTCZakladki.TabPages[1].ForeColor;
            mpTCZakladki.TabPages[1].Controls.Add(mpTXTGornaGranicaPrzedzialu);
            // sformatowanie kontrolki TextBox dla górnej granicy przedziału liczności
            mpTXTGornaGranicaPrzedzialu.BackColor = Color.White;
            mpTXTGornaGranicaPrzedzialu.ForeColor = Color.Black;
            mpTXTGornaGranicaPrzedzialu.Text = "";
            mpTXTGornaGranicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 12.25F, FontStyle.Bold);
            mpTXTGornaGranicaPrzedzialu.TextAlign = HorizontalAlignment.Center;
            mpTXTGornaGranicaPrzedzialu.Location = new Point(665, 190);
            mpTCZakladki.TabPages[1].Controls.Add(mpTXTGornaGranicaPrzedzialu);
        }

        private void mpBTNAkceptacjaLiczności_Click(object sender, EventArgs e)
        {
            // sprawdzanie, czy została wybrana waluta
            if (mpCMBRodzajWaluty.SelectedIndex < 0)
            {
                mpErrorProvider1.SetError(mpCMBRodzajWaluty, "ERROR: musisz wybrać walutę");
                return;
            }
            // sprawdzenie, czyzostała wybrana kontrolka RadioButton dla określenia sposobu wyznaczenia liczności
            if (!(mpRDBUstawienieLicznosciDomyslne.Checked || mpRDBUstawieniePrzedziałuLiczności.Checked))
            {
                mpErrorProvider1.SetError(mpBTNAkceptacjaLiczności, "ERROR: musisz wybrać spodów ustalenia licznośc nominałów");
                return;
            }
            // ustawienie stanu braku aktywności kontrolek RadioButton
            mpRDBUstawienieLicznosciDomyslne.Enabled = false;
            mpRDBUstawieniePrzedziałuLiczności.Enabled = false;
            //rozpoznanie która z kontrolek została wybrana
            if (mpRDBUstawienieLicznosciDomyslne.Checked)
            {
                // utworzenie generatora liczb losowaych
                Random mpRandom = new Random();
                // wpisanie wartości nominałów oraz ich liczności w tablicy pojemnik nominałów
                for(ushort i = 0; i < mpPojemnikNominalow.Length; i++)
                {
                    mpPojemnikNominalow[i].mpWartosc = mpWartoscNominalow[i];
                    mpPojemnikNominalow[i].mpLicznosc = (ushort) mpRandom.Next(mpMaxLicznoscNominalow);
                }
                // odsłonięcie kontrolek dla wizualizacji ustalonej liczności nominałów
                mpLBLWyplacaneNominaly.Visible = true;
                mpLBLWyplacaneNominaly.Text = "Wylosowane liczności nominałów";
                mpDGVListaNominalow.Visible = true;
                mpDGVListaNominalow.Rows.Clear();
                // wpisanie liczności nominałów do kontrolki DataGridView
                for(ushort i = 0; i < mpPojemnikNominalow.Length; i++)
                {
                    mpDGVListaNominalow.Rows.Add();
                    mpDGVListaNominalow.Rows[i].Cells[0].Value = mpPojemnikNominalow[i].mpLicznosc;
                    mpDGVListaNominalow.Rows[i].Cells[0].Value = mpPojemnikNominalow[i].mpWartosc;
                }
            }
            else
            {

            }
        }
    }
}
