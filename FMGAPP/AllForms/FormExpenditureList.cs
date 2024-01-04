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
    public partial class FormExpenditureList : Form
    {
        public FormExpenditureList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormExpenditure open = new FormExpenditure();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormExpenditure open = new FormExpenditure();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FormExpenditure open = new FormExpenditure();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnGotoTitle_Click(object sender, EventArgs e)
        {
            FormExpenditureTitleList open = new FormExpenditureTitleList();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }
    }
}
