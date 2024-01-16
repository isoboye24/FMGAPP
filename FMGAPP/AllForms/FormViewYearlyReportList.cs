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
    public partial class FormViewYearlyReportList : Form
    {
        public FormViewYearlyReportList()
        {
            InitializeComponent();
        }
        FinancialReportDetailDTO detail = new FinancialReportDetailDTO();
        FinancialReportBLL bll = new FinancialReportBLL();
        FinancialReportDTO dto = new FinancialReportDTO();
        private void btnView_Click(object sender, EventArgs e)
        {
            if (detail.FinancialReportID == 0)
            {
                MessageBox.Show("Please choose a yearly report from the table.");
            }
            else
            {
                FormViewMonthlyReport open = new FormViewMonthlyReport();
                open.detail = detail;
                open.isYearlyReport = true;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
            }
        }

        private void FormViewYearlyReportList_Load(object sender, EventArgs e)
        {
            dto = bll.SelectYearlyReport();

            dataGridView1.DataSource = dto.FinancialReports;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Total Offerings";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Total Expenditure";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Total Balance";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "Year";
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = dto.FinancialReports;            
            if (txtTotalOfferings.Text.Trim() != "")
            {
                if (rbLessOffering.Checked)
                {
                    list = list.Where(x => x.TotalOfferings < Convert.ToDecimal(txtTotalOfferings.Text)).ToList();
                }
                else if (rbEqualOffering.Checked)
                {
                    list = list.Where(x => x.TotalOfferings == Convert.ToDecimal(txtTotalOfferings.Text)).ToList();
                }
                else if (rbMoreOffering.Checked)
                {
                    list = list.Where(x => x.TotalOfferings > Convert.ToDecimal(txtTotalOfferings.Text)).ToList();
                }
                else
                {
                    MessageBox.Show("Please select a criterion from the offerings group.");
                }
            }
            if (txtTotalExpenditure.Text.Trim() != "")
            {
                if (rbLessExpenditure.Checked)
                {
                    list = list.Where(x => x.TotalExpenditures < Convert.ToDecimal(txtTotalExpenditure.Text)).ToList();
                }
                else if (rbEqualExpenditure.Checked)
                {
                    list = list.Where(x => x.TotalExpenditures == Convert.ToDecimal(txtTotalExpenditure.Text)).ToList();
                }
                else if (rbMoreExpenditure.Checked)
                {
                    list = list.Where(x => x.TotalExpenditures > Convert.ToDecimal(txtTotalExpenditure.Text)).ToList();
                }
                else
                {
                    MessageBox.Show("Please select a criterion from the Expenditure group.");
                }
            }
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new FinancialReportDetailDTO();
            detail.FinancialReportID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.TotalOfferings = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.TotalOfferingsWithCurrency = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.TotalExpenditures = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detail.TotalExpendituresWithCurrency = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            detail.TotalBalance = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.TotalBalanceWithCurrency = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            detail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            List <FinancialReportDetailDTO> list = dto.FinancialReports;
            list = list.Where(x => x.Year.ToString().Contains(txtYear.Text.Trim())).ToList();
            dataGridView1.DataSource = list;
        }
        private void FillDataGrid()
        {
            bll = new FinancialReportBLL();
            dto = bll.SelectYearlyReport();
            dataGridView1.DataSource = dto.FinancialReports;
        }
        private void ClearFilters()
        {
            txtTotalExpenditure.Clear();
            rbLessExpenditure.Checked = false;
            rbEqualExpenditure.Checked = false;
            rbMoreExpenditure.Checked = false;
            txtTotalOfferings.Clear();
            rbLessOffering.Checked = false;
            rbEqualOffering.Checked = false;
            rbMoreOffering.Checked = false;
            txtYear.Clear();
            FillDataGrid();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }
    }
}
