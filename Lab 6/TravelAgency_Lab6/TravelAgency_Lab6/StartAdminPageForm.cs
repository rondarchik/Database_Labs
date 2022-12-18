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
    public partial class StartAdminPageForm : Form
    {
        private ApplicationDB db;
        private SignInAdminForm previous;
        private int id;

        public StartAdminPageForm()
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
        }

        public StartAdminPageForm(SignInAdminForm prev, int id)
        {
            InitializeComponent();
            FormClosing += CloseApp;
            db = new ApplicationDB();
            this.previous = prev;
            this.id = id;

            usersDataGrid.DataSource = db.GetUsers().Tables[0].DefaultView;

            usersComboBox.Items.Clear();
            foreach (var item in db.GetUsersId(id))
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
                SignInAdminForm newForm = new SignInAdminForm();
                newForm.Show();
                Hide();
            }
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            AddEditUserForm newForm = new AddEditUserForm(this, "add");
            newForm.Show();
            Hide();
        }

        private void editUser_Click(object sender, EventArgs e)
        {
            AddEditUserForm newForm = new AddEditUserForm(this, Convert.ToInt32(usersComboBox.SelectedItem), "edit");
            newForm.Show();
            Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            db.DeleteUser(Convert.ToInt32(usersComboBox.SelectedItem));
            usersDataGrid.DataSource = db.GetUsers().Tables[0].DefaultView;
            usersComboBox.Items.Clear();
            foreach (var item in db.GetUsersId(id))
            {
                usersComboBox.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usersDataGrid.DataSource = db.GetUsers().Tables[0].DefaultView;

            usersComboBox.Items.Clear();
            foreach (var item in db.GetUsersId(id))
            {
                usersComboBox.Items.Add(item);
            }
        }
    }
}
