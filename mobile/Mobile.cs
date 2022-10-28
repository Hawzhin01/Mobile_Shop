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
    public partial class Mobile : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-739V4OA\SQLEXPRESS;Initial Catalog=Mobile_Shop;Integrated Security=True");

        public Mobile()
        {
            InitializeComponent();
            get();
            db.Open();
            SqlCommand cmd = new SqlCommand("select * from Name_Shop", db);
            SqlDataReader x = cmd.ExecuteReader();
            if (x.Read())
            {
                label1.Text = "مۆبایلی " + x["name"].ToString();
            }

            db.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            @base ba = new @base();
            ba.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id.Text=="" || brand.Text=="" || modele.Text==""|| stock.Text=="" || price.Text=="" || ram.Text==""|| rom.Text == "" || mp.Text == "")
            {
                MessageBox.Show("تکایە هەموو خانەکان بە وشەی گونجاو پڕبکەرەوە","ئاگاداری",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    db.Close();
                    db.Open();
                    string nrx = price.Text + " $";
                    string kat = DateTime.Now.ToString("HH:mm     dd-MM-yyyy") ;
                    SqlCommand cmd = new SqlCommand("Insert into Mobile_stock(Mbrand,Mmodel,Mprice,Mstock,MRam,MRom,Mcamera,MDate) values(N'" + brand.Text + "',N'" + modele.Text + "',N'" + nrx+ "',N'" + stock.Text + "',N'" + ram.Text + " GB" + "',N'" + rom.Text + " GB" + "',N'" + mp.Text + " mp" + "','"+kat+"')", db);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("بە سەرکەوتووی زیادکرا");
                    brand.Clear();
                    id.Clear();
                    modele.Clear();
                    price.Clear();
                    stock.Clear();
                    ram.Clear();
                    rom.Clear();
                    mp.Clear();
                    get();
                    db.Close();
                }
                catch(Exception )
                {
                    MessageBox.Show("تکایە ئایدیەکە و بگۆڕە چونکە کاڵای تر هەیە بە هەمان ئایدی");
                }



            }
        }
        private void get()
        {
            db.Close();
            db.Open();
            SqlCommand cmd = new SqlCommand("select * from Mobile_stock",db);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = this.dataGridView1.CurrentRow;
                id.Text = row.Cells["Mobile_id"].Value.ToString();
                brand.Text = row.Cells["Mbrand"].Value.ToString();
                modele.Text = row.Cells["Mmodel"].Value.ToString();
                price.Text = row.Cells["Mprice"].Value.ToString();
                stock.Text = row.Cells["Mstock"].Value.ToString();
                ram.Text = row.Cells["MRam"].Value.ToString();
                rom.Text = row.Cells["MRom"].Value.ToString();
                mp.Text = row.Cells["Mcamera"].Value.ToString();

               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("بۆ سڕینەوەی داتا پێویست دەکات خانەی ئایدی پڕبکەیتەوە");
                id.Focus();
            }
            else
            {
                try
                {
                    db.Close();
                    db.Open();
                    SqlCommand binin = new SqlCommand("select * from Mobile_stock where Mobile_id='" + id.Text + "'", db);
                    SqlCommand srinawa = new SqlCommand("delete from Mobile_stock where Mobile_id='" + id.Text + "'", db);
                    SqlDataReader haia = binin.ExecuteReader();
                    
                    if (haia.Read())
                    {db.Close();
                        DialogResult delete = MessageBox.Show("دڵنیای لە سڕیەنەوەی ئەم داتایە", "ئاگاداری", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (delete == DialogResult.Yes)
                        {
                            db.Close();
                            db.Open();
                            srinawa.ExecuteNonQuery();
                            get();
                            db.Close();
                            MessageBox.Show("بەسەرکەوتووی سڕایەوە");
                            brand.Clear();
                            id.Clear();
                            modele.Clear();
                            price.Clear();
                            stock.Clear();
                            ram.Clear();
                            rom.Clear();
                            mp.Clear();

                        }
                    }
                    else
                    {
                        MessageBox.Show("هیج داتایەکمان نیە بەم ئایدیە تکایە دڵنیا بەرەوە لە ڕاستی ئایدیەکە");
                        id.Focus();
                    }
                    db.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("we have a problem " + Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brand.Clear();
            id.Clear();
            modele.Clear();
            price.Clear();
            stock.Clear();
            ram.Clear();
            rom.Clear();
            mp.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || brand.Text == "" || modele.Text == "" || stock.Text == "" || price.Text == "" || ram.Text == "" || rom.Text == "" || mp.Text == "")
            {
                MessageBox.Show("تکایە هەموو خانەکان بە وشەی گونجاو پڕبکەرەوە", "ئاگاداری", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    db.Close();
                    db.Open();
                    string nrx = price.Text + " $";
                   
                    SqlCommand cmd = new SqlCommand("update  Mobile_stock set Mbrand=N'" + brand.Text + "',Mmodel=N'"+ modele.Text + "',Mprice=N'" + nrx + "',Mstock=N'" + stock.Text + "',MRam=N'" + ram.Text + "',MRom=N'" + rom.Text + "',Mcamera=N'" + mp.Text + "' where Mobile_id='"+id.Text+"'", db);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("بە سەرکەوتووی تازەکرایەوە");
                    brand.Clear();
                    id.Clear();
                    modele.Clear();
                    price.Clear();
                    stock.Clear();
                    ram.Clear();
                    rom.Clear();
                    mp.Clear();
                    get();
                    db.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }



            }

        }

        private void Mobile_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }

