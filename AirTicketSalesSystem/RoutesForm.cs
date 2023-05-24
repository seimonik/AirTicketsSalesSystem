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
    public partial class RoutesForm : Form
    {
        public RoutesForm()
        {
            InitializeComponent();
            UserName.Text = user.login;
        }
        public RoutesForm(LoginUser user)
        {
            InitializeComponent();
            this.user = user;
            UserName.Text = user.login;
        }
        public LoginUser user;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox_departure_point_airport.Text == "" || textBox_arrival_point_airport.Text == "")
            {
                MessageBox.Show("Не все данные введены");
                return;
            }
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectCommand = $"insert into dbo.Routes(DepartureAirportCode, ArrivalAirportСode) values('{textBox_departure_point_airport.Text}', '{textBox_arrival_point_airport.Text}')";
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand(selectCommand, connection))
                {
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Маршрут успешно добавлен");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Нет такого аэропорта");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectQuery = $"SELECT * FROM Routes";
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

                                dataGridView1.Columns[0].HeaderText = "Номер маршрута";
                                dataGridView1.Columns[1].HeaderText = "Аэропорт вылета";
                                dataGridView1.Columns[2].HeaderText = "Аэропорт приземления";
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

        private void buyticket_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regular_Flights_ADMIN fForm = new Regular_Flights_ADMIN(user);
            fForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void RoutesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox_departure_point_airport.Text == "" || textBox_arrival_point_airport.Text == "")
            {
                MessageBox.Show("Не все данные введены");
                return;
            }
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectQuery = $"SELECT * FROM Routes WHERE DepartureAirportCode='{textBox_departure_point_airport.Text}' and ArrivalAirportСode='{textBox_arrival_point_airport.Text}'";
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

                                dataGridView1.Columns[0].HeaderText = "Номер маршрута";
                                dataGridView1.Columns[1].HeaderText = "Аэропорт вылета";
                                dataGridView1.Columns[2].HeaderText = "Аэропорт приземления";
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

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectQuery = $"SELECT * FROM Airports";
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

                                dataGridView1.Columns[0].HeaderText = "Код аэропорта";
                                dataGridView1.Columns[1].HeaderText = "Название";
                                dataGridView1.Columns[2].HeaderText = "Город";
                                dataGridView1.Columns[3].HeaderText = "Часовой пояс";
                                dataGridView1.Columns[4].HeaderText = "Телефон";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Не все данные введены");
                return;
            }
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectCommand = $"insert into dbo.Airports(AirportCode, Name, Location, TimeZone, Telephone) values('{textBox2.Text}', '{textBox1.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}')";
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand(selectCommand, connection))
                {
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Аэропорт успешно добавлен");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Такой аэропорт уже внесен в базу данных");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditorForm flightsForm = new EditorForm(user);
            flightsForm.Show();
        }
    }
}
