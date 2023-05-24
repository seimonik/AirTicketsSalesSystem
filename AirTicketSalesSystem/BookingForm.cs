using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirTicketSalesSystem
{
    public partial class BookingForm : Form
    {
        public BookingForm()
        {
            InitializeComponent();
        }
        public LoginUser user;

        public TicketClass ticket;
        public int IdPass;

        //public ReadyTicket juTicket;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Label numbersvid = new Label();
            TextBox numbersvidetelstvo = new TextBox();
            if (checkBox1.Checked == true)
            {
                passport.Controls.Clear();

                label5.Text = "Номер свидетельства о рождении";
                passport.Controls.Add(label5);
                passport.Controls.Add(numpass);
            }
            else
            {
                passport.Controls.Clear();

                label5.Text = "Серия и номер паспорта";

                passport.Controls.Add(numpass);
                passport.Controls.Add(label5);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "" || textBoxName.Text == "" || textBoxPatronymic.Text == "" ||
                (radioButton1.Checked == false && radioButton2.Checked == false) ||
                numpass.Text == "" || 
                emailbox.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Не все данные введены");
                return;
            }

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                string FullName = textBoxSurname.Text + " " + textBoxName.Text + " " + textBoxPatronymic.Text;
                string Sex = radioButton1.Checked == true ? "муж" : "жен";
                //DateTime birthdate = Birthdate.Value.Date;
                string birthdate = Birthdate.Value.Date.ToString("yyyy-MM-dd");
                string Numberpassport = numpass.Text;
                string email = emailbox.Text;
                string telephone = textBox4.Text;
                string rate = "";
                if (buisnessBox.Checked == true)
                {
                    rate = "бизнес";
                }
                else
                {
                    rate = "эконом";
                }

                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("InsertPass", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@FullName"].Value = FullName;
                    sqlCommand.Parameters.Add(new SqlParameter("@PassportNumber", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@PassportNumber"].Value = Numberpassport;
                    sqlCommand.Parameters.Add(new SqlParameter("@Birthdate", SqlDbType.Date));
                    sqlCommand.Parameters["@Birthdate"].Value = birthdate;
                    sqlCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@Sex"].Value = Sex;
                    sqlCommand.Parameters.Add(new SqlParameter("@Telephone", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@Telephone"].Value = telephone;
                    sqlCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@Email"].Value = email;

                    // Add the output parameter.
                    sqlCommand.Parameters.Add(new SqlParameter("@idPass", SqlDbType.Int));
                    sqlCommand.Parameters["@idPass"].Direction = ParameterDirection.Output;
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        string lol = sqlCommand.Parameters["@idPass"].Value.ToString();

                        IdPass = (int)sqlCommand.Parameters["@idPass"].Value;
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

                double FullPrice = buisnessBox.Checked == true ? ticket.BusinessPrice : ticket.EconomyPrice;
                var addQuery = $"insert into dbo.Tickets(TicketNumber, Rate, FinalPrice, IdPassengers, FlightsId, PurchaseDate, UserId) values('{randomString()}', '{rate}', '{FullPrice}', '{IdPass}', '{ticket.FlightsId}', '{DateTime.Now}', '{user.id}')";

                // записть в dbo.Ticket
                using (SqlCommand sqlCommand = new SqlCommand(addQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Рейс был забронирован");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                        this.Hide();
                        MainForm mainf = new MainForm(user);
                        mainf.user = user;
                        mainf.Show();
                    }
                }
            }


            //DataBase db = new DataBase();

            //MySqlCommand command = new MySqlCommand("INSERT INTO `tickets` (`Surname`, `Name`, `Patronymic`, `Sex`, `Birthdate`, `Numberpassport`, `Pointpassport`, `Numbersvidetelstvo`, `Email`, `Phone`, `id_route`, `id_flight`, `id_user`) VALUES (@Surname, @Name, @Patronymic, @Sex, @Birthdate, @Numberpassport, @Pointpassport, @Numbersvidetelstvo, @Email, @Phone, @id_route, @id_flight, @id_user)", db.getConnection());

            //ReadyTicket rticket = new ReadyTicket();

            //string FullName = textBoxSurname.Text + " " + textBoxName.Text + " " + textBoxPatronymic.Text;
            //string Sex = radioButton1.Checked == true ? "муж" : "жен";
            //string birthdate = Birthdate.Text;
            //if (checkBox1.Checked == false)
            //{
            //    string Numberpassport = numpass.Text;
            //}
            //else
            //{
            //    string Numberpassport = numpass.Text;
            //}
            //string email = emailbox.Text;
            //string telephone = textBox4.Text;

            //db.openConnection();

            //if (command.ExecuteNonQuery() == 1)
            //{
            //    MessageBox.Show("Рейс был забронирован");
            //}

            //db.closeConnection();

            //this.Hide();
            //MainForm mainf = new MainForm(user);
            //mainf.user = user;
            //mainf.Show();
        }

        private void BookingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            MainForm mainf = new MainForm();
            mainf.user = user;
            mainf.Show();
        }

        private string randomString()
        {
            // Создаем генератор случайных чисел.
            Random rand = new Random();

            // Получаем количество слов и букв за слово.
            int num_letters = rand.Next(0, 10);

            // Создаем массив букв, которые мы будем использовать.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            // Сделайте слово.
            string word = "";
            for (int j = 1; j <= num_letters; j++)
            {
                // Выбор случайного числа от 0 до 25
                // для выбора буквы из массива букв.
                int letter_num = rand.Next(0, letters.Length - 1);

                // Добавить письмо.
                word += letters[letter_num];
            }

            return word;
        }
    }
}
