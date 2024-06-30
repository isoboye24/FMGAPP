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
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FMGAPP.AllForms
{
    public partial class FormMonthlyReports : Form
    {
        public FormMonthlyReports()
        {
            InitializeComponent();
        }

        private void btnTotalBalance_Click(object sender, EventArgs e)
        {
            FormViewFinancialTotalBalance open = new FormViewFinancialTotalBalance();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }
        FinancialReportBLL bll = new FinancialReportBLL();
        FinancialReportDTO dto = new FinancialReportDTO();
        FinancialReportDetailDTO detail = new FinancialReportDetailDTO();
        FinancialReportBLL offlineBLL = new FinancialReportBLL();
        FinancialReportDTO offlineDTO = new FinancialReportDTO();
        FinancialReportDetailDTO offlineDetail = new FinancialReportDetailDTO();
        FinancialReportBLL onlineBLL = new FinancialReportBLL();
        FinancialReportDTO onlineDTO = new FinancialReportDTO();
        FinancialReportDetailDTO onlineDetail = new FinancialReportDetailDTO();

        string queryOffline = "SELECT MONTH.monthName, SUM(OFFERING.offerings) \r\n" +
            "FROM OFFERING\r\n" +
            "JOIN MONTH ON OFFERING.monthID = MONTH.monthID\r\n" +
            "WHERE OFFERING.year = 2024 AND OFFERING.offeringStatusID = 5 AND OFFERING.isDeleted = 0\r\n" +
            "GROUP BY MONTH.monthName, OFFERING.monthID\r\n" +
            "ORDER BY OFFERING.monthID ASC";

        string queryOnline = "SELECT MONTH.monthName, SUM(OFFERING.offerings) \r\n" +
           "FROM OFFERING\r\n" +
           "JOIN MONTH ON OFFERING.monthID = MONTH.monthID\r\n" +
           "WHERE OFFERING.year = 2024 AND OFFERING.offeringStatusID = 6 AND OFFERING.isDeleted = 0\r\n" +
           "GROUP BY MONTH.monthName, OFFERING.monthID\r\n" +
           "ORDER BY OFFERING.monthID ASC";

        private void FrontendSizes()
        {
            cmbMonthTotal.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbMonthOffline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbMonthOnline.Font = new Font("Segoe UI", 18, FontStyle.Regular);

            txtTotalExpenditureTotal.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtTotalOfferings.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtYearTotal.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtOfflineOfferings.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtYearOffline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtOnlineOfferings.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtYearOnline.Font = new Font("Segoe UI", 18, FontStyle.Regular);

            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            rbEqualExpenditureTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbEqualOfferingTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessExpenditureTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessOfferingTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreExpenditureTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreOfferingTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbEqualOfferingOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessOfferingOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreOfferingOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbEqualOfferingOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessOfferingOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreOfferingOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnClearTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearchTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnViewTotal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnTotalMonthlyToExcel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClearOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearchOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClearOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearchOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
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
            grid.Columns[8].HeaderText = "Month";
            grid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[9].HeaderText = "Year";
            grid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[10].Visible = false;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
        }

        private void FormFinancialReportList_Load(object sender, EventArgs e)
        {
            FrontendSizes();

            #region
            dto = bll.Select();
            cmbMonthTotal.DataSource = dto.Months;
            General.ComboBoxProps(cmbMonthTotal, "MonthName", "MonthID");

            dataGridViewTotal.DataSource = dto.FinancialReports;
            dataGridViewTotal.Columns[0].Visible = false;
            dataGridViewTotal.Columns[1].Visible = false;
            dataGridViewTotal.Columns[2].HeaderText = "Total Offerings";
            dataGridViewTotal.Columns[3].Visible = false;
            dataGridViewTotal.Columns[4].HeaderText = "Total Expenditure";
            dataGridViewTotal.Columns[5].Visible = false;
            dataGridViewTotal.Columns[6].HeaderText = "Total Balance";
            dataGridViewTotal.Columns[7].Visible = false;
            dataGridViewTotal.Columns[8].HeaderText = "Month";
            dataGridViewTotal.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTotal.Columns[9].HeaderText = "Year";
            dataGridViewTotal.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTotal.Columns[10].HeaderText = "";
            dataGridViewTotal.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn column in dataGridViewTotal.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }

            offlineDTO = offlineBLL.Select(5);
            cmbMonthOffline.DataSource = dto.Months;
            General.ComboBoxProps(cmbMonthOffline, "MonthName", "MonthID");

            dataGridViewOffline.DataSource = offlineDTO.FinancialReports;
            DataGrid(dataGridViewOffline);

            onlineDTO = onlineBLL.Select(6);
            cmbMonthOnline.DataSource = dto.Months;
            General.ComboBoxProps(cmbMonthOnline, "MonthName", "MonthID");

            dataGridViewOnline.DataSource = onlineDTO.FinancialReports;
            DataGrid(dataGridViewOnline);
            #endregion

            General.CreateChart(chartMonthlyOfferingOffline, queryOffline, SeriesChartType.Column, "Month", "");
            General.CreateChart(chartMonthlyOfferingOnline, queryOnline, SeriesChartType.Column, "Month", "");
        }

        private void FillDataGrid()
        {
            bll = new FinancialReportBLL();
            dto = bll.Select();
            dataGridViewTotal.DataSource = dto.FinancialReports;

            offlineDTO = offlineBLL.Select(5);
            dataGridViewOffline.DataSource = offlineDTO.FinancialReports;
            DataGrid(dataGridViewOffline);

            onlineDTO = onlineBLL.Select(6);
            dataGridViewOnline.DataSource = onlineDTO.FinancialReports;
            DataGrid(dataGridViewOnline);
        }
        private void ClearFilters()
        {
            cmbMonthTotal.SelectedIndex = -1;
            cmbMonthOffline.SelectedIndex = -1;
            cmbMonthOnline.SelectedIndex = -1;

            txtTotalExpenditureTotal.Clear();
            txtTotalOfferings.Clear();
            txtYearTotal.Clear();
            txtOfflineOfferings.Clear();
            txtYearOffline.Clear();
            txtOnlineOfferings.Clear();
            txtYearOnline.Clear();

            rbLessExpenditureTotal.Checked = false;
            rbEqualExpenditureTotal.Checked = false;
            rbMoreExpenditureTotal.Checked = false;
            rbLessOfferingTotal.Checked = false;
            rbEqualOfferingTotal.Checked = false;
            rbMoreOfferingTotal.Checked = false;

            rbLessOfferingOffline.Checked = false;
            rbEqualOfferingOffline.Checked = false;
            rbMoreOfferingOffline.Checked = false;
            rbLessOfferingOnline.Checked = false;
            rbEqualOfferingOnline.Checked = false;
            rbMoreOfferingOnline.Checked = false;

            FillDataGrid();
        }

        private void dataGridViewTotal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.Value != null)
            {
                decimal cellValue;
                if (decimal.TryParse(e.Value.ToString(), out cellValue))
                {
                    if (cellValue < 750)
                    {
                        DataGridViewRow row = dataGridViewTotal.Rows[e.RowIndex];
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.BackColor = Color.PaleVioletRed;
                            cell.Style.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        DataGridViewRow row = dataGridViewTotal.Rows[e.RowIndex];
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.BackColor = dataGridViewTotal.DefaultCellStyle.BackColor;
                            cell.Style.ForeColor = dataGridViewTotal.DefaultCellStyle.ForeColor;

                        }
                    }
                }
            }
        }

        private void btnClearTotal_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void btnSearchTotal_Click(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = dto.FinancialReports;
            if (cmbMonthTotal.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonthTotal.SelectedValue)).ToList();
            }
            if (cmbMonthTotal.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonthTotal.SelectedValue)).ToList();
            }
            if (txtTotalOfferings.Text.Trim() != "")
            {
                if (rbLessOfferingTotal.Checked)
                {
                    list = list.Where(x => x.TotalOfferings < Convert.ToDecimal(txtTotalOfferings.Text)).ToList();
                }
                else if (rbEqualOfferingTotal.Checked)
                {
                    list = list.Where(x => x.TotalOfferings == Convert.ToDecimal(txtTotalOfferings.Text)).ToList();
                }
                else if (rbMoreOfferingTotal.Checked)
                {
                    list = list.Where(x => x.TotalOfferings > Convert.ToDecimal(txtTotalOfferings.Text)).ToList();
                }
                else
                {
                    MessageBox.Show("Please select a criterion from the offerings group.");
                }
            }
            if (txtTotalExpenditureTotal.Text.Trim() != "")
            {
                if (rbLessExpenditureTotal.Checked)
                {
                    list = list.Where(x => x.TotalExpenditures < Convert.ToDecimal(txtTotalExpenditureTotal.Text)).ToList();
                }
                else if (rbEqualExpenditureTotal.Checked)
                {
                    list = list.Where(x => x.TotalExpenditures == Convert.ToDecimal(txtTotalExpenditureTotal.Text)).ToList();
                }
                else if (rbMoreExpenditureTotal.Checked)
                {
                    list = list.Where(x => x.TotalExpenditures > Convert.ToDecimal(txtTotalExpenditureTotal.Text)).ToList();
                }
                else
                {
                    MessageBox.Show("Please select a criterion from the Expenditure group.");
                }
            }
            dataGridViewTotal.DataSource = list;
        }

        private void DataRowEntered(DataGridView newGrid, FinancialReportDetailDTO details, DataGridViewCellEventArgs e)
        {
            details.FinancialReportID = Convert.ToInt32(newGrid.Rows[e.RowIndex].Cells[0].Value);
            details.TotalOfferings = Convert.ToDecimal(newGrid.Rows[e.RowIndex].Cells[1].Value);
            details.TotalOfferingsWithCurrency = newGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            details.TotalExpenditures = Convert.ToDecimal(newGrid.Rows[e.RowIndex].Cells[3].Value);
            details.TotalExpendituresWithCurrency = newGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
            details.TotalBalance = Convert.ToDecimal(newGrid.Rows[e.RowIndex].Cells[5].Value);
            details.TotalBalanceWithCurrency = newGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
            details.MonthID = Convert.ToInt32(newGrid.Rows[e.RowIndex].Cells[7].Value);
            details.MonthName = newGrid.Rows[e.RowIndex].Cells[8].Value.ToString();
            details.Year = Convert.ToInt32(newGrid.Rows[e.RowIndex].Cells[9].Value);
            details.percentage = Convert.ToDecimal(newGrid.Rows[e.RowIndex].Cells[10].Value);
        }
        private void dataGridViewTotal_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new FinancialReportDetailDTO();
            DataRowEntered(dataGridViewTotal, detail, e);
        }

        private void txtYearTotal_TextChanged(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = dto.FinancialReports;
            list = list.Where(x => x.Year.ToString().Contains(txtYearTotal.Text.Trim())).ToList();
            dataGridViewTotal.DataSource = list;
        }

        private void txtYearTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtTotalOfferings_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViewTotal_Click(object sender, EventArgs e)
        {
            if (detail.FinancialReportID == 0)
            {
                MessageBox.Show("Please choose a monthly report from the table.");
            }
            else
            {
                FormViewMonthlyReport open = new FormViewMonthlyReport();
                open.detail = detail;
                open.isMonthlyReport = true;
                open.status = "Total";
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
            }
        }

        private void btnSearchOffline_Click(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = offlineDTO.FinancialReports;
            if (cmbMonthOffline.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonthOffline.SelectedValue)).ToList();
            }
            if (cmbMonthOffline.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonthOffline.SelectedValue)).ToList();
            }
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
                    MessageBox.Show("Please select a criterion from the offering table.");
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

        private void dataGridViewOffline_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            offlineDetail = new FinancialReportDetailDTO();
            DataRowEntered(dataGridViewOffline, offlineDetail, e);
        }

        private void btnClearOffline_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void btnClearOnline_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void btnSearchOnline_Click(object sender, EventArgs e)
        {
            List<FinancialReportDetailDTO> list = onlineDTO.FinancialReports;
            if (cmbMonthOnline.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonthOnline.SelectedValue)).ToList();
            }
            if (cmbMonthOnline.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonthOnline.SelectedValue)).ToList();
            }
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
                    MessageBox.Show("Please select a criterion from the offering table.");
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

        private void dataGridViewOnline_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            onlineDetail = new FinancialReportDetailDTO();
            DataRowEntered(dataGridViewOnline, onlineDetail, e);
        }

        private void btnTotalMonthlyToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.ExcelExport(dataGridViewTotal, label15.Text);
        }
    }
}
