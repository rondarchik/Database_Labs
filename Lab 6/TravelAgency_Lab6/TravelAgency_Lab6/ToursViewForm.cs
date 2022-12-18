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
    public partial class ToursViewForm : Form
    {
        private ApplicationDB db;
        private StartClientPageForm previous;
        private int id;

        public ToursViewForm(StartClientPageForm previous, int id)
        {
            InitializeComponent();
            db = new ApplicationDB();
            this.previous = previous;
            this.id = id;

            tours_dataGridView.DataSource = db.GetToursInfo().Tables[0].DefaultView;
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
                StartClientPageForm newForm = new StartClientPageForm(id);
                newForm.Show();
                Hide();
            }
        }

        private void bookingTour_Click(object sender, EventArgs e)
        {
            TourBookingForm newForm = new TourBookingForm(this, id);
            newForm.Show();
            Hide();
        }
    }
}
