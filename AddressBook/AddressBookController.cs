using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AddressBook
{
    public class AddressBookController
    {
        public List<Person> ListData { get; set; } = null;
        public AddressBookController() // constructor
        {
            ListData = new List<Person>();
            try
            {
                if (File.Exists(Properties.Settings.Default.NamaFile))
                {
                    string[] fileContent = File.ReadAllLines(Properties.Settings.Default.NamaFile);
                    foreach (string item in fileContent)
                    {
                        string[] arrItem = item.Split(';');
                        ListData.Add(new Person
                        {
                            Nama = arrItem[0].Trim(),
                            Alamat = arrItem[1].Trim(),
                            Kota = arrItem[2].Trim(),
                            NoHp = arrItem[3].Trim(),
                            TanggalLahir = Convert.ToDateTime(arrItem[4]),
                            Email = arrItem[5].Trim()
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void loadData(DataGridView dgv, Label lbl)
        {
            try
            {
                dgv.Rows.Clear();
                AddressBookController controller = new AddressBookController();
                List<Person> listData = controller.ListData;
                foreach (Person psn in listData)
                {
                    dgv.Rows.Add(new string[] { psn.Nama, psn.Alamat, psn.Kota, psn.NoHp, psn.TanggalLahir.ToShortDateString(), psn.Email });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddressBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                lbl.Text = $"{dgv.Rows.Count.ToString("n0")} Record data.";
            }
        }

        public void saveData(bool mode, Person psn, Person temp)
        {
            try
            {
                if (mode)
                {
                    using (var fs = new FileStream(Properties.Settings.Default.NamaFile, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            writer.WriteLine($"{psn.Nama};{psn.Alamat};{psn.Kota};{psn.NoHp};{psn.TanggalLahir.ToShortDateString()};{psn.Email}"); // nama;alamat, ....
                        }
                    }
                    MessageBox.Show("Your Data has been created", "Notification", MessageBoxButtons.OK);
                }
                else // edit data
                {
                    string[] line = File.ReadAllLines(Properties.Settings.Default.NamaFile);
                    using (var fs = new FileStream("temporary.csv", FileMode.Create, FileAccess.ReadWrite))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            for (int i = 0; i < line.Length; i++)
                            {
                                if (line[i] == $"{temp.Nama};{temp.Alamat};{temp.Kota};{temp.NoHp};{temp.TanggalLahir.ToShortDateString()};{temp.Email}")
                                {
                                    writer.WriteLine($"{psn.Nama};{psn.Alamat};{psn.Kota};{psn.NoHp};{psn.TanggalLahir.ToShortDateString()};{psn.Email}");
                                }
                                else
                                {
                                    writer.WriteLine(line[i]);
                                }
                            }
                        }
                    }
                    File.Delete(Properties.Settings.Default.NamaFile);
                    File.Move("temporary.csv", Properties.Settings.Default.NamaFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddressBook", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                MessageBox.Show("Your Data Have Been edit Success", "Notification", MessageBoxButtons.OK);
            }
        }

        public void deleteData(Person psn)
        {
            if (MessageBox.Show("Hapus Baris Data Terpilih ? ", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] line = File.ReadAllLines(Properties.Settings.Default.NamaFile);
                using (var fs = new FileStream("temporary.csv", FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] != $"{psn.Nama};{psn.Alamat};{psn.Kota};{psn.NoHp};{psn.TanggalLahir.ToShortDateString()};{psn.Email}")
                            {
                                writer.WriteLine(line[i]);
                            }
                        }
                    }
                    File.Delete(Properties.Settings.Default.NamaFile);
                    File.Move("temporary.csv", Properties.Settings.Default.NamaFile);
                }
            }
        }

        public void FilterData(DataGridView dgv, Person psn, Label lbl)
        {
            try
            {
                dgv.Rows.Clear();
                string[] fileContent = File.ReadAllLines(Properties.Settings.Default.NamaFile);
                foreach (string line in fileContent)
                {
                    bool benar = false;
                    string[] arrItem = line.Split(';');
                    if ((psn.Nama != "" && arrItem[0].ToLower().Contains(psn.Nama.ToLower().Trim()))
                        || (psn.Alamat != "" && arrItem[1].ToLower().Contains(psn.Alamat.ToLower().Trim()))
                        || (psn.Kota != "" && arrItem[2].ToLower().Contains(psn.Kota.ToLower().Trim()))
                        || (psn.NoHp != "" && arrItem[3].ToLower().Contains(psn.NoHp.ToLower().Trim()))
                        || (psn.TanggalLahir.ToShortDateString() != "" && arrItem[4].ToLower().Contains(psn.TanggalLahir.ToShortDateString()))
                        || (psn.Email != "" && arrItem[5].ToLower().Contains(psn.Email.ToLower().Trim())))
                    {
                        DateTime tglDari, tglSampai;
                        if (psn.TanggalLahir.ToShortDateString().Trim().Contains("-"))
                        {
                            string[] arrTanggal = psn.TanggalLahir.ToShortDateString().Split('-');
                            if (!DateTime.TryParse(arrTanggal[0], out tglDari))
                            {
                                throw new Exception("Sorry, kriteria tanggal lahir tidak valid ...");
                            }
                            if (!DateTime.TryParse(arrTanggal[1], out tglSampai))
                            {
                                throw new Exception("Sorry, kriteria tanggal lahir tidak valid ...");
                            }
                        }
                        else
                        {
                            if (!DateTime.TryParse(psn.TanggalLahir.ToShortDateString(), out tglDari))
                            {
                                throw new Exception("Sorry, kriteria tanggal lahir tidak valid ...");
                            }
                            tglSampai = tglDari;
                        }
                        DateTime tglLahir = Convert.ToDateTime(arrItem[4]);
                        if (tglLahir.Date >= tglDari.Date && tglLahir.Date <= tglSampai.Date) benar = true;
                        benar = true;
                    }
                    if (benar)
                    {
                        dgv.Rows.Add(new string[] { arrItem[0], arrItem[1], arrItem[2], arrItem[3], arrItem[4], arrItem[5] });
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("", "Filter Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                lbl.Text = $"{dgv.Rows.Count.ToString("n0")} Record data.";
            }
        }

        public bool EmailIsValid(string emailAddr)
        {
            string emailPattern1 = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(emailPattern1);
            Match match = regex.Match(emailAddr);
            return match.Success;
        }
    }
}
