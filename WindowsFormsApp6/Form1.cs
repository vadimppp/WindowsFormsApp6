using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
        }
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;

        private void button1_Click(object sender, EventArgs e)
        {
            dbFileName = textBox1.Text + ".sqlite";
            if (!File.Exists(dbFileName)) SQLiteConnection.CreateFile(dbFileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Catalog (id INTEGER PRIMARY KEY AUTOINCREMENT, name Text, discount Text,dependence Text,description Text,price Text, proverka Text)";
                m_sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Таблица успешно создана!");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                dbFileName = "catalog1.sqlite";
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
            }

            try
            {
                m_sqlCmd.CommandText = "INSERT INTO Catalog ('name', 'discount','dependence','description','price','proverka') values ('" + comboBox1.Text + "' , '" + textBox4.Text + "', '" + textBox6.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox7.Text + "')";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            m_dbConn.Close();

            comboBox1.SelectedIndex = -1;
            textBox3.Text = "";
            textBox3.Clear();
            textBox4.Text = "";
            textBox4.Clear();
            textBox5.Text = "";
            textBox5.Clear();
            textBox6.Text = "";
            textBox6.Clear();
            textBox7.Text = "";
            textBox7.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            if (m_dbConn.State != ConnectionState.Open)
            {
                dbFileName = "catalog1.sqlite";
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
            }

            try
            {
                sqlQuery = "SELECT * FROM Catalog";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    dgvViewer.Rows.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++)
                        dgvViewer.Rows.Add(dTable.Rows[i].ItemArray);
                }
                else
                    MessageBox.Show("Database is empty");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            m_dbConn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvViewer.Rows.Clear();
            dgvViewer.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            textBox4.Text = "4";
                            textBox4.Enabled = false; // чтобы не был активным
                            textBox6.Text = "Нет";
                            textBox6.Enabled = false; // чтобы не был активным
                            textBox3.Text = "Test1";
                            textBox3.Enabled = false; // чтобы не был активным
                            textBox5.Text = "57470";
                            textBox5.Enabled = true; // чтобы  был активным
                        }
                        break;

                    case 1:
                        {
                            textBox4.Text = "5";
                            textBox4.Enabled = false; // чтобы не был активным
                            textBox6.Text = "Есть";
                            textBox6.Enabled = false; // чтобы не был активным
                            textBox3.Text = "Test55";
                            textBox3.Enabled = false; // чтобы не был активным
                            textBox5.Text = "5360";
                            textBox5.Enabled = true; // чтобы  был активным
                        }
                        break;

                    case 2:
                        {
                            textBox4.Text = "2";
                            textBox4.Enabled = false; // чтобы не был активным
                            textBox6.Text = "Есть";
                            textBox6.Enabled = false; // чтобы не был активным
                            textBox3.Text = "Test88";
                            textBox3.Enabled = false; // чтобы не был активным
                            textBox5.Text = "136540";
                            textBox5.Enabled = true; // чтобы  был активным
                        }
                        break;
                    case 3:
                        {
                            textBox4.Text = "0";
                            textBox4.Enabled = false; // чтобы не был активным
                            textBox6.Text = "Есть";
                            textBox6.Enabled = false; // чтобы не был активным
                            textBox3.Text = "Test66";
                            textBox3.Enabled = false; // чтобы не был активным
                            textBox5.Text = "54054";
                            textBox5.Enabled = true; // чтобы  был активным
                        }
                        break;
                    case 4:
                        {
                            textBox4.Text = "11";
                            textBox4.Enabled = false; // чтобы не был активным
                            textBox6.Text = "Нет";
                            textBox6.Enabled = false; // чтобы не был активным
                            textBox3.Text = "Test11";
                            textBox3.Enabled = false; // чтобы не был активным
                            textBox5.Text = "57850";
                            textBox5.Enabled = true; // чтобы  был активным
                        }
                        break;

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double a;
            double b;
            double c;
            a = Convert.ToDouble(textBox4.Text);
            b = Convert.ToDouble(textBox5.Text);
            c = b - ((b * a) / 100);
            textBox7.Text = Convert.ToString(c);
        }
    }
}
