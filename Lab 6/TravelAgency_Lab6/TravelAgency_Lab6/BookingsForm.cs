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
    public partial class BookingsForm : Form
    {
        private ApplicationDB db;
        private StartClientPageForm previous;
        private int id;

        public BookingsForm(StartClientPageForm prev, int id)
        {
            InitializeComponent();
            db = new ApplicationDB();
            this.previous = prev;
            this.id = id;

            bookings_dataGridView.DataSource = db.GetClientBookings(id).Tables[0].DefaultView;

            foreach (var item in db.GetBookingsId(id))
            {
                bookingsComboBox.Items.Add(item);
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            db.DeleteBooking(Convert.ToInt32(bookingsComboBox.SelectedItem.ToString()));
            bookings_dataGridView.DataSource = db.GetClientBookings(id).Tables[0].DefaultView;
            bookingsComboBox.Items.Clear();
            foreach (var item in db.GetBookingsId(id))
            {
                bookingsComboBox.Items.Add(item);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            previous.Show();
            Hide();
        }
    }
}
