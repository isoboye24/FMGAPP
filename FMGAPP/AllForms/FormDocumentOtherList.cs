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
    public partial class FormDocumentOtherList : Form
    {
        public FormDocumentOtherList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormDocumentOther open = new FormDocumentOther();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            ClearFilters();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (detail.DocumentID == 0)
            {
                MessageBox.Show("Please select a document from the table");
            }
            else
            {
                FormDocumentOther open = new FormDocumentOther();
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
            if (detail.DocumentID == 0)
            {
                MessageBox.Show("Please select a document from the table");
            }
            else
            {
                if (detail.DocumentType != "Word Document")
                {
                    ReadFiles.CopyDocument(detail.DocumentPath, detail.DocumentName);
                    ClearFilters();
                }
                else if (detail.DocumentType == "Word Document")
                {
                    DialogResult result = MessageBox.Show("Open document \"" + detail.DocumentName + " ?\"", "Warning!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        FormViewOtherDocument open = new FormViewOtherDocument();
                        open.detail = detail;
                        this.Hide();
                        open.ShowDialog();
                        this.Visible = true;
                        ClearFilters();
                    }
                }
            }
        }
        OtherDocumentsBLL bll = new OtherDocumentsBLL();
        OtherDocumentDTO dto = new OtherDocumentDTO();
        OtherDocumentsDetailDTO detail = new OtherDocumentsDetailDTO();
        private void FormDocumentOtherList_Load(object sender, EventArgs e)
        {
            txtDocName.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbMonth.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbYears.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbDocTypes.Font = new Font("Segoe UI", 18, FontStyle.Regular);
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
            cmbDocTypes.DataSource = dto.DocumentTypes;
            cmbDocTypes.SelectedIndex = -1;

            dataGridView1.DataSource = dto.OtherDocuments;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Doc Name";
            dataGridView1.Columns[2].HeaderText = "Doc Type";
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
            bll = new OtherDocumentsBLL();
            dto = bll.Select();
            dataGridView1.DataSource = dto.OtherDocuments;
        }
        private void ClearFilters()
        {
            cmbMonth.SelectedIndex = -1;
            cmbYears.SelectedIndex = -1;
            cmbDocTypes.SelectedIndex = -1;
            txtDocName.Clear();
            FillDataGrid();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<OtherDocumentsDetailDTO> list = dto.OtherDocuments;
            if (cmbMonth.SelectedIndex !=-1 && cmbYears.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue) && x.Year == Convert.ToInt32(cmbYears.SelectedValue)).ToList();
            }
            else if (cmbMonth.SelectedIndex != -1 || cmbYears.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue) || x.Year == Convert.ToInt32(cmbYears.SelectedValue)).ToList();
            }
            else if (cmbDocTypes.SelectedIndex != -1)
            {
                list = list.Where(x => x.DocumentType.Contains(cmbDocTypes.SelectedValue.ToString())).ToList();
            }            
            dataGridView1.DataSource = list;
        }

        private void txtDocName_TextChanged(object sender, EventArgs e)
        {
            List<OtherDocumentsDetailDTO> list = dto.OtherDocuments;
            list = list.Where(x => x.DocumentName.Contains(txtDocName.Text.Trim())).ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new OtherDocumentsDetailDTO();
            detail.DocumentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.DocumentName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.DocumentPath = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.DocumentType = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Day = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.DocumentID == 0)
            {
                MessageBox.Show("Please select a document from the table");
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                if (e.Value.ToString() == "Excel Document")
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.DarkOrange;
                }
                else if (e.Value.ToString() == "PDF Document")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Purple;
                }
                else if (e.Value.ToString() == "PowerPoint Document")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Brown;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }
    }
}
