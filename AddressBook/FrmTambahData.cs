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
using System.Text.RegularExpressions;

namespace AddressBook
{
    public partial class FrmTambahData : Form
    {

        bool _result = false;

        bool _addMode = false; // true : add item, false : edit item

        Person _addrBook = null;

        AddressBookController addr = new AddressBookController();

        Person psn_New = new Person();


        public bool Run(FrmTambahData form)
        {
            form.ShowDialog();
            return _result;
        }


        public FrmTambahData(bool addMode, Person addrBook = null)
        {
            InitializeComponent();
            _addMode = addMode;
            if (addrBook != null)
            {
                _addrBook = addrBook;
                this.txtNama.Text = addrBook.Nama;
                this.txtAlamat.Text = addrBook.Alamat;
                this.txtKota.Text = addrBook.Kota;
                this.txtNoHp.Text = addrBook.NoHp;
                this.dtpTglLahir.Value = addrBook.TanggalLahir.Date;
                this.txtEmail.Text = addrBook.Email;
            }

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
            else if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Sorry, email tidak valid...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
            else
            {
                addr.saveData(_addMode, initial_people(psn_New), _addrBook);
                this.Close();
                _result = true;
            }
        }

       

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{tab}");
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (this.txtEmail.Text.Trim() != "")
            {
                if (!addr.EmailIsValid(this.txtEmail.Text))
                {
                    MessageBox.Show("Sorry, Data email tidak valid ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtEmail.Clear();
                    this.txtEmail.Focus();
                }
            }
        }


        private Person initial_people(Person p)
        {
            p.Nama = this.txtNama.Text.Trim();
            p.Alamat = this.txtAlamat.Text.Trim();
            p.Kota = this.txtKota.Text.Trim();
            p.NoHp = this.txtNoHp.Text.Trim();
            p.TanggalLahir = this.dtpTglLahir.Value;
            p.Email = this.txtEmail.Text.Trim();

            return p;
        }

        private void txtNoHp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
