﻿using System;
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
    public partial class FrmAddressBook : Form
    {
        public FrmAddressBook()
        {
            InitializeComponent();
        }

        private void FrmAddressBook_Load()
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
            if (form.Run(form))
            {
                FrmAddressBook_Load();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dgvData.SelectedRows[0];
                Person addressBook = new Person();
                addressBook.Nama = row.Cells[0].Value.ToString();
                addressBook.Alamat = row.Cells[1].Value.ToString();
                addressBook.Kota = row.Cells[2].Value.ToString();
                addressBook.NoHp = row.Cells[3].Value.ToString();
                addressBook.TanggalLahir = Convert.ToDateTime(row.Cells[4].Value).Date;
                addressBook.Email = row.Cells[5].Value.ToString();
                FrmTambahData form = new FrmTambahData(false, addressBook);
                if (form.Run(form))
                {
                    FrmAddressBook_Load();
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count > 0 && MessageBox.Show("Hapus Baris Data Ini ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow row = this.dgvData.SelectedRows[0];
                Person addrBook = new Person();
                addrBook.Nama = row.Cells[0].Value.ToString();
                addrBook.Alamat = row.Cells[1].Value.ToString();
                addrBook.Kota = row.Cells[2].Value.ToString();
                addrBook.NoHp = row.Cells[3].Value.ToString();
                addrBook.TanggalLahir = Convert.ToDateTime(row.Cells[4].Value).Date;
                addrBook.Email = row.Cells[5].Value.ToString();
                try
                {
                    string[] fileContent = File.ReadAllLines("addressbook.csv");
                    using (FileStream fs = new FileStream("temporary.csv", FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            foreach (string line in fileContent)
                            {
                                string[] arrline = line.Split(';');
                                if (arrline[0] == addrBook.Nama && arrline[1] == addrBook.Alamat && arrline[2] == addrBook.Kota && arrline[3] == addrBook.NoHp && Convert.ToDateTime(arrline[4]).Date == addrBook.TanggalLahir.Date && arrline[5] == addrBook.Email)
                                { // tidak melakukan apa"
                                }
                                else
                                {
                                    writer.WriteLine(line);
                                }
                            }
                        }
                    }
                    File.Delete("addressbook.csv");
                    File.Move("temporary.csv", "addressbook.csv");
                    FrmAddressBook_Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}

