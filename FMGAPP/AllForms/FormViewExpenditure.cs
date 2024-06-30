using FMGAPP.DAL.DTO;
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
    public partial class FormViewExpenditure : Form
    {
        public FormViewExpenditure()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public ExpenditureDetailDTO detail = new ExpenditureDetailDTO();
        private void FormViewExpenditure_Load(object sender, EventArgs e)
        {
            labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            txtSummary.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtTitle.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtAmountSpent.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            txtAmountSpent.Text = detail.AmountSpent.ToString();
            txtSummary.Text = detail.Summary;
             labelTitle.Text = "Expenditure made on " + detail.Day + "/" + detail.MonthID + "/" + detail.Year;
            txtTitle.Text = detail.ExpenditureTitle;
        }
    }
}
