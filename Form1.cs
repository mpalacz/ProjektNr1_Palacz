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

        //                                  PLN YEN EUR                   PLN YEN EUR
        float[] mpWartoscWrzuconychMonet = { 0f, 0f, 0f }, mpDoZaplaty = { 0f, 0f, 0f };
        Dictionary<string, MPProdukt> mpStworzenieKonteneraProduktow()
        {
            // stworzenie słownika do przechowywania produktów
            Dictionary<string, MPProdukt> mpPojemnikProduktow = new Dictionary<string, MPProdukt>();
            // tworzenie referencji dla każdego produktu
            MPProdukt mpTauriner = new MPProdukt(mpTXTTaurinerCena, 0.5f, 12f, 0.1f);
            MPProdukt mpToughnessLight = new MPProdukt(mpTXTToughnessLightCena, 1f, 30f, 0.2f);
            MPProdukt mpToughnessZ = new MPProdukt(mpTXTToughnessZCena, 1.5f, 40f, 0.3f);
            MPProdukt mpToughnessZZ = new MPProdukt(mpTXTToughnessZZCena, 2f, 55f, 0.4f);
            MPProdukt mpToughnessEmperor = new MPProdukt(mpTXTToughnessEmperorCena, 4f, 110f, 0.8f);
            MPProdukt mpToughnessInfinity = new MPProdukt(mpTXTToughnessInfinityCena, 5f, 140f, 1f);
            MPProdukt mpStaminanX = new MPProdukt(mpTXTStaminanXCena, 2f, 55f, 0.4f);
            MPProdukt mpStaminanXX = new MPProdukt(mpTXTStaminanXXCena, 5f, 140f, 1f);
            MPProdukt mpStaminanRoyale = new MPProdukt(mpTXTStaminanRoyaleCena, 7.5f, 200f, 1.6f);
            MPProdukt mpStaminanSpark = new MPProdukt(mpTXTStaminanSparkCena, 10f, 275f, 2.1f);
            // dodawanie produktów do słownika
            mpPojemnikProduktow.Add("Tauriner", mpTauriner);
            mpPojemnikProduktow.Add("ToughnessLight", mpToughnessLight);
            mpPojemnikProduktow.Add("ToughnessZ", mpToughnessZ);
            mpPojemnikProduktow.Add("ToughnessZZ", mpToughnessZZ);
            mpPojemnikProduktow.Add("ToughnessEmperor", mpToughnessEmperor);
            mpPojemnikProduktow.Add("ToughnessInfinity", mpToughnessInfinity);
            mpPojemnikProduktow.Add("StaminanX", mpStaminanX);
            mpPojemnikProduktow.Add("StaminanXX", mpStaminanXX);
            mpPojemnikProduktow.Add("StaminanRoyale", mpStaminanRoyale);
            mpPojemnikProduktow.Add("StaminanSpark", mpStaminanSpark);
            // zwrot słownika
            return mpPojemnikProduktow;
        }
        Dictionary<string, MPProdukt> mpPojemnikProduktow;
        void mpWyswietlenieCen()
        {
            string mpCena = "";
            foreach (MPProdukt mpProdukt in mpPojemnikProduktow.Values)
            {
                switch (mpCMBWaluta.SelectedIndex)
                {
                    case 0:
                        mpCena = mpProdukt.mpCenaPLN + " PLN";
                        break;
                    case 1:
                        mpCena = mpProdukt.mpCenaYEN + "¥";
                        break;
                    case 2:
                        mpCena = mpProdukt.mpCenaEUR + "€";
                        break;
                }
                mpProdukt.mpTXTCena.Text = mpCena;
            }
        }
        void mpAktualizacjaWartosciKoszykaIWrzuconychMonet()
        {
            switch (mpCMBWaluta.SelectedIndex)
            {
                case 0:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[0]) + " PLN";
                    mpTXTWrzuconeMonety.Text = Convert.ToString(mpWartoscWrzuconychMonet[0]) + " PLN";
                    break;
                case 1:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[1]) + "¥";
                    mpTXTWrzuconeMonety.Text = Convert.ToString(mpWartoscWrzuconychMonet[1]) + "¥";
                    break;
                case 2:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[2]) + "€";
                    mpTXTWrzuconeMonety.Text = Convert.ToString(mpWartoscWrzuconychMonet[2]) + "€";
                    break;
            }
        }
        public ProjektNr1_Palacz53262()
        {
            InitializeComponent();
            // ustawienie aktywnej zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
            // utworzenie egzemplarza pojemnika nominałów
            mpPojemnikNominalow = new mpNominaly[mpWartoscNominalow.Length];
            mpCMBRodzajWaluty.SelectedIndex = 0;

            // tworzenie produktów i przypisywanie do nich cen
            mpPojemnikProduktow = mpStworzenieKonteneraProduktow();
            mpCMBMetodaPlatnosci.SelectedIndex = 0;
            mpCMBWaluta.SelectedIndex = 0;
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
                for (ushort i = 0; i < mpPojemnikNominalow.Length; i++)
                {
                    mpPojemnikNominalow[i].mpWartosc = mpWartoscNominalow[i];
                    mpPojemnikNominalow[i].mpLicznosc = (ushort)mpRandom.Next(mpMaxLicznoscNominalow);
                }
                // odsłonięcie kontrolek dla wizualizacji ustalonej liczności nominałów
                mpLBLWyplacaneNominaly.Visible = true;
                mpLBLWyplacaneNominaly.Text = "Wylosowane liczności nominałów";
                mpDGVListaNominalow.Visible = true;
                mpDGVListaNominalow.Rows.Clear();
                // wpisanie liczności nominałów do kontrolki DataGridView
                for (ushort i = 0; i < mpPojemnikNominalow.Length; i++)
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

        private void mpBTNTauriner_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["Tauriner"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["Tauriner"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["Tauriner"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["Tauriner"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNStaminanX_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["StaminanX"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["StaminanX"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["StaminanX"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["StaminanX"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNStaminanXX_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["StaminanXX"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["StaminanXX"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["StaminanXX"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["StaminanXX"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNStaminanRoyale_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["StaminanRoyale"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["StaminanRoyale"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["StaminanRoyale"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["StaminanRoyale"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNStaminanSpark_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["StaminanSpark"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["StaminanSpark"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["StaminanSpark"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["StaminanSpark"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNToughnessLight_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["ToughnessLight"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["ToughnessLight"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["ToughnessLight"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["ToughnessLight"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNToughnessZ_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["ToughnessZ"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["ToughnessZ"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["ToughnessZ"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["ToughnessZ"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNToughnessZZ_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["ToughnessZZ"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["ToughnessZZ"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["ToughnessZZ"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["ToughnessZZ"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNToughnessEmperor_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["ToughnessEmperor"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["ToughnessEmperor"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["ToughnessEmperor"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["ToughnessEmperor"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNToughnessInfinity_Click(object sender, EventArgs e)
        {
            mpPojemnikProduktow["ToughnessInfinity"].mpIloscZamowionych++;
            mpDoZaplaty[0] += mpPojemnikProduktow["ToughnessInfinity"].mpCenaPLN;
            mpDoZaplaty[1] += mpPojemnikProduktow["ToughnessInfinity"].mpCenaYEN;
            mpDoZaplaty[2] += mpPojemnikProduktow["ToughnessInfinity"].mpCenaEUR;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN50Groszy_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[0] +=0.5f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN1Zloty_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[0] += 1f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN2Zlote_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[0] += 2f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN5Zloty_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[0] += 5f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN5Jenow_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[1] += 5f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN10Jenow_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[1] += 10f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN50Jenow_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[1] += 50f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN100Jenow_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[1] += 100f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN10EuroCentow_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[2] += 0.1f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN20EuroCentow_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[2] += 0.2f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN50EuroCentow_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[2] += 0.5f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTN1Euro_Click(object sender, EventArgs e)
        {
            mpWartoscWrzuconychMonet[2] += 1f;
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }

        private void mpBTNZwrotMonet_Click(object sender, EventArgs e)
        {

        }

        private void mpBTNResetKoszyka_Click(object sender, EventArgs e)
        {

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
            mpWyswietlenieCen();
            mpAktualizacjaWartosciKoszykaIWrzuconychMonet();
        }
    }
    public class MPProdukt
    {
        public TextBox mpTXTCena { get; private set; }
        public float mpCenaPLN { get; private set; }
        public float mpCenaYEN { get; private set; }
        public float mpCenaEUR { get; private set; }
        public ushort mpIloscZamowionych { get; set; }
        public MPProdukt(TextBox mpTXTCena, float mpCenaPLN, float mpCenaYEN, float mpCenaEUR)
        {
            this.mpTXTCena = mpTXTCena;
            this.mpCenaPLN = mpCenaPLN;
            this.mpCenaYEN = mpCenaYEN;
            this.mpCenaEUR = mpCenaEUR;
            mpIloscZamowionych = 0;
        }
    }
}