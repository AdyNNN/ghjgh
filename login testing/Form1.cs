using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace login_testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            String match = "SELECT * FROM Table";
            SqlCommand cmd = new SqlCommand(match, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string user = reader["username"].ToString()!;
            string pass = reader["password"].ToString()!;
            string inputUsername = textBoxusername.Text;
            string inputPassword = textBoxpassword.Text;
            if (user == inputUsername && pass == inputPassword)
            {
                portal f = new portal();
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username/password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxusername.Text = "";
                textBoxpassword.Text = "";
            }
            conn.Close();
        }
    }
}
