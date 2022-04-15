
namespace Slagalica_118_2018
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_korisnickoIme = new System.Windows.Forms.TextBox();
            this.tb_lozinka = new System.Windows.Forms.TextBox();
            this.lbl_losLogin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_prijava = new System.Windows.Forms.Button();
            this.btn_odustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisnicko ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lozinka:";
            // 
            // tb_korisnickoIme
            // 
            this.tb_korisnickoIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_korisnickoIme.Location = new System.Drawing.Point(26, 67);
            this.tb_korisnickoIme.Name = "tb_korisnickoIme";
            this.tb_korisnickoIme.Size = new System.Drawing.Size(222, 24);
            this.tb_korisnickoIme.TabIndex = 2;
            // 
            // tb_lozinka
            // 
            this.tb_lozinka.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_lozinka.Location = new System.Drawing.Point(26, 155);
            this.tb_lozinka.Name = "tb_lozinka";
            this.tb_lozinka.PasswordChar = '*';
            this.tb_lozinka.Size = new System.Drawing.Size(222, 24);
            this.tb_lozinka.TabIndex = 6;
            // 
            // lbl_losLogin
            // 
            this.lbl_losLogin.AutoSize = true;
            this.lbl_losLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_losLogin.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_losLogin.Location = new System.Drawing.Point(28, 206);
            this.lbl_losLogin.Name = "lbl_losLogin";
            this.lbl_losLogin.Size = new System.Drawing.Size(214, 16);
            this.lbl_losLogin.TabIndex = 7;
            this.lbl_losLogin.Text = "Pogresno korisnicko ime / lozinka !";
            this.lbl_losLogin.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(116, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Login";
            // 
            // btn_prijava
            // 
            this.btn_prijava.Location = new System.Drawing.Point(26, 255);
            this.btn_prijava.Name = "btn_prijava";
            this.btn_prijava.Size = new System.Drawing.Size(75, 23);
            this.btn_prijava.TabIndex = 10;
            this.btn_prijava.Text = "Prijava";
            this.btn_prijava.UseVisualStyleBackColor = true;
            this.btn_prijava.Click += new System.EventHandler(this.btn_prijava_Click);
            // 
            // btn_odustani
            // 
            this.btn_odustani.Location = new System.Drawing.Point(173, 255);
            this.btn_odustani.Name = "btn_odustani";
            this.btn_odustani.Size = new System.Drawing.Size(75, 23);
            this.btn_odustani.TabIndex = 11;
            this.btn_odustani.Text = "Odustani";
            this.btn_odustani.UseVisualStyleBackColor = true;
            this.btn_odustani.Click += new System.EventHandler(this.btn_odustani_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 290);
            this.Controls.Add(this.btn_odustani);
            this.Controls.Add(this.btn_prijava);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_losLogin);
            this.Controls.Add(this.tb_lozinka);
            this.Controls.Add(this.tb_korisnickoIme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_korisnickoIme;
        private System.Windows.Forms.TextBox tb_lozinka;
        private System.Windows.Forms.Label lbl_losLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_prijava;
        private System.Windows.Forms.Button btn_odustani;
    }
}