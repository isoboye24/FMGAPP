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
    public partial class FormOfferingList : Form
    {
        public FormOfferingList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormOffering open = new FormOffering();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            ClearFilters();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (detail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                FormOffering open = new FormOffering();
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
            if (detail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                FormOffering open = new FormOffering();
                open.detail = detail;
                open.isView = true;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                ClearFilters();
            }            
        }
        OfferingBLL bll = new OfferingBLL();
        OfferingsDTO dto = new OfferingsDTO();
        OfferingsDetailDTO detail = new OfferingsDetailDTO();
        private void FormOfferingList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbMonth.DataSource = dto.Months;
            General.ComboBoxProps(cmbMonth, "MonthName", "MonthID");

            dataGridView1.DataSource = dto.Offerings;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Offerings";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Day";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Month";
            dataGridView1.Columns[7].HeaderText = "Year";
        }
        private void ClearFilters()
        {
            cmbMonth.SelectedIndex = -1;
            txtAmount.Clear();
            txtDay.Clear();
            txtYear.Clear();
            rbEqual.Checked = false;
            rbLess.Checked = false;
            rbMore.Checked = false;
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Offerings;
        }
        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = dto.Offerings;
            list = list.Where(x => x.Day.ToString().Contains(txtDay.Text)).ToList();
            dataGridView1.DataSource = list;
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = dto.Offerings;
            list = list.Where(x => x.Year.ToString().Contains(txtYear.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<OfferingsDetailDTO> list = dto.Offerings;
            if (txtAmount.Text.Trim() != "")
            {
                if (rbLess.Checked)
                {
                    list = list.Where(x => x.Offering < Convert.ToDecimal(txtAmount.Text)).ToList();
                }
                else if (rbEqual.Checked)
                {
                    list = list.Where(x => x.Offering == Convert.ToDecimal(txtAmount.Text)).ToList();
                }
                else if (rbMore.Checked)
                {
                    list = list.Where(x => x.Offering > Convert.ToDecimal(txtAmount.Text)).ToList();
                }                
                else
                {
                    MessageBox.Show("Please select a criterion from the radio boxes");
                }                
            }
            if (cmbMonth.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue)).ToList();
            }
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new OfferingsDetailDTO();
            detail.OfferingID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.Offering = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.OfferingWithCurrency = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Summary = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.Day = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.OfferingID == 0)
            {
                MessageBox.Show("Please choose an offering from the table.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?","Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("Offering was deleted");
                        ClearFilters();
                    }
                }                
            }
        }
    }
}
