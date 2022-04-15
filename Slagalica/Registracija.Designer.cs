
namespace Slagalica_118_2018
{
    partial class Registracija
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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_regKorisnicko = new System.Windows.Forms.TextBox();
            this.tb_regLozinka = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_regLoseKorisnicko = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisnicko ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registracija";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lozinka:";
            // 
            // tb_regKorisnicko
            // 
            this.tb_regKorisnicko.Location = new System.Drawing.Point(31, 70);
            this.tb_regKorisnicko.Name = "tb_regKorisnicko";
            this.tb_regKorisnicko.Size = new System.Drawing.Size(176, 20);
            this.tb_regKorisnicko.TabIndex = 3;
            // 
            // tb_regLozinka
            // 
            this.tb_regLozinka.Location = new System.Drawing.Point(31, 138);
            this.tb_regLozinka.Name = "tb_regLozinka";
            this.tb_regLozinka.PasswordChar = '*';
            this.tb_regLozinka.Size = new System.Drawing.Size(176, 20);
            this.tb_regLozinka.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Registracija";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Odustani";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_regLoseKorisnicko
            // 
            this.lbl_regLoseKorisnicko.AutoSize = true;
            this.lbl_regLoseKorisnicko.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_regLoseKorisnicko.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_regLoseKorisnicko.Location = new System.Drawing.Point(9, 179);
            this.lbl_regLoseKorisnicko.Name = "lbl_regLoseKorisnicko";
            this.lbl_regLoseKorisnicko.Size = new System.Drawing.Size(135, 13);
            this.lbl_regLoseKorisnicko.TabIndex = 8;
            this.lbl_regLoseKorisnicko.Text = "Korisnicko ime vec postoji !";
            this.lbl_regLoseKorisnicko.Visible = false;
            // 
            // Registracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 244);
            this.Controls.Add(this.lbl_regLoseKorisnicko);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_regLozinka);
            this.Controls.Add(this.tb_regKorisnicko);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registracija";
            this.Text = "Registracija";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_regKorisnicko;
        private System.Windows.Forms.TextBox tb_regLozinka;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_regLoseKorisnicko;
    }
}