using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikacjaKartoniarka {
    public partial class Form1 : Form {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
            Initial Catalog=" + AppDomain.CurrentDomain.BaseDirectory + @"Database1.mdf;" +
            "User ID=kartoniarka; password=AJff2021");
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.tabela4TableAdapter.Fill(this.database1DataSet.tabela4);
            this.tabela3TableAdapter.Fill(this.database1DataSet.tabela3);
            this.tabela2TableAdapter.Fill(this.database1DataSet.tabela2);
            this.tabela1TableAdapter.Fill(this.database1DataSet.tabela1);
            Console.WriteLine(@"Data Source=(LocalDB)\MSSQLLocalDB;
            Initial Catalog=" + AppDomain.CurrentDomain.BaseDirectory + @"Database1.mdf;" +
    "User ID=kartoniarka; password=AJff2021");
        }

        private void button1_Click(object sender, EventArgs e) {
            con.Open();
            SqlCommand com = new SqlCommand("DELETE FROM tabela1", con);
            SqlCommand cob = new SqlCommand("DELETE FROM tabela2", con);
            SqlCommand cov = new SqlCommand("DELETE FROM tabela3", con);
            SqlCommand coc = new SqlCommand("DELETE FROM tabela4", con);
            com.ExecuteNonQuery();
            cob.ExecuteNonQuery();
            cov.ExecuteNonQuery();
            coc.ExecuteNonQuery();
            con.Close();
            this.tabela4TableAdapter.Fill(this.database1DataSet.tabela4);
            this.tabela3TableAdapter.Fill(this.database1DataSet.tabela3);
            this.tabela2TableAdapter.Fill(this.database1DataSet.tabela2);
            this.tabela1TableAdapter.Fill(this.database1DataSet.tabela1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {        
            if (e.RowIndex >= 0) {
                if (dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                if (dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }
   

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                if (dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                if (dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView4.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO tabela1 (text) VALUES ('" + textBox1.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                this.tabela1TableAdapter.Fill(this.database1DataSet.tabela1);
                textBox1.Clear();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO tabela2 (text) VALUES ('" + textBox2.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                this.tabela2TableAdapter.Fill(this.database1DataSet.tabela2);
                textBox2.Clear();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO tabela3 (text) VALUES ('" + textBox3.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                this.tabela3TableAdapter.Fill(this.database1DataSet.tabela3);
                textBox3.Clear();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO tabela4 (text) VALUES ('" + textBox4.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                this.tabela4TableAdapter.Fill(this.database1DataSet.tabela4);
                textBox4.Clear();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM tabela1 WHERE text = '" + 
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                this.tabela1TableAdapter.Fill(this.database1DataSet.tabela1);
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM tabela2 WHERE text = '" +
                    dataGridView2.Rows[e.RowIndex].Cells[0].Value + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                this.tabela2TableAdapter.Fill(this.database1DataSet.tabela2);
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM tabela3 WHERE text = '" +
                    dataGridView3.Rows[e.RowIndex].Cells[0].Value + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                this.tabela3TableAdapter.Fill(this.database1DataSet.tabela3);
            }
        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM tabela4 WHERE text = '" +
                    dataGridView4.Rows[e.RowIndex].Cells[0].Value + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                this.tabela4TableAdapter.Fill(this.database1DataSet.tabela4);
            }
        }
    }
}
