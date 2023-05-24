using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AirTicketSalesSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.PasswordField.AutoSize = false;
            this.PasswordField.Size = new Size(this.PasswordField.Size.Width, 42);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Create the connection.
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("Entrance", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@LoginUser", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@LoginUser"].Value = LoginField.Text;
                    sqlCommand.Parameters.Add(new SqlParameter("@PassUser", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@PassUser"].Value = PasswordField.Text;

                    // Add the output parameter.
                    sqlCommand.Parameters.Add(new SqlParameter("@IdPass", SqlDbType.Int));
                    sqlCommand.Parameters["@IdPass"].Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add(new SqlParameter("@login", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@login"].Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@pass"].Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.Int));
                    sqlCommand.Parameters["@type"].Direction = ParameterDirection.Output;
                    try
                    {
                        connection.Open();

                        // Run the stored procedure.
                        sqlCommand.ExecuteNonQuery();
                        int IdPass = (int)sqlCommand.Parameters["@IdPass"].Value;
                        string log = sqlCommand.Parameters["@login"].Value.ToString();
                        string pass = sqlCommand.Parameters["@pass"].Value.ToString();
                        int type = (int)sqlCommand.Parameters["@type"].Value;
                        LoginUser user = new LoginUser(IdPass, log, pass, type);
                        if (user.type == 1)
                        {
                            this.Hide();
                            Regular_Flights_ADMIN editorForm = new Regular_Flights_ADMIN(user);
                            editorForm.user = user;
                            editorForm.Show();
                        }
                        else
                        {
                            this.Hide();
                            MainForm mainForm = new MainForm(user);
                            mainForm.user = user;
                            mainForm.Show();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
