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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            //userNameField.Text = "Введите имя";
            //userNameField.ForeColor = Color.Gray;
            //userNameField.Font = new Font(userNameField.Text, 14);

            //userSurnameField.Text = "Введите фамилию";
            //userSurnameField.ForeColor = Color.Gray;
            //userSurnameField.Font = new Font(userSurnameField.Text, 14);

            LoginField.Text = "Введите логин";
            LoginField.ForeColor = Color.Gray;
            LoginField.Font = new Font(LoginField.Text, 14);

            PasswordField.Text = "Введите пароль";
            PasswordField.ForeColor = Color.Gray;
            PasswordField.Font = new Font(PasswordField.Text, 14);
            PasswordField.UseSystemPasswordChar = false;
        }

        //private void userNameField_Enter(object sender, EventArgs e)
        //{
        //    if (userNameField.Text == "Введите имя")
        //    {
        //        userNameField.Text = "";
        //        userNameField.ForeColor = Color.Black;
        //    }
        //}

        //private void userNameField_Leave(object sender, EventArgs e)
        //{
        //    if (userNameField.Text == "")
        //    {
        //        userNameField.Text = "Введите имя";
        //        userNameField.ForeColor = Color.Gray;
        //    }
        //}

        //private void userSurnameField_Enter(object sender, EventArgs e)
        //{
        //    if (userSurnameField.Text == "Введите фамилию")
        //    {
        //        userSurnameField.Text = "";
        //        userSurnameField.ForeColor = Color.Black;
        //    }
        //}

        //private void userSurnameField_Leave(object sender, EventArgs e)
        //{
        //    if (userSurnameField.Text == "")
        //    {
        //        userSurnameField.Text = "Введите фамилию";
        //        userSurnameField.ForeColor = Color.Gray;
        //    }
        //}

        private void LoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Введите логин")
            {
                LoginField.Text = "";
                LoginField.ForeColor = Color.Black;
            }
        }

        private void LoginField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "Введите логин";
                LoginField.ForeColor = Color.Gray;
            }
        }

        private void PasswordField_Enter(object sender, EventArgs e)
        {
            if (PasswordField.Text == "Введите пароль")
            {
                PasswordField.Text = "";
                PasswordField.ForeColor = Color.Black;
                PasswordField.UseSystemPasswordChar = true;
            }
        }

        private void PasswordField_Leave(object sender, EventArgs e)
        {
            if (PasswordField.Text == "")
            {
                PasswordField.Text = "Введите пароль";
                PasswordField.ForeColor = Color.Gray;
                PasswordField.UseSystemPasswordChar = false;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            //if(userNameField.Text=="Введите имя" || userSurnameField.Text == "Введите фамилию" || LoginField.Text == "Введите логин" || PasswordField.Text == "Введите пароль")
            //{
            //    MessageBox.Show("Не все данные ввведены");
            //    return;
            //}
            if (LoginField.Text == "Введите логин" || PasswordField.Text == "Введите пароль")
            {
                MessageBox.Show("Не все данные ввведены");
                return;
            }

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                var selectQuery = $"insert into dbo.Users(Login, Password, type) values('{LoginField.Text}', '{PasswordField.Text}', '0')";
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Аккаунт был создан");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует, введите другой");
                    }
                }
            }

            
        }

        public bool isUserExists()
        {
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует, введите другой");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
