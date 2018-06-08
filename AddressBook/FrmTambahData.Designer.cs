namespace AddressBook
{
    partial class FrmTambahData
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
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKota = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoHp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpTglLahir = new System.Windows.Forms.DateTimePicker();
            this.S = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(90, 10);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(220, 22);
            this.txtNama.TabIndex = 0;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(90, 37);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(402, 22);
            this.txtAlamat.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alamat";
            // 
            // txtKota
            // 
            this.txtKota.Location = new System.Drawing.Point(90, 65);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(167, 22);
            this.txtKota.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kota";
            // 
            // txtNoHp
            // 
            this.txtNoHp.Location = new System.Drawing.Point(90, 93);
            this.txtNoHp.Name = "txtNoHp";
            this.txtNoHp.Size = new System.Drawing.Size(200, 22);
            this.txtNoHp.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "No. HP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tgl. Lahir";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(90, 149);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(402, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email";
            // 
            // dtpTglLahir
            // 
            this.dtpTglLahir.Location = new System.Drawing.Point(90, 121);
            this.dtpTglLahir.Name = "dtpTglLahir";
            this.dtpTglLahir.Size = new System.Drawing.Size(200, 22);
            this.dtpTglLahir.TabIndex = 4;
            // 
            // S
            // 
            this.S.Location = new System.Drawing.Point(417, 207);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(75, 30);
            this.S.TabIndex = 7;
            this.S.Text = "&Batal";
            this.S.UseVisualStyleBackColor = true;
            this.S.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(336, 207);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 30);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "&Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // FrmTambahData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 267);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.S);
            this.Controls.Add(this.dtpTglLahir);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNoHp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTambahData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tambah Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoHp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpTglLahir;
        private System.Windows.Forms.Button S;
        private System.Windows.Forms.Button btnSimpan;
    }
}