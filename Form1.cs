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
        // deklaracja tablicy aktywności zakładek formularza
        bool[] mpStanTabPage = { true, false, false };
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

        struct mpProdukty
        {
            public TextBox mpTXTCena;
            public float mpCenaPLN;
            public ushort mpCenaYEN;
            public float mpCenaEUR;
            public void mpStworzProdukt(TextBox mpTXTCenaF, float mpCenaPLNF, ushort mpCenaYENF, float mpCenaEURF)
            {
                mpTXTCena = mpTXTCenaF;
                mpCenaPLN = mpCenaPLNF;
                mpCenaYEN = mpCenaYENF;
                mpCenaEUR = mpCenaEURF;
            }
        }
        mpProdukty[] mpStworzenieKonteneraProduktow()
        {
            mpProdukty mpTauriner = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTTaurinerCena, 0.5f, 12, 0.1f);
            mpProdukty mpToughnessLight = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTToughnessLightCena, 1f, 30, 0.2f);
            mpProdukty mpToughnessZ = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTToughnessZCena, 1.5f, 40, 0.3f);
            mpProdukty mpToughnessZZ = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTToughnessZZCena, 2f, 55, 0.4f);
            mpProdukty mpToughnessEmperor = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTToughnessEmperorCena, 4f, 110, 0.8f);
            mpProdukty mpToughnessInfinity = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTToughnessInfinityCena, 5f, 140, 1f);
            mpProdukty mpStaminanX = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTStaminanXCena, 2f, 55, 0.4f);
            mpProdukty mpStaminanXX = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTStaminanXXCena, 5f, 140, 1f);
            mpProdukty mpStaminanRoyale = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTStaminanRoyaleCena, 7.5f, 200, 1.6f);
            mpProdukty mpStaminanSpark = new mpProdukty();
            mpTauriner.mpStworzProdukt(mpTXTStaminanSparkCena, 10f, 275, 2.1f);
            mpProdukty[] mpPojemnikProduktow = { mpTauriner, mpToughnessLight, mpToughnessZ, mpToughnessZZ, mpToughnessEmperor, mpToughnessInfinity, mpStaminanX, mpStaminanXX, mpStaminanRoyale, mpStaminanSpark };
            return mpPojemnikProduktow;
        }
        public ProjektNr1_Palacz53262()
        {
            InitializeComponent();
            // ustawienie aktywnej zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
            // utworzenie egzemplarza pojemnika nominałów
            mpPojemnikNominalow = new mpNominaly[mpWartoscNominalow.Length];
            mpCMBRodzajWaluty.SelectedIndex = 0;

            mpCMBMetodaPlatnosci.SelectedIndex = 0;
            mpCMBWaluta.SelectedIndex = 0;
            // tworzenie i przypisywanie zmiennych do produktów
            mpProdukty[] mpPojemnikProduktow = mpStworzenieKonteneraProduktow();
        }
        private void mpTCZakladki_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == mpTCZakladki.TabPages[0])
            {
                // sprawdzenie, czy ta zakładka może być aktywna
                if (mpStanTabPage[0])
                {
                    e.Cancel = false; // zezwolenie na przejście do zakładki tabPage1
                    mpTCZakladki.SelectedTab = mpTabPage1;
                }
                else
                    e.Cancel = true; // nie będzie przejścia do zakładki tabPage1
            }
            else
                if (e.TabPage == mpTCZakladki.TabPages[1])
                // sprawdzenie, czy jest zezwolenie na przejście do zakładki tabPage2
                if (mpStanTabPage[1])
                {
                    e.Cancel = false;
                    mpTCZakladki.SelectedTab = mpTabPage2;
                }
                else
                    e.Cancel = true;
            else
                if (e.TabPage == mpTCZakladki.TabPages[2])
                // sprawdzenie czy otwarcie tej zakładki jest dozwolone
                if (mpStanTabPage[2])
                {
                    e.Cancel = false;
                    mpTCZakladki.SelectedTab = mpTabPage3;
                }
                else
                    e.Cancel = true;
        }
        private void mpBTNWyplata_Click(object sender, EventArgs e)
        {
            // zmiana stanu aktywności Pulpit
            mpStanTabPage[0] = false;
            // zezwolenie na przejście do zakładki Bankomat
            mpStanTabPage[1] = true;
            // otworzenie zakładki Bankomat
            mpTCZakladki.SelectedTab = mpTabPage2;
        }
        private void mpBTNKupno_Click(object sender, EventArgs e)
        {
            // zmiana stanu aktywności Pulpit
            mpStanTabPage[0] = false;
            // zezwolenie na przejście do zakładki Automat vendingowy
            mpStanTabPage[2] = true;
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
            mpStanTabPage[1] = false;
            // ustawnienie stanu aktywności dla zakładki Pulpit
            mpStanTabPage[0] = true;
            // przejście do zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
        }

        private void mpRDBUstawieniePrzedziałuLiczności_CheckedChanged(object sender, EventArgs e)
        {
            // ustawnienie drugiej kontrolki na wartość przeciwną
            mpRDBUstawienieLicznosciDomyslne.Checked = !mpRDBUstawieniePrzedziałuLiczności.Checked;
            // zmiana parametru Visble kontrolek związanych z granicą przedziału na true
            mpLBLEtykietaDolnejGranicyPrzedzialu.Visible = true;
            mpLBLEtykietaGornejGranicyPrzedzialu.Visible = true;
            mpTXTDolnaGranicaPrzedzialu.Visible = true;
            mpTXTGornaGranicaPrzedzialu.Visible = true;
        }
        private void mpRDBUstawienieLicznosciDomyslne_CheckedChanged(object sender, EventArgs e)
        {
            // ustawnienie drugiej kontrolki na wartość przeciwną
            mpRDBUstawieniePrzedziałuLiczności.Checked = !mpRDBUstawienieLicznosciDomyslne.Checked;
            // zmiana parametru Visble kontrolek związanych z granicą przedziału na true
            mpLBLEtykietaDolnejGranicyPrzedzialu.Visible = false;
            mpLBLEtykietaGornejGranicyPrzedzialu.Visible = false;
            mpTXTDolnaGranicaPrzedzialu.Visible = false;
            mpTXTGornaGranicaPrzedzialu.Visible = false;
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

        private void mpCMBMetodaPlatnosci_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mpCMBMetodaPlatnosci.SelectedIndex)
            {
                case 0:
                    mpLBLPlatnoscKarta.Visible = false;
                    mpBTNPlatnoscKarta.Visible = false;
                    mpCMBWaluta.SelectedIndexChanged += mpCMBWaluta_SelectedIndexChanged;
                    break;
                case 1:
                    mpGRBJeny.Visible = false;
                    mpGRBEuro.Visible = false;
                    mpGRBZlotowki.Visible = false;
                    mpLBLPlatnoscKarta.Visible = true;
                    mpBTNPlatnoscKarta.Visible = true;
                    break;
            }
        }
        private void mpCMBWaluta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mpCMBMetodaPlatnosci.SelectedIndex == 0)
            {
                switch (mpCMBWaluta.SelectedIndex)
                {
                    case 0:
                        mpGRBEuro.Visible = false;
                        mpGRBJeny.Visible = false;
                        mpGRBZlotowki.Visible = true;
                        break;
                    case 1:
                        mpGRBEuro.Visible = false;
                        mpGRBJeny.Visible = true;
                        mpGRBZlotowki.Visible = false;
                        break;
                    case 2:
                        mpGRBEuro.Visible = true;
                        mpGRBJeny.Visible = false;
                        mpGRBZlotowki.Visible = false;
                        break;
                }
            }
        }
    }
}
