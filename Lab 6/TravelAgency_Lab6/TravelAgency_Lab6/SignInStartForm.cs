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
    public partial class SignInStartForm : Form
    {
        private ApplicationDB db;

        public SignInStartForm()
        {
            InitializeComponent();

            FormClosing += CloseApp;
            db = new ApplicationDB();

            loginErrorLabel.Visible = false;
        }

        public void CloseApp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void signUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm newForm = new SignUpForm(this);
            newForm.Show();
            Hide();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            int id = db.GetUserId(emailTextBox.Text, passwordTextBox.Text);

            if (db.UserIsClient(id))
            {
                StartClientPageForm newForm = new StartClientPageForm(db.GetUserName(id), id);
                newForm.Show();
                Hide();
            }
            else
            {
                loginErrorLabel.Visible = true;
            }
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            SignInAdminForm newForm = new SignInAdminForm(this);
            newForm.Show();
            Hide();
        }

        private void managerButton_Click(object sender, EventArgs e)
        {
            SignInManagerForm newForm = new SignInManagerForm(this);
            newForm.Show();
            Hide();
        }
    }
}
