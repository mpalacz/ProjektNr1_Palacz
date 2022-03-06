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

        public ProjektNr1_Palacz53262()
        {
            InitializeComponent();
            // ustawienie aktywnej zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
        }

        private void tcZakladki_Selecting(object sender, TabControlCancelEventArgs e)
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

        private void btnWyplata_Click(object sender, EventArgs e)
        {
            // zmiana stanu aktywności Pulpit
            mpStanTabPage[0] = false;
            // zezwolenie na przejście do zakładki Bankomat
            mpStanTabPage[1] = true;
            // otworzenie zakładki Bankomat
            mpTCZakladki.SelectedTab = mpTabPage2;
        }

        private void btnKupno_Click(object sender, EventArgs e)
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
    }
    
}
