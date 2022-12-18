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
    public partial class ReviewForm : Form
    {
        private ApplicationDB db;
        private StartClientPageForm previous;
        private int id;

        public ReviewForm()
        {
            InitializeComponent();

            db = new ApplicationDB();

            foreach (var item in db.GetToursNames())
            {
                toursComboBox.Items.Add(item);
            }
        }

        public ReviewForm(StartClientPageForm previous, int id)
        {
            InitializeComponent();

            db = new ApplicationDB();

            this.previous = previous;
            this.id = id;

            foreach (var item in db.GetToursNames())
            {
                toursComboBox.Items.Add(item);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            db.AddReview(id, ratingTrackBar.Value, toursComboBox.SelectedIndex + 1, reviewTextBox.Text);

            previous.Show();
            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            previous.Show();
            Hide();
        }
    }
}
