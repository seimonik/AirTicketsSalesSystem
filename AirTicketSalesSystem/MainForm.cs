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
    public partial class MainForm : Form
    {
        private int selectedRow = -1;
        public MainForm()
        {
            InitializeComponent();
            //UserName.Text = user.Name + " " + user.Surname;
        }

        public MainForm(LoginUser us)
        {
            InitializeComponent();
            this.user = us;
            UserName.Text = us.login;
        }

        public LoginUser user;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //private void CreateColumns()
        //{
        //    dgvFlights.Columns.Add("FlightNumber", "Номер рейса");
        //    dgvFlights.Columns.Add("DepartureDate", "Дата отправления");
        //    dgvFlights.Columns.Add("DepartureTime", "Время отправления");
        //    dgvFlights.Columns.Add("ArrivalDate", "Дата прибытия");
        //    dgvFlights.Columns.Add("ArrivalTime", "Время прибытия");
        //    dgvFlights.Columns.Add("EconomyPrice", "Цена эконома");
        //    dgvFlights.Columns.Add("BusinessPrice", "Цена бизнеса");
        //}
        //private void ReadSingleRows(DataGridView dgv, IDataRecord record)
        //{
        //    dgv.Rows.Add(record.GetString(0), record.GetData(1), record.GetDateTime(2), record.GetData(3), record.GetDateTime(4), );

        //}

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("GetFlights", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@departure", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@departure"].Value = departurecity.Text;
                    sqlCommand.Parameters.Add(new SqlParameter("@arrival", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@arrival"].Value = cityofarrival.Text;
                    sqlCommand.Parameters.Add(new SqlParameter("@date", SqlDbType.Date, 50));
                    DateTime data = date_and_time_departure.Value;
                    sqlCommand.Parameters["@date"].Value = date_and_time_departure.Value;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            // Create a data table to hold the retrieved data.
                            DataTable dataTable = new DataTable();
                            //dataTable.

                            // Load the data from SqlDataReader into the data table.
                            dataTable.Load(dataReader);

                            // ДАННЫЕ ИЗ ТАБЛИЦЫ
                            if (dataTable.Rows.Count > 0)
                            {
                                this.dgvFlights.DataSource = dataTable;
                            }
                            else
                            {
                                paneldata.Controls.Clear();
                                int rowsCount = dgvFlights.Rows.Count - 1;
                                for (int i = 0; i < rowsCount; i++)
                                {
                                    dgvFlights.Rows.Remove(dgvFlights.Rows[0]);
                                }

                                Panel panelflights = new Panel();
                                panelflights.Size = new Size(dgvFlights.Width, 50);
                                panelflights.Location = dgvFlights.Location;

                                Label NotFound = new Label();
                                NotFound.Text = "Не было найдено рейсов по Вашему запросу";
                                NotFound.Location = new Point(0, 0);
                                NotFound.AutoSize = true;

                                dgvFlights.Controls.Add(panelflights);
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
        void bch_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataGridViewRow row = dgvFlights.Rows[selectedRow];
            TicketClass r = new TicketClass();
            r.FlightsId = int.Parse(row.Cells[0].Value.ToString());
            r.FlightNumber = row.Cells[1].Value.ToString();
            r.EconomyPrice = Convert.ToDouble(row.Cells[6].Value.ToString());
            r.BusinessPrice = Convert.ToDouble(row.Cells[7].Value.ToString());

            BookingForm bookingForm = new BookingForm();
            bookingForm.user = user;
            bookingForm.ticket = r;
            bookingForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyFlightsForm flightsForm = new MyFlightsForm(user);
            flightsForm.Show();
        }

        private void dgvFlights_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0)
            {
                this.Hide();
                DataGridViewRow row = dgvFlights.Rows[selectedRow];
                TicketClass r = new TicketClass();
                r.FlightsId = int.Parse(row.Cells[0].Value.ToString());
                r.FlightNumber = row.Cells[1].Value.ToString();
                r.EconomyPrice = Convert.ToDouble(row.Cells[6].Value.ToString());
                r.BusinessPrice = Convert.ToDouble(row.Cells[7].Value.ToString());

                BookingForm bookingForm = new BookingForm();
                bookingForm.user = user;
                bookingForm.ticket = r;
                bookingForm.Show();
            }
            else
            {
                MessageBox.Show("Выберите рейс");
            }
        }
    }
}
