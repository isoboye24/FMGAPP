using FMGAPP.BLL;
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
    public partial class FormViewTotalBalance : Form
    {
        public FormViewTotalBalance()
        {
            InitializeComponent();
        }
        FinancialReportBLL bll = new FinancialReportBLL();
        private void FormViewTotalBalance_Load(object sender, EventArgs e)
        {
            labelHeading.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            labelHeading.Text = "Overall Total Balance Report";
            labelOfferingAmount.Text = "€ " + bll.TotalOffering();
            labelExpenditureAmount.Text = "€ " + bll.TotalExpenditures();
            labelBalanceAmount.Text = "€ " + (bll.TotalOffering() - bll.TotalExpenditures());
        }
    }
}
