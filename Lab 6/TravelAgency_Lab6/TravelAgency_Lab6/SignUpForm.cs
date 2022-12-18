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
    public partial class SignUpForm : Form
    {
        private ApplicationDB db;
        private SignInStartForm previous;

        public SignUpForm()
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();

            inputValidateLabel.Visible = false;
        }

        public SignUpForm(SignInStartForm prev)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
            this.previous = prev;

            inputValidateLabel.Visible = false;
        }

        public void CloseApp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == null || surnameTextBox.Text == null || patronymicTextBox.Text == null ||
                emailTextBox.Text == null || passwordTextBox.Text == null || confirmPassTextBox.Text == null ||
                phoneTextBox.Text == null || birthdayTextBox.Text == null)
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
                int id = db.AddClient(nameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, surnameTextBox.Text, patronymicTextBox.Text,
                   phoneTextBox.Text, birthdayTextBox.Text);

                StartClientPageForm newForm = new StartClientPageForm(nameTextBox.Text, id);
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
                SignInStartForm newForm = new SignInStartForm();
                newForm.Show();
                Hide();
            }
        }
    }
}
