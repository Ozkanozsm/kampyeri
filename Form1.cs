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
        public Form1()
        {
            InitializeComponent();
            connString = server + port + database + userid + password;
            connection = new NpgsqlConnection(connString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = connection;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM tablem";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            connection.Dispose();
            connection.Close();
            Application.Exit();
        }
    }
}
