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
    public partial class Access : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-739V4OA\SQLEXPRESS;Initial Catalog=Mobile_Shop;Integrated Security=True");

        public Access()
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (aid.Text == "" || abrand.Text == "" || amodele.Text == "" || astock.Text == "" || aprice.Text == "")
            {
                MessageBox.Show("تکایە هەموو خانەکان بە وشەی گونجاو پڕبکەرەوە", "ئاگاداری", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    db.Close();
                    db.Open();
                    string nrx = aprice.Text + " $";
                    string kat = DateTime.Now.ToString("hh:mm     dd-MM-yyyy");
                    SqlCommand cmd = new SqlCommand("Insert into Access_Table(Access_id,Abrand,Amodel,Aprice,Astock,ADate) values('"+aid.Text+"',N'" + abrand.Text + "',N'" + amodele.Text + "',N'" + nrx + "',N'" + astock.Text + "',N'"+kat+"')", db);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("بە سەرکەوتووی زیادکرا");
                    abrand.Clear();
                    aid.Clear();
                    amodele.Clear();
                    aprice.Clear();
                    astock.Clear();
                    
                    get();
                    db.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("تکایە ئایدیەکە و بگۆڕە چونکە کاڵای تر هەیە بە هەمان ئایدی");
                }



            }
        }
        private void get()
        {
            db.Close();
            db.Open();
            SqlCommand cmd = new SqlCommand("select * from Access_Table", db);
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

        

        private void Access_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = this.dataGridView1.CurrentRow;
                aid.Text = row.Cells["Access_id"].Value.ToString();
                abrand.Text = row.Cells["Amodel"].Value.ToString();
                amodele.Text = row.Cells["Abrand"].Value.ToString();
                aprice.Text = row.Cells["Aprice"].Value.ToString();
                astock.Text = row.Cells["Astock"].Value.ToString();



            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (aid.Text == "" || abrand.Text == "" || amodele.Text == "" || astock.Text == "" || aprice.Text == "")
            {
                MessageBox.Show("تکایە هەموو خانەکان بە وشەی گونجاو پڕبکەرەوە", "ئاگاداری", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    db.Close();
                    db.Open();
                    string nrx = aprice.Text + " $";

                    SqlCommand cmd = new SqlCommand("update  Access_Table set Abrand=N'" + abrand.Text + "',Amodel=N'" + amodele.Text + "',Aprice=N'" + nrx + "',Astock=N'" + astock.Text + "' where Access_id='" + aid.Text + "'", db);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("بە سەرکەوتووی تازەکرایەوە");
                    abrand.Clear();
                    aid.Clear();
                    amodele.Clear();
                    aprice.Clear();
                    astock.Clear();
                    get();
                    db.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrand.Clear();
            aid.Clear();
            amodele.Clear();
            aprice.Clear();
            astock.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (aid.Text == "")
            {
                MessageBox.Show("بۆ سڕینەوەی داتا پێویست دەکات خانەی ئایدی پڕبکەیتەوە");
                aid.Focus();
            }
            else
            {
                try
                {
                    db.Close();
                    db.Open();
                    SqlCommand binin = new SqlCommand("select * from Access_Table where Access_id='" + aid.Text + "'", db);
                    SqlCommand srinawa = new SqlCommand("delete from Access_Table where Access_id='" + aid.Text + "'", db);
                    SqlDataReader haia = binin.ExecuteReader();

                    if (haia.Read())
                    {
                        db.Close();
                        DialogResult delete = MessageBox.Show("دڵنیای لە سڕیەنەوەی ئەم داتایە", "ئاگاداری", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (delete == DialogResult.Yes)
                        {
                            db.Close();
                            db.Open();
                            srinawa.ExecuteNonQuery();
                            get();
                            db.Close();
                            MessageBox.Show("بەسەرکەوتووی سڕایەوە");
                            abrand.Clear();
                            aid.Clear();
                            amodele.Clear();
                            aprice.Clear();
                            astock.Clear();
                            

                        }
                    }
                    else
                    {
                        MessageBox.Show("هیج داتایەکمان نیە بەم ئایدیە تکایە دڵنیا بەرەوە لە ڕاستی ئایدیەکە");
                        aid.Focus();
                    }
                    db.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("we have a problem " + Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
