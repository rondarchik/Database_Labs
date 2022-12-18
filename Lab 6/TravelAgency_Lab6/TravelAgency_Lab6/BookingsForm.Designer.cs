namespace TravelAgency_Lab6
{
    partial class BookingsForm
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
            this.bookings_dataGridView = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.bookingsComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bookings_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bookings_dataGridView
            // 
            this.bookings_dataGridView.AllowUserToAddRows = false;
            this.bookings_dataGridView.AllowUserToDeleteRows = false;
            this.bookings_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.bookings_dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.bookings_dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bookings_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookings_dataGridView.Enabled = false;
            this.bookings_dataGridView.Location = new System.Drawing.Point(94, 84);
            this.bookings_dataGridView.Name = "bookings_dataGridView";
            this.bookings_dataGridView.ReadOnly = true;
            this.bookings_dataGridView.RowHeadersWidth = 51;
            this.bookings_dataGridView.RowTemplate.Height = 24;
            this.bookings_dataGridView.Size = new System.Drawing.Size(1102, 657);
            this.bookings_dataGridView.TabIndex = 1;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Crimson;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.SystemColors.Control;
            this.backButton.Location = new System.Drawing.Point(738, 782);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(291, 49);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Crimson;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.SystemColors.Control;
            this.delete.Location = new System.Drawing.Point(218, 782);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(291, 49);
            this.delete.TabIndex = 10;
            this.delete.Text = "Delete booking";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // bookingsComboBox
            // 
            this.bookingsComboBox.Location = new System.Drawing.Point(535, 793);
            this.bookingsComboBox.Name = "bookingsComboBox";
            this.bookingsComboBox.Size = new System.Drawing.Size(121, 24);
            this.bookingsComboBox.TabIndex = 11;
            // 
            // BookingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TravelAgency_Lab6.Properties.Resources.travelAgencyBack;
            this.ClientSize = new System.Drawing.Size(1282, 853);
            this.Controls.Add(this.bookingsComboBox);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.bookings_dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.bookings_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView bookings_dataGridView;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ComboBox bookingsComboBox;
    }
}