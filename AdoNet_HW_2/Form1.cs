using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdoNet_HW_2
{
    public partial class Form1 : Form
    {
        public string connection = @"Data Source = SQL5103.site4now.net; Initial Catalog = DB_A7168B_kuvaevsql; User Id = DB_A7168B_kuvaevsql_admin; Password=qwerty009";
        SqlConnection sqlConnection = null;
        SqlDataAdapter sqlDateAdapter = null;
        DataSet dataSet = null;
        SqlCommandBuilder sqlCommanBulder = null;
        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connection);
            getModyfiedValues.Click += BtnModifiedValues_Click; 
            try
            {
                string query = "select * from [Coffe Shop]";
                dataGridView1.DataSource = null;
                dataSet = new DataSet();
                sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
                sqlDateAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
        private void BtnModifiedValues_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dataSet.Tables[0].GetChanges(DataRowState.Modified);
        }
        // Показать информацию о кофе в описании, которых встречается упоминание вишни
        private void query1_Click(object sender, EventArgs e)
        {
            string query = "select [Sort Name], [About] from [Coffe Shop] where [About] like 'вишня'";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }
        // Показать информацию о кофе с себестоимостью в указанном диапазоне
        private void query2_Click(object sender, EventArgs e)
        {
            string query = "select [Sort Name], [About] from [Coffe Shop] where [Price] between 1000 and 2000";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }
        // Показать информацию о кофе с количеством грамм в указанном диапазоне
        private void query3_Click(object sender, EventArgs e)
        {
            string query = "select [Sort Name], [About] from [Coffe Shop] where [Weight] between 300 and 400";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }
        // Показать информацию о кофе из указанных стран
        private void query4_Click(object sender, EventArgs e)
        {
            string query = "select [Sort Name], [About] from [Coffe Shop] where [Country] = 'Италия'";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }
        #region Отобразить название страны происхождения и количество сортов кофе из этой страны
        private void query5_Click(object sender, EventArgs e)
        {
            string query = "select count([Sort Name]) from [Coffe Shop] where [Country] = 'Италия'";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void query6_Click(object sender, EventArgs e)
        {
            string query = "select count([Sort Name]) from [Coffe Shop] where [Country] = 'Индонезия'";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void query7_Click(object sender, EventArgs e)
        {
            string query = "select count([Sort Name]) from [Coffe Shop] where [Country] = 'Бразилия'";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }
        #endregion
        #region Отобразить среднее количество грамм кофе по каждой стране
        private void query8_Click(object sender, EventArgs e)
        {
            string query = "select avg([Weight]) from [Coffe Shop] where [Country] = 'Италия'";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void query9_Click(object sender, EventArgs e)
        {
            string query = "select avg([Weight]) from [Coffe Shop] where [Country] = 'Индонезия'";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void query10_Click(object sender, EventArgs e)
        {
            string query = "select avg([Weight]) from [Coffe Shop] where [Country] = 'Бразилия'";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }
        #endregion
        #region Показать три самых дешевых сорта кофе по всем странам
        private void query11_Click(object sender, EventArgs e)
        {
            string query = "select top(3) * from [Coffe Shop] where [Country] = 'Италия' order by [Price] asc";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void query12_Click(object sender, EventArgs e)
        {
            string query = "select top(3) * from [Coffe Shop] where [Country] = 'Индонезия' order by [Price] asc";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void query13_Click(object sender, EventArgs e)
        {
            string query = "select top(3) * from [Coffe Shop] where [Country] = 'Бразилия' order by [Price] asc";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }
        #endregion
        #region Показать три самых дорогих сорта кофе по всем странам
        private void query14_Click(object sender, EventArgs e)
        {
            string query = "select top(3) * from [Coffe Shop] where [Country] = 'Италия' order by [Price] desc";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void query15_Click(object sender, EventArgs e)
        {
            string query = "select top(3) * from [Coffe Shop] where [Country] = 'Индонезия' order by [Price] desc";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void query16_Click(object sender, EventArgs e)
        {
            string query = "select top(3) * from [Coffe Shop] where [Country] = 'Бразилия' order by [Price] desc";
            dataGridView2.DataSource = null;
            dataSet = new DataSet();
            sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
            sqlDateAdapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }
        #endregion
        private void clear_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
