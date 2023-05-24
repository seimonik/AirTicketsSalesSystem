using MySql.Data.MySqlClient;
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

namespace AirTicketSalesSystem
{
    public partial class MyFlightsForm : Form
    {
        public LoginUser user;
        public MyFlightsForm()
        {
            InitializeComponent();
        }
        public MyFlightsForm(LoginUser user)
        {
            InitializeComponent();

            this.user = user;
            UserName.Text = user.login;
        }

        private void MyFlightsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void buyticket_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm(user);
            mainForm.user = user;
            mainForm.Show();
        }

        private void MyFlightsForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectQuery = $"SELECT * FROM Tickets WHERE UserId='{user.id}'";
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("GetTickets", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@UserId"].Value = user.id;
                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            // Create a data table to hold the retrieved data.
                            DataTable dataTable = new DataTable();

                            // Load the data from SqlDataReader into the data table.
                            dataTable.Load(dataReader);

                            // ДАННЫЕ ИЗ ТАБЛИЦЫ
                            if (dataTable.Rows.Count > 0)
                            {
                                this.dataGridView1.DataSource = dataTable;

                                dataGridView1.Columns[0].HeaderText = "Номер билета";
                                dataGridView1.Columns[1].HeaderText = "Номер рейса";
                                dataGridView1.Columns[2].HeaderText = "Авиакомпания";
                                dataGridView1.Columns[3].HeaderText = "Город вылета";
                                dataGridView1.Columns[4].HeaderText = "Аэропорт";
                                dataGridView1.Columns[5].HeaderText = "Город прилета";
                                dataGridView1.Columns[6].HeaderText = "Аэропорт";
                                dataGridView1.Columns[7].HeaderText = "Тип";
                                dataGridView1.Columns[8].HeaderText = "Дата покупки";
                                dataGridView1.Columns[9].HeaderText = "Цена";
                            }
                            else
                            {
                                int rowsCount = dataGridView1.Rows.Count - 1;
                                for (int i = 0; i < rowsCount; i++)
                                {
                                    dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
                                }

                                Panel panelflights = new Panel();
                                panelflights.Size = new Size(dataGridView1.Width, 50);
                                panelflights.Location = dataGridView1.Location;

                                Label NotFound = new Label();
                                NotFound.Text = "У Вас нет забронированных рейсов";
                                NotFound.Location = new Point(0, 0);
                                NotFound.AutoSize = true;

                                dataGridView1.Controls.Add(panelflights);
                                panelflights.Controls.Add(NotFound);
                            }
                            // Close the SqlDataReader.
                            dataReader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR!!!");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
