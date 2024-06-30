using FMGAPP.BLL;
using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FMGAPP.AllForms
{
    public partial class FormOfferingList : Form
    {
        public FormOfferingList()
        {
            InitializeComponent();
        }

        OfferingBLL offlineBLL = new OfferingBLL();
        OfferingsDTO offlineDTO = new OfferingsDTO();
        OfferingsDetailDTO offlineDetail = new OfferingsDetailDTO();
        
        OfferingBLL onlineBLL = new OfferingBLL();
        OfferingsDTO onlineDTO = new OfferingsDTO();
        OfferingsDetailDTO onlineDetail = new OfferingsDetailDTO();

        private void FrontendSizes()
        {
            txtDayOnline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtAmountOnline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtYearOnline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtAmountOffline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtDayOffline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtYearOffline.Font = new Font("Segoe UI", 18, FontStyle.Regular);

            cmbMonthOnline.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbMonthOffline.Font = new Font("Segoe UI", 18, FontStyle.Regular);

            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label5.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label6.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label7.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label8.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label9.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label10.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            rbEqualOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbEqualOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbLessOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rbMoreOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnClearOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearchOnline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnViewOnlineOff.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAddOnlineOff.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDeleteOnlineOff.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEditOnlineOff.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnClearOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearchOffline.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnViewOfflineOff.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDeleteOfflineOff.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAddOfflineOff.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEditOfflineOff.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            offlineOfferings.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            onlineOfferings.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
        private void FormOfferingList_Load(object sender, EventArgs e)
        {
            FrontendSizes();
            
            offlineDTO = offlineBLL.Select(5);
            cmbMonthOffline.DataSource = offlineDTO.Months;
            General.ComboBoxProps(cmbMonthOffline, "MonthName", "MonthID");

            dataGridViewOfflineOfferings.DataSource = offlineDTO.Offerings;
            dataGridViewOfflineOfferings.Columns[0].Visible = false;
            dataGridViewOfflineOfferings.Columns[1].Visible = false;
            dataGridViewOfflineOfferings.Columns[2].HeaderText = "Offline Offerings";
            dataGridViewOfflineOfferings.Columns[3].Visible = false;
            dataGridViewOfflineOfferings.Columns[4].HeaderText = "Day";
            dataGridViewOfflineOfferings.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOfflineOfferings.Columns[5].Visible = false;
            dataGridViewOfflineOfferings.Columns[6].HeaderText = "Month";
            dataGridViewOfflineOfferings.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOfflineOfferings.Columns[7].HeaderText = "Year";
            dataGridViewOfflineOfferings.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOfflineOfferings.Columns[8].Visible = false;
            dataGridViewOfflineOfferings.Columns[9].Visible = false;
            dataGridViewOfflineOfferings.Columns[10].Visible = false;
            dataGridViewOfflineOfferings.Columns[11].Visible = false;
            dataGridViewOfflineOfferings.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn column in dataGridViewOfflineOfferings.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }

            onlineDTO = onlineBLL.Select(6);
            cmbMonthOnline.DataSource = onlineDTO.Months;
            General.ComboBoxProps(cmbMonthOnline, "MonthName", "MonthID");

            dataGridViewOnline.DataSource = onlineDTO.Offerings;
            dataGridViewOnline.Columns[0].Visible = false;
            dataGridViewOnline.Columns[1].Visible = false;
            dataGridViewOnline.Columns[2].HeaderText = "Online Offerings";
            dataGridViewOnline.Columns[3].Visible = false;
            dataGridViewOnline.Columns[4].HeaderText = "Day";
            dataGridViewOnline.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOnline.Columns[5].Visible = false;
            dataGridViewOnline.Columns[6].HeaderText = "Month";
            dataGridViewOnline.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOnline.Columns[7].HeaderText = "Year";
            dataGridViewOnline.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOnline.Columns[8].Visible = false;
            dataGridViewOnline.Columns[9].Visible = false;
            dataGridViewOnline.Columns[10].Visible = false;
            dataGridViewOnline.Columns[11].Visible = false;
            foreach (DataGridViewColumn column in dataGridViewOnline.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
        }
        private void ClearFilters()
        {
            cmbMonthOnline.SelectedIndex = -1;
            txtAmountOnline.Clear();
            txtDayOnline.Clear();
            txtYearOnline.Clear();
            rbEqualOnline.Checked = false;
            rbLessOnline.Checked = false;
            rbMoreOnline.Checked = false;

            cmbMonthOffline.SelectedIndex = -1;
            txtAmountOffline.Clear();
            txtDayOffline.Clear();
            txtYearOffline.Clear();
            rbEqualOffline.Checked = false;
            rbLessOffline.Checked = false;
            rbMoreOffline.Checked = false;
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            offlineDTO = offlineBLL.Select(5);
            dataGridViewOfflineOfferings.DataSource = offlineDTO.Offerings;

            onlineDTO = onlineBLL.Select(6);
            dataGridViewOnline.DataSource = onlineDTO.Offerings;

        }
        
       
        private void btnAddOnlineOff_Click(object sender, EventArgs e)
        {
            FormOffering open = new FormOffering();
            this.Hide();
            open.labelTitleString = "Add Online Offering";
            open.offeringStatusString = "Online";
            open.ShowDialog();
            this.Visible = true;
            ClearFilters();
        }

        private void btnEditOnlineOff_Click(object sender, EventArgs e)
        {
            if (onlineDetail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                FormOffering open = new FormOffering();
                open.detail = onlineDetail;
                open.isEdit = true;
                open.labelTitleString = "Edit Online Offering";
                open.offeringStatusString = "Online";
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                ClearFilters();
            }
        }

        private void btnViewOnlineOff_Click(object sender, EventArgs e)
        {
            if (onlineDetail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                FormOffering open = new FormOffering();
                open.detail = onlineDetail;
                open.offeringStatusString = "Online";
                open.isView = true;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                ClearFilters();
            }
        }

        private void btnDeleteOnlineOff_Click(object sender, EventArgs e)
        {
            if (onlineDetail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (onlineBLL.Delete(onlineDetail))
                    {
                        MessageBox.Show("Offering was deleted");
                        ClearFilters();
                    }
                }
            }
        }

        private void btnAddOfflineOff_Click_1(object sender, EventArgs e)
        {
            FormOffering open = new FormOffering();
            this.Hide();
            open.labelTitleString = "Add Offline Offering";
            open.offeringStatusString = "Offline";
            open.ShowDialog();
            this.Visible = true;
            ClearFilters();
        }

        private void btnEditOfflineOff_Click_1(object sender, EventArgs e)
        {
            if (offlineDetail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                FormOffering open = new FormOffering();
                open.detail = offlineDetail;
                open.isEdit = true;
                this.Hide();
                open.labelTitleString = "Edit Offline Offering";
                open.offeringStatusString = "Offline";
                open.ShowDialog();
                this.Visible = true;
                ClearFilters();
            }
        }

        private void btnViewOfflineOff_Click_1(object sender, EventArgs e)
        {
            if (offlineDetail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                FormOffering open = new FormOffering();
                open.detail = offlineDetail;
                open.isView = true;
                open.offeringStatusString = "Offline";
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                ClearFilters();
            }
        }

        private void btnDeleteOfflineOff_Click_1(object sender, EventArgs e)
        {
            if (offlineDetail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (offlineBLL.Delete(offlineDetail))
                    {
                        MessageBox.Show("Offering was deleted");
                        ClearFilters();
                    }
                }
            }
        }

        private void dataGridViewOfflineOfferings_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            offlineDetail = new OfferingsDetailDTO();
            offlineDetail.OfferingID = Convert.ToInt32(dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[0].Value);
            offlineDetail.Offering = Convert.ToDecimal(dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[1].Value);
            offlineDetail.OfferingWithCurrency = dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[2].Value.ToString();
            offlineDetail.Summary = dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[3].Value.ToString();
            offlineDetail.Day = Convert.ToInt32(dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[4].Value);
            offlineDetail.MonthID = Convert.ToInt32(dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[5].Value);
            offlineDetail.MonthName = dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[6].Value.ToString();
            offlineDetail.Year = Convert.ToInt32(dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[7].Value);
            offlineDetail.OfferingDate = Convert.ToDateTime(dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[8].Value);
            offlineDetail.OfferingStatusID = Convert.ToInt32(dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[9].Value);
            offlineDetail.OfferingStatus = dataGridViewOfflineOfferings.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void dataGridViewOnline_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            onlineDetail = new OfferingsDetailDTO();
            onlineDetail.OfferingID = Convert.ToInt32(dataGridViewOnline.Rows[e.RowIndex].Cells[0].Value);
            onlineDetail.Offering = Convert.ToDecimal(dataGridViewOnline.Rows[e.RowIndex].Cells[1].Value);
            onlineDetail.OfferingWithCurrency = dataGridViewOnline.Rows[e.RowIndex].Cells[2].Value.ToString();
            onlineDetail.Summary = dataGridViewOnline.Rows[e.RowIndex].Cells[3].Value.ToString();
            onlineDetail.Day = Convert.ToInt32(dataGridViewOnline.Rows[e.RowIndex].Cells[4].Value);
            onlineDetail.MonthID = Convert.ToInt32(dataGridViewOnline.Rows[e.RowIndex].Cells[5].Value);
            onlineDetail.MonthName = dataGridViewOnline.Rows[e.RowIndex].Cells[6].Value.ToString();
            onlineDetail.Year = Convert.ToInt32(dataGridViewOnline.Rows[e.RowIndex].Cells[7].Value);
            onlineDetail.OfferingDate = Convert.ToDateTime(dataGridViewOnline.Rows[e.RowIndex].Cells[8].Value);
            onlineDetail.OfferingStatusID = Convert.ToInt32(dataGridViewOnline.Rows[e.RowIndex].Cells[9].Value);
            onlineDetail.OfferingStatus = dataGridViewOnline.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void btnClearOffline_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void btnSearchOffline_Click(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = offlineDTO.Offerings;
            if (txtAmountOffline.Text.Trim() != "")
            {
                if (rbLessOffline.Checked)
                {
                    list = list.Where(x => x.Offering < Convert.ToDecimal(txtAmountOffline.Text)).ToList();
                }
                else if (rbEqualOffline.Checked)
                {
                    list = list.Where(x => x.Offering == Convert.ToDecimal(txtAmountOffline.Text)).ToList();
                }
                else if (rbMoreOffline.Checked)
                {
                    list = list.Where(x => x.Offering > Convert.ToDecimal(txtAmountOffline.Text)).ToList();
                }
                else
                {
                    MessageBox.Show("Please select a criterion from the radio boxes");
                }
            }
            if (cmbMonthOffline.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonthOffline.SelectedValue)).ToList();
            }
            dataGridViewOfflineOfferings.DataSource = list;
        }

        private void dataGridViewOnline_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDayOnline_TextChanged_1(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = onlineDTO.Offerings;
            list = list.Where(x => x.Day.ToString().Contains(txtDayOnline.Text)).ToList();
            dataGridViewOnline.DataSource = list;
        }

        private void txtYearOnline_TextChanged_1(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = onlineDTO.Offerings;
            list = list.Where(x => x.Year.ToString().Contains(txtYearOnline.Text)).ToList();
            dataGridViewOnline.DataSource = list;
        }

        private void txtDayOffline_TextChanged(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = offlineDTO.Offerings;
            list = list.Where(x => x.Day.ToString().Contains(txtDayOffline.Text)).ToList();
            dataGridViewOfflineOfferings.DataSource = list;
        }

        private void txtYearOffline_TextChanged(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = offlineDTO.Offerings;
            list = list.Where(x => x.Year.ToString().Contains(txtYearOffline.Text)).ToList();
            dataGridViewOfflineOfferings.DataSource = list;
        }

        private void btnClearOnline_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void btnSearchOnline_Click_1(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = onlineDTO.Offerings;
            if (txtAmountOnline.Text.Trim() != "")
            {
                if (rbLessOnline.Checked)
                {
                    list = list.Where(x => x.Offering < Convert.ToDecimal(txtAmountOnline.Text)).ToList();
                }
                else if (rbEqualOnline.Checked)
                {
                    list = list.Where(x => x.Offering == Convert.ToDecimal(txtAmountOnline.Text)).ToList();
                }
                else if (rbMoreOnline.Checked)
                {
                    list = list.Where(x => x.Offering > Convert.ToDecimal(txtAmountOnline.Text)).ToList();
                }
                else
                {
                    MessageBox.Show("Please select a criterion from the radio boxes");
                }
            }
            if (cmbMonthOnline.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonthOnline.SelectedValue)).ToList();
            }
            dataGridViewOnline.DataSource = list;
        }

        private void txtYearOffline_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtDayOffline_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
    }
}
