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
    public partial class FormDocumentImageList : Form
    {
        public FormDocumentImageList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormDocumentImage open = new FormDocumentImage();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            ClearFilters();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (detail.DocumentImageID == 0)
            {
                MessageBox.Show("Please choose a document from the table.");
            }
            else
            {
                FormDocumentImage open = new FormDocumentImage();
                open.detail = detail;
                open.isEdit = true;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                ClearFilters();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (detail.DocumentImageID == 0)
            {
                MessageBox.Show("Please choose a document from the table.");
            }
            else
            {
                FormViewImageDocument open = new FormViewImageDocument();
                open.detail = detail;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                ClearFilters();
            }
        }
        ImageDocumentBLL bll = new ImageDocumentBLL();
        ImageDocumentDTO dto = new ImageDocumentDTO();
        ImageDocumentDetailDTO detail = new ImageDocumentDetailDTO();
        private void FormDocumentImageList_Load(object sender, EventArgs e)
        {
            txtImageCaption.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbMonth.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbYears.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAdd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClear.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDelete.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEdit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSearch.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnView.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            dto = bll.Select();
            cmbMonth.DataSource = dto.Months;
            General.ComboBoxProps(cmbMonth, "MonthName", "MonthID");
            cmbYears.DataSource = dto.Years;
            cmbYears.SelectedIndex = -1;

            dataGridView1.DataSource = dto.ImageDocuments;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Document Name";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Day";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Month";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].HeaderText = "Year";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
        }
        private void FillDataGrid()
        {
            bll = new ImageDocumentBLL();
            dto = bll.Select();
            dataGridView1.DataSource = dto.ImageDocuments;
        }
        private void ClearFilters()
        {
            cmbMonth.SelectedIndex = -1;
            cmbYears.SelectedIndex = -1;
            txtImageCaption.Clear();
            FillDataGrid();
        }

        private void txtImageCaption_TextChanged(object sender, EventArgs e)
        {
            List<ImageDocumentDetailDTO> list = dto.ImageDocuments;
            list = list.Where(x => x.DocumentName.Contains(txtImageCaption.Text.Trim())).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ImageDocumentDetailDTO> list = dto.ImageDocuments;
            if (cmbMonth.SelectedIndex != -1 && cmbYears.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue) && x.Year == Convert.ToInt32(cmbYears.SelectedValue)).ToList();
            }
            if (cmbMonth.SelectedIndex != -1 || cmbYears.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue) || x.Year == Convert.ToInt32(cmbYears.SelectedValue)).ToList();
            }
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ImageDocumentDetailDTO();
            detail.DocumentImageID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.ImagePath = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.DocumentName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Summary = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.Day = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.DocumentImageID == 0)
            {
                MessageBox.Show("Please choose a document from the table.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("Document was deleted");
                        ClearFilters();
                    }
                }                
            }
        }
    }
}
