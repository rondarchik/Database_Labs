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
    public partial class AddEditTourForm : Form
    {
        private ApplicationDB db;
        private StartManagerPageForm previous;
        private string action;
        private int id;


        public AddEditTourForm(StartManagerPageForm previous, string action)
        {
            InitializeComponent();
            db = new ApplicationDB();
            this.previous = previous;
            this.action = action;

            if (action == "add")
            {
                signUpButton.Text = "Add tour";
                signUpButton.BackColor = Color.Lime;

                nameTextBox.Text = "";
                emailTextBox.Text = "";
                passwordTextBox.Text = "";
            }
            else if (action == "edit")
            {
                signUpButton.Text = "Edit tour";
                signUpButton.BackColor = Color.SkyBlue;

                nameTextBox.Text = db.GetToursInfo(id)[0];
                emailTextBox.Text = db.GetToursInfo(id)[1];
                passwordTextBox.Text = db.GetToursInfo(id)[2];
            }

            foreach (var item in db.GetHotels())
            {
                hotelComboBox.Items.Add(item);
            }

            foreach (var item in db.GetTypes())
            {
                typeComboBox.Items.Add(item);
            }
        }

        public AddEditTourForm(StartManagerPageForm previous, int id, string action)
        {
            InitializeComponent();
            db = new ApplicationDB();
            this.previous = previous;
            this.action = action;
            this.id = id;

            if (action == "add")
            {
                signUpButton.Text = "Add tour";
                signUpButton.BackColor = Color.Lime;

                nameTextBox.Text = "";
                emailTextBox.Text = "";
                passwordTextBox.Text = "";
            }
            else if (action == "edit")
            {
                signUpButton.Text = "Edit tour";
                signUpButton.BackColor = Color.SkyBlue;

                nameTextBox.Text = db.GetToursInfo(id)[0];
                emailTextBox.Text = db.GetToursInfo(id)[1];
                passwordTextBox.Text = db.GetToursInfo(id)[2];
            }
            foreach (var item in db.GetHotels())
            {
                hotelComboBox.Items.Add(item);
            }

            foreach (var item in db.GetTypes())
            {
                typeComboBox.Items.Add(item);
            }
        }

        private void inputValidateLabel_Click(object sender, EventArgs e)
        {

        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (action == "add")
            {
                db.AddTour(nameTextBox.Text, emailTextBox.Text, passwordTextBox.Text,
                    db.GetTypeIdByName(typeComboBox.SelectedItem.ToString()), db.GetHotelIdByName(hotelComboBox.SelectedItem.ToString()));
            }
            else if (action == "edit")
            {

                db.EditTour(id,
                    nameTextBox.Text, emailTextBox.Text, passwordTextBox.Text,
                    db.GetTypeIdByName(typeComboBox.SelectedItem.ToString()), db.GetHotelIdByName(hotelComboBox.SelectedItem.ToString()));
            }

            previous.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            previous.Show();
            this.Hide();
        }
    }
}
