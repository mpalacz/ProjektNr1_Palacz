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
        public ProjektNr1_Palacz53262()
        {
            InitializeComponent();
            // ustawienie aktywnej zakładki Pulpit
            mpTCZakladki.SelectedTab = mpTabPage1;
            mpBTNWyplata.Click += mpBTNWyplata_Click;
            mpBTNKupno.Click += mpBTNKupno_Click;
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
    }
}
