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
    public partial class StartManagerPageForm : Form
    {
        private ApplicationDB db;
        private SignInManagerForm previous;
        private int id;

        public StartManagerPageForm()
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
        }

        public StartManagerPageForm(int id)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
            this.id = id;
        }

        public StartManagerPageForm(SignInManagerForm prev, int id)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
            this.previous = prev;
            this.id = id;


            usersDataGrid.DataSource = db.GetToursInfo().Tables[0].DefaultView;

            usersComboBox.Items.Clear();
            foreach (var item in db.GetToursNames())
            {
                usersComboBox.Items.Add(item);
            }
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
                SignInManagerForm newForm = new SignInManagerForm();
                newForm.Show();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usersDataGrid.DataSource = db.GetToursInfo().Tables[0].DefaultView;

            usersComboBox.Items.Clear();
            foreach (var item in db.GetToursNames())
            {
                usersComboBox.Items.Add(item);
            }
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            AddEditTourForm newForm = new AddEditTourForm(this, "add");
            newForm.Show();
            Hide();
        }

        private void editUser_Click(object sender, EventArgs e)
        {
            AddEditTourForm newForm = new AddEditTourForm(this, db.GetTourIdByName(usersComboBox.SelectedItem.ToString()), "edit");
            newForm.Show();
            Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            db.DeleteTour(db.GetTourIdByName(usersComboBox.SelectedItem.ToString()));
            usersDataGrid.DataSource = db.GetToursInfo().Tables[0].DefaultView;
            usersComboBox.Items.Clear();
            foreach (var item in db.GetToursNames())
            {
                usersComboBox.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerClientsForm newForm = new ManagerClientsForm(this, id);
            newForm.Show();
            Hide();
        }
    }
}
