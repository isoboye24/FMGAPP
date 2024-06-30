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
    public partial class FormSettingsList : Form
    {
        public FormSettingsList()
        {
            InitializeComponent();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ExpenditureTitleBLL ExpTitleBLL = new ExpenditureTitleBLL();
        ExpenditureTitleDTO expTitleDTO = new ExpenditureTitleDTO();
        ExpenditureTitleDetailDTO expTitleDetail = new ExpenditureTitleDetailDTO();
        OfferingStatusBLL offStatusBLL = new OfferingStatusBLL();
        OfferingStatusDTO offStatusDTO = new OfferingStatusDTO();
        OfferingStatusDetailDTO offStatusDetail = new OfferingStatusDetailDTO();
        
        private void FillDataGrid()
        {
            ExpTitleBLL = new ExpenditureTitleBLL();
            expTitleDTO = ExpTitleBLL.Select();
            dataGridViewExpTitle.DataSource = expTitleDTO.ExpenditureTitles;
            txtExpenditureTitle.Clear();

            offStatusBLL = new OfferingStatusBLL();
            offStatusDTO = offStatusBLL.Select();
            dataGridViewOffStatus.DataSource = offStatusDTO.OfferingStatuses;
            txtOffStatus.Clear();
        }

        private void dataGridViewExpTitle_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            expTitleDetail = new ExpenditureTitleDetailDTO();
            expTitleDetail.ExpenditureTitleID = Convert.ToInt32(dataGridViewExpTitle.Rows[e.RowIndex].Cells[0].Value);
            expTitleDetail.ExpenditureTitle = dataGridViewExpTitle.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnAddOffStatus_Click(object sender, EventArgs e)
        {
            FormAddSettings open = new FormAddSettings();
            this.Hide();
            open.titleString = "Add Offering Status";
            open.labelSettingsString = "Add Offering Status";
            open.ShowDialog();
            this.Visible = true;
            FillDataGrid();
        }

        private void btnEditOffStatus_Click(object sender, EventArgs e)
        {
            if (offStatusDetail.OfferingStatusID == 0)
            {
                MessageBox.Show("Please select an offering status from the table.");
            }
            else
            {
                FormAddSettings open = new FormAddSettings();
                open.offStatusDetail = offStatusDetail;
                open.isEditOffStatus = true;
                open.titleString = "Edit Offering Status";
                open.labelSettingsString = "Edit Offering Status";
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                FillDataGrid();
            }
        }

        private void btnDeleteOffStatus_Click(object sender, EventArgs e)
        {
            if (offStatusDetail.OfferingStatusID == 0)
            {
                MessageBox.Show("Please select an offering status from the table.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (offStatusBLL.Delete(offStatusDetail))
                    {
                        MessageBox.Show("Offering status was deleted");
                        FillDataGrid();
                    }
                }
            }
        }

        private void FormSettingsList_Load(object sender, EventArgs e)
        {
            txtExpenditureTitle.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtOffStatus.Font = new Font("Segoe UI", 18, FontStyle.Regular);

            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnAddExpTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDeleteExpTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEditExpTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAddOffStatus.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDeleteOffStatus.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEditOffStatus.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            expTitleDTO = ExpTitleBLL.Select();
            dataGridViewExpTitle.DataSource = expTitleDTO.ExpenditureTitles;
            dataGridViewExpTitle.Columns[0].Visible = false;
            dataGridViewExpTitle.Columns[1].HeaderText = "Expenditure Titles";
            foreach (DataGridViewColumn column in dataGridViewExpTitle.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }

            offStatusDTO = offStatusBLL.Select();
            dataGridViewOffStatus.DataSource = offStatusDTO.OfferingStatuses;
            dataGridViewOffStatus.Columns[0].Visible = false;
            dataGridViewOffStatus.Columns[1].HeaderText = "Offering Statuses";
            foreach (DataGridViewColumn column in dataGridViewOffStatus.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
        }

        private void btnAddExpTitle_Click_1(object sender, EventArgs e)
        {
            FormAddSettings open = new FormAddSettings();
            this.Hide();
            open.ShowDialog();
            open.titleString = "Add Expenditure Title";
            open.labelSettingsString = "Add Expenditure Title";
            this.Visible = true;
            FillDataGrid();
        }

        private void btnEditExpTitle_Click(object sender, EventArgs e)
        {
            if (expTitleDetail.ExpenditureTitleID == 0)
            {
                MessageBox.Show("Please select an expenditure title from the table.");
            }
            else
            {
                FormAddSettings open = new FormAddSettings();
                open.expTitleDetail = expTitleDetail;
                open.isEditExpTitle = true;
                open.titleString = "Edit Expenditure Title";
                open.labelSettingsString = "Expenditure Title";
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                FillDataGrid();
            }
        }

        private void btnDeleteExpTitle_Click(object sender, EventArgs e)
        {
            if (expTitleDetail.ExpenditureTitleID == 0)
            {
                MessageBox.Show("Please select an expenditure title from the table.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (ExpTitleBLL.Delete(expTitleDetail))
                    {
                        MessageBox.Show("Expenditure title was deleted");
                        FillDataGrid();
                    }
                }
            }
        }

        private void dataGridViewOffStatus_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            offStatusDetail = new OfferingStatusDetailDTO();
            offStatusDetail.OfferingStatusID = Convert.ToInt32(dataGridViewOffStatus.Rows[e.RowIndex].Cells[0].Value);
            offStatusDetail.OfferingStatus = dataGridViewOffStatus.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
