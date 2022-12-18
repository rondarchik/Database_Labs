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
    public partial class SignInAdminForm : Form
    {
        private ApplicationDB db;
        private SignInStartForm previous;

        public SignInAdminForm()
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();

            loginErrorLabel.Visible = false;

        }

        public SignInAdminForm(SignInStartForm prev)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
            this.previous = prev;

            loginErrorLabel.Visible = false;

        }

        public void CloseApp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            int id = db.GetUserId(emailTextBox.Text, passwordTextBox.Text);

            if (db.UserIsAdmin(id))
            {
                StartAdminPageForm newForm = new StartAdminPageForm(this, id);
                newForm.Show();
                Hide();
            }
            else
            {
                loginErrorLabel.Visible = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (previous != null)
            {
                previous.Show();
                Hide();
            }
            else
            {
                SignInStartForm newForm = new SignInStartForm();
                newForm.Show();
                Hide();
            }
        }
    }
}
