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
    public partial class ManagerClientsForm : Form
    {
        private ApplicationDB db;
        private StartManagerPageForm previous;
        private int id;

        public ManagerClientsForm(StartManagerPageForm prev, int id)
        {
            InitializeComponent();
            db = new ApplicationDB();
            this.previous = prev;
            this.id = id;

            tours_dataGridView.DataSource = db.GetFilterUsers(id).Tables[0].DefaultView;

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            previous.Show();
            this.Hide();
        }

        private void tours_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
