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
    public partial class StartClientPageForm : Form
    {
        private ApplicationDB db;
        private SignInStartForm previous;
        private string userName;
        private int id;

        public StartClientPageForm()
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();

            inputValidateLabel.ForeColor = Color.Red;
            inputValidateLabel.Visible = false;

            
        }

        public StartClientPageForm(string name)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();

            this.userName = name;
            inputValidateLabel.ForeColor = Color.Red;
            inputValidateLabel.Visible = false;

        }

        public StartClientPageForm(int id)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();

            this.id = id;
            inputValidateLabel.ForeColor = Color.Red;
            inputValidateLabel.Visible = false;

            nameTextBox.Text = db.GetClientInfo(id)[0];
            emailTextBox.Text = db.GetClientInfo(id)[1];
            passwordTextBox.Text = db.GetClientInfo(id)[2];
            confirmPassTextBox.Text = db.GetClientInfo(id)[2];
            surnameTextBox.Text = db.GetClientInfo(id)[3];
            patronymicTextBox.Text = db.GetClientInfo(id)[4];
            phoneTextBox.Text = db.GetClientInfo(id)[5];
            birthdayTextBox.Text = db.GetClientInfo(id)[6];
        }

        public StartClientPageForm(string name, int id)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();

            this.userName = name;
            this.id = id;
            inputValidateLabel.ForeColor = Color.Red;
            inputValidateLabel.Visible = false;

            nameTextBox.Text = db.GetClientInfo(id)[0];
            emailTextBox.Text = db.GetClientInfo(id)[1];
            passwordTextBox.Text = db.GetClientInfo(id)[2];
            confirmPassTextBox.Text = db.GetClientInfo(id)[2];
            surnameTextBox.Text = db.GetClientInfo(id)[3];
            patronymicTextBox.Text = db.GetClientInfo(id)[4];
            phoneTextBox.Text = db.GetClientInfo(id)[5];
            birthdayTextBox.Text = db.GetClientInfo(id)[6];
        }

        public StartClientPageForm(SignInStartForm prev)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
            this.previous = prev;
            inputValidateLabel.ForeColor = Color.Red;
            inputValidateLabel.Visible = false;

        }

        public void CloseApp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void logOutButton_Click(object sender, EventArgs e)
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == null || surnameTextBox.Text == null || patronymicTextBox.Text == null ||
                    emailTextBox.Text == null || passwordTextBox.Text == null || confirmPassTextBox.Text == null ||
                    phoneTextBox.Text == null || birthdayTextBox.Text == null)
            {
                inputValidateLabel.Text = "Проверьте правильность заполнения формы!";
                inputValidateLabel.ForeColor = Color.Red;
                inputValidateLabel.Visible = true;
            }
            else if (!InputValidate.IsPasswordsMatch(passwordTextBox.Text, confirmPassTextBox.Text))
            {
                inputValidateLabel.Text = "Пароли не совпадают!";
                inputValidateLabel.ForeColor = Color.Red;
                inputValidateLabel.Visible = true;
            }
            else
            {
                db.UpdateClientInfo(id, nameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, surnameTextBox.Text, patronymicTextBox.Text,
                   phoneTextBox.Text, birthdayTextBox.Text);

                inputValidateLabel.Text = "Изменения успешно сохранены!";
                inputValidateLabel.ForeColor = Color.Black;
                inputValidateLabel.Visible = true;
            }
        }

        private void toursButton_Click(object sender, EventArgs e)
        {
            ToursViewForm newForm = new ToursViewForm(this, id);
            newForm.Show();
            Hide();
        }

        private void addCart_Click(object sender, EventArgs e)
        {
            db.AddCreditCard(id, creditCardTextBox.Text);

            MessageBox.Show("Successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            ReviewForm newForm = new ReviewForm(this, id);
            newForm.Show();
            Hide();
        }

        private void bookingsButton_Click(object sender, EventArgs e)
        {
            BookingsForm newForm = new BookingsForm(this, id);
            newForm.Show();
            Hide();
        }

        private void birthdayLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
