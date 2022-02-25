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
    public partial class ProjektNr1_Palacz : Form
    {
        // deklaracja tablicy aktywności zakładek formularza
        bool[] stanTabPage = { true, false, false };

        public ProjektNr1_Palacz()
        {
            InitializeComponent();
            // ustawienie aktywnej zakładki Pulpit
            tcZakladki.SelectedTab = tabPage1;
        }

        private void tcZakladki_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tcZakladki.TabPages[0])
            {
                // sprawdzenie, czy ta zakładka może być aktywna
                if (stanTabPage[0])
                {
                    e.Cancel = false; // zezwolenie na przejście do zakładki tabPage1
                    tcZakladki.SelectedTab = tabPage1;
                }
                else
                    e.Cancel = true; // nie będzie przejścia do zakładki tabPage1
            }
            else
                if (e.TabPage == tcZakladki.TabPages[1])
                // sprawdzenie, czy jest zezwolenie na przejście do zakładki tabPage2
                if (stanTabPage[1])
                {
                    e.Cancel = false;
                    tcZakladki.SelectedTab = tabPage2;
                }
                else
                    e.Cancel = true;
            else
                if (e.TabPage == tcZakladki.TabPages[2])
                // sprawdzenie czy otwarcie tej zakładki jest dozwolone
                if (stanTabPage[2])
                {
                    e.Cancel = false;
                    tcZakladki.SelectedTab = tabPage3;
                }
                else
                    e.Cancel = true;
        }

        private void btnWyplata_Click(object sender, EventArgs e)
        {
            // zmiana stanu aktywności Pulpit
            stanTabPage[0] = false;
            // zezwolenie na przejście do zakładki Bankomat
            stanTabPage[1] = true;
            // otworzenie zakładki Bankomat
            tcZakladki.SelectedTab = tabPage2;
        }

        private void btnKupno_Click(object sender, EventArgs e)
        {
            // zmiana stanu aktywności Pulpit
            stanTabPage[0] = false;
            // zezwolenie na przejście do zakładki Automat vendingowy
            stanTabPage[2] = true;
            // otworzenie zakładki Automat vendingowy
            tcZakladki.SelectedTab = tabPage3;
        }
    }
    
}
