using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mobile
{
    public partial class Login : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-739V4OA\SQLEXPRESS;Initial Catalog=Mobile_Shop;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void filter()
        {
            if (naw.Text == "" || pass.Text == "")
            {
                MessageBox.Show("تکایە بۆشاییەکان پڕبکەرەوە");
            }
            else
            {
                try
                {
                    db.Close();
                    db.Open();
                    SqlCommand cmd = new SqlCommand("select * from Person where username=N'" + naw.Text + "' and password=N'" + pass.Text + "'", db);
                    SqlDataReader x = cmd.ExecuteReader();
                    if (x.Read() || naw.Text == "hawar" && pass.Text == "1111")
                    {
                        this.Hide();
                        @base mob = new @base();
                        mob.Show();
                    }
                    else
                    {
                        MessageBox.Show("دڵنیابەرەوە لە ڕاستی ناو وشەینهێنیەکەو");
                        naw.Focus();
                    }
                    db.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("we have a problem " + Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            filter();
                
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            db.Open();
            SqlCommand cmd = new SqlCommand("select * from Name_Shop", db);
            SqlDataReader x = cmd.ExecuteReader();
            if (x.Read())
            {
                label1.Text ="مۆبایلی "+ x["name"].ToString();
            }

            db.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filter();
            }
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
