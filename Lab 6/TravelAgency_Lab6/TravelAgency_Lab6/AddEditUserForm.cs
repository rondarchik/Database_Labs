using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency_Lab6
{
    public partial class AddEditUserForm : Form
    {
        private ApplicationDB db;
        private StartAdminPageForm previous;
        private string action;
        private int id;

        public AddEditUserForm(StartAdminPageForm previous, string action)
        {
            InitializeComponent();
            db= new ApplicationDB();
            this.previous= previous;
            this.action= action;

            if (action == "add")
            {
                signUpButton.Text = "Add user";
                signUpButton.BackColor = Color.Lime;

                nameTextBox.Text = "";
                emailTextBox.Text = "";
                passwordTextBox.Text = "";
            }
            else if (action == "edit")
            {
                signUpButton.Text = "Edit user";
                signUpButton.BackColor = Color.SkyBlue;

                nameTextBox.Text = db.GetUserInfo(id)[0];
                emailTextBox.Text = db.GetUserInfo(id)[1];
                passwordTextBox.Text = db.GetUserInfo(id)[2];
            }
        }

        public AddEditUserForm(StartAdminPageForm previous, int id, string action)
        {
            InitializeComponent();
            db = new ApplicationDB();
            this.previous = previous;
            this.action = action;
            this.id = id;

            if (action == "add")
            {
                signUpButton.Text = "Add user";
                signUpButton.BackColor = Color.Lime;

                nameTextBox.Text = "";
                emailTextBox.Text = "";
                passwordTextBox.Text = "";
            }
            else if (action == "edit")
            {
                signUpButton.Text = "Edit user";
                signUpButton.BackColor = Color.SkyBlue;

                nameTextBox.Text = db.GetUserInfo(id)[0];
                emailTextBox.Text = db.GetUserInfo(id)[1];
                passwordTextBox.Text = db.GetUserInfo(id)[2];
            }
        }

        private void inputValidateLabel_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            previous.Show();
            this.Hide();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (action == "add")
            {
                db.AddUser(nameTextBox.Text, emailTextBox.Text, passwordTextBox.Text);
            }
            else if (action == "edit")
            {
                db.EditUser(id, nameTextBox.Text, emailTextBox.Text, passwordTextBox.Text);

            }

            previous.Show();
            this.Hide();
        }
    }
}
