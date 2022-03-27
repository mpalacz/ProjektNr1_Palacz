using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjektNr1_Palacz
{
    public partial class Form2 : Form
    {
        // lista przechowująca dane urzytkowników
        // (korzystam z listy na potrzeby projektu, gdyż w rzeczywistości dane znajdowały by się w zewnętrznej bazie danych)
        private List<MPUzytkownik> mpListaUzytkownikow = new List<MPUzytkownik>();

        public Form2()
        {
            InitializeComponent();
            mpListaUzytkownikow.Add(new MPUzytkownik("admin", "admin@email.com", "admin")); // dodanie urzytkownika do listy w celach testowych
        }

        // funkcja sprawdzająca czy dany string może być adresem e-mail
        private bool mpCzyEmail(string mpEmail)
        {
            foreach (char znak in mpEmail) // pętla przechodząca przez każdy znak w stringu
                if (znak == '@') return true; // jeśli w napisie znajduje się @, zwracana jest wartość true
            return false; // w przeciwnym wypadku zwracany jest false
        }

        // obsługa przycisku logującego urzytkownika do płatności
        private void mpBTNZaloguj_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Clear(); // wyczysczenie kontrolek errorProvider
            bool mpCzyZalogowano = false; // zmienna przechowuje informacje czy użyutkownik pomyślnie się zalogował
            foreach(MPUzytkownik mpUzytkownik in mpListaUzytkownikow) // pętka iterująca przez każdego urzytkownika
            {
                if (mpUzytkownik.mpCzyPorpawnyLogin(mpTXTLogin.Text)) // sprawdzenie czy dany login lub e-mail znajduje się w bazie 
                {
                    if (!mpUzytkownik.mpCzyPoprawneHaslo(mpTXTHaslo.Text)) // sprawdzenie czy hasło jest błędne
                    {
                        MessageBox.Show("Wpisano niepoprawne hasło.", "Błędne hasło", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        return; 
                    }
                    mpCzyZalogowano = true; // jeśli użytkonik podał właściwy login i hasło, status zmiennej zmienia się na true
                }
            }
            if (!mpCzyZalogowano) // sprawdzenie czy logowanie się nie powiodło
            {
                // w tej części funkcji jedynym możliwym powodem nieudanego logowania moży być tylko błędny login,
                // więc zostaje wyświetlona stosowna informacja
                mpErrorProvider1.SetError(mpTXTLogin, "Wpisano nieporpawne dane logowania");
            }
            else // przypadek gdy logowanie się powiedzie
            {
                // przejście do ekranu kończącego logowanie
                mpGRBLogowanie.Visible = false; 
                mpGRBZalogowano.Visible = true; 
            }
        }

        // obsługa przycisku przenoszącego do ekranu zakładania konta
        private void mpBTNZalozKonto_Click(object sender, EventArgs e)
        {
            // wyczyszczenie tekstu w kontrolkach textBox w ekranie logowania
            mpTXTLogin.Text = "";
            mpTXTHaslo.Text = "";
            mpGRBLogowanie.Visible = false; // ukrycie ekranu logowania
            mpGRBZakladanieKonta.Visible = true; // pokazanie ekranu ekranu zakładania konta
        }

        // obsługa przycisku rejestrującego nowego użytkownika
        private void mpBTNZarejestroj_Click(object sender, EventArgs e)
        {
            mpErrorProvider1.Clear(); // wyczysczenie kontrolek errorProvider
            if (!mpCzyEmail(mpTXTEmailNowegoKonta.Text)) // sprawdzenie czy podany e-mail nie może zostać uznany za adres e-mail
            {
                mpErrorProvider1.SetError(mpTXTEmailNowegoKonta, "Wpisana wartośc nie jest adresem e-mail"); 
                return; 
            }
            if (mpTXTHasloNowegoKonta.Text != mpTXTPowtorzoneHaslo.Text) // sprawdzenie czy potwierdzenie hasła się nie powiodło
            {
                mpErrorProvider1.SetError(mpTXTPowtorzoneHaslo, "Hasła się różnią"); 
                return; 
            }
            foreach (MPUzytkownik mpUzytkownik in mpListaUzytkownikow) // iterowanie przez listę użytkowników
            {
                if(mpUzytkownik.mpCzyPorpawnyLogin(mpTXTLoginNowegoKonta.Text)) // sprawdzenie czy istnieje konto o ponadym loginie
                {
                    MessageBox.Show("Podany login jest już wykorzystywany przez innego użytkownika.\nPodaj inny login", "Istnieje już taki użytkownik",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (mpUzytkownik.mpCzyPorpawnyLogin(mpTXTEmailNowegoKonta.Text)) // sprawdzenie czy na podanego maila istnieje już konto
                {
                    MessageBox.Show("Na podanego e-maila istnieje już utworzone konto.\nPodaj inny adres e-mail, albo spróbuj ponownie się zalogować.", "Wykorzystany e-mail",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // sytuacja gdy wszystkie dane zostały wpisane poprawnie
            // dodanie urzytkownika do listy
            mpListaUzytkownikow.Add(new MPUzytkownik(mpTXTLoginNowegoKonta.Text, mpTXTEmailNowegoKonta.Text, mpTXTHasloNowegoKonta.Text));
            mpBTNAnulujZakladanieKonta.PerformClick(); // przejście do ekranu logowania
        }

        // ubsługa przycisku służącego do powrotu do ekranu logowania
        private void mpBTNAnulujZakladanieKonta_Click(object sender, EventArgs e)
        {
            // wyczyszczenie tekstu w kontrolkach textBox w ekranie zakładanie konta
            mpTXTEmailNowegoKonta.Text = "";
            mpTXTHasloNowegoKonta.Text = "";
            mpTXTLoginNowegoKonta.Text = "";
            mpTXTPowtorzoneHaslo.Text = "";
            // przejście do ekranu logowania
            mpGRBLogowanie.Visible = true;
            mpGRBZakladanieKonta.Visible = false;
            // wyczyszczenie kontrolek errorProvider
            mpErrorProvider1.Clear();
        }
    }
    // klasa przechodująca dane użyutkownika
    public class MPUzytkownik 
    {
        public string mpLogin { get; private set; }
        public string mpEmail { get; private set; }
        private string mpHaslo { get; set; }

        public MPUzytkownik(string mpLogin, string mpEmail,string mpHaslo)
        {
            this.mpLogin = mpLogin;
            this.mpEmail = mpEmail;
            this.mpHaslo = mpHaslo;
        }

        // funkcja sprawdzająca czy podnay login jest prawidłowy (jako login może też służyć hasło)
        public bool mpCzyPorpawnyLogin(string mpLogin)
        {
            return mpLogin == this.mpLogin || mpLogin == this.mpEmail;
        }

        // funkcja sprawdzająca poprawność hasła
        public bool mpCzyPoprawneHaslo(string mpHaslo)
        {
            return this.mpHaslo == mpHaslo;
        }
    }
}
