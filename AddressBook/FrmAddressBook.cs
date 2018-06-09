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
    public partial class FrmAddressBook : Form
    {
        Person psn = new Person();
        AddressBookController addr = new AddressBookController();

        public FrmAddressBook()
        {
            InitializeComponent();
        }

        private void FrmAddressBook_Load(object sender , EventArgs e)
        {
            try
            {
                this.dgvData.Rows.Clear();
                if (File.Exists("addressbook.csv"))
                {
                    string[] arrLine = File.ReadAllLines("addressbook.csv");
                    if (arrLine.Length > 0)
                    {
                        foreach (string item in arrLine)
                        {
                            if (item.Trim() == "") continue;
                            string[] arrItem = item.Split(';');
                            this.dgvData.Rows.Add(new String[] {
                                arrItem[0], arrItem[1], arrItem[2],
                                arrItem[3], arrItem[4], arrItem[5],
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.lblBanyakRecordData.Text = $"{this.dgvData.Rows.Count.ToString("n0")} Record data.";
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FrmTambahData form = new FrmTambahData(true);
            form.Run(form);

            addr.loadData(this.dgvData, this.lblBanyakRecordData);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvData.SelectedRows[0];
                Person addrBook = new Person();
                addrBook.Nama = row.Cells[0].Value.ToString();
                addrBook.Alamat = row.Cells[1].Value.ToString();
                addrBook.Kota = row.Cells[2].Value.ToString();
                addrBook.NoHp = row.Cells[3].Value.ToString();
                addrBook.TanggalLahir = Convert.ToDateTime(row.Cells[4].Value).Date;
                addrBook.Email = row.Cells[5].Value.ToString();
                FrmTambahData form = new FrmTambahData(false, addrBook);
                if (form.Run(form))
                {
                    FrmAddressBook_Load(null,null);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            addr.deleteData(initial_people(psn, true));
            addr.loadData(this.dgvData, this.lblBanyakRecordData);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (this.txtNama.Text.Trim() != "" || this.txtAlamat.Text.Trim() != "" || this.txtKota.Text.Trim() != "" || this.txtNoHp.Text.Trim() != "" || this.txtTglLahir.Text.Trim() != "" || this.txtEmail.Text.Trim() != "")
            {
                addr.FilterData(this.dgvData, initial_people(psn, false), this.lblBanyakRecordData);
            }
            else
            {
                addr.loadData(this.dgvData, this.lblBanyakRecordData);
            }
        }

        public bool EmailIsValid(string emailAddr)
        {
            string emailPattern1 = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(emailPattern1);
            Match match = regex.Match(emailAddr);
            return match.Success;
        }

        private Person initial_people(Person p, bool mode)
        {
            if (mode)
            {
                p.Nama = dgvData.CurrentRow.Cells[0].Value.ToString();
                p.Alamat = dgvData.CurrentRow.Cells[1].Value.ToString();
                p.Kota = dgvData.CurrentRow.Cells[2].Value.ToString();
                p.NoHp = dgvData.CurrentRow.Cells[3].Value.ToString();
                p.TanggalLahir = Convert.ToDateTime(dgvData.CurrentRow.Cells[4].Value).Date;
                p.Email = dgvData.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                p.Nama = this.txtNama.Text.Trim();
                p.Alamat = this.txtAlamat.Text.Trim();
                p.Kota = this.txtKota.Text.Trim();
                p.NoHp = this.txtNoHp.Text.Trim();
                if (this.txtTglLahir.Text.Trim() != "")
                    p.TanggalLahir = Convert.ToDateTime(this.txtTglLahir.Text.Trim());
                p.Email = this.txtEmail.Text.Trim();
            }

            return p;
        }
    }
}