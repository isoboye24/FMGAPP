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
    public partial class FormFinancialReportList : Form
    {
        public FormFinancialReportList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormFinancialReport open = new FormFinancialReport();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormFinancialReport open = new FormFinancialReport();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FormFinancialReport open = new FormFinancialReport();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }

        private void btnTotalBalance_Click(object sender, EventArgs e)
        {
            FormViewFinancialTotalBalance open = new FormViewFinancialTotalBalance();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }
    }
}
