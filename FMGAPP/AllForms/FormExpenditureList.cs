﻿using FMGAPP.BLL;
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
    public partial class FormExpenditureList : Form
    {
        public FormExpenditureList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormExpenditure open = new FormExpenditure();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
            ClearFilters();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (detail.ExpenditureID == 0)
            {
                MessageBox.Show("Please choose an expenditure from the table.");
            }
            else
            {
                FormExpenditure open = new FormExpenditure();
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
            if (detail.ExpenditureID == 0)
            {
                MessageBox.Show("Please choose an expenditure from the table.");
            }
            else
            {
                FormViewExpenditure open = new FormViewExpenditure();
                open.detail = detail;
                this.Hide();
                open.ShowDialog();
                this.Visible = true;
                ClearFilters();
            }            
        }
        ExpenditureBLL bll = new ExpenditureBLL();
        ExpenditureDTO dto = new ExpenditureDTO();
        ExpenditureDetailDTO detail = new ExpenditureDetailDTO();
        private void FormExpenditureList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbMonth.DataSource = dto.Months;
            General.ComboBoxProps(cmbMonth, "MonthName", "MonthID");
            cmbExpenditureTitle.DataSource = dto.ExpenditureTitles;
            General.ComboBoxProps(cmbExpenditureTitle, "ExpenditureTitle", "ExpenditureTitleID");

            dataGridView1.DataSource = dto.Expenditures;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Amount Spent";
            dataGridView1.Columns[2].HeaderText = "Expenditure Title";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Day";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Month";
            dataGridView1.Columns[7].HeaderText = "Year";
            dataGridView1.Columns[8].Visible = false;
        }
        public void ClearFilters()
        {
            cmbMonth.SelectedIndex = -1;
            cmbExpenditureTitle.SelectedIndex = -1;
            txtAmount.Clear();
            txtYear.Clear();
            rbLess.Checked = false;
            rbEqual.Checked = false;
            rbMore.Checked = false;
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            bll = new ExpenditureBLL();
            dto = bll.Select();
            dataGridView1.DataSource = dto.Expenditures;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            List<ExpenditureDetailDTO> list = dto.Expenditures;
            list = list.Where(x => x.Year.ToString().Contains(txtYear.Text.Trim())).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ExpenditureDetailDTO> list = dto.Expenditures;
            if (txtAmount.Text.Trim() != "")
            {
                if (rbLess.Checked)
                {
                    list = list.Where(x => x.AmountSpent < Convert.ToDecimal(txtAmount.Text.Trim())).ToList();
                }
                else if (rbEqual.Checked)
                {
                    list = list.Where(x => x.AmountSpent == Convert.ToDecimal(txtAmount.Text.Trim())).ToList();
                }
                else if (rbMore.Checked)
                {
                    list = list.Where(x => x.AmountSpent > Convert.ToDecimal(txtAmount.Text.Trim())).ToList();
                }
            }
            else if (cmbExpenditureTitle.SelectedIndex != -1)
            {
                list = list.Where(x => x.ExpenditureTitleID == Convert.ToInt32(cmbExpenditureTitle.SelectedValue)).ToList();
            }
            else if (cmbMonth.SelectedIndex != -1)
            {
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue)).ToList();
            }
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ExpenditureDetailDTO();
            detail.ExpenditureID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.AmountSpent = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.ExpenditureTitle = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Summary = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.Day = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            detail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detail.ExpenditureTitleID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ExpenditureID == 0)
            {
                MessageBox.Show("Please choose an expenditure from the table.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("An expenditure was deleted.");
                        ClearFilters();
                    }
                }                
            }
        }
    }
}
