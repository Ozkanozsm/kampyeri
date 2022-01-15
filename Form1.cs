using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace kampyeri
{
    public partial class FormKampY : Form
    {
        private string server = "Server=localhost;";
        private string port = "Port=5432;";
        private string database = "Database=kamp;";
        private string userid = "User Id=postgres;";
        private string password = "Password=12345678;";
        private string connString;
        private List<string> alltables;
        private NpgsqlConnection connection;
        private NpgsqlCommand comm;
        private NpgsqlDataReader dr;
        private List<TextBox> textBoxes;
        private List<string> textsirala;
        public FormKampY()
        {
            InitializeComponent();
            connString = server + port + database + userid + password;
            connection = new NpgsqlConnection(connString);
            datagvStyle();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxes = new();
            textBoxes.Add(indata1);
            textBoxes.Add(indata2);
            textBoxes.Add(indata3);
            textBoxes.Add(indata4);
            textBoxes.Add(indata5);
            textBoxes.Add(indata6);
            BaglantiYazisiUpdate(false);
            lblError.Text = null;
            alltables = new();
            alltables.Add("kampcalisanlari");
            alltables.Add("kampyerleri");
            alltables.Add("musteriler");
            cmbxInsert.Items.AddRange(alltables.ToArray());
            cmbxInsert.SelectedIndex = 0;
            alltables.Add("kampozellikleri");
            cmbxDataGet.Items.AddRange(alltables.ToArray());
            cmbxDataGet.SelectedIndex = 1;
            textsirala = new();
            textsirala.Add("A->Z");
            textsirala.Add("Z->A");
            cmbxsirala.Items.AddRange(textsirala.ToArray());
            cmbxsirala.SelectedIndex = 0;
        }

        private void datagvStyle()
        {
            dataGView.AlternatingRowsDefaultCellStyle.BackColor = Color.Aqua;
            dataGView.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.Black;
            dataGView.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dataGView.RowsDefaultCellStyle.BackColor = Color.Beige;
            dataGView.RowsDefaultCellStyle.SelectionBackColor = Color.Black;
            dataGView.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dataGView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGView.BackgroundColor = Color.White;
        }

        private void BaglantiYazisiUpdate(bool isOpened)
        {
            if (isOpened)
            {
                lblConnection.Text = "Baglanti acik";
                lblConnection.BackColor = Color.Green;
            }
            else
            {
                lblConnection.Text = "Baglanti kapali";
                lblConnection.BackColor = Color.Red;
            }
        }

        private void dbBaglan()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    lblError.Text = "Baglanti zaten acik";
                }
                connection.Open();
                BaglantiYazisiUpdate(true);
            }
            catch (Exception e)
            {
                lblError.Text = e.Message.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ascmetin;
            if (cmbxDataGet.SelectedIndex == 1 || cmbxDataGet.SelectedIndex == 3)
            {
                ascmetin = " ORDER BY kampyeriid DESC";
            }
            else
            {
                ascmetin = " ORDER BY tckimlikno ASC";
            }
            string komut = "SELECT * FROM " + alltables[cmbxDataGet.SelectedIndex] + ascmetin;
            try
            {
                using (comm = new NpgsqlCommand(komut, connection))
                {
                    dr = comm.ExecuteReader();
                }

                if (dr.HasRows)
                {
                    DataTable dt = new();
                    dt.Load(dr);
                    dataGView.ReadOnly = true;
                    dataGView.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata olustu.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaglantiYazisiUpdate(false);
            connection.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int insertlenecek = cmbxInsert.SelectedIndex;
            int tc;
            int ckampyid;
            decimal ctelno;
            int kapasite;
            int yas;
            int mkampyeriid;
            decimal mtelno;
            bool cntrl1, cntrl2, cntrl3, cntrl4;
            if (connection.State == ConnectionState.Open)
            {
                switch (insertlenecek)
                {
                    case 0:
                        cntrl1 = int.TryParse(indata1.Text, out tc);
                        cntrl2 = int.TryParse(indata2.Text, out ckampyid);
                        cntrl3 = decimal.TryParse(indata6.Text, out ctelno);
                        if (!cntrl1)
                        {
                            MessageBox.Show("TC sayi degil");
                        }
                        if (!cntrl2)
                        {
                            MessageBox.Show("Kamp yeri id sayi degil");
                        }
                        if (!cntrl3)
                        {
                            MessageBox.Show("TEL no sayi degil");
                        }
                        if (cntrl1 && cntrl2 && cntrl3)
                        {
                            using (comm = new NpgsqlCommand("INSERT INTO kampcalisanlari VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", connection))
                            {

                                comm.Parameters.AddWithValue("p1", tc);
                                comm.Parameters.AddWithValue("p2", ckampyid);
                                comm.Parameters.AddWithValue("p3", indata3.Text);
                                comm.Parameters.AddWithValue("p4", indata4.Text);
                                comm.Parameters.AddWithValue("p5", indata5.Text);
                                comm.Parameters.AddWithValue("p6", ctelno);
                                comm.ExecuteNonQuery();
                            }
                            MessageBox.Show($"{indata3.Text} eklendi");
                            ClearTextBox();
                        }

                        break;
                    case 1:
                        cntrl1 = int.TryParse(indata3.Text, out kapasite);
                        if (!cntrl1)
                        {
                            MessageBox.Show("Kapasite sayi degil");
                        }
                        if (cntrl1)
                        {
                            using (comm = new NpgsqlCommand("INSERT INTO kampyerleri VALUES (default, @p1, @p2, @p3)", connection))
                            {

                                comm.Parameters.AddWithValue("p1", indata1.Text);
                                comm.Parameters.AddWithValue("p2", indata2.Text);
                                comm.Parameters.AddWithValue("p3", kapasite);
                                comm.ExecuteNonQuery();
                            }
                            MessageBox.Show($"{indata1.Text} eklendi");

                            ClearTextBox();
                        }

                        break;
                    case 2:
                        cntrl1 = int.TryParse(indata1.Text, out tc);
                        cntrl2 = int.TryParse(indata4.Text, out yas);
                        cntrl3 = decimal.TryParse(indata5.Text, out mtelno);
                        cntrl4 = int.TryParse(indata6.Text, out mkampyeriid);
                        if (!cntrl1)
                        {
                            MessageBox.Show("TC sayi degil");
                        }
                        if (!cntrl2)
                        {
                            MessageBox.Show("Yas sayi degil");
                        }
                        if (!cntrl3)
                        {
                            MessageBox.Show("Tel no sayi degil");
                        }
                        if (!cntrl4)
                        {
                            MessageBox.Show("Kamp yeri id sayi degil");
                        }
                        try
                        {
                            if (cntrl1 && cntrl2 && cntrl3 && cntrl4)
                            {
                                using (comm = new NpgsqlCommand("INSERT INTO musteriler VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", connection))
                                {
                                    comm.Parameters.AddWithValue("p1", tc);
                                    comm.Parameters.AddWithValue("p2", indata2.Text);
                                    comm.Parameters.AddWithValue("p3", indata3.Text);
                                    comm.Parameters.AddWithValue("p4", yas);
                                    comm.Parameters.AddWithValue("p5", mtelno);
                                    comm.Parameters.AddWithValue("p6", mkampyeriid);

                                    comm.ExecuteNonQuery();
                                }
                                MessageBox.Show($"{indata2.Text} eklendi");
                                ClearTextBox();
                            }
                        }

                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "HATA");
                        }
                        break;
                }

            }
            else
            {
                MessageBox.Show("Baglanti kapali");
            }

        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            dbBaglan();
        }

        private void LabelBosalt()
        {
            lbl1.Text = null;
            lbl2.Text = null;
            lbl3.Text = null;
            lbl4.Text = null;
            lbl5.Text = null;
            lbl6.Text = null;
        }

        private void ClearTextBox()
        {
            foreach (var tbox in textBoxes)
            {
                tbox.Text = null;
            }
        }
        private void TextBoxDisable()
        {
            foreach (var tbox in textBoxes)
            {
                tbox.Text = null;
            }
            foreach (var tbox in textBoxes)
            {
                tbox.Enabled = false;
            }
        }

        private void TextBoxEnable(int sayi)
        {
            for (int i = 0; i < sayi; i++)
            {
                textBoxes[i].Enabled = true;
            }
        }

        private void cmbxInsert_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelBosalt();
            TextBoxDisable();
            switch (cmbxInsert.SelectedIndex)
            {
                case 0:
                    lbl1.Text = "TC Kimlik No";
                    lbl2.Text = "Calışan Kamp Yeri ID";
                    lbl3.Text = "Çalışan Adı";
                    lbl4.Text = "Çalışan Görevi";
                    lbl5.Text = "Çalışan Adresi";
                    lbl6.Text = "Çalışan Telefon No";
                    TextBoxEnable(6);
                    break;
                case 1:
                    lbl1.Text = "Kamp Yeri Adı";
                    lbl2.Text = "Kamp Adresi";
                    lbl3.Text = "Kamp Kapasitesi";
                    TextBoxEnable(3);
                    break;
                case 2:
                    lbl1.Text = "TC Kimlik No";
                    lbl2.Text = "Müşteri Adı";
                    lbl3.Text = "Müşteri Soyadı";
                    lbl4.Text = "Müşteri Yaşı";
                    lbl5.Text = "Müşteri Telefon No";
                    lbl6.Text = "Müşteri Kamp Yeri ID";
                    TextBoxEnable(6);
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                int updateid = int.Parse(tboxUpdatelenecekid.Text);
                using (comm = new NpgsqlCommand("UPDATE kampyerleri SET kampYeriAdi = @p1 WHERE kampYeriID = @p2", connection))
                {
                    comm.Parameters.AddWithValue("p1", txtupdateYeniad.Text);
                    comm.Parameters.AddWithValue("p2", updateid);
                    comm.ExecuteNonQuery();
                }
                tboxUpdatelenecekid.Text = null;
                txtupdateYeniad.Text = null;
                MessageBox.Show("Update edildi");
            }
            else
            {
                MessageBox.Show("Baglanti kapali");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    int kampyeriid = int.Parse(tboxcalidsilinecek.Text);

                    using (comm = new NpgsqlCommand("DELETE FROM kampyerleri WHERE kampyeriid = @p1", connection))
                    {
                        comm.Parameters.AddWithValue("p1", kampyeriid);
                        comm.ExecuteNonQuery();
                    }
                    MessageBox.Show($"{kampyeriid} id'li kamp yeri silindi");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Baglanti kapali");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string komut = "Select * from musaitKampYerleri";
            try
            {
                using (comm = new NpgsqlCommand(komut, connection))
                {
                    dr = comm.ExecuteReader();
                }
                if (dr.HasRows)
                {
                    DataTable dt = new();
                    dt.Load(dr);
                    dataGView.ReadOnly = true;
                    dataGView.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata olustu.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sehiradi = txboxsehir.Text.ToLower();
            try
            {
                using (comm = new NpgsqlCommand("SELECT getKonumKampYeri(@p1)", connection))
                {
                    comm.Parameters.AddWithValue("p1", sehiradi);
                    dr = comm.ExecuteReader();
                }

                if (dr.HasRows)
                {

                    DataTable dt = new();
                    dt.Load(dr);
                    dataGView.ReadOnly = true;
                    dataGView.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata olustu.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string komutum = "SELECT kampyeriid FROM kampyerleri EXCEPT SELECT calisankampyeriid from kampcalisanlari;";
            try
            {
                using (comm = new NpgsqlCommand(komutum, connection))
                {
                    dr = comm.ExecuteReader();
                }
                if (dr.HasRows)
                {
                    DataTable dt = new();
                    dt.Load(dr);
                    dataGView.ReadOnly = true;
                    dataGView.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata olustu.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox4.Text);

                using (comm = new NpgsqlCommand("Select * from getmusterilist(@p1)", connection))
                {
                    comm.Parameters.AddWithValue("p1", id);
                    dr = comm.ExecuteReader();
                }
                if (dr.HasRows)
                {
                    DataTable dt = new();
                    dt.Load(dr);
                    dataGView.ReadOnly = true;
                    dataGView.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata olustu.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                int kampid = int.Parse(textBox5.Text);

                try
                {
                    using (comm = new NpgsqlCommand("Select * from getgorevcalisan(@p1, @p2)", connection))
                    {
                        comm.Parameters.AddWithValue("p2", kampid);
                        comm.Parameters.AddWithValue("p1", textBox6.Text);
                        dr = comm.ExecuteReader();
                    }
                    if (dr.HasRows)
                    {
                        DataTable dt = new();
                        dt.Load(dr);
                        dataGView.ReadOnly = true;
                        dataGView.DataSource = dt;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata olustu.");
                }
            }
            else
            {
                MessageBox.Show("Baglanti kapali");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                int calisansayisi = int.Parse(textBox7.Text);
                string komut = "SELECT k.calisanKampYeriID, COUNT(*) FROM kampcalisanlari k GROUP BY k.calisanKampYeriID HAVING COUNT(*) >= " + calisansayisi.ToString();

                try
                {
                    using (comm = new NpgsqlCommand(komut, connection))
                    {
                        dr = comm.ExecuteReader();
                    }
                    if (dr.HasRows)
                    {
                        DataTable dt = new();
                        dt.Load(dr);
                        dataGView.ReadOnly = true;
                        dataGView.DataSource = dt;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata olustu.");
                }
            }
            else
            {
                MessageBox.Show("Baglanti kapali");
            }

        }

        private void btnSirala_Click(object sender, EventArgs e)
        {
            string descorasc;
            if (cmbxsirala.SelectedIndex == 0)
            {
                descorasc = "ASC";
            }
            else
            {
                descorasc = "DESC";
            }
            string komut = "SELECT * from kampyerleri ORDER BY kampAdres " + descorasc;
            try
            {
                using (comm = new NpgsqlCommand(komut, connection))
                {
                    dr = comm.ExecuteReader();
                }
                if (dr.HasRows)
                {
                    DataTable dt = new();
                    dt.Load(dr);
                    dataGView.ReadOnly = true;
                    dataGView.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata olustu.");
            }
        }
    }
}
