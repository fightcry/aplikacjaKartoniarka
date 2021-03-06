using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace aplikacjaKartoniarka {
    public partial class Form1 : Form {
        static SqlConnection con = new SqlConnection(@"Data Source=ajffsql2\ajffsql2;
            Initial Catalog=Kartoniarka;" +
            "User ID=kartoniarka; password=AJff2021");
        static string select1 = "SELECT text FROM tabela1";
        static string select2 = "SELECT text FROM tabela2";
        static string select3 = "SELECT text FROM tabela3";
        static string select4 = "SELECT text FROM tabela4";
        SqlDataAdapter table1Adapter = new SqlDataAdapter(select1, con);
        SqlDataAdapter table2Adapter = new SqlDataAdapter(select2, con);
        SqlDataAdapter table3Adapter = new SqlDataAdapter(select3, con);
        SqlDataAdapter table4Adapter = new SqlDataAdapter(select4, con);
        

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            var commandBuilder1 = new SqlCommandBuilder(table1Adapter);
            var commandBuilder2 = new SqlCommandBuilder(table2Adapter);
            var commandBuilder3 = new SqlCommandBuilder(table3Adapter);
            var commandBuilder4 = new SqlCommandBuilder(table4Adapter);

            database1DataSet.EnforceConstraints = false;

            table1Adapter.Fill(this.database1DataSet.tabela1);
            table2Adapter.Fill(this.database1DataSet.tabela2);
            table3Adapter.Fill(this.database1DataSet.tabela3);
            table4Adapter.Fill(this.database1DataSet.tabela4);

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();
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

            database1DataSet.tabela1.Clear();
            database1DataSet.tabela2.Clear();
            database1DataSet.tabela3.Clear();
            database1DataSet.tabela4.Clear();
            table1Adapter.Fill(this.database1DataSet.tabela1);
            table2Adapter.Fill(this.database1DataSet.tabela2);
            table3Adapter.Fill(this.database1DataSet.tabela3);
            table4Adapter.Fill(this.database1DataSet.tabela4);
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                List<bool> colorList = new List<bool>();
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO tabela1 (text) VALUES ('" + textBox1.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                foreach (DataGridViewRow item in dataGridView1.Rows) {
                    if (item.DefaultCellStyle.BackColor == Color.Green)
                        colorList.Add(true);
                    else
                        colorList.Add(false);
                }
                database1DataSet.tabela1.Clear();
                table1Adapter.Fill(this.database1DataSet.tabela1);
                int row = 0;
                foreach (bool item in colorList) {
                    if (item)
                        dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                    row += 1;
                }
                textBox1.Clear();
                dataGridView1.ClearSelection();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                List<bool> colorList = new List<bool>();
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO tabela2 (text) VALUES ('" + textBox2.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                foreach (DataGridViewRow item in dataGridView2.Rows) {
                    if (item.DefaultCellStyle.BackColor == Color.Green)
                        colorList.Add(true);
                    else
                        colorList.Add(false);
                }
                database1DataSet.tabela2.Clear();
                table2Adapter.Fill(this.database1DataSet.tabela2);
                int row = 0;
                foreach (bool item in colorList) {
                    if (item)
                        dataGridView2.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                    row += 1;
                }
                textBox2.Clear();
                dataGridView2.ClearSelection();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                List<bool> colorList = new List<bool>();
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO tabela3 (text) VALUES ('" + textBox3.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                foreach (DataGridViewRow item in dataGridView3.Rows) {
                    if (item.DefaultCellStyle.BackColor == Color.Green)
                        colorList.Add(true);
                    else
                        colorList.Add(false);
                }
                database1DataSet.tabela3.Clear();
                table3Adapter.Fill(this.database1DataSet.tabela3);
                int row = 0;
                foreach (bool item in colorList) {
                    if (item)
                        dataGridView3.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                    row += 1;
                }
                textBox3.Clear();
                dataGridView3.ClearSelection();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                List<bool> colorList = new List<bool>();
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO tabela4 (text) VALUES ('" + textBox4.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                foreach (DataGridViewRow item in dataGridView4.Rows) {
                    if (item.DefaultCellStyle.BackColor == Color.Green)
                        colorList.Add(true);
                    else
                        colorList.Add(false);
                }
                database1DataSet.tabela4.Clear();
                table4Adapter.Fill(this.database1DataSet.tabela4);
                int row = 0;
                foreach (bool item in colorList) {
                    if (item)
                        dataGridView4.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                    row += 1;
                }
                textBox4.Clear();
                dataGridView4.ClearSelection();
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e) {
            Int32 rowToDelete = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete >= 0) {
                List<bool> colorList = new List<bool>();
                foreach (DataGridViewRow item in dataGridView1.Rows) {
                    if (item.DefaultCellStyle.BackColor == Color.Green)
                        colorList.Add(true);
                    else
                        colorList.Add(false);
                }
                colorList.RemoveAt(rowToDelete);
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM tabela1 WHERE text = '" +
                    dataGridView1.Rows[rowToDelete].Cells[0].Value + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                database1DataSet.tabela1.Clear();
                table1Adapter.Fill(this.database1DataSet.tabela1);
                int row = 0;
                foreach (bool item in colorList) {
                    if (item)
                        dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                    row += 1;
                }
                dataGridView1.ClearSelection();
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                if (hti.RowIndex >= 0 && hti.RowIndex < dataGridView1.Rows.Count)
                    dataGridView1.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e) {
            Int32 rowToColor = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToColor >= 0) {
                if (dataGridView1.Rows[rowToColor].DefaultCellStyle.BackColor == Color.Green)
                    dataGridView1.Rows[rowToColor].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView1.Rows[rowToColor].DefaultCellStyle.BackColor = Color.Green;
            }
            dataGridView1.ClearSelection();
        }

        private void toolStripTextBox5_Click(object sender, EventArgs e) {
            Int32 rowToDelete = dataGridView3.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete >= 0) {
                List<bool> colorList = new List<bool>();
                foreach (DataGridViewRow item in dataGridView3.Rows) {
                    if (item.DefaultCellStyle.BackColor == Color.Green)
                        colorList.Add(true);
                    else
                        colorList.Add(false);
                }
                colorList.RemoveAt(rowToDelete);
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM tabela3 WHERE text = '" +
                    dataGridView3.Rows[rowToDelete].Cells[0].Value + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                database1DataSet.tabela3.Clear();
                table3Adapter.Fill(this.database1DataSet.tabela3);
                int row = 0;
                foreach (bool item in colorList) {
                    if (item)
                        dataGridView3.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                    row += 1;
                }
                dataGridView3.ClearSelection();
            }
        }

        private void toolStripTextBox6_Click(object sender, EventArgs e) {
            Int32 rowToColor = dataGridView3.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToColor >= 0) {
                if (dataGridView3.Rows[rowToColor].DefaultCellStyle.BackColor == Color.Green)
                    dataGridView3.Rows[rowToColor].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView3.Rows[rowToColor].DefaultCellStyle.BackColor = Color.Green;
            }
            dataGridView3.ClearSelection();
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e) {
            Int32 rowToDelete = dataGridView2.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete >= 0) {
                List<bool> colorList = new List<bool>();
                foreach (DataGridViewRow item in dataGridView2.Rows) {
                    if (item.DefaultCellStyle.BackColor == Color.Green)
                        colorList.Add(true);
                    else
                        colorList.Add(false);
                }
                colorList.RemoveAt(rowToDelete);
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM tabela2 WHERE text = '" +
                    dataGridView2.Rows[rowToDelete].Cells[0].Value + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                database1DataSet.tabela2.Clear();
                table2Adapter.Fill(this.database1DataSet.tabela2);
                int row = 0;
                foreach (bool item in colorList) {
                    if (item)
                        dataGridView2.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                    row += 1;
                }
                dataGridView2.ClearSelection();
            }
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e) {
            Int32 rowToColor = dataGridView2.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToColor >= 0) {
                if (dataGridView2.Rows[rowToColor].DefaultCellStyle.BackColor == Color.Green)
                    dataGridView2.Rows[rowToColor].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView2.Rows[rowToColor].DefaultCellStyle.BackColor = Color.Green;
            }
            dataGridView2.ClearSelection();
        }

        private void toolStripTextBox7_Click(object sender, EventArgs e) {
            Int32 rowToDelete = dataGridView4.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete >= 0) {
                List<bool> colorList = new List<bool>();
                foreach (DataGridViewRow item in dataGridView4.Rows) {
                    if (item.DefaultCellStyle.BackColor == Color.Green)
                        colorList.Add(true);
                    else
                        colorList.Add(false);
                }
                colorList.RemoveAt(rowToDelete);
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM tabela4 WHERE text = '" +
                    dataGridView4.Rows[rowToDelete].Cells[0].Value + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                database1DataSet.tabela4.Clear();
                table4Adapter.Fill(this.database1DataSet.tabela4);
                int row = 0;
                foreach (bool item in colorList) {
                    if (item)
                        dataGridView4.Rows[row].DefaultCellStyle.BackColor = Color.Green;
                    row += 1;
                }
                dataGridView4.ClearSelection();
            }
        }

        private void toolStripTextBox8_Click(object sender, EventArgs e) {
            Int32 rowToColor = dataGridView4.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToColor >= 0) {
                if (dataGridView4.Rows[rowToColor].DefaultCellStyle.BackColor == Color.Green)
                    dataGridView4.Rows[rowToColor].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView4.Rows[rowToColor].DefaultCellStyle.BackColor = Color.Green;
            }
            dataGridView4.ClearSelection();
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var hti = dataGridView2.HitTest(e.X, e.Y);
                dataGridView2.ClearSelection();
                if (hti.RowIndex >= 0 && hti.RowIndex < dataGridView2.Rows.Count)
                    dataGridView2.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void dataGridView3_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var hti = dataGridView3.HitTest(e.X, e.Y);
                dataGridView3.ClearSelection();
                if (hti.RowIndex >= 0 && hti.RowIndex < dataGridView3.Rows.Count)
                    dataGridView3.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void dataGridView4_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var hti = dataGridView4.HitTest(e.X, e.Y);
                dataGridView4.ClearSelection();
                if (hti.RowIndex >= 0 && hti.RowIndex < dataGridView4.Rows.Count)
                    dataGridView4.Rows[hti.RowIndex].Selected = true;
            }
        }
    }
}
