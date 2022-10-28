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
    public partial class Sells : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-739V4OA\SQLEXPRESS;Initial Catalog=Mobile_Shop;Integrated Security=True");
        public string com = "";
        public int zhmara=0;
        public double koy_gshty = 0;
        public string table_name;
        public string id_table;
        public Sells()
        {
            InitializeComponent();
            adad.Text = Convert.ToString(zhmara);
            total.Text = Convert.ToString(koy_gshty)+" $";


            db.Open();
            SqlCommand cmd = new SqlCommand("select * from Name_Shop", db);
            SqlDataReader x = cmd.ExecuteReader();
            if (x.Read())
            {
                label1.Text = "مۆبایلی " + x["name"].ToString();
            }

            db.Close();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            condi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sprice.Text == "" || id.Text == "" || brand.Text == "" || modele.Text == "" || price.Text == "" || stock.Text == "")
            {
                MessageBox.Show("دڵنیا بەرەوە لە پڕکردنەوەی هەموو خانەکان");
                sprice.Focus();
            }
            else if (adad.Text == "0")
            {
                MessageBox.Show("عەدەدی کەرەستەکە دیاری بکە");

            }
           
            else
            {
                DialogResult srinawa = MessageBox.Show(" ئایە ئەتەوێ بیفرۆشی", "ئاگاداری", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (srinawa == DialogResult.Yes)
                {
                    db.Close();
                    db.Open();
                    string kat = DateTime.Now.ToString("HH:mm     dd-MM-yyyy");
                    SqlCommand cmd = new SqlCommand("Insert into Sale_Table(Sbrand,Smodel,Sprice,Sstock,sale_price,sadad,Stotal,sdate) values(N'" + brand.Text + "',N'" + modele.Text + "',N'" + price.Text + "',N'" + stock.Text + "',N'" + sprice.Text+ "',N'" + adad.Text +"',N'" + total.Text+ "','" + kat + "')", db);
                    SqlCommand dele = new SqlCommand("delete from "+table_name+" where  "+id_table+" ='" + id.Text + "'", db);
                    cmd.ExecuteNonQuery();
                    dele.ExecuteNonQuery();
                    db.Close();
                    MessageBox.Show("فرۆشرا");
                    if (table_name == "Mobile_stock")
                    {
                        get();
                    }
                    else
                    {
                        get2();
                    }
                    



                }
            }
        }



        private void get()
        {
            db.Close();
            db.Open();
            SqlCommand cmd = new SqlCommand(com, db);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            editdatagridview();
            cmd.ExecuteNonQuery();
            db.Close();
        }
        private void editdatagridview()
        {
            
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var dgv = new DataGridView();
                dataGridView1.RowTemplate.Height = 40;




            }
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("NRT reg", 12, FontStyle.Regular);

            dataGridView1.Columns["Mobile_id"].HeaderText = "ئایدی";
            dataGridView1.Columns["Mbrand"].HeaderText = "براند";
            dataGridView1.Columns["Mmodel"].HeaderText = "مۆدێل";
            dataGridView1.Columns["Mprice"].HeaderText = "نرخ";
            dataGridView1.Columns["Mstock"].HeaderText = "کەرەستەکان";
            dataGridView1.Columns["MRam"].HeaderText = "ڕام";
            dataGridView1.Columns["MRom"].HeaderText = "ڕووم";
            dataGridView1.Columns["Mcamera"].HeaderText = "کامێرا";
            dataGridView1.Columns["MDate"].HeaderText = "بەرواری زیادبوون";






            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(172, 95, 219);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;



            dataGridView1.Columns["Mobile_id"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Mbrand"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Mmodel"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Mprice"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Mstock"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["MRam"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["MRom"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Mcamera"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["MDate"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Sells_Load(object sender, EventArgs e)
        {
            condi();
        }


        private void condi()
        {

    
            if (radioButton1.Checked && garan.Text == "")
            {
                table_name = "Mobile_stock";
                id_table = "Mobile_id";
                com = "select * from Mobile_stock";

                get();
            }
            else if (radioButton1.Checked && garan.Text != "")
            {
                table_name = "Mobile_stock";
                id_table = "Mobile_id";


                com = "select * from Mobile_stock where Mmodel like N'" + garan.Text + "%'";
                get();
            }

            else if (radioButton2.Checked && garan.Text == "")
            {
                table_name = "Access_Table";
                id_table = "Access_id";


                com = "select * from Access_Table";
                get2();
            }

 
            else if (radioButton2.Checked && garan.Text != "")
            {
                table_name = "Access_Table";
                id_table = "Access_id";



                com = "select * from Access_Table where Amodel like N'" + garan.Text + "%'";
                get2();
            }
        }




        private void get2()
        {
            db.Close();
            db.Open();
            SqlCommand cmd = new SqlCommand(com, db);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            dataGridView1.DataSource = dt;
            editdatagridview2();
            cmd.ExecuteNonQuery();
            db.Close();
        }
        private void editdatagridview2()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                var dgv = new DataGridView();
                dataGridView1.RowTemplate.Height = 40;




            }
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("NRT reg", 12, FontStyle.Regular);

            dataGridView1.Columns["Access_id"].HeaderText = "ئایدی";
            dataGridView1.Columns["Abrand"].HeaderText = "براند";
            dataGridView1.Columns["Amodel"].HeaderText = "مۆدێل";
            dataGridView1.Columns["Aprice"].HeaderText = "نرخ";
            dataGridView1.Columns["Astock"].HeaderText = "کەرەستەکان";
            dataGridView1.Columns["ADate"].HeaderText = "بەرواری زیادبوون";






            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(172, 95, 219);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;



            dataGridView1.Columns["Access_id"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Amodel"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Abrand"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Aprice"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["Astock"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
            dataGridView1.Columns["ADate"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);



        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            condi();
        }

        private void garan_TextChanged(object sender, EventArgs e)
        {
            condi();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            zhmara= zhmara+1;
            adad.Text = Convert.ToString(zhmara);
            lekdani_nrxakan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brand.Clear();
            id.Clear();
            modele.Clear();
            price.Clear();
            stock.Clear();
            sprice.Clear();
            adad.Text = "0";
            total.Text = "0 $";
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Close();
            @base ba = new @base();
            ba.Show();
        }

        private void mins_Click(object sender, EventArgs e)
        {
            
            if (zhmara <= 0)
            {
                adad.Text = "0";
                lekdani_nrxakan();

            }
            else
            {   zhmara = zhmara - 1;
                adad.Text = Convert.ToString(zhmara);
                lekdani_nrxakan();
            }
        }

        private void Sells_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sprice.Text = "";
            lekdani_nrxakan();
            koy_gshty = 0;
            total.Text = Convert.ToString(koy_gshty) + " $";
            try
                {
            if (radioButton1.Checked)
            {
                

                    DataGridViewRow row = this.dataGridView1.CurrentRow;
                    id.Text = row.Cells["Mobile_id"].Value.ToString();
                    brand.Text = row.Cells["Mbrand"].Value.ToString();
                    modele.Text = row.Cells["Mmodel"].Value.ToString();
                    price.Text = row.Cells["Mprice"].Value.ToString();
                    stock.Text = row.Cells["Mstock"].Value.ToString();
                }
                
           
            else if (radioButton2.Checked)
            {
                

                    DataGridViewRow row = this.dataGridView1.CurrentRow;
                    id.Text = row.Cells["Access_id"].Value.ToString();
                    modele.Text = row.Cells["Amodel"].Value.ToString();
                    brand.Text = row.Cells["Abrand"].Value.ToString();
                    price.Text = row.Cells["Aprice"].Value.ToString();
                    stock.Text = row.Cells["Astock"].Value.ToString();



                }
                zhmara = 1;
                adad.Text = Convert.ToString(zhmara);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void sprice_TextChanged(object sender, EventArgs e)
        {
            try
            {
            lekdani_nrxakan();

            }
            catch (Exception)
            {
                MessageBox.Show("تکایە تەنها ژمارە داغڵبکە");
                sprice.Focus();
            }

        }
        private void lekdani_nrxakan()
        {
            if (sprice.Text != "")
            {
                double salle_price = Convert.ToDouble(sprice.Text);
                int num = Convert.ToInt32(adad.Text);
                double sol = salle_price * num;
                total.Text = Convert.ToString(sol) + " $";
            }
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }

