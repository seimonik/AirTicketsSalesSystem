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

namespace AirTicketSalesSystem
{
    public partial class PassengersForm : Form
    {
        public PassengersForm(Flight fl)
        {
            InitializeComponent();

            DataBase db = new DataBase();
            DataTable tableRoute = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `routes` WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = fl.id_route;

            adapter.SelectCommand = command;
            adapter.Fill(tableRoute);

            Label city = new Label();
            city.Font = new Font("Arial", 19);
            city.Text = tableRoute.Rows[0][1].ToString() + " " + tableRoute.Rows[0][2].ToString() + " -- " + tableRoute.Rows[0][3].ToString() + " " + tableRoute.Rows[0][4].ToString() + " " + fl.flight_number;

            city.AutoSize = true;
            city.Location = new Point(20, 17);

            panel3.Controls.Add(city);

            DataTable tablePass = new DataTable();

            adapter = new MySqlDataAdapter();

            command = new MySqlCommand("SELECT * FROM `tickets` WHERE `id_flight` = @id_flight", db.getConnection());
            command.Parameters.Add("@id_flight", MySqlDbType.Int32).Value = fl.id;

            adapter.SelectCommand = command;
            adapter.Fill(tablePass);

            for(int i = 0; i < tablePass.Rows.Count; i++)
            {
                Panel readyFlow = new Panel();

                if (i % 2 == 0)
                {
                    readyFlow.BackColor = Color.FromArgb(241, 214, 223);
                }
                else
                {
                    readyFlow.BackColor = Color.FromArgb(214, 241, 232);
                }
                Point a = new Point(0, 7);

                Label name = new Label();
                name.Font = new Font("Arial", 14);
                name.Text = tablePass.Rows[i][1].ToString() + " " + tablePass.Rows[i][2].ToString() + " " + tablePass.Rows[i][3].ToString() + " " + tablePass.Rows[i][5].ToString() + " пол: " + tablePass.Rows[i][4].ToString();
                name.AutoSize = true;
                name.Location = a;

                flowLayoutPanelFlights.Controls.Add(readyFlow);

                Label passport = new Label();

                if (tablePass.Rows[i][7].ToString() == "")
                {
                    passport.Font = new Font("Arial", 14);
                    passport.Text = "Номер свидетельства о рождении: " + tablePass.Rows[i][6].ToString();
                    passport.AutoSize = true;
                    a.Y += name.Height;
                    passport.Location = a;

                    a.Y += passport.Height;
                }
                else
                {
                    passport.Font = new Font("Arial", 14);
                    passport.Text = "Серия и номер паспорта: " + tablePass.Rows[i][6].ToString();
                    passport.AutoSize = true;
                    a.Y += name.Height;
                    passport.Location = a;

                    Label pointpass = new Label();
                    pointpass.Font = new Font("Arial", 14);
                    pointpass.Text = "Выдан: " + tablePass.Rows[i][7].ToString();
                    pointpass.AutoSize = true;
                    pointpass.MaximumSize = new Size(flowLayoutPanelFlights.Width, 500);
                    a.Y += passport.Height;
                    pointpass.Location = a;
                    readyFlow.Controls.Add(pointpass);
                    
                    a.Y += pointpass.Height;
                }

                Label phone = new Label();
                phone.Font = new Font("Arial", 14);
                phone.Text = "Тел.: " + tablePass.Rows[i][10].ToString() + "  e-mail: " + tablePass.Rows[i][9].ToString();
                phone.AutoSize = true;
                phone.Location = a;

                a.Y += phone.Height;
                readyFlow.Size = new Size(flowLayoutPanelFlights.Width, a.Y + 7);

                readyFlow.Controls.Add(name);
                readyFlow.Controls.Add(passport);
                readyFlow.Controls.Add(phone);
            }
        }
    }
}
