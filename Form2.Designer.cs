
namespace ProjektNr1_Palacz53262
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mpGRBLogowanie = new System.Windows.Forms.GroupBox();
            this.mpBTNZalozKonto = new System.Windows.Forms.Button();
            this.mpBTNAnuluj = new System.Windows.Forms.Button();
            this.mpBTNZaloguj = new System.Windows.Forms.Button();
            this.mpTXTHaslo = new System.Windows.Forms.TextBox();
            this.mpTXTLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mpGRBZakladanieKonta = new System.Windows.Forms.GroupBox();
            this.mpBTNAnulujZakladanieKonta = new System.Windows.Forms.Button();
            this.mpBTNZarejestroj = new System.Windows.Forms.Button();
            this.mpTXTHasloNowegoKonta = new System.Windows.Forms.TextBox();
            this.mpTXTPowtorzoneHaslo = new System.Windows.Forms.TextBox();
            this.mpTXTLoginNowegoKonta = new System.Windows.Forms.TextBox();
            this.mpTXTEmailNowegoKonta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mpErrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mpGRBLogowanie.SuspendLayout();
            this.mpGRBZakladanieKonta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mpErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mpGRBLogowanie
            // 
            this.mpGRBLogowanie.Controls.Add(this.mpBTNZalozKonto);
            this.mpGRBLogowanie.Controls.Add(this.mpBTNAnuluj);
            this.mpGRBLogowanie.Controls.Add(this.mpBTNZaloguj);
            this.mpGRBLogowanie.Controls.Add(this.mpTXTHaslo);
            this.mpGRBLogowanie.Controls.Add(this.mpTXTLogin);
            this.mpGRBLogowanie.Controls.Add(this.label2);
            this.mpGRBLogowanie.Controls.Add(this.label1);
            this.mpGRBLogowanie.Location = new System.Drawing.Point(12, 12);
            this.mpGRBLogowanie.Name = "mpGRBLogowanie";
            this.mpGRBLogowanie.Size = new System.Drawing.Size(284, 285);
            this.mpGRBLogowanie.TabIndex = 0;
            this.mpGRBLogowanie.TabStop = false;
            this.mpGRBLogowanie.Text = "Logowanie";
            // 
            // mpBTNZalozKonto
            // 
            this.mpBTNZalozKonto.Location = new System.Drawing.Point(92, 232);
            this.mpBTNZalozKonto.Name = "mpBTNZalozKonto";
            this.mpBTNZalozKonto.Size = new System.Drawing.Size(98, 39);
            this.mpBTNZalozKonto.TabIndex = 5;
            this.mpBTNZalozKonto.Text = "Załóż konto";
            this.mpBTNZalozKonto.UseVisualStyleBackColor = true;
            this.mpBTNZalozKonto.Click += new System.EventHandler(this.mpBTNZalozKonto_Click);
            // 
            // mpBTNAnuluj
            // 
            this.mpBTNAnuluj.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mpBTNAnuluj.Location = new System.Drawing.Point(201, 232);
            this.mpBTNAnuluj.Name = "mpBTNAnuluj";
            this.mpBTNAnuluj.Size = new System.Drawing.Size(70, 39);
            this.mpBTNAnuluj.TabIndex = 4;
            this.mpBTNAnuluj.Text = "Anuluj";
            this.mpBTNAnuluj.UseVisualStyleBackColor = true;
            // 
            // mpBTNZaloguj
            // 
            this.mpBTNZaloguj.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mpBTNZaloguj.Location = new System.Drawing.Point(14, 232);
            this.mpBTNZaloguj.Name = "mpBTNZaloguj";
            this.mpBTNZaloguj.Size = new System.Drawing.Size(70, 39);
            this.mpBTNZaloguj.TabIndex = 3;
            this.mpBTNZaloguj.Text = "Zaloguj";
            this.mpBTNZaloguj.UseVisualStyleBackColor = true;
            this.mpBTNZaloguj.Click += new System.EventHandler(this.mpBTNZaloguj_Click);
            // 
            // mpTXTHaslo
            // 
            this.mpTXTHaslo.Location = new System.Drawing.Point(14, 138);
            this.mpTXTHaslo.Name = "mpTXTHaslo";
            this.mpTXTHaslo.Size = new System.Drawing.Size(257, 26);
            this.mpTXTHaslo.TabIndex = 2;
            this.mpTXTHaslo.UseSystemPasswordChar = true;
            // 
            // mpTXTLogin
            // 
            this.mpTXTLogin.Location = new System.Drawing.Point(14, 50);
            this.mpTXTLogin.Name = "mpTXTLogin";
            this.mpTXTLogin.Size = new System.Drawing.Size(257, 26);
            this.mpTXTLogin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasło";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login lub e-mail";
            // 
            // mpGRBZakladanieKonta
            // 
            this.mpGRBZakladanieKonta.Controls.Add(this.mpBTNAnulujZakladanieKonta);
            this.mpGRBZakladanieKonta.Controls.Add(this.mpBTNZarejestroj);
            this.mpGRBZakladanieKonta.Controls.Add(this.mpTXTHasloNowegoKonta);
            this.mpGRBZakladanieKonta.Controls.Add(this.mpTXTPowtorzoneHaslo);
            this.mpGRBZakladanieKonta.Controls.Add(this.mpTXTLoginNowegoKonta);
            this.mpGRBZakladanieKonta.Controls.Add(this.mpTXTEmailNowegoKonta);
            this.mpGRBZakladanieKonta.Controls.Add(this.label6);
            this.mpGRBZakladanieKonta.Controls.Add(this.label5);
            this.mpGRBZakladanieKonta.Controls.Add(this.label4);
            this.mpGRBZakladanieKonta.Controls.Add(this.label3);
            this.mpGRBZakladanieKonta.Location = new System.Drawing.Point(12, 12);
            this.mpGRBZakladanieKonta.Name = "mpGRBZakladanieKonta";
            this.mpGRBZakladanieKonta.Size = new System.Drawing.Size(284, 285);
            this.mpGRBZakladanieKonta.TabIndex = 1;
            this.mpGRBZakladanieKonta.TabStop = false;
            this.mpGRBZakladanieKonta.Text = "Zakładanie konta";
            this.mpGRBZakladanieKonta.Visible = false;
            // 
            // mpBTNAnulujZakladanieKonta
            // 
            this.mpBTNAnulujZakladanieKonta.Location = new System.Drawing.Point(203, 229);
            this.mpBTNAnulujZakladanieKonta.Name = "mpBTNAnulujZakladanieKonta";
            this.mpBTNAnulujZakladanieKonta.Size = new System.Drawing.Size(75, 34);
            this.mpBTNAnulujZakladanieKonta.TabIndex = 9;
            this.mpBTNAnulujZakladanieKonta.Text = "Anuluj";
            this.mpBTNAnulujZakladanieKonta.UseVisualStyleBackColor = true;
            this.mpBTNAnulujZakladanieKonta.Click += new System.EventHandler(this.mpBTNAnulujZakladanieKonta_Click);
            // 
            // mpBTNZarejestroj
            // 
            this.mpBTNZarejestroj.Location = new System.Drawing.Point(10, 229);
            this.mpBTNZarejestroj.Name = "mpBTNZarejestroj";
            this.mpBTNZarejestroj.Size = new System.Drawing.Size(97, 34);
            this.mpBTNZarejestroj.TabIndex = 8;
            this.mpBTNZarejestroj.Text = "Zarejestrój";
            this.mpBTNZarejestroj.UseVisualStyleBackColor = true;
            this.mpBTNZarejestroj.Click += new System.EventHandler(this.mpBTNZarejestroj_Click);
            // 
            // mpTXTHasloNowegoKonta
            // 
            this.mpTXTHasloNowegoKonta.Location = new System.Drawing.Point(10, 146);
            this.mpTXTHasloNowegoKonta.Name = "mpTXTHasloNowegoKonta";
            this.mpTXTHasloNowegoKonta.Size = new System.Drawing.Size(268, 26);
            this.mpTXTHasloNowegoKonta.TabIndex = 7;
            this.mpTXTHasloNowegoKonta.UseSystemPasswordChar = true;
            // 
            // mpTXTPowtorzoneHaslo
            // 
            this.mpTXTPowtorzoneHaslo.Location = new System.Drawing.Point(10, 197);
            this.mpTXTPowtorzoneHaslo.Name = "mpTXTPowtorzoneHaslo";
            this.mpTXTPowtorzoneHaslo.Size = new System.Drawing.Size(268, 26);
            this.mpTXTPowtorzoneHaslo.TabIndex = 6;
            this.mpTXTPowtorzoneHaslo.UseSystemPasswordChar = true;
            // 
            // mpTXTLoginNowegoKonta
            // 
            this.mpTXTLoginNowegoKonta.Location = new System.Drawing.Point(10, 95);
            this.mpTXTLoginNowegoKonta.Name = "mpTXTLoginNowegoKonta";
            this.mpTXTLoginNowegoKonta.Size = new System.Drawing.Size(268, 26);
            this.mpTXTLoginNowegoKonta.TabIndex = 5;
            // 
            // mpTXTEmailNowegoKonta
            // 
            this.mpTXTEmailNowegoKonta.Location = new System.Drawing.Point(10, 44);
            this.mpTXTEmailNowegoKonta.Name = "mpTXTEmailNowegoKonta";
            this.mpTXTEmailNowegoKonta.Size = new System.Drawing.Size(268, 26);
            this.mpTXTEmailNowegoKonta.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "Powtórz hasło";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hasło";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "E-mail";
            // 
            // mpErrorProvider1
            // 
            this.mpErrorProvider1.ContainerControl = this;
            // 
            // mpLoginForm
            // 
            this.AcceptButton = this.mpBTNZaloguj;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mpBTNAnuluj;
            this.ClientSize = new System.Drawing.Size(304, 304);
            this.Controls.Add(this.mpGRBZakladanieKonta);
            this.Controls.Add(this.mpGRBLogowanie);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "mpLoginForm";
            this.Text = "mpLoginForm";
            this.mpGRBLogowanie.ResumeLayout(false);
            this.mpGRBLogowanie.PerformLayout();
            this.mpGRBZakladanieKonta.ResumeLayout(false);
            this.mpGRBZakladanieKonta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mpErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mpGRBLogowanie;
        private System.Windows.Forms.Button mpBTNAnuluj;
        private System.Windows.Forms.Button mpBTNZaloguj;
        private System.Windows.Forms.TextBox mpTXTHaslo;
        private System.Windows.Forms.TextBox mpTXTLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mpBTNZalozKonto;
        private System.Windows.Forms.GroupBox mpGRBZakladanieKonta;
        private System.Windows.Forms.Button mpBTNAnulujZakladanieKonta;
        private System.Windows.Forms.Button mpBTNZarejestroj;
        private System.Windows.Forms.TextBox mpTXTHasloNowegoKonta;
        private System.Windows.Forms.TextBox mpTXTPowtorzoneHaslo;
        private System.Windows.Forms.TextBox mpTXTLoginNowegoKonta;
        private System.Windows.Forms.TextBox mpTXTEmailNowegoKonta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider mpErrorProvider1;
    }
}