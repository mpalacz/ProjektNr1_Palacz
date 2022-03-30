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
        const ushort mpMargines = 20;
        const ushort mpMaxLicznoscNominalow = 100;
        const ushort mpBanknotONajnizszejWartosci = 10;
        float[] mpWartoscNominalow = { 200, 100, 50, 20, 10, 5, 2, 1, 0.5f, 0.2f, 0.1f };
        // deklaracja struktury (rekordu) opisującego element tablicy PojemnikNominalow
        struct mpNominaly
        {
            public float mpWartosc;
            public ushort mpLicznosc;
            public mpNominaly(float mpWartosc, ushort mpLicznosc)
            {
                this.mpWartosc = mpWartosc;
                this.mpLicznosc = mpLicznosc;
            }
        }
        // deklaracja zmiennej tablicowej (referencyjnej) pojemnik nominałów
        mpNominaly[] mpPojemnikNominalow;

        // Automat vendingowy
        private int mpIndexWaluty; // zmienna przechowująca indeks wybranej waluty (zmienna stworzona tylko w celach stylistycznych
        // waluty po kolei: PLN, YEN, EUR
        private Dictionary<float, ushort>[] mpDodaneSrodki = { new Dictionary<float, ushort>(), new Dictionary<float, ushort>(), new Dictionary<float, ushort>() }; // tablica przechowująca wartość wrzuconych pieniędzy w każdej walucie
        private float[] mpDoZaplaty = { 0f, 0f, 0f }; // tablica przechowująca łączną wartośc wybranych produktów
        private Dictionary<string, MPProdukt> mpPojemnikProduktow; // słownik przechowujący wszystkie produkty w automacie
        private Dictionary<string, ushort> mpKoszyk = new Dictionary<string, ushort>(); // słownik przechowujący produkty znajdujące się w koszyku
        private List<string> mpOstatnieAktywnosci = new List<string>(); // lista przechowująca ostatnie wykonane aktywności

        // deklaracja tablicy przechowującej nominały PLN
        mpNominaly[] mpPojemnikNominalowPLN = { new mpNominaly(200, 0), new mpNominaly(100, 0), new mpNominaly(50, 0),
            new mpNominaly(20, 0), new mpNominaly(10, 0), new mpNominaly(5, 0), new mpNominaly(2, 0), new mpNominaly(1, 0),
            new mpNominaly(0.5f, 0), new mpNominaly(0.2f, 0), new mpNominaly(0.1f, 0), new mpNominaly(0.05f, 0), new mpNominaly(0.02f, 0),
            new mpNominaly(0.01f, 0) };
        // deklaracja tablicy przechowującej nominały YEN
        mpNominaly[] mpPojemnikNominalowYEN = { new mpNominaly(10000, 0), new mpNominaly(5000, 0), new mpNominaly(1000, 0),
            new mpNominaly(500, 0), new mpNominaly(100, 0), new mpNominaly(50, 0), new mpNominaly(10, 0), new mpNominaly(5, 0),
            new mpNominaly(1, 0) };
        // deklaracja tablicy przechowującej nominały EUR
        mpNominaly[] mpPojemnikNominalowEUR = { new mpNominaly(200, 0), new mpNominaly(100, 0), new mpNominaly(50, 0),
            new mpNominaly(20, 0), new mpNominaly(10, 0), new mpNominaly(5, 0), new mpNominaly(2, 0), new mpNominaly(1, 0),
            new mpNominaly(0.5f, 0), new mpNominaly(0.2f, 0), new mpNominaly(0.1f, 0), new mpNominaly(0.05f, 0), new mpNominaly(0.02f, 0),
            new mpNominaly(0.01f, 0) };

        // funkcja wypełniająca mpPojemnikProduktow
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

        private float mpSumaDodanychSrodkow(int mpIndexWaluty)
        {
            if (mpDodaneSrodki[mpIndexWaluty].Count == 0)
                return 0;
            float mpSuma = 0;
            foreach (KeyValuePair<float, ushort> mpNominal in mpDodaneSrodki[mpIndexWaluty])
                mpSuma += mpNominal.Key * mpNominal.Value;
            return mpSuma;
        }

        // funkcja służąca wyświetleniu cen każdego produktu w wybranej walucie
        private void mpWyswietlenieCen()
        {
            string mpCena = "";
            foreach (MPProdukt mpProdukt in mpPojemnikProduktow.Values) // iterowanie przez każdy produkt
            {
                // sprawdzenie która waluta została wybrana 
                switch (mpIndexWaluty)  
                {
                    case 0: // PLN
                        mpCena = mpProdukt.mpCenaPLN + " PLN";
                        break;
                    case 1: // YEN
                        mpCena = mpProdukt.mpCenaYEN + "¥";
                        break;
                    case 2: // EUR
                        mpCena = mpProdukt.mpCenaEUR + "€";
                        break;
                }
                mpProdukt.mpTXTCena.Text = mpCena; // wyświetlenie ceny produktu we właściwej walucie w odpowiednim textBox
            } // czynność wykonywana dla każdego produktu
        }

        // wyświetlenie wartości mpWrzuconePieniadze, mpDoZaplaty oraz zawartości koszyka
        private void mpWyświetelnieDanych()
        {
            // sprawdznie jaka waluta została wybrana 
            // i wyświetlenie wartości mpWrzuconePieniadze i mpDoZaplaty w wybranej walucie
            switch (mpIndexWaluty)
            {
                case 0:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[0]) + " PLN";
                    mpTXTDodaneSrodki.Text = Convert.ToString(mpSumaDodanychSrodkow(0)) + " PLN";
                    break;
                case 1:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[1]) + "¥";
                    mpTXTDodaneSrodki.Text = Convert.ToString(mpSumaDodanychSrodkow(1)) + "¥";
                    break;
                case 2:
                    mpTXTDoZaplaty.Text = Convert.ToString(mpDoZaplaty[2]) + "€";
                    mpTXTDodaneSrodki.Text = Convert.ToString(mpSumaDodanychSrodkow(2)) + "€";
                    break;
            }
            // wyświetlenie koszyka
            mpRTBKoszyk.Text = ""; // wyczyszczenie textBoxa z zawartością koszyka
            if (mpKoszyk.Count != 0) // sprawdzenie czy koszyk nie jest pusty
            {
                foreach (KeyValuePair<string, ushort> mpProdukt in mpKoszyk) // iteropwanie przez kazdy produkt w koszyku
                {
                    mpRTBKoszyk.Text += $"{mpProdukt.Key} {mpProdukt.Value}x\n"; // dodanie nazwy i ilości wybranego produktu do textBoxa wyświetlającego koszyk
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

        // powrót do pulpitu
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
            mpBTNAdmin.Visible = true; // ponowne pokazanie przycisku mpBTNAdmin
        } 

        // Pulpit
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

            // tworzenie produktów i przypisywanie do nich cen
            mpPojemnikProduktow = mpStworzenieKonteneraProduktow();
            // ustawienie początkowych wartości dla metody płatności i rodzaju waluty
            mpCMBMetodaPlatnosci.SelectedIndex = 0;
            mpCMBRodzajWalutyAutomat.SelectedIndex = 0;
            // domyśle wygenerowanie losowych wartości liczności nominałów
            mpBTNAkceptacjaLicznościAutomat.PerformClick();
            mpGRBAdmin.Visible = false; // ukrycie funkcji administratora
        }

        // zamknięcie aplikacji
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
                mpErrorProvider1.SetError(mpBTNAkceptacjaLicznościBankomat, "ERROR: musisz wybrać spodów ustalenia licznośc nominałów");
                return;
            }
            // ustawienie stanu braku aktywności kontrolek RadioButton
            mpRDBUstawienieLicznosciDomyslne.Enabled = false;
            mpRDBUstawieniePrzedziałuLiczności.Enabled = false;
            // utworzenie generatora liczb losowaych
            Random mpRandom = new Random();
            //rozpoznanie która z kontrolek została wybrana
            if (mpRDBUstawienieLicznosciDomyslne.Checked)
            {
                // wpisanie wartości nominałów oraz ich liczności w tablicy pojemnik nominałów
                for (ushort i = 0; i < mpPojemnikNominalow.Length; i++)
                {
                    mpPojemnikNominalow[i].mpWartosc = mpWartoscNominalow[i];
                    mpPojemnikNominalow[i].mpLicznosc = (ushort)mpRandom.Next(mpMaxLicznoscNominalow);
                }
                // odsłonięcie kontrolek dla wizualizacji ustalonej liczności nominałów
                mpLBLWyplacaneNominaly.Visible = true;
                mpLBLWyplacaneNominaly.Text = "Wylosowane liczności nominałów";
                mpDGVListaNominalowBankomat.Visible = true;
                mpDGVListaNominalowBankomat.Rows.Clear();
                // wpisanie liczności nominałów do kontrolki DataGridView
                for (ushort i = 0; i < mpPojemnikNominalow.Length; i++)
                {
                    mpDGVListaNominalowBankomat.Rows.Add();
                    mpDGVListaNominalowBankomat.Rows[i].Cells[0].Value = mpPojemnikNominalow[i].mpLicznosc;
                    mpDGVListaNominalowBankomat.Rows[i].Cells[1].Value = mpPojemnikNominalow[i].mpWartosc;
                }
            }
            else
            {
                // wpisanie wartości nominałów oraz ich liczności w tablicy pojemnik nominałów
                for (ushort i = 0; i < mpPojemnikNominalow.Length; i++)
                {
                    mpPojemnikNominalow[i].mpWartosc = mpWartoscNominalow[i];
                    mpPojemnikNominalow[i].mpLicznosc = (ushort)mpRandom.Next(Convert.ToInt32(mpTXTDolnaGranicaPrzedzialu.Text), Convert.ToInt32(mpTXTGornaGranicaPrzedzialu.Text));
                }
                // odsłonięcie kontrolek dla wizualizacji ustalonej liczności nominałów
                mpLBLWyplacaneNominaly.Visible = true;
                mpLBLWyplacaneNominaly.Text = "Wylosowane liczności nominałów";
                mpDGVListaNominalowBankomat.Visible = true;
                mpDGVListaNominalowBankomat.Rows.Clear();
                // wpisanie liczności nominałów do kontrolki DataGridView
                for (ushort i = 0; i < mpPojemnikNominalow.Length; i++)
                {
                    mpDGVListaNominalowBankomat.Rows.Add();
                    mpDGVListaNominalowBankomat.Rows[i].Cells[0].Value = mpPojemnikNominalow[i].mpLicznosc;
                    mpDGVListaNominalowBankomat.Rows[i].Cells[1].Value = mpPojemnikNominalow[i].mpWartosc;
                }
            }
        }

        private void mpBTNAkceptacja_Click(object sender, EventArgs e)
        {
            float mpKwotaDoWypłaty;
            mpErrorProvider1.Dispose();
            if (string.IsNullOrEmpty(mpTXTKwotaDoWyplaty.Text))
            {

            }
            if (!float.TryParse(mpTXTKwotaDoWyplaty.Text, out mpKwotaDoWypłaty))
            {
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
            mpDGVListaNominalowBankomat.Rows.Clear();
            // ustawnienie indeksu wierszy kontrolki DataGridView
            ushort mpIndexDGV = 0;
            // iteracyjne dkonowanie wypłaty
            ushort mpLiczbaNominalow;
            while ((mpResztaDoWyplaty > 0.0F) && (mpIndexPojemnikaNominalow < mpPojemnikNominalow.Length))
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
                    mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpLicznosc = (ushort)(mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpLicznosc - mpLiczbaNominalow);
                }
                // dokonanie (symulacja) wypłaty nominałów liczności mpLiczbaNominalow
                if (mpLiczbaNominalow > 0)
                {
                    // dodanie nowego (pustego) wiersza
                    mpDGVListaNominalowBankomat.Rows.Add();
                    // wypełnienie poszczególnych pól (komórek) dodanego wiersza do kontrolki DataGridView
                    mpDGVListaNominalowBankomat.Rows[mpIndexDGV].Cells[0].Value = mpLiczbaNominalow;
                    mpDGVListaNominalowBankomat.Rows[mpIndexDGV].Cells[1].Value = mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpWartosc;
                    if (mpPojemnikNominalow[mpIndexPojemnikaNominalow].mpWartosc >= mpBanknotONajnizszejWartosci)
                        mpDGVListaNominalowBankomat.Rows[mpIndexDGV].Cells[2].Value = "banknot";
                    else
                        mpDGVListaNominalowBankomat.Rows[mpIndexDGV].Cells[2].Value = "moneta";
                    // wypisanie waluty
                    mpDGVListaNominalowBankomat.Rows[mpIndexDGV].Cells[3].Value = mpCMBRodzajWaluty.SelectedItem;
                    // wycentrowanie zapisów w poszczególnych komórkach
                    for (ushort i = 0; i < mpDGVListaNominalowBankomat.Columns.Count; i++)
                        mpDGVListaNominalowBankomat.Rows[mpIndexDGV].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                mpDGVListaNominalowBankomat.Visible = false;
            }
            else
            {
                // odsłaniamy kontrolki z wypłatą
                mpLBLWyplacaneNominaly.Visible = true;
                mpDGVListaNominalowBankomat.Visible = true;
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
            mpBTNAkceptacjaLicznościBankomat.Enabled = true;
            // ustawnienie braku "zaznaczenia" kontrolek Radiobutton
            mpRDBUstawienieLicznosciDomyslne.Checked = true;
            // ustawienie stanu aktywności kontrolek Radiobutton
            mpRDBUstawienieLicznosciDomyslne.Enabled = true;
            mpRDBUstawieniePrzedziałuLiczności.Enabled = true;
        }

        //Automat vendingowy
        // funkcja obsługująca zdarzenie zmiany waluty
        private void mpCMBRodzajWalutyAutomat_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpIndexWaluty = mpCMBRodzajWalutyAutomat.SelectedIndex; // przypisanie wybranego indexu kontrolki do 
            if (mpCMBMetodaPlatnosci.SelectedIndex == 0) // sprawdzenie czy została wybrana płatność gotówką
            {
                // sprawdzenie która waluta została wybrana i wyświetlenie stosownego onka z nominałami
                switch (mpIndexWaluty) 
                {
                    case 0: // PLN
                        mpGRBEuro.Visible = false;
                        mpGRBJeny.Visible = false;
                        mpGRBZlotowki.Visible = true;
                        break;
                    case 1: // YEN
                        mpGRBEuro.Visible = false;
                        mpGRBJeny.Visible = true;
                        mpGRBZlotowki.Visible = false;
                        break;
                    case 2: // EUR
                        mpGRBEuro.Visible = true;
                        mpGRBJeny.Visible = false;
                        mpGRBZlotowki.Visible = false;
                        break;
                }
            }
            // aktualizacja wyświetlanych danych
            mpWyswietlenieCen();
            mpWyświetelnieDanych();
        }

        // funkcja obsługująca zdarzenie zmiany metody płatności
        private void mpCMBMetodaPlatnosci_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sprawdzenie która metoda płatności została wybrana i wyświetlenie stosownych kontrolek
            switch (mpCMBMetodaPlatnosci.SelectedIndex)
            {
                case 0: // gotówka
                    mpLBLPlatnoscKarta.Visible = false;
                    mpBTNPlatnoscKarta.Visible = false;
                    mpBTNKupnoGotowka.Visible = true;
                    // wyświetlenie odpowieniej kontrolki, zawierającaj nominały o wybranej walucie
                    mpCMBRodzajWalutyAutomat_SelectedIndexChanged(sender, e);
                    break;
                case 1: // karta
                    mpGRBJeny.Visible = false;
                    mpGRBEuro.Visible = false;
                    mpGRBZlotowki.Visible = false;
                    mpLBLPlatnoscKarta.Visible = true;
                    mpBTNPlatnoscKarta.Visible = true;
                    mpBTNKupnoGotowka.Visible = false;
                    break;
            }
        }

        // funkcja dodająca do koszyka wybrany produkt
        private void mpDodajDoKoszyka(string mpNazwaProduktu)
        {
            try { mpKoszyk[mpNazwaProduktu]++; } // próba zwiększenia ilości produktu w koszyku, jeśli dany produkt został wcześniej dodany do koszyka
            catch { mpKoszyk.Add(mpNazwaProduktu, 1); } // dodanie produktu do koszyka jeśli wcześniej nie zostało to wykonane
            finally
            {
                // zwiększenie wartości do zapłaty w każdej walucie
                mpDoZaplaty[0] += mpPojemnikProduktow[mpNazwaProduktu].mpCenaPLN;
                mpDoZaplaty[1] += mpPojemnikProduktow[mpNazwaProduktu].mpCenaYEN;
                mpDoZaplaty[2] += mpPojemnikProduktow[mpNazwaProduktu].mpCenaEUR;
                mpWyświetelnieDanych(); // aktualizacja wyświetlanych danych
                mpOstatnieAktywnosci.Add(mpNazwaProduktu); // zapisanie aktywności dodania produtku
                mpBTNCofnij.Enabled = true; // udostępnienie funkcji cofnięcia dodania produktu
            }
        }

        // obsługa przycisków służących do wyboru produktów
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

        // funkcja dodająca środki za pomocą gotówki
        private void mpWrzutPieniedzy(int mpIndexWaluty, float mpKwota)
        {
            if (!mpDodaneSrodki[mpIndexWaluty].ContainsKey(mpKwota))
                mpDodaneSrodki[mpIndexWaluty].Add(mpKwota, 1);
            else
                for (ushort mpI = 0; mpI < mpDodaneSrodki[mpIndexWaluty].Count; mpI++)
                {
                    KeyValuePair<float, ushort> mpElement = mpDodaneSrodki[mpIndexWaluty].ElementAt(mpI);
                    if (mpElement.Key == mpKwota)
                        mpDodaneSrodki[mpIndexWaluty][mpI]++;
                }
            mpWyświetelnieDanych(); // aktualizacja wyświetlanych danych
        }

        // obsługa przycisków służących do wrzucenia gotówki
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

        // funkcja zwracająca wrzuconą gotówkę
        private void mpZwrotPieniedzy()
        {
            // wyzerowanie wartości wrzyconych pieniędzy
            mpDodaneSrodki[0] = new Dictionary<float, ushort>();
            mpDodaneSrodki[1] = new Dictionary<float, ushort>();
            mpDodaneSrodki[2] = new Dictionary<float, ushort>();
            mpWyświetelnieDanych(); // aktualizacja wyświetlanych danych
        }


        // kliknięcie przycisku obsługującego zwrot gotówki
        private void mpBTNZwrotMonet_Click(object sender, EventArgs e)
        {
            if (mpSumaDodanychSrodkow(0) + mpSumaDodanychSrodkow(1) + mpSumaDodanychSrodkow(2) == 0) // sprawdzenie czy nie zostały dodane środki za pomocą gotówki
            {
                MessageBox.Show("Nie wrzucono żadnych pieniędzy!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // upewnienie sie czy użytkownik jest pewny swojej decyzji
            if (MessageBox.Show("Czy na pewno chcesz dokonać zwrotu monet?", "Zwrót monet", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) 
                mpZwrotPieniedzy(); 
        }

        // funkcja orpóżniająca (resetująca) koszyk
        private void mpOproznienieKoszyka()
        {
            // wyzerowanie wartości do zapłaty
            mpDoZaplaty[0] = 0;
            mpDoZaplaty[1] = 0;
            mpDoZaplaty[2] = 0;
            mpKoszyk = new Dictionary<string, ushort>(); // przypisanie nowego pustego słownika do koszyka
            mpWyświetelnieDanych(); // aktualizacja wyświetlanych danych
        }

        // kliknięcie przycisku obsługującego reset koszyka
        private void mpBTNResetKoszyka_Click(object sender, EventArgs e)
        {
            if (mpKoszyk.Count == 0) // sprawdzenie czy koszyk jest pusty
            {
                MessageBox.Show("Nie wybrano żadnego produktu!", "Pusty koszyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // upewnienie sie czy użytkownik jest pewny swojej decyzji
            if (MessageBox.Show("Czy na pewno chcesz zresetować koszyk?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mpOproznienieKoszyka();
                // sprawdzenie czy zostały dodane środki w formie gotówki
                if (mpSumaDodanychSrodkow(mpIndexWaluty) != 0)
                    // sprawdzenie czy użtywkownik chce dodatkowo otrzymać zwrot gotówki
                    if (MessageBox.Show("Czy zwrócić dodane środki?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        mpZwrotPieniedzy();
                // reset funkcji cofania
                mpOstatnieAktywnosci = new List<string>();
                mpBTNCofnij.Enabled = false;
            }
        }

        private void mpRDBLosowyPrzedzialLicznosciAutomat_CheckedChanged(object sender, EventArgs e)
        {
            // ustawnienie drugiej kontrolki na wartość przeciwną
            mpRDBUstalonyPrzedzialLicznosciAutomat.Checked = !mpRDBDomyslnyPrzedzialLicznosciAutomat.Checked;
            // zmiana parametru Visble kontrolek związanych z granicą przedziału na true
            mpLBLDolnaGranicaLicznosciAutomat.Visible = false;
            mpLBLGornaGranicaLicznosciAutomat.Visible = false;
            mpTXTDolnaGranicaLicznosciAutomat.Visible = false;
            mpTXTGornaGranicaLicznosciAutomat.Visible = false;
        }

        private void mpRDBUstalonyPrzedzialLicznosciAutomat_CheckedChanged(object sender, EventArgs e)
        {
            // ustawnienie drugiej kontrolki na wartość przeciwną
            mpRDBUstalonyPrzedzialLicznosciAutomat.Checked = !mpRDBDomyslnyPrzedzialLicznosciAutomat.Checked;
            // zmiana parametru Visble kontrolek związanych z granicą przedziału na true
            mpLBLDolnaGranicaLicznosciAutomat.Visible = true;
            mpLBLGornaGranicaLicznosciAutomat.Visible = true;
            mpTXTDolnaGranicaLicznosciAutomat.Visible = true;
            mpTXTGornaGranicaLicznosciAutomat.Visible = true;
        }

        // funkcja wyświetlajaca liczność nominałów w kontrolce mpDGVListaNominalowAutomat
        private void mpWyswietlenieLicznosci()
        {
            mpDGVListaNominalowAutomat.Rows.Clear(); // wyczyszczenie kontrolki mpDGVListaNominalowAutomat
            for (ushort mpI = 0; mpI < mpPojemnikNominalowPLN.Length; mpI++) // iterowanie przez elementy tablicy mpPojemnikNominalowPLN
            {
                mpDGVListaNominalowAutomat.Rows.Add(); // dodanie wiersza do mpDGVListaNominalowAutomat
                mpDGVListaNominalowAutomat.Rows[mpI].Cells[0].Value = mpPojemnikNominalowPLN[mpI].mpWartosc + " PLN"; // wyświetlenie wartości namonału
                mpDGVListaNominalowAutomat.Rows[mpI].Cells[1].Value = mpPojemnikNominalowPLN[mpI].mpLicznosc; // wyświetlenie liczności nominału
            }
            // Ten sam algorymt jest wykonywany, dla pozostałych walut, z tą różnicą, że do indeksu wiersza kontrolki
            // mpDGVListaNominalowAutomat dodawana jest długość tablicy pojemnika nominałów wcześniej ziterowanej waluty,
            // by móc iterować przez kolejne wiersze kontrolki mpDGVListaNominalowAutomat.
            for (ushort mpI = 0; mpI < mpPojemnikNominalowYEN.Length; mpI++)
            {
                mpDGVListaNominalowAutomat.Rows.Add();
                mpDGVListaNominalowAutomat.Rows[mpI + mpPojemnikNominalowPLN.Length].Cells[0].Value = mpPojemnikNominalowYEN[mpI].mpWartosc + "¥";
                mpDGVListaNominalowAutomat.Rows[mpI + mpPojemnikNominalowPLN.Length].Cells[1].Value = mpPojemnikNominalowYEN[mpI].mpLicznosc;
            }
            for (ushort mpI = 0; mpI < mpPojemnikNominalowEUR.Length; mpI++)
            {
                mpDGVListaNominalowAutomat.Rows.Add();
                mpDGVListaNominalowAutomat.Rows[mpI + mpPojemnikNominalowPLN.Length + mpPojemnikNominalowYEN.Length].Cells[0].Value =
                    mpPojemnikNominalowEUR[mpI].mpWartosc + "€";
                mpDGVListaNominalowAutomat.Rows[mpI + mpPojemnikNominalowPLN.Length + mpPojemnikNominalowYEN.Length].Cells[1].Value = mpPojemnikNominalowEUR[mpI].mpLicznosc;
            }
        }

        // obsługa przycisku udostępniającego funkcje administratora
        private void mpBTNAdmin_Click(object sender, EventArgs e)
        {
            mpGRBAdmin.Visible = true; // wyświetlenie panelu administratora
            mpBTNAdmin.Visible = false; // schowanie przycisku
        }

        // kliknięcie przycisku obsługującego losowanie liczności nominałów
        private void mpBTNAkceptacjaLicznościAutomat_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Clear(); // wyczyszczenie kontrolki mpErrorProvider1
            ushort mpDolnaGranicaLicznosciAutomat, mpGornaGranicaLicznosciAutomat; // zmienne przechowujące dolną i górną granicę licznośći
            if (mpRDBDomyslnyPrzedzialLicznosciAutomat.Checked) // jeśli mpRDBLosowyPrzedzialLicznosciAutomat jest zaznaczony, ustawiane są wartości domyślne
            {
                mpDolnaGranicaLicznosciAutomat = 0; // 0 jest najmniejszym możliwym minimum (liczność nie może być mniejsza od zera)
                mpGornaGranicaLicznosciAutomat = mpMaxLicznoscNominalow; // stała pochądząca z projektu Bankomat, definiująca domyślą górną granicę liczności
            }
            else // jeśli mpRDBUstalonyPrzedzialLicznosciAutomat jest zaznaczony, przedziały liczności są podawane przez użytkownika administratora (w domyśle adminitratora)
            {
                // sprawdzenie czy w textBoxach wpisano liczby naturalne
                if (!ushort.TryParse(mpTXTDolnaGranicaLicznosciAutomat.Text, out mpDolnaGranicaLicznosciAutomat))
                {
                    mpErrorProvider1.SetError(mpTXTDolnaGranicaLicznosciAutomat, "Wpisano nie właściwy znak, podaj liczbę naturalną...");
                    return;
                }
                if (!ushort.TryParse(mpTXTGornaGranicaLicznosciAutomat.Text, out mpGornaGranicaLicznosciAutomat))
                {
                    mpErrorProvider1.SetError(mpTXTGornaGranicaLicznosciAutomat, "Wpisano nie właściwy znak, podaj liczbę naturalną...");
                    return;
                }
                // sprawdzenie czy dolna granica przedziału jest mniejsza do górnej
                if (mpDolnaGranicaLicznosciAutomat >= mpGornaGranicaLicznosciAutomat)
                {
                    mpErrorProvider1.SetError(mpTXTDolnaGranicaLicznosciAutomat, "Dolna granica przedziału liczności, musi być mnijesza niż górna.");
                    return;
                }
            }
            Random mpRandom = new Random(); // wywołanie generatora liczb losowych
            for (ushort mpI = 0; mpI < mpPojemnikNominalowPLN.Length; mpI++) // iterowanie przez indeksy mpPojemnikNominalowPLN
            {
                // przypisywanie losowych wartośc w ustawionych granicach (losowane są jednocześnie liczności
                // dla nominałów w mpPojemnikNominalowPLN i mpPojemnikNominalowEUR, gdyż obie talice tablice mają tą samą długość)
                mpPojemnikNominalowPLN[mpI].mpLicznosc = (ushort)(mpRandom.Next(mpDolnaGranicaLicznosciAutomat, mpGornaGranicaLicznosciAutomat));
                mpPojemnikNominalowEUR[mpI].mpLicznosc = (ushort)(mpRandom.Next(mpDolnaGranicaLicznosciAutomat, mpGornaGranicaLicznosciAutomat));
            }
            // ta sama czynność dla mpPojemnikNominalowYEN
            for (ushort mpI = 0; mpI < mpPojemnikNominalowYEN.Length; mpI++)
                mpPojemnikNominalowYEN[mpI].mpLicznosc = (ushort)(mpRandom.Next(mpDolnaGranicaLicznosciAutomat, mpGornaGranicaLicznosciAutomat));
            mpWyswietlenieLicznosci(); // wyświetlenie wyników w kontrolce mpDGVListaNominalowAutomat
        }

        // kliknięcie przycisku obsługującego zakup za pomocą gotówki
        private void mpBTNKupnoGotowka_Click(object sender, EventArgs e)
        {
            if (mpKoszyk.Count() == 0) // sprawdzenie czy koszyk jest pusty
            {
                MessageBox.Show("Koszyk jest pusty.", "Pusty koszyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // sprawdzenie czy dodana kwota nie jest wystarczająca do zakupu produktów w wybranej walucie
            else if (mpSumaDodanychSrodkow(mpIndexWaluty) < mpDoZaplaty[mpIndexWaluty]) 
            {
                MessageBox.Show("Wrzucona kwota jest za mała.", "Za mało pieniędzy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mpKomunikat = "Zakupiono:\n" + mpRTBKoszyk.Text + "Reszta: "; // zmienna przchowująca komunikat z listą produtków i resztą
            string mpNazwaWaluty = "", mpNazwaZdawkowej = ""; // zmienne przechowujące nazwy wybranej waluty
            // zmienna określająca liczbę nominałów w danej walucie
            // (potrzebne przy iterowaniu przez nominały, by wypisać odpowienią nazwę)
            ushort mpLiczbaNiezdawkowych = 0; 
            List<mpNominaly[]> mpPojemnikNominalow = new List<mpNominaly[]>(); // lista przechowujące tablice nominalów w każdej walucie
            mpPojemnikNominalow.Add(mpPojemnikNominalowPLN);
            mpPojemnikNominalow.Add(mpPojemnikNominalowYEN);
            mpPojemnikNominalow.Add(mpPojemnikNominalowEUR);
            float mpReszta = 0; // zmienna przechowująca resztę
            ushort mpIloscNominalowDoWydania; // zmienna pomocnicza przechowująca liczność nominału, który zostanie wydany użytkownikowi
            switch (mpIndexWaluty)
            {
                case 0:
                    mpNazwaWaluty = "PLN";
                    mpNazwaZdawkowej = "groszy";
                    mpLiczbaNiezdawkowych = 7;
                    break;
                case 1:
                    mpNazwaWaluty = "¥";
                    mpLiczbaNiezdawkowych = 9;
                    break;
                case 2:
                    mpNazwaWaluty = "€";
                    mpNazwaZdawkowej = "centów";
                    mpLiczbaNiezdawkowych = 7;
                    break;
            }
            mpKomunikat += (mpReszta = mpSumaDodanychSrodkow(mpIndexWaluty) - mpDoZaplaty[mpIndexWaluty]) + mpNazwaWaluty + "\n";
            for (int mpI = 0; mpI <= mpLiczbaNiezdawkowych && mpReszta >= 1; mpI++) // iterowanie przez wszystkie nominały niezdawkowe dopuki reszta jest różna od 0
            {
                // jeśli w automacie brakuje środków o danym nominale, wykonywane jest przejście to do kolejnego mniejszego nominału
                if (mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc == 0) continue;
                // obliczenie ile w wartości reszty mieści się monet/banknotów o danej wartości
                mpIloscNominalowDoWydania = (ushort)(mpReszta / mpPojemnikNominalow[mpIndexWaluty][mpI].mpWartosc);
                if (mpIloscNominalowDoWydania != 0) // sprawdzenie czy mpIloscNominalowDoWydania jest różne od 0
                {
                    // jeśli mpIloscNominalowDoWydania jest większa od zasobów automatu, do mpIloscNominalowDoWydania przypisywana jest liczność danego nominału
                    if (mpIloscNominalowDoWydania > mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc) 
                        mpIloscNominalowDoWydania = mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc;
                    // dodanie do komuniaktu ilości wydawanego nominału nominału
                    mpKomunikat += $"{mpIloscNominalowDoWydania}x {mpPojemnikNominalow[mpIndexWaluty][mpI].mpWartosc} {mpNazwaWaluty}\n"; 
                    mpReszta -= mpPojemnikNominalow[mpIndexWaluty][mpI].mpWartosc * mpIloscNominalowDoWydania; // odjęcie od reszty wydanych nominałów
                    mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc -= mpIloscNominalowDoWydania; // zmiejszenie ilości nominałów o wydawaną resztę
                }
            }
            // ten sam algorytm wykonywany jest dla monet zdawkowych (tylko przy PLN i EUR, bo YEN nie ma monet zdawkowych)
            if (mpIndexWaluty != 1)
            {
                for (int mpI = 8; mpI < mpPojemnikNominalow[mpIndexWaluty].Length && mpReszta > 0; mpI++)
                {
                    if (mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc == 0) continue;
                    mpIloscNominalowDoWydania = (ushort)(mpReszta / mpPojemnikNominalow[mpIndexWaluty][mpI].mpWartosc);
                    if (mpIloscNominalowDoWydania != 0)
                    {
                        if (mpIloscNominalowDoWydania > mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc) 
                            mpIloscNominalowDoWydania = mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc;
                        mpKomunikat += $"{mpIloscNominalowDoWydania}x {mpPojemnikNominalow[mpIndexWaluty][mpI].mpWartosc * 100} {mpNazwaZdawkowej}\n";
                        mpReszta -= mpPojemnikNominalow[mpIndexWaluty][mpI].mpWartosc * mpIloscNominalowDoWydania;
                        mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc -= mpIloscNominalowDoWydania;
                    }
                }
            }
            // jeśli zostały dodane środki w innych walutach, zostaje wyświetlona informacja o ich zwrocie
            if (mpSumaDodanychSrodkow(0) + mpSumaDodanychSrodkow(1) + mpSumaDodanychSrodkow(2) - mpSumaDodanychSrodkow(mpIndexWaluty) != 0)
                mpKomunikat += "Dodatkowo zwrócono dodane w pozostałych walutach środki";
            if (mpReszta > 0) // jeśli reszta pozostanie większa od zera, funkcja nie została wykonana poprawnie przez brak nominałów do wydania reszty
            {
                MessageBox.Show("Nie można zrealizować opecji, gdyż automat nie posiada wystarczającej ilości sródków do wydania reszty." +
                    "\nProszę wykorzystać inne nominały lub walutę, albo skorzystać z płatności kartą.", "Nie można wydać reszty", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(mpKomunikat, "Na zdrowie!", MessageBoxButtons.OK, MessageBoxIcon.Information); // wyświetlenie komunikatu
            // dodanie wrzuconej przez użytkownika gotówki, to odpowiedniego pojemnika nominałów
            for (ushort mpI = 0; mpI < mpPojemnikNominalow[mpIndexWaluty].Length; mpI++) // iterowanie przez mpPojemnikNominalow dla wybranej waluty
                foreach (KeyValuePair<float, ushort> mpNominal in mpDodaneSrodki[mpIndexWaluty]) // iterowanie przez mpDodaneSrodki dla wybranej waluty
                    if (mpPojemnikNominalow[mpIndexWaluty][mpI].mpWartosc == mpNominal.Key) // jeśli zostanie znaleziony dodany nominał
                        // jego liczność w pojemniku nominałów jest zwiększana o ilość dodanych nominałów
                        mpPojemnikNominalow[mpIndexWaluty][mpI].mpLicznosc += mpNominal.Value; 
            // wyzerowanie zmiennych mpDoZaplaty i mpWrzuconePieniadze
            mpZwrotPieniedzy();
            mpOproznienieKoszyka();
            // wyświetlenie zaktualizowanych danych dotyczących liczności każdego nominału
            mpWyswietlenieLicznosci();
            // zresetowanie i zablokowanie funkcji cofania
            mpOstatnieAktywnosci = new List<string>();
            mpBTNCofnij.Enabled = false;
        }

        // kliknięcie przycisku obsługującego zakup za pomocą karty
        private void mpBTNPlatnoscKarta_Click(object sender, EventArgs e)
        {
            if (mpKoszyk.Count() == 0) // sprawdzenie czy koszyk jest pusty
            {
                MessageBox.Show("Koszyk jest pusty.", "Pusty koszyk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form2 mpLoginForm = new Form2(); // utworzenie obiektu drugiego okna, służącego do zalogowania się
            mpLoginForm.ShowDialog(); // wyświetlenie okna
            if (mpLoginForm.DialogResult == DialogResult.OK) // sprawdzenie czy logowanie zostało wykonane pomyślnie
            {
                string mpWaluta = ""; // zmienna przechowująca oznaczenie wybranej waluty
                // sprawdzenie która waluta została wybrana
                // i przypisanie odpowiedniej wartości do mpWaluta
                switch (mpIndexWaluty) 
                {
                    case 0:
                        mpWaluta = "PLN";
                        break;
                    case 1:
                        mpWaluta = "¥";
                        break;
                    case 2:
                        mpWaluta = "€";
                        break;
                }
                MessageBox.Show("Zakupiono:\n" + mpRTBKoszyk.Text + "Łączna kwota: " +
                    mpDoZaplaty[mpIndexWaluty] + mpWaluta, "Na zdrowie!"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information); // wyświetlenie zawartości koszyka i jego wartości
                if (mpSumaDodanychSrodkow(0) + mpSumaDodanychSrodkow(1) + mpSumaDodanychSrodkow(2) != 0) // sprawdzenie czy do automatu została wrzucona gotówka
                {
                    MessageBox.Show("Zwrócono wprowadzoną gotówkę.", "Zwrot gotówki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mpZwrotPieniedzy();
                }
                mpOproznienieKoszyka();
            }
        }

        // kliknięcie przycisku obsługującego cofnięcie ostatniego dodanie produktu do koszyka
        private void mpBTNCofnij_Click(object sender, EventArgs e)
        {
            // zmiejszenie mpDoZaplaty o wartość ostatnio dodanego produktu
            mpDoZaplaty[0] -= mpPojemnikProduktow[mpOstatnieAktywnosci[mpOstatnieAktywnosci.Count - 1]].mpCenaPLN;
            mpDoZaplaty[1] -= mpPojemnikProduktow[mpOstatnieAktywnosci[mpOstatnieAktywnosci.Count - 1]].mpCenaYEN;
            mpDoZaplaty[2] -= mpPojemnikProduktow[mpOstatnieAktywnosci[mpOstatnieAktywnosci.Count - 1]].mpCenaEUR;
            mpKoszyk[mpOstatnieAktywnosci[mpOstatnieAktywnosci.Count - 1]]--; // zmiejszenie ilości ostatnio dodanego produktu w koszyku o 1
            if (mpKoszyk[mpOstatnieAktywnosci[mpOstatnieAktywnosci.Count - 1]] == 0) // sprawdzenie czy cofnięty produkt, był ostatnim egzemplarzem w koszyku
                mpKoszyk.Remove(mpOstatnieAktywnosci[mpOstatnieAktywnosci.Count - 1]); // usunięcie typu produktu z koszyka
            mpWyświetelnieDanych(); // aktualizacja wyświetlanych danych
            mpOstatnieAktywnosci.RemoveAt(mpOstatnieAktywnosci.Count - 1); // usunięcie ostatniej aktywności, która została właśnie cofnięta
            if (mpOstatnieAktywnosci.Count == 0) // sprawdzenie czy lista ostatnich aktywności jest pusta
                mpBTNCofnij.Enabled = false; // zablokowanie funkcji cofnięcia
        }
    }

    // klasa przechowująca wszystkie informacje o produkcie
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