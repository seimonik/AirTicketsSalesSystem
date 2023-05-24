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
    public partial class EditorForm : Form
    {
        private int selectedRow = -1;
        public EditorForm()
        {
            InitializeComponent();
            UserName.Text = user.login;
        }
        public EditorForm(LoginUser user)
        {
            InitializeComponent();
            this.user = user;
            UserName.Text = user.login;
        }
        public LoginUser user;
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectQuery = $"SELECT * FROM Flights";
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

                                dataGridView1.Columns[0].HeaderText = "Id рейса";
                                dataGridView1.Columns[1].HeaderText = "Дата вылета";
                                dataGridView1.Columns[2].HeaderText = "Время вылета";
                                dataGridView1.Columns[3].HeaderText = "Дата прлета";
                                dataGridView1.Columns[4].HeaderText = "Время прилета";
                                dataGridView1.Columns[5].HeaderText = "Цена эконома";
                                dataGridView1.Columns[6].HeaderText = "Цена бизнеса";
                                dataGridView1.Columns[7].HeaderText = "Забронировано (э)";
                                dataGridView1.Columns[8].HeaderText = "Забронировано (б)";
                                dataGridView1.Columns[9].HeaderText = "Номер рейса";
                                dataGridView1.Columns[10].HeaderText = "Id самолета";
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
        void bPass_Click(object sender, EventArgs e)
        {
            Flight r = (Flight)((Control)sender).Tag;
            PassengersForm passengers = new PassengersForm(r);
            passengers.Show();
        }
        void bDel_Click(object sender, EventArgs e)
        {
            Flight r = (Flight)((Control)sender).Tag;
            DataBase db = new DataBase();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `flight` WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = r.id;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Рейс был удален");
            }

            db.closeConnection();
            buttonSearch_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown_id_route.Text == "" || textBox_flight_number.Text == "" || textBox_price.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Не все данные введены");
                return;
            }

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectCommand = $"insert into dbo.Flights(FlightNumber, DepartureDate, DepartureTime, ArrivalDate, ArrivalTime, EconomyPrice, BusinessPrice, ReservedEconomy, ReservedBusiness, IdAircraft) values('{textBox_flight_number.Text}', '{dateTimePickerDeparture.Value}', '{TimePickerDeparture.Value}', '{datePickerArrival.Value}', '{TimePickerArrival.Value}', '{textBox_price.Text}', '{textBox1.Text}', '0', '0', '{numericUpDown_id_route.Value}')";
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand(selectCommand, connection))
                {
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Рейс успешно добавлен");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regular_Flights_ADMIN flightsForm = new Regular_Flights_ADMIN(user);
            flightsForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectQuery = $"SELECT * FROM Aircraft";
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

                                dataGridView1.Columns[0].HeaderText = "Id самолета";
                                dataGridView1.Columns[1].HeaderText = "Название";
                                dataGridView1.Columns[2].HeaderText = "Скорость";
                                dataGridView1.Columns[3].HeaderText = "Максимальная высота";
                                dataGridView1.Columns[4].HeaderText = "Макс дальность";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (selectedRow >= 0)
        //    {
        //        DataGridViewRow row = dataGridView1.Rows[selectedRow];

        //    }
        //    else
        //    {
        //        MessageBox.Show("Выберите рейс");
        //    }
        //}
    }
}
