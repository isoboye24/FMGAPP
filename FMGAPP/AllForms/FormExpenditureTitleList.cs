using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMGAPP.AllForms
{
    public partial class FormExpenditureTitleList : Form
    {
        public FormExpenditureTitleList()
        {
            InitializeComponent();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormExpenditureTitle open = new FormExpenditureTitle();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormExpenditureTitle open = new FormExpenditureTitle();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
