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
    public partial class FrmAddressBook : Form
    {
        public FrmAddressBook()
        {
            InitializeComponent();
        }

        private void FrmAddressBook_Load(object sender, EventArgs e)
        {
            try
            {
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
            
        }
    }

    }

