namespace TravelAgency_Lab6
{
    partial class StartAdminPageForm
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
            this.logOutButton = new System.Windows.Forms.Button();
            this.usersDataGrid = new System.Windows.Forms.DataGridView();
            this.usersComboBox = new System.Windows.Forms.ComboBox();
            this.delete = new System.Windows.Forms.Button();
            this.editUser = new System.Windows.Forms.Button();
            this.addUser = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.Crimson;
            this.logOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.SystemColors.Control;
            this.logOutButton.Location = new System.Drawing.Point(1169, 1);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(111, 40);
            this.logOutButton.TabIndex = 0;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // usersDataGrid
            // 
            this.usersDataGrid.AllowUserToAddRows = false;
            this.usersDataGrid.AllowUserToDeleteRows = false;
            this.usersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.usersDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.usersDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.usersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGrid.Location = new System.Drawing.Point(90, 98);
            this.usersDataGrid.Name = "usersDataGrid";
            this.usersDataGrid.ReadOnly = true;
            this.usersDataGrid.RowHeadersWidth = 51;
            this.usersDataGrid.RowTemplate.Height = 24;
            this.usersDataGrid.Size = new System.Drawing.Size(1102, 657);
            this.usersDataGrid.TabIndex = 1;
            // 
            // usersComboBox
            // 
            this.usersComboBox.Location = new System.Drawing.Point(418, 793);
            this.usersComboBox.Name = "usersComboBox";
            this.usersComboBox.Size = new System.Drawing.Size(121, 24);
            this.usersComboBox.TabIndex = 13;
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Crimson;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.SystemColors.Control;
            this.delete.Location = new System.Drawing.Point(901, 776);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(291, 49);
            this.delete.TabIndex = 12;
            this.delete.Text = "Delete user";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // editUser
            // 
            this.editUser.BackColor = System.Drawing.Color.SkyBlue;
            this.editUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editUser.ForeColor = System.Drawing.SystemColors.Control;
            this.editUser.Location = new System.Drawing.Point(581, 776);
            this.editUser.Name = "editUser";
            this.editUser.Size = new System.Drawing.Size(291, 49);
            this.editUser.TabIndex = 14;
            this.editUser.Text = "Edit user";
            this.editUser.UseVisualStyleBackColor = false;
            this.editUser.Click += new System.EventHandler(this.editUser_Click);
            // 
            // addUser
            // 
            this.addUser.BackColor = System.Drawing.Color.Lime;
            this.addUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUser.ForeColor = System.Drawing.SystemColors.Control;
            this.addUser.Location = new System.Drawing.Point(90, 776);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(291, 49);
            this.addUser.TabIndex = 15;
            this.addUser.Text = "Add user";
            this.addUser.UseVisualStyleBackColor = false;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(90, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(291, 49);
            this.button1.TabIndex = 16;
            this.button1.Text = "Update table";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartAdminPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TravelAgency_Lab6.Properties.Resources.travelAgencyBack;
            this.ClientSize = new System.Drawing.Size(1282, 853);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addUser);
            this.Controls.Add(this.editUser);
            this.Controls.Add(this.usersComboBox);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.usersDataGrid);
            this.Controls.Add(this.logOutButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartAdminPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.DataGridView usersDataGrid;
        private System.Windows.Forms.ComboBox usersComboBox;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button editUser;
        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.Button button1;
    }
}