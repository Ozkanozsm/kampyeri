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

    public partial class Form1 : Form
    {
        private string server = "Server=localhost;";
        private string port = "Port=5432;";
        private string database = "Database=denemedb;";
        private string userid = "User Id=postgres;";
        private string password = "Password=12345678;";
        private string connString;
        private NpgsqlConnection connection;
        private NpgsqlCommand comm;
        private NpgsqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            connString = server + port + database + userid + password;
            connection = new NpgsqlConnection(connString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaglantiYazisiUpdate(false);
            lblError.Text = null;
            //dbBaglan();
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
                //MessageBox.Show("connection acildi");
                BaglantiYazisiUpdate(true);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //MessageBox.Show("zort");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (comm = new NpgsqlCommand("SELECT * FROM tablem", connection))
                {
                    dr = comm.ExecuteReader();
                }

                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    MessageBox.Show(dataGView.Rows.ToString());
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
            //connection.Dispose();
            connection.Close();
            //Application.Exit();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int num;
            bool success = int.TryParse(indata1.Text, out num);
            if (success)
            {
                using (comm = new NpgsqlCommand("INSERT INTO tablem VALUES (@p1 , @p2)", connection))
                {
                    // text to string parse
                    comm.Parameters.AddWithValue("p1", Convert.ToInt32(indata1.Text));
                    comm.Parameters.AddWithValue("p2", indata2.Text);
                    //MessageBox.Show(comm.CommandText);
                    comm.ExecuteNonQuery();
                }
                indata1.Text = null;
                indata2.Text = null;
            }
            else
            {
                MessageBox.Show($"'{indata1.Text}' sayı degil");
                lblError.Text = "ilk haneye girilen veri sayı değil";
            }

        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            dbBaglan();
        }
    }
}
