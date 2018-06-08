using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AddressBook
{
    public partial class FrmTambahData : Form
    {

        bool _result = false;

        bool _addMode = false; // true : add item, false : edit item


        public bool Run(FrmTambahData form)
        {
            form.ShowDialog();
            return _result;
        }

        public FrmTambahData(bool addMode)
        {
            InitializeComponent();
            _addMode = addMode;
        }

        public FrmTambahData()
        {
        }
        
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // validas
            if (this.txtNama.Text.Trim() == "") // jika isian nama kosong
            {
                MessageBox.Show("Sorry, nama wajib isi...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNama.Focus();
            }
            else if (this.txtAlamat.Text.Trim() == "") // jika isian alamat kosong
            {
                MessageBox.Show("Sorry, alamat wajib isi...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtAlamat.Focus();
            }
            else if (this.txtKota.Text.Trim() == "") // jika isian kota kosong 
            {
                MessageBox.Show("Sorry, kota wajib isi...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtKota.Focus();
            }
            else if (this.txtNoHp.Text.Trim() == "") // jika isian no hp kosong 
            {
                MessageBox.Show("Sorry, no hp wajib isi...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNoHp.Focus();
            }
            else if (this.txtEmail.Text.Trim() == "") // jika isian email kosong 
            {
                MessageBox.Show("Sorry, email wajib isi...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtEmail.Focus();
            }
            else
            {
                try
                {
                    if (_addMode) // add new item
                    {
                        using (var fs = new FileStream("addressbook.csv", FileMode.Append, FileAccess.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(fs))
                            {
                                writer.WriteLine($"{txtNama.Text.Trim()};{txtAlamat.Text.Trim()};{txtKota.Text.Trim()};{txtNoHp.Text.Trim()};{dtpTglLahir.Value.ToShortDateString()};{txtEmail.Text.Trim()};");
                            }
                        }
                    }
                    else // edit data
                    {

                    }
                    _result = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // simpan data ke file

            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
