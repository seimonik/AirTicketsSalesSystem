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
    public partial class Regular_Flights_ADMIN : Form
    {
        int selectedRow = -1;
        public LoginUser user;
        public Regular_Flights_ADMIN(LoginUser user)
        {
            InitializeComponent();

            this.user = user;
            UserName.Text = user.login;
        }
        public Regular_Flights_ADMIN()
        {
            InitializeComponent();
        }

        private void buttonRegularFlights_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectQuery = $"SELECT * FROM Regular_Flights";
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, connection))
                {
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

                                dataGridView1.Columns[0].HeaderText = "Номер рейса";
                                dataGridView1.Columns[1].HeaderText = "Дата открытия";
                                dataGridView1.Columns[2].HeaderText = "Дата закрытия";
                                dataGridView1.Columns[3].HeaderText = "Номер маршрута";
                                dataGridView1.Columns[4].HeaderText = "Код аэропорта";
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

        private void Regular_Flights_ADMIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if(selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_code.Text = row.Cells[4].Value.ToString();
                numericUpDown_id_route.Value = Convert.ToDecimal(row.Cells[3].Value.ToString());
                textBoxFlightNumber.Text = row.Cells[0].Value.ToString();
                dateTimePickerDeparture.Value = DateTime.Parse(row.Cells[1].Value.ToString());
                datePickerArrival.Value = DateTime.Parse(row.Cells[2].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("InsertRegFlights", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@Flightnumber", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@Flightnumber"].Value = textBoxFlightNumber.Text;
                    sqlCommand.Parameters.Add(new SqlParameter("@OpeningDate", SqlDbType.Date));
                    sqlCommand.Parameters["@OpeningDate"].Value = DateTime.Parse(dateTimePickerDeparture.Value.ToString());
                    sqlCommand.Parameters.Add(new SqlParameter("@ClosingDate", SqlDbType.Date));
                    sqlCommand.Parameters["@ClosingDate"].Value = DateTime.Parse(datePickerArrival.Value.ToString());
                    sqlCommand.Parameters.Add(new SqlParameter("@RouteNumber", SqlDbType.Int));
                    sqlCommand.Parameters["@RouteNumber"].Value = (int)numericUpDown_id_route.Value;
                    sqlCommand.Parameters.Add(new SqlParameter("@AirlineCode", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@AirlineCode"].Value = textBox_code.Text;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
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

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoutesForm flightsForm = new RoutesForm(user);
            flightsForm.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditorForm flightsForm = new EditorForm(user);
            flightsForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
