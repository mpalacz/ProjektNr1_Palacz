﻿using System;
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
        const ushort mpMargines = 20;
        const ushort mpMaxLicznoscNominalow = 100;
        const ushort mpBanknotONajnizszejWartosci = 10;
        float[] mpWartoscNominalow = { 200, 100, 50, 20, 10, 5, 2, 1, 0.5f, 0.2f, 0.1f };
        // deklaracja struktury (rekordu) opisującego element tablicy PojemnikNominalow
        struct mpNominaly
        {
            public float mpWartosc;
            public ushort mpLicznosc;
        }
        // deklaracja zmiennej tablicowej (referencyjnej) pojemnik nominałów
        mpNominaly[] mpPojemnikNominalow;

        // Automat vendingowy
        //                                  PLN YEN EUR                   PLN YEN EUR
        private float[] mpWrzuconePieniadze = { 0f, 0f, 0f }, mpDoZaplaty = { 0f, 0f, 0f };
        Dictionary<string, MPProdukt> mpPojemnikProduktow;
        Dictionary<string, ushort> mpKoszyk = new Dictionary<string, ushort>();
        private string mpOstatniaAktywnosc;
        private Dictionary<string, MPProdukt> mpStworzenieKonteneraProduktow()
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
        private void mpDodajDoKoszyka(string mpNazwaProduktu)
        {
            try { mpKoszyk[mpNazwaProduktu]++; }
            catch (Exception e) { mpKoszyk.Add(mpNazwaProduktu, 1); }
            finally
            {
                mpDoZaplaty[0] += mpPojemnikProduktow[mpNazwaProduktu].mpCenaPLN;
                mpDoZaplaty[1] += mpPojemnikProduktow[mpNazwaProduktu].mpCenaYEN;
                mpDoZaplaty[2] += mpPojemnikProduktow[mpNazwaProduktu].mpCenaEUR;
                mpAktualizacjaWyswietlanychDanych();
                mpOstatniaAktywnosc = mpNazwaProduktu;
                mpBTNCofnij.Enabled = true;
            }
        }
        private void mpWyswietlenieCen()
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
        private void mpAktualizacjaWyswietlanychDanych()
        {
            switch (mpCMBWaluta.SelectedIndex)
            {
                case 0:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[0]) + " PLN";
                    mpTXTWrzuconeMonety.Text = Convert.ToString(mpWrzuconePieniadze[0]) + " PLN";
                    break;
                case 1:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[1]) + "¥";
                    mpTXTWrzuconeMonety.Text = Convert.ToString(mpWrzuconePieniadze[1]) + "¥";
                    break;
                case 2:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[2]) + "€";
                    mpTXTWrzuconeMonety.Text = Convert.ToString(mpWrzuconePieniadze[2]) + "€";
                    break;
            }
            // wyświetlenie koszyka
            mpRTBKoszyk.Text = "";
            if (mpKoszyk.Count != 0)
            {
                foreach (KeyValuePair<string, ushort> mpProdukt in mpKoszyk)
                {
                    mpRTBKoszyk.Text += $"{mpProdukt.Key} {mpProdukt.Value}x\n";
                }
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
        // Manipulacja zakładkami
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
        private void mpBTNPowrot1_Click(object sender, EventArgs e)
        {
            // ustawienie stanu braku aktywności dla zakładki Bankomat
            mpStanTabPage[1] = false;
            // ustawnienie stanu aktywności dla zakładki Pulpit
            mpStanTabPage[0] = true;
            // przejście do zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
        }
        private void mpBTNPowrot2_Click(object sender, EventArgs e)
        {
            // ustawienie stanu braku aktywności dla zakładki Automat vendingowy
            mpStanTabPage[2] = false;
            // ustawnienie stanu aktywności dla zakładki Pulpit
            mpStanTabPage[0] = true;
            // przejście do zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
        } 
        //Pulpit
        // Przejście do bankomatu
        private void mpBTNWyplata_Click(object sender, EventArgs e)
        {
            // zmiana stanu aktywności Pulpit
            mpStanTabPage[0] = false;
            // zezwolenie na przejście do zakładki Bankomat
            mpStanTabPage[1] = true;
            // otworzenie zakładki Bankomat
            mpTCZakladki.SelectedTab = mpTabPage2;
        }
        // Przejście do automatu vendingowego
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
        //Bankomat
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
        //Automat vendingowy
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
            mpAktualizacjaWyswietlanychDanych();
        }
        private void mpCMBMetodaPlatnosci_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mpCMBMetodaPlatnosci.SelectedIndex)
            {
                case 0:
                    mpLBLPlatnoscKarta.Visible = false;
                    mpBTNPlatnoscKarta.Visible = false;
                    mpBTNKupnoGotowka.Visible = true;
                    mpCMBWaluta_SelectedIndexChanged(sender, e);
                    break;
                case 1:
                    mpGRBJeny.Visible = false;
                    mpGRBEuro.Visible = false;
                    mpGRBZlotowki.Visible = false;
                    mpLBLPlatnoscKarta.Visible = true;
                    mpBTNPlatnoscKarta.Visible = true;
                    mpBTNKupnoGotowka.Visible = false;
                    break;
            }
        }
        private void mpBTNTauriner_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("Tauriner");
        }
        private void mpBTNStaminanX_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("StaminanX");
        }
        private void mpBTNStaminanXX_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("StaminanXX");
        }
        private void mpBTNStaminanRoyale_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("StaminanRoyale");
        }
        private void mpBTNStaminanSpark_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("StaminanSpark");
        }
        private void mpBTNToughnessLight_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("ToughnessLight");
        }
        private void mpBTNToughnessZ_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("ToughnessZ");
        }
        private void mpBTNToughnessZZ_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("ToughnessZZ");
        }
        private void mpBTNToughnessEmperor_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("ToughnessEmperor");
        }
        private void mpBTNToughnessInfinity_Click(object sender, EventArgs e)
        {
            mpDodajDoKoszyka("ToughnessInfinity");
        }
        private void mpWrzutPieniedzy(int mpIndexWaluty,float mpKwota)
        {
            mpWrzuconePieniadze[mpIndexWaluty] += mpKwota;
            mpAktualizacjaWyswietlanychDanych();
        }
        private void mpBTN1Grosz_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 0.01f);
        }
        private void mpBTN2Grosze_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 0.02f);
        }
        private void mpBTN5Groszy_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 0.05f);
        }
        private void mpBTN10Groszy_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 0.1f);
        }
        private void mpBTN20Groszy_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 0.2f);
        }
        private void mpBTN50Groszy_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 0.5f);
        }
        private void mpBTN1Zloty_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 1f);
        }
        private void mpBTN2Zlote_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 2f);
        }
        private void mpBTN5Zloty_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 5f);
        }
        private void mpBTN10Zloty_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 10f);
        }
        private void mpBTN20Zloty_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 20f);
        }
        private void mpBTN50Zloty_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 50f);
        }
        private void mpBTN100Zloty_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 100f);
        }
        private void mpBTN200Zloty_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(0, 200f);
        }
        private void mpBTN1Jen_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 1f);
        }
        private void mpBTN5Jenow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 5f);
        }
        private void mpBTN10Jenow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 10f);
        }
        private void mpBTN50Jenow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 50f);
        }
        private void mpBTN100Jenow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 100f);
        }
        private void mpBTN500Yen_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 500f);
        }
        private void mpBTN1000Yen_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 1000f);
        }
        private void mpBTN5000Jenow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 5000f);
        }
        private void mpBTN10000Jenow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(1, 10000f);
        }
        private void mpBTN1EuroCent_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 0.01f);
        }
        private void mpBTN2EuroCenty_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 0.02f);
        }
        private void mpBTN5EuroCentow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 0.05f);
        }
        private void mpBTN10EuroCentow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 0.1f);
        }
        private void mpBTN20EuroCentow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 0.2f);
        }
        private void mpBTN50EuroCentow_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 0.5f);
        }
        private void mpBTN1Euro_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 1f);
        }
        private void mpBTN2Euro_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 2f);
        }
        private void mpBTN5Euro_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 5f);
        }
        private void mpBTN10Euro_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 10f);
        }
        private void mpBTN20Euro_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 20f);
        }
        private void mpBTN50Euro_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 20f);
        }
        private void mpBTN100Euro_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 100f);
        }
        private void mpBTN200Euro_Click(object sender, EventArgs e)
        {
            mpWrzutPieniedzy(2, 200f);
        }
        private void mpZwrotPieniedzy()
        {
            mpWrzuconePieniadze[0] = 0;
            mpWrzuconePieniadze[1] = 0;
            mpWrzuconePieniadze[2] = 0;
            mpAktualizacjaWyswietlanychDanych();
        }

        private void mpBTNZwrotMonet_Click(object sender, EventArgs e)
        {
            if (mpWrzuconePieniadze[0] + mpWrzuconePieniadze[1] + mpWrzuconePieniadze[2] == 0)
            {
                MessageBox.Show("Nie wrzucono żadnych pieniędzy!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Czy na pewno chcesz dokonać zwrotu monet?", "Zwrót monet", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) 
                mpZwrotPieniedzy();
        }
        private void mpOproznienieKoszyka()
        {
            mpDoZaplaty[0] = 0;
            mpDoZaplaty[1] = 0;
            mpDoZaplaty[2] = 0;
            mpKoszyk = new Dictionary<string, ushort>();
            mpAktualizacjaWyswietlanychDanych();
        }
        private void mpBTNAnulujZakupy_Click(object sender, EventArgs e)
        {
            if (mpDoZaplaty[0] + mpDoZaplaty[1] + mpDoZaplaty[2] == 0)
            {
                MessageBox.Show("Nie wybrano żadnego produktu!", "Pusty koszyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Czy na pewno chcesz zresetować?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mpOproznienieKoszyka();
            }
            if (mpCMBMetodaPlatnosci.SelectedIndex == 0 && mpWrzuconePieniadze[mpCMBWaluta.SelectedIndex] != 0)
                if (MessageBox.Show("Czy zwrócić wrzucone monety?", "Reset", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    mpZwrotPieniedzy();
        }

        private void mpBTNKupnoGotowka_Click(object sender, EventArgs e)
        {
            if (mpKoszyk.Count() == 0)
            {
                MessageBox.Show("Koszyk jest pusty.", "Pusty koszyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (mpWrzuconePieniadze[mpCMBWaluta.SelectedIndex] < mpDoZaplaty[mpCMBWaluta.SelectedIndex])
            {
                MessageBox.Show("Wrzucona kwota jest za mała.", "Za mało pieniędzy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mpKomunikat = "Zakupiono:\n" + mpRTBKoszyk.Text + "Reszta: ";
            float mpReszta;
            switch (mpCMBWaluta.SelectedIndex)
            {
                case 0:
                    mpKomunikat += (mpReszta = mpWrzuconePieniadze[0] - mpDoZaplaty[0]) + "PLN\n";
                    float[] mpNominalyPLN = { 200, 100, 50, 20, 10, 5, 2, 1, 0.5f, 0.2f, 0.1f, 0.05f, 0.02f, 0.01f };
                    for (int mpI = 0; mpI <= 7 && mpReszta >= 1; mpI++)
                    {
                        ushort mpIloraz = (ushort)(mpReszta / mpNominalyPLN[mpI]);
                        if (mpIloraz != 0)
                        {
                            mpKomunikat += $"{mpIloraz}x {mpNominalyPLN[mpI]} złoty\n";
                            mpReszta -= mpNominalyPLN[mpI] * mpIloraz;
                        }
                    }
                    for (int mpI = 8; mpI < mpNominalyPLN.Length && mpReszta > 0; mpI++)
                    {
                        ushort mpIloraz = (ushort)(mpReszta / mpNominalyPLN[mpI]);
                        if (mpIloraz != 0)
                        {
                            mpKomunikat += $"{mpIloraz}x {mpNominalyPLN[mpI] * 100} groszy\n";
                            mpReszta -= mpNominalyPLN[mpI] * mpIloraz;
                        }
                    }
                    break;
                case 1:
                    mpKomunikat += (mpReszta = mpWrzuconePieniadze[1] - mpDoZaplaty[1]) + "¥\n";
                    ushort[] mpNominalyYEN = { 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };
                    for (int mpI = 0; mpI < mpNominalyYEN.Length && mpReszta > 0; mpI++)
                    {
                        ushort mpIloraz = (ushort)(mpReszta / mpNominalyYEN[mpI]);
                        if (mpIloraz != 0)
                        {
                            mpKomunikat += $"{mpIloraz}x {mpNominalyYEN[mpI]} ¥\n";
                            mpReszta -= mpNominalyYEN[mpI] * mpIloraz;
                        }
                    }
                    break;
                case 2:
                    mpKomunikat += (mpReszta = mpWrzuconePieniadze[2] - mpDoZaplaty[2]) + "€\n";
                    float[] mpNominalyEUR = { 200, 100, 50, 20, 10, 5, 2, 1, 0.5f, 0.2f, 0.1f, 0.05f, 0.02f, 0.01f };
                    for (int mpI = 0; mpI <= 7 && mpReszta >= 1; mpI++)
                    {
                        ushort mpIloraz = (ushort)(mpReszta / mpNominalyEUR[mpI]);
                        if (mpIloraz != 0)
                        {
                            mpKomunikat += $"{mpIloraz}x {mpNominalyEUR[mpI]} €\n";
                            mpReszta -= mpNominalyEUR[mpI] * mpIloraz;
                        }
                    }
                    for (int mpI = 8; mpI < mpNominalyEUR.Length && mpReszta > 0; mpI++)
                    {
                        ushort mpIloraz = (ushort)(mpReszta / mpNominalyEUR[mpI]);
                        if (mpIloraz != 0)
                        {
                            mpKomunikat += $"{mpIloraz}x {mpNominalyEUR[mpI] * 100} centów\n";
                            mpReszta -= mpNominalyEUR[mpI] * mpIloraz;
                        }
                    }
                    break;
            }
            MessageBox.Show(mpKomunikat, "Na zdrowie!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mpZwrotPieniedzy();
            mpOproznienieKoszyka();
        }

        private void mpBTNPlatnoscKarta_Click(object sender, EventArgs e)
        {
            if (mpKoszyk.Count() == 0)
            {
                MessageBox.Show("Koszyk jest pusty.", "Pusty koszyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form2 mpLoginForm = new Form2();
            mpLoginForm.ShowDialog();
            if (mpLoginForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Zakupiono:\n" + mpRTBKoszyk.Text, "Na zdrowie!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (mpWrzuconePieniadze[0] + mpWrzuconePieniadze[1] + mpWrzuconePieniadze[2] != 0)
                {
                    MessageBox.Show("Zwrócono wprowadzoną gotówkę.", "Zwrot gotówki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mpZwrotPieniedzy();
                }
                mpOproznienieKoszyka();
            }
        }

        private void mpBTNAkceptacja_Click(object sender, EventArgs e)
        {
            float mpKwotaDoWypłaty;
            mpErrorProvider1.Dispose();
            if (string.IsNullOrEmpty(mpTXTKwotaDoWyplaty.Text)) {

            } 
            if (!float.TryParse(mpTXTKwotaDoWyplaty.Text, out mpKwotaDoWypłaty)) {
                mpErrorProvider1.SetError(mpTXTKwotaDoWyplaty, "Error: w zapisie kwoty wystąpił niestosowny znak");
                return;
            }
            if (mpKwotaDoWypłaty <= 0.0F)
            {
                mpErrorProvider1.SetError(mpTXTKwotaDoWyplaty, "wypłata musi wyć więskza od 0.0");
                return;
            }
            if (!mpCzyWyplataMozeBycZrealizowana(mpPojemnikNominalow, mpKwotaDoWypłaty))
            {
                // w bankomacie nie ma odpowiedniego kapitału (liczby nominałów)
                mpErrorProvider1.SetError(mpBTNAkceptacja, "ERROR: nie możemy zrealizować tak dużej wypłaty! PRZEPRASZAMY! Ale możesz pobrać mniejszą kwotę!");
                return;
            }

            // realizacja wypłaty
            // deklaracja zmiennej pomocniczej
            float mpResztaDoWyplaty = mpKwotaDoWypłaty;
            // rozpoczynamy wypłatę od najwyższych nominałów, czyli od pierwszej pozycji pojemnika nominałów
            ushort mpIndexPojemnikaNominalow = 0;
            // ustalenie atrybutów kontrolek dla prezentacji wypłaty
            // zmiana tytułu kontrolki label opisującej kontrolkę DataGridView
            mpLBLWyplacaneNominaly.Text = "Wypłacane nominały:";
            // "wyczyszczenie" kontrolki DataGridView
            mpDGVListaNominalow.Rows.Clear();
            // ustawnienie indeksu wierszy kontrolki DataGridView
            ushort mpIndexDGV = 0;
            // iteracyjne dkonowanie wypłaty
            ushort mpLiczbaNominalow;
            while((mpResztaDoWyplaty>0.0F)&&(mpIndexPojemnikaNominalow < mpPojemnikNominalow.Length))
            {
                // policzenie ile nominałów byłoby potrzebnych dla zrealizowania wypłaty
                mpLiczbaNominalow = (ushort)(mpResztaDoWyplaty / mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpWartosc);
                // sprawdzenie czy na pozycji mpIndexPojemnikaNominalow w mpPojemnikNominalow jest taka liczba nominałów
                if (mpLiczbaNominalow > mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpLicznosc)
                {
                    // w pozycji mpIndexPojemnikaNominalow nie ma wymaganej liczności nominałów, to
                    // powielamy wszystkie nominały z pozycji mpIndexPojemnikaNominalow
                    mpLiczbaNominalow = mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpLicznosc;
                    // wyzerowanie liczności nominałów
                    mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpLicznosc = 0;
                }
                else
                {
                    // z pozycji mpIndexPojemnikaNominalow pobieramy nominały o wymaganej licznośc, czyli mpLiczbaNominalow
                    mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpLicznosc = (ushort) (mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpLicznosc - mpLiczbaNominalow);
                }
                // dokonanie (symulacja) wypłaty nominałów liczności mpLiczbaNominalow
                if (mpLiczbaNominalow > 0)
                {
                    // dodanie nowego (pustego) wiersza
                    mpDGVListaNominalow.Rows.Add();
                    // wypełnienie poszczególnych pól (komórek) dodanego wiersza do kontrolki DataGridView
                    mpDGVListaNominalow.Rows[mpIndexDGV].Cells[0].Value = mpLiczbaNominalow;
                    mpDGVListaNominalow.Rows[mpIndexDGV].Cells[1].Value = mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpWartosc;
                    if (mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpWartosc >= mpBanknotONajnizszejWartosci)
                        mpDGVListaNominalow.Rows[mpIndexDGV].Cells[2].Value = "banknot";
                    else
                        mpDGVListaNominalow.Rows[mpIndexDGV].Cells[2].Value = "moneta";
                    // wypisanie waluty
                    mpDGVListaNominalow.Rows[mpIndexDGV].Cells[3].Value = mpCMBRodzajWaluty.SelectedItem;
                    // wycentrowanie zapisów w poszczególnych komórkach
                    for (ushort i = 0; i < mpDGVListaNominalow.Columns.Count; i++)
                        mpDGVListaNominalow.Rows[mpIndexDGV].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    // zwiększenie indeksu wiersza w kontrolce DataGridView
                    mpIndexDGV++;
                }
                // uaktualnienie reszty do wypłaty
                mpResztaDoWyplaty -= mpLiczbaNominalow * mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpWartosc;
                // przjeście do następnej pozycji pojemnika nominałów
                mpIndexPojemnikaNominalow++;
            }
            // sprawdzenie, czy wszystko zostało wypłacone
            if (mpResztaDoWyplaty > 0)
            {
                // niewypłaciliśmy pełnej kwoty
                mpErrorProvider1.SetError(mpBTNAkceptacja, "PRZEPRASZAMY: nie możemy wypłacić pełnej kwoty, " +
                    "gdyż brak nam odpowiednich nominałów");
                // ukrycie kontrolek  z wypłatą nominałów
                mpLBLWyplacaneNominaly.Visible = false;
                mpDGVListaNominalow.Visible = false;
            }
            else
            {
                // odsłaniamy kontrolki z wypłatą
                mpLBLWyplacaneNominaly.Visible = true;
                mpDGVListaNominalow.Visible = true;
                // potwierdzenie wypłaty wymaganej kwoty
                mpTXTWyplacanaKwota.Text = mpTXTKwotaDoWyplaty.Text;
                // odsłonięcie kontrolek
                mpTXTWyplacanaKwota.Visible = true;
                mpLBLWyplacanaKwota.Visible = true;
                // odsłonięcie kontrolek operacyjnych
                mpBTNResetuj.Visible = true;
                mpBTNWyjscie.Visible = true;
                // ustawienie stanu aktywności dla przycisku poleceń AKCEPTACJA
                mpBTNAkceptacja.Enabled = false;
            }

        }

        static Boolean mpCzyWyplataMozeBycZrealizowana(mpNominaly[] mpPojemnikNominałów, float mpKwotaDoWypłaty)
        {
            float KapitałBankomatu = 0;
            for (int psi = 0; psi < mpPojemnikNominałów.Length; psi++)
                if (mpPojemnikNominałów[psi].mpLicznosc > 0)
                    KapitałBankomatu = KapitałBankomatu + mpPojemnikNominałów[psi].mpLicznosc * mpPojemnikNominałów[psi].mpWartosc;
            // zwrócenie wyniku
            return KapitałBankomatu >= mpKwotaDoWypłaty;
        }

        private void mpBTNWyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mpBTNResetuj_Click(object sender, EventArgs e)
        {
            // ustawienie "początkowe" kontrolki wyboru waluty
            mpCMBRodzajWaluty.SelectedIndex = 0;
            mpCMBRodzajWaluty.Enabled = true;
            // ustawienie "początkowe" kontrolek wypłaty
            mpTXTKwotaDoWyplaty.Text = "";
            mpTXTKwotaDoWyplaty.Enabled = false;
            mpLBLWyplacanaKwota.Visible = false;
            mpTXTWyplacanaKwota.Visible = false;
            // ukrycie przeycisków operacyjnych
            mpBTNResetuj.Visible = false;
            mpBTNWyjscie.Visible = false;
            // przywrócenie stanu początkowego kontrolek do określenie liczności nominałów
            mpBTNAkceptacjaLiczności.Enabled = true;
            // ustawnienie braku "zaznaczenia" kontrolek Radiobutton
            mpRDBUstawienieLicznosciDomyslne.Checked = true;
            // ustawienie stanu aktywności kontrolek Radiobutton
            mpRDBUstawienieLicznosciDomyslne.Enabled = true;
            mpRDBUstawieniePrzedziałuLiczności.Enabled = true;
        }

        private void mpBTNCofnij_Click(object sender, EventArgs e)
        {
            mpDoZaplaty[0] -= mpPojemnikProduktow[mpOstatniaAktywnosc].mpCenaPLN;
            mpDoZaplaty[1] -= mpPojemnikProduktow[mpOstatniaAktywnosc].mpCenaYEN;
            mpDoZaplaty[2] -= mpPojemnikProduktow[mpOstatniaAktywnosc].mpCenaEUR;
            mpKoszyk[mpOstatniaAktywnosc]--;
            if (mpKoszyk[mpOstatniaAktywnosc] == 0)
                mpKoszyk.Remove(mpOstatniaAktywnosc);
            mpAktualizacjaWyswietlanychDanych();
            mpBTNCofnij.Enabled = false;
        }
    }
    public class MPProdukt
    {
        public TextBox mpTXTCena { get; private set; }
        public float mpCenaPLN { get; private set; }
        public float mpCenaYEN { get; private set; }
        public float mpCenaEUR { get; private set; }
        public MPProdukt(TextBox mpTXTCena, float mpCenaPLN, float mpCenaYEN, float mpCenaEUR)
        {
            this.mpTXTCena = mpTXTCena;
            this.mpCenaPLN = mpCenaPLN;
            this.mpCenaYEN = mpCenaYEN;
            this.mpCenaEUR = mpCenaEUR;
        }
    }
}