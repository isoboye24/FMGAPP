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
    public partial class FormExpenditureTitleList : Form
    {
        public FormExpenditureTitleList()
        {
            InitializeComponent();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormExpenditureTitle open = new FormExpenditureTitle();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            FillDataGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (detail.ExpenditureTitleID == 0)
            {
                MessageBox.Show("Please select an expenditure title from the table.");
            }
            else
            {
                FormExpenditureTitle open = new FormExpenditureTitle();
                open.detail = detail;
                open.isEdit = true;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                FillDataGrid();
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ExpenditureTitleID == 0)
            {
                MessageBox.Show("Please select an expenditure title from the table.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?","Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("Expenditure title was deleted");
                        FillDataGrid();
                    }
                }
            }            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ExpenditureTitleBLL bll = new ExpenditureTitleBLL();
        ExpenditureTitleDTO dto = new ExpenditureTitleDTO();
        ExpenditureTitleDetailDTO detail = new ExpenditureTitleDetailDTO();
        private void FormExpenditureTitleList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.ExpenditureTitles;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Expenditure Titles";
        }
        private void FillDataGrid()
        {
            bll = new ExpenditureTitleBLL();
            dto = bll.Select();
            dataGridView1.DataSource = dto.ExpenditureTitles;
            txtExpenditureTitle.Clear();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ExpenditureTitleDetailDTO();
            detail.ExpenditureTitleID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.ExpenditureTitle = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
