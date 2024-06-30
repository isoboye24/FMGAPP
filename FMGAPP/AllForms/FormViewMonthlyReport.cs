using FMGAPP.BLL;
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
    public partial class FormViewMonthlyReport : Form
    {
        public FormViewMonthlyReport()
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
        public FinancialReportDetailDTO detail = new FinancialReportDetailDTO();
        public bool isMonthlyReport = false;
        public bool isYearlyReport = false;
        public string status;
        private void FormViewMonthlyReport_Load(object sender, EventArgs e)
        {
            if (isMonthlyReport)
            {
                labelHeading.Text = status + " " + detail.MonthName + " " + detail.Year + " Balance Report";
                labelOfferingAmount.Text = detail.TotalOfferingsWithCurrency;
                labelExpenditureAmount.Text = detail.TotalExpendituresWithCurrency;
                labelBalanceAmount.Text = detail.TotalBalanceWithCurrency;
            }
            else if (isYearlyReport)
            {
                labelHeading.Text = detail.Year + " Balance Report";
                labelOfferingAmount.Text = detail.TotalOfferingsWithCurrency;
                labelExpenditureAmount.Text = detail.TotalExpendituresWithCurrency;
                labelBalanceAmount.Text = detail.TotalBalanceWithCurrency;
            }            
        }        
    }
}
