namespace TravelAgency_Lab6
{
    partial class ManagerClientsForm
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
            this.backButton = new System.Windows.Forms.Button();
            this.tours_dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tours_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Crimson;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.SystemColors.Control;
            this.backButton.Location = new System.Drawing.Point(706, 750);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(291, 49);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // tours_dataGridView
            // 
            this.tours_dataGridView.AllowUserToAddRows = false;
            this.tours_dataGridView.AllowUserToDeleteRows = false;
            this.tours_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tours_dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tours_dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tours_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tours_dataGridView.Location = new System.Drawing.Point(90, 54);
            this.tours_dataGridView.Name = "tours_dataGridView";
            this.tours_dataGridView.ReadOnly = true;
            this.tours_dataGridView.RowHeadersWidth = 51;
            this.tours_dataGridView.RowTemplate.Height = 24;
            this.tours_dataGridView.Size = new System.Drawing.Size(1102, 657);
            this.tours_dataGridView.TabIndex = 9;
            this.tours_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tours_dataGridView_CellContentClick);
            // 
            // ManagerClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TravelAgency_Lab6.Properties.Resources.travelAgencyBack;
            this.ClientSize = new System.Drawing.Size(1282, 853);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.tours_dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagerClientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerClientsForm";
            ((System.ComponentModel.ISupportInitialize)(this.tours_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.DataGridView tours_dataGridView;
    }
}