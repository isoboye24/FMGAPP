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
using System.Windows.Forms.DataVisualization.Charting;

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
        FinancialReportBLL offlineBLL = new FinancialReportBLL();
        FinancialReportDTO offlineDTO = new FinancialReportDTO();
        FinancialReportDetailDTO offlineDetail = new FinancialReportDetailDTO();
        FinancialReportBLL onlineBLL = new FinancialReportBLL();
        FinancialReportDTO onlineDTO = new FinancialReportDTO();
        FinancialReportDetailDTO onlineDetail = new FinancialReportDetailDTO();

        string queryOffline = "SELECT OFFERING.year, SUM(OFFERING.offerings) \r\n" +
            "FROM OFFERING\r\n" +
            "WHERE OFFERING.offeringStatusID = 5 AND OFFERING.isDeleted = 0\r\n" +
            "GROUP BY OFFERING.year\r\n" +
            "ORDER BY OFFERING.year ASC";

        string queryOnline = "SELECT OFFERING.year, SUM(OFFERING.offerings) \r\n" +
            "FROM OFFERING\r\n" +
            "WHERE OFFERING.offeringStatusID = 6 AND OFFERING.isDeleted = 0\r\n" +
            "GROUP BY OFFERING.year\r\n" +
            "ORDER BY OFFERING.year ASC";

        private void FrontendSizes()
        {
            txtTotalExpenditure.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtTotalOfferings.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtYear.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtOfflineOfferings.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtYearOffline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtOnlineOfferings.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtYearOnline.Font = new Font("Segoe UI", 18, FontStyle.Regular);

            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label5.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label6.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label8.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label9.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label10.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label11.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            rbEqualExpenditure.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessExpenditure.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreExpenditure.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbEqualOffering.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessOffering.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreOffering.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbEqualOfferingOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessOfferingOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreOfferingOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbEqualOfferingOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessOfferingOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreOfferingOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnClear.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearch.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnViewTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClearOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearchOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClearOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearchOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnTotalYearlyToExcel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }

        private void DataGrid(DataGridView grid)
        {
            grid.Columns[0].Visible = false;
            grid.Columns[1].Visible = false;
            grid.Columns[2].HeaderText = "Total Offerings";
            grid.Columns[3].Visible = false;
            grid.Columns[4].Visible = false;
            grid.Columns[5].Visible = false;
            grid.Columns[6].Visible = false;
            grid.Columns[7].Visible = false;
            grid.Columns[8].Visible = false;
            grid.Columns[9].HeaderText = "Year";
            grid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[10].Visible = false;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
            General.CreateChart(chartYearlyOfferingOffline, queryOffline, SeriesChartType.Column, "Year", "");
            General.CreateChart(chartYearlyOfferingOnline, queryOnline, SeriesChartType.Column, "Year", "");
        }
        private void FillDataGrid()
        {
            bll = new FinancialReportBLL();
            dto = bll.SelectYearlyReport();
            dataGridViewTotal.DataSource = dto.FinancialReports;

            offlineBLL = new FinancialReportBLL();
            offlineDTO = offlineBLL.SelectYearlyReport();
            dataGridViewOffline.DataSource = offlineDTO.FinancialReports;

            onlineBLL = new FinancialReportBLL();
            onlineDTO = onlineBLL.SelectYearlyReport();
            dataGridViewOnline.DataSource = onlineDTO.FinancialReports;
        }
        private void ClearFilters()
        {
            txtTotalExpenditure.Clear();
            txtTotalOfferings.Clear();
            txtYear.Clear();
            txtOfflineOfferings.Clear();
            txtYearOffline.Clear();
            txtOnlineOfferings.Clear();
            txtYearOnline.Clear();

            rbLessExpenditure.Checked = false;
            rbEqualExpenditure.Checked = false;
            rbMoreExpenditure.Checked = false;
            rbLessOffering.Checked = false;
            rbEqualOffering.Checked = false;
            rbMoreOffering.Checked = false;
            rbLessOfferingOffline.Checked = false;
            rbEqualOfferingOffline.Checked = false;
            rbMoreOfferingOffline.Checked = false;
            rbLessOfferingOnline.Checked = false;
            rbEqualOfferingOnline.Checked = false;
            rbMoreOfferingOnline.Checked = false;

            FillDataGrid();
        }
        private void FormViewYearlyReportList_Load(object sender, EventArgs e)
        {
            FrontendSizes();
            dto = bll.SelectYearlyReport();

            dataGridViewTotal.DataSource = dto.FinancialReports;
            dataGridViewTotal.Columns[0].Visible = false;
            dataGridViewTotal.Columns[1].Visible = false;
            dataGridViewTotal.Columns[2].HeaderText = "Total Offerings";
            dataGridViewTotal.Columns[3].Visible = false;
            dataGridViewTotal.Columns[4].HeaderText = "Total Expenditure";
            dataGridViewTotal.Columns[5].Visible = false;
            dataGridViewTotal.Columns[6].HeaderText = "Total Balance";
            dataGridViewTotal.Columns[7].Visible = false;
            dataGridViewTotal.Columns[8].Visible = false;
            dataGridViewTotal.Columns[9].HeaderText = "Year";
            dataGridViewTotal.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTotal.Columns[10].Visible = false;
            foreach (DataGridViewColumn column in dataGridViewTotal.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }

            offlineDTO = offlineBLL.SelectYearlyReport(5);
            dataGridViewOffline.DataSource = offlineDTO.FinancialReports;
            DataGrid(dataGridViewOffline);

            onlineDTO = onlineBLL.SelectYearlyReport(6);
            dataGridViewOnline.DataSource = onlineDTO.FinancialReports;
            DataGrid(dataGridViewOnline);
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
            dataGridViewTotal.DataSource = list;
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            List <FinancialReportDetailDTO> list = dto.FinancialReports;
            list = list.Where(x => x.Year.ToString().Contains(txtYear.Text.Trim())).ToList();
            dataGridViewTotal.DataSource = list;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void dataGridViewTotal_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new FinancialReportDetailDTO();
            detail.FinancialReportID = Convert.ToInt32(dataGridViewTotal.Rows[e.RowIndex].Cells[0].Value);
            detail.TotalOfferings = Convert.ToDecimal(dataGridViewTotal.Rows[e.RowIndex].Cells[1].Value);
            detail.TotalOfferingsWithCurrency = dataGridViewTotal.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.TotalExpenditures = Convert.ToDecimal(dataGridViewTotal.Rows[e.RowIndex].Cells[3].Value);
            detail.TotalExpendituresWithCurrency = dataGridViewTotal.Rows[e.RowIndex].Cells[4].Value.ToString();
            detail.TotalBalance = Convert.ToDecimal(dataGridViewTotal.Rows[e.RowIndex].Cells[5].Value);
            detail.TotalBalanceWithCurrency = dataGridViewTotal.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.MonthID = Convert.ToInt32(dataGridViewTotal.Rows[e.RowIndex].Cells[7].Value);
            detail.MonthName = dataGridViewTotal.Rows[e.RowIndex].Cells[8].Value.ToString();
            detail.Year = Convert.ToInt32(dataGridViewTotal.Rows[e.RowIndex].Cells[9].Value);
        }

        private void btnViewTotal_Click(object sender, EventArgs e)
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

        private void btnSearchOffline_Click(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = offlineDTO.FinancialReports;
            if (txtOfflineOfferings.Text.Trim() != "")
            {
                if (rbLessOfferingOffline.Checked)
                {
                    list = list.Where(x => x.TotalOfferings < Convert.ToDecimal(txtOfflineOfferings.Text)).ToList();
                }
                else if (rbEqualOfferingOffline.Checked)
                {
                    list = list.Where(x => x.TotalOfferings == Convert.ToDecimal(txtOfflineOfferings.Text)).ToList();
                }
                else if (rbMoreOfferingOffline.Checked)
                {
                    list = list.Where(x => x.TotalOfferings > Convert.ToDecimal(txtOfflineOfferings.Text)).ToList();
                }
                else
                {
                    MessageBox.Show("Please select a criterion from the offerings group.");
                }
            }
            dataGridViewOffline.DataSource = list;
        }

        private void txtYearOffline_TextChanged(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = offlineDTO.FinancialReports;
            list = list.Where(x => x.Year.ToString().Contains(txtYearOffline.Text.Trim())).ToList();
            dataGridViewOffline.DataSource = list;
        }

        private void txtYearOffline_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClearOffline_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void dataGridViewOnline_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnSearchOnline_Click(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = onlineDTO.FinancialReports;
            if (txtOnlineOfferings.Text.Trim() != "")
            {
                if (rbLessOfferingOnline.Checked)
                {
                    list = list.Where(x => x.TotalOfferings < Convert.ToDecimal(txtOnlineOfferings.Text)).ToList();
                }
                else if (rbEqualOfferingOnline.Checked)
                {
                    list = list.Where(x => x.TotalOfferings == Convert.ToDecimal(txtOnlineOfferings.Text)).ToList();
                }
                else if (rbMoreOfferingOnline.Checked)
                {
                    list = list.Where(x => x.TotalOfferings > Convert.ToDecimal(txtOnlineOfferings.Text)).ToList();
                }
                else
                {
                    MessageBox.Show("Please select a criterion from the offerings group.");
                }
            }
            dataGridViewOnline.DataSource = list;
        }

        private void txtYearOnline_TextChanged(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = onlineDTO.FinancialReports;
            list = list.Where(x => x.Year.ToString().Contains(txtYearOnline.Text.Trim())).ToList();
            dataGridViewOnline.DataSource = list;
        }

        private void txtYearOnline_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClearOnline_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void btnTotalYearlyToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.ExcelExport(dataGridViewTotal, label13.Text);
        }
    }
}
