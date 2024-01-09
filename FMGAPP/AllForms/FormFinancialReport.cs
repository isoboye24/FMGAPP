using FMGAPP.BLL;
using FMGAPP.DAL;
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
    public partial class FormFinancialReport : Form
    {
        public FormFinancialReport()
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
        FinancialReportBLL bll = new FinancialReportBLL();
        FinancialReportDTO dto = new FinancialReportDTO();
        public FinancialReportDetailDTO detail = new FinancialReportDetailDTO();
        public bool isEdit = false;
        private void FormFinancialReport_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbMonth.DataSource = dto.Months;
            General.ComboBoxProps(cmbMonth, "MonthName", "MonthID");
            if (isEdit)
            {
                txtSummary.Text = detail.Summary;
                txtYear.Text = detail.Year.ToString();
                cmbMonth.SelectedValue = detail.MonthID;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a month");
            }
            else if(txtYear.Text.Trim() == "")
            {
                MessageBox.Show("Year is empty");
            }
            else
            {
                if (!isEdit)
                {
                    List<OFFERING> offeringList = bll.CheckOfferings(Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(txtYear.Text));
                    List<EXPENDITURE> expenditureList = bll.CheckExpenditure(Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(txtYear.Text));
                    List<OFFERING> offeringAmount = bll.CheckOfferingsAmount(Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(txtYear.Text));
                    List<EXPENDITURE> expenditureAmount = bll.CheckExpenditureAmount(Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(txtYear.Text));
                    if (offeringList.Count > 0 && expenditureList.Count > 0)
                    {
                        MessageBox.Show("There is financial report for " + General.ConventIntToMonth(cmbMonth.SelectedIndex + 1).ToString() + " " + txtYear.Text);
                    }
                    else if (offeringAmount.Count == 0 && expenditureAmount.Count == 0)
                    {
                        MessageBox.Show("There is no offerings and no expenditure for " + General.ConventIntToMonth(cmbMonth.SelectedIndex + 1).ToString() +" " + txtYear.Text);
                    }
                    else
                    {
                        FinancialReportDetailDTO financialReport = new FinancialReportDetailDTO();
                        financialReport.TotalOfferings = bll.TotalOffering(Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(txtYear.Text));
                        financialReport.TotalExpenditures = bll.TotalExpenditures(Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(txtYear.Text));
                        financialReport.Summary = txtSummary.Text.Trim();
                        financialReport.MonthID = Convert.ToInt32(cmbMonth.SelectedValue);
                        financialReport.Year = Convert.ToInt32(txtYear.Text);
                        if (bll.Insert(financialReport))
                        {
                            MessageBox.Show("Financial report was added");
                            txtYear.Clear();
                            txtSummary.Clear();
                            cmbMonth.SelectedIndex = -1;
                        }
                    }                    
                }
                else
                {
                    if (detail.Summary == txtSummary.Text.Trim() && detail.Year == Convert.ToInt32(txtYear.Text.Trim()) && detail.MonthID == Convert.ToInt32(cmbMonth.SelectedValue))
                    {
                        MessageBox.Show("There is no change.");
                    }
                    else
                    {
                        detail.Summary = txtSummary.Text.Trim();
                        detail.Year = Convert.ToInt32(txtYear.Text.Trim());
                        detail.MonthID = Convert.ToInt32(cmbMonth.SelectedValue);
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Financial report was updated.");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
