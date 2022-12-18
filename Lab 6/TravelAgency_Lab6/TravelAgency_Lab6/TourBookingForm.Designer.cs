namespace TravelAgency_Lab6
{
    partial class TourBookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TourBookingForm));
            this.toursComboBox = new System.Windows.Forms.ComboBox();
            this.toursLabel = new System.Windows.Forms.Label();
            this.managersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toursComboBox
            // 
            resources.ApplyResources(this.toursComboBox, "toursComboBox");
            this.toursComboBox.Name = "toursComboBox";
            this.toursComboBox.SelectedIndexChanged += new System.EventHandler(this.toursComboBox_SelectedIndexChanged);
            // 
            // toursLabel
            // 
            resources.ApplyResources(this.toursLabel, "toursLabel");
            this.toursLabel.Name = "toursLabel";
            // 
            // managersComboBox
            // 
            resources.ApplyResources(this.managersComboBox, "managersComboBox");
            this.managersComboBox.Name = "managersComboBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LimeGreen;
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Crimson;
            resources.ApplyResources(this.backButton, "backButton");
            this.backButton.ForeColor = System.Drawing.SystemColors.Control;
            this.backButton.Name = "backButton";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // TourBookingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.managersComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toursComboBox);
            this.Controls.Add(this.toursLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TourBookingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox toursComboBox;
        private System.Windows.Forms.Label toursLabel;
        private System.Windows.Forms.ComboBox managersComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button backButton;
    }
}