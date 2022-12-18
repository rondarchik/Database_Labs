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
    public partial class SignUpManagerForm : Form
    {
        private ApplicationDB db;
        private SignInManagerForm previous;

        public SignUpManagerForm()
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
        }

        public SignUpManagerForm(SignInManagerForm prev)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
            this.previous = prev;
        }

        public void CloseApp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {

            if (nameTextBox.Text == null || emailTextBox.Text == null || passwordTextBox.Text == null || confirmPassTextBox.Text == null)
            {
                inputValidateLabel.Text = "Проверьте правильность заполнения формы!";
                inputValidateLabel.Visible = true;
            }
            else if (!InputValidate.IsPasswordsMatch(passwordTextBox.Text, confirmPassTextBox.Text))
            {
                inputValidateLabel.Text = "Пароли не совпадают!";
                inputValidateLabel.Visible = true;
            }
            else
            {
                int id = db.AddManager(nameTextBox.Text, emailTextBox.Text, passwordTextBox.Text);

                StartManagerPageForm newForm = new StartManagerPageForm(id);
                newForm.Show();
                Hide();
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
                SignInManagerForm newForm = new SignInManagerForm();
                newForm.Show();
                Hide();
            }
        }
    }
}
