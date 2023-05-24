
namespace AirTicketSalesSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvFlights = new System.Windows.Forms.DataGridView();
            this.paneldata = new System.Windows.Forms.Panel();
            this.price = new System.Windows.Forms.Label();
            this.arrival = new System.Windows.Forms.Label();
            this.departure = new System.Windows.Forms.Label();
            this.where = new System.Windows.Forms.Label();
            this.from = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.departurecity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cityofarrival = new System.Windows.Forms.ComboBox();
            this.date_and_time_departure = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buyticket = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).BeginInit();
            this.paneldata.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(228)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dgvFlights);
            this.panel1.Controls.Add(this.paneldata);
            this.panel1.Controls.Add(this.panelSearch);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1608, 846);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 776);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 44);
            this.button1.TabIndex = 16;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvFlights
            // 
            this.dgvFlights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFlights.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(238)))), ((int)(((byte)(194)))));
            this.dgvFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlights.Location = new System.Drawing.Point(21, 325);
            this.dgvFlights.Name = "dgvFlights";
            this.dgvFlights.ReadOnly = true;
            this.dgvFlights.RowHeadersVisible = false;
            this.dgvFlights.RowHeadersWidth = 51;
            this.dgvFlights.RowTemplate.Height = 24;
            this.dgvFlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlights.Size = new System.Drawing.Size(1541, 420);
            this.dgvFlights.TabIndex = 15;
            this.dgvFlights.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlights_CellClick);
            // 
            // paneldata
            // 
            this.paneldata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(197)))), ((int)(((byte)(137)))));
            this.paneldata.Controls.Add(this.price);
            this.paneldata.Controls.Add(this.arrival);
            this.paneldata.Controls.Add(this.departure);
            this.paneldata.Controls.Add(this.where);
            this.paneldata.Controls.Add(this.from);
            this.paneldata.Location = new System.Drawing.Point(21, 268);
            this.paneldata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paneldata.Name = "paneldata";
            this.paneldata.Size = new System.Drawing.Size(1541, 52);
            this.paneldata.TabIndex = 14;
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.price.Location = new System.Drawing.Point(1253, 14);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(52, 20);
            this.price.TabIndex = 16;
            this.price.Text = "Цена";
            // 
            // arrival
            // 
            this.arrival.AutoSize = true;
            this.arrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arrival.Location = new System.Drawing.Point(939, 14);
            this.arrival.Name = "arrival";
            this.arrival.Size = new System.Drawing.Size(72, 20);
            this.arrival.TabIndex = 15;
            this.arrival.Text = "Прилет";
            // 
            // departure
            // 
            this.departure.AutoSize = true;
            this.departure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departure.Location = new System.Drawing.Point(629, 14);
            this.departure.Name = "departure";
            this.departure.Size = new System.Drawing.Size(63, 20);
            this.departure.TabIndex = 14;
            this.departure.Text = "Вылет";
            // 
            // where
            // 
            this.where.AutoSize = true;
            this.where.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.where.Location = new System.Drawing.Point(303, 14);
            this.where.Name = "where";
            this.where.Size = new System.Drawing.Size(50, 20);
            this.where.TabIndex = 13;
            this.where.Text = "Куда";
            // 
            // from
            // 
            this.from.AutoSize = true;
            this.from.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.from.Location = new System.Drawing.Point(3, 14);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(71, 20);
            this.from.TabIndex = 12;
            this.from.Text = "Откуда";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(197)))), ((int)(((byte)(137)))));
            this.panelSearch.Controls.Add(this.buttonSearch);
            this.panelSearch.Controls.Add(this.label1);
            this.panelSearch.Controls.Add(this.label2);
            this.panelSearch.Controls.Add(this.departurecity);
            this.panelSearch.Controls.Add(this.label3);
            this.panelSearch.Controls.Add(this.cityofarrival);
            this.panelSearch.Controls.Add(this.date_and_time_departure);
            this.panelSearch.Location = new System.Drawing.Point(21, 148);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1541, 116);
            this.panelSearch.TabIndex = 12;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.Location = new System.Drawing.Point(1257, 43);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(140, 37);
            this.buttonSearch.TabIndex = 11;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Город вылета";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(331, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Город прибытия";
            // 
            // departurecity
            // 
            this.departurecity.FormattingEnabled = true;
            this.departurecity.Location = new System.Drawing.Point(7, 38);
            this.departurecity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.departurecity.Name = "departurecity";
            this.departurecity.Size = new System.Drawing.Size(293, 44);
            this.departurecity.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(680, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Туда";
            // 
            // cityofarrival
            // 
            this.cityofarrival.FormattingEnabled = true;
            this.cityofarrival.Location = new System.Drawing.Point(333, 38);
            this.cityofarrival.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cityofarrival.Name = "cityofarrival";
            this.cityofarrival.Size = new System.Drawing.Size(293, 44);
            this.cityofarrival.TabIndex = 6;
            // 
            // date_and_time_departure
            // 
            this.date_and_time_departure.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_and_time_departure.Location = new System.Drawing.Point(684, 38);
            this.date_and_time_departure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.date_and_time_departure.Name = "date_and_time_departure";
            this.date_and_time_departure.Size = new System.Drawing.Size(200, 41);
            this.date_and_time_departure.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(238)))), ((int)(((byte)(194)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1608, 127);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(228)))), ((int)(((byte)(172)))));
            this.panel3.Controls.Add(this.UserName);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.buyticket);
            this.panel3.Location = new System.Drawing.Point(21, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1541, 84);
            this.panel3.TabIndex = 1;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserName.Location = new System.Drawing.Point(876, 26);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(200, 32);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "Имя Фамилия";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AirTicketSalesSystem.Properties.Resources.exit;
            this.pictureBox1.Location = new System.Drawing.Point(1470, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(228)))), ((int)(((byte)(172)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(328, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = "Мои рейсы";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // buyticket
            // 
            this.buyticket.AutoSize = true;
            this.buyticket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(173)))), ((int)(((byte)(215)))));
            this.buyticket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.buyticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyticket.Location = new System.Drawing.Point(34, 29);
            this.buyticket.Name = "buyticket";
            this.buyticket.Size = new System.Drawing.Size(173, 31);
            this.buyticket.TabIndex = 0;
            this.buyticket.Text = "Купить билет";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1608, 846);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).EndInit();
            this.paneldata.ResumeLayout(false);
            this.paneldata.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label buyticket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox departurecity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date_and_time_departure;
        private System.Windows.Forms.ComboBox cityofarrival;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Panel paneldata;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label arrival;
        private System.Windows.Forms.Label departure;
        private System.Windows.Forms.Label where;
        private System.Windows.Forms.Label from;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvFlights;
        private System.Windows.Forms.Button button1;
    }
}