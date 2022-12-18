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
    public partial class TourBookingForm : Form
    {
        private ApplicationDB db;
        private ToursViewForm previous;
        private int id;

        public TourBookingForm(ToursViewForm previous, int id)
        {
            InitializeComponent();

            db = new ApplicationDB();

            this.previous = previous;
            this.id = id;

            foreach (var item in db.GetToursNames())
            {
                toursComboBox.Items.Add(item);
            }

            foreach (var item in db.GetManagersName())
            {
                managersComboBox.Items.Add(item);
            }
        }

        private void toursComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            db.AddBooking(id, toursComboBox.SelectedIndex + 1, db.GetIDByName(managersComboBox.SelectedItem.ToString()));

            previous.Show();
            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            previous.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
