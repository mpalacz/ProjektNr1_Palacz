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
    public partial class Form2 : Form
    {
        private List<MPUzytkownik> mpListaUzytkownikow = new List<MPUzytkownik>();
        public Form2()
        {
            InitializeComponent();
            mpListaUzytkownikow.Add(new MPUzytkownik("admin", "admin@email.com", "admin"));
        }

        private bool mpCzyEmail(string mpEmail)
        {
            foreach (char znak in mpEmail)
                if (znak == '@') return true;
            return false;
        }

        private void mpBTNZaloguj_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Clear();
            bool mpCzyZalogowano = false;
            foreach(MPUzytkownik mpUzytkownik in mpListaUzytkownikow)
            {
                if (mpUzytkownik.mpCzyPorpawnyLogin(mpTXTLogin.Text))
                {
                    if (!mpUzytkownik.mpCzyPoprawneHaslo(mpTXTHaslo.Text))
                    {
                        MessageBox.Show("Wpisano niepoprawne hasło.", "Błędne hasło", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mpCzyZalogowano = true;
                }
            }
            if (!mpCzyZalogowano)
            {
                mpErrorProvider1.SetError(mpTXTLogin, "Wpisano nieporpawne dane logowania");
            }
            else
            {
                mpGRBLogowanie.Visible = false;
                mpGRBZalogowano.Visible = true;
            }
        }

        private void mpBTNZalozKonto_Click(object sender, EventArgs e)
        {
            mpTXTLogin.Text = "";
            mpTXTHaslo.Text = "";
            mpGRBLogowanie.Visible = false;
            mpGRBZakladanieKonta.Visible = true;
        }

        private void mpBTNZarejestroj_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Clear();
            if (!mpCzyEmail(mpTXTEmailNowegoKonta.Text))
            {
                mpErrorProvider1.SetError(mpTXTEmailNowegoKonta, "Wpisana wartośc nie jest adresem e-mail");
                return;
            }
            if (mpTXTHasloNowegoKonta.Text != mpTXTPowtorzoneHaslo.Text)
            {
                mpErrorProvider1.SetError(mpTXTPowtorzoneHaslo, "Hasła się różnią");
                return;
            }
            mpListaUzytkownikow.Add(new MPUzytkownik(mpTXTLoginNowegoKonta.Text, mpTXTEmailNowegoKonta.Text, mpTXTHasloNowegoKonta.Text));
            mpBTNAnulujZakladanieKonta.PerformClick();
        }

        private void mpBTNAnulujZakladanieKonta_Click(object sender, EventArgs e)
        {
            mpTXTEmailNowegoKonta.Text = "";
            mpTXTHasloNowegoKonta.Text = "";
            mpTXTLoginNowegoKonta.Text = "";
            mpTXTPowtorzoneHaslo.Text = "";
            mpGRBLogowanie.Visible = true;
            mpGRBZakladanieKonta.Visible = false;
            mpErrorProvider1.Clear();
        }
    }
    public class MPUzytkownik 
    {
        public string mpLogin { get; private set; }
        private string mpEmail { get; set; }
        private string mpHaslo { get; set; }

        public MPUzytkownik(string mpLogin, string mpEmail,string mpHaslo)
        {
            this.mpLogin = mpLogin;
            this.mpEmail = mpEmail;
            this.mpHaslo = mpHaslo;
        }
        public bool mpCzyPorpawnyLogin(string mpLogin)
        {
            return mpLogin == this.mpLogin || mpLogin == this.mpEmail;
        }
        public bool mpCzyPoprawneHaslo(string mpHaslo)
        {
            return this.mpHaslo == mpHaslo;
        }
    }
}
