using FMGAPP.BLL;
using FMGAPP.DAL;
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
    public partial class FormExpenditure : Form
    {
        public FormExpenditure()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ExpenditureBLL bll = new ExpenditureBLL();
        ExpenditureDTO dto = new ExpenditureDTO();
        public ExpenditureDetailDTO detail = new ExpenditureDetailDTO();
        public bool isEdit = false;
        private void FormExpenditure_Load(object sender, EventArgs e)
        {
            labelTitleChildForm.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            dateTimePickerSpentDate.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtSummary.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtAmountSpent.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            cmbExpenditureTitle.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnSave.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            dto = bll.Select();
            cmbExpenditureTitle.DataSource = dto.ExpenditureTitles;
            General.ComboBoxProps(cmbExpenditureTitle, "ExpenditureTitle", "ExpenditureTitleID");

            if (isEdit)
            {
                txtAmountSpent.Text = detail.AmountSpent.ToString();
                txtSummary.Text = detail.Summary;
                dateTimePickerSpentDate.Value = detail.ExpenditureDate;
                cmbExpenditureTitle.SelectedValue = detail.ExpenditureTitleID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmountSpent.Text.Trim() == "")
            {
                MessageBox.Show("Amount is empty");
            }
            else if (txtSummary.Text.Trim() == "")
            {
                MessageBox.Show("Summary is empty");
            }
            else if (cmbExpenditureTitle.SelectedIndex == -1)
            {
                MessageBox.Show("Expenditure title is empty");
            }
            else
            {
                if (!isEdit)
                {
                    ExpenditureDetailDTO expenditure = new ExpenditureDetailDTO();
                    expenditure.AmountSpent = Convert.ToDecimal(txtAmountSpent.Text);
                    expenditure.Summary = txtSummary.Text;
                    expenditure.Day = dateTimePickerSpentDate.Value.Day;
                    expenditure.MonthID = dateTimePickerSpentDate.Value.Month;
                    expenditure.Year = dateTimePickerSpentDate.Value.Year;
                    expenditure.ExpenditureDate = dateTimePickerSpentDate.Value;
                    expenditure.ExpenditureTitleID = Convert.ToInt32(cmbExpenditureTitle.SelectedValue);
                    if (bll.Insert(expenditure))
                    {
                        MessageBox.Show("Expenditure was added");
                        txtAmountSpent.Clear();
                        txtSummary.Clear();
                        cmbExpenditureTitle.SelectedIndex = -1;
                        dateTimePickerSpentDate.Value = DateTime.Today;
                    }
                }
                else if (isEdit)
                {
                    if (detail.ExpenditureDate == dateTimePickerSpentDate.Value &&
                         detail.Summary ==txtSummary.Text.Trim() && detail.AmountSpent == Convert.ToDecimal(txtAmountSpent.Text) && 
                         detail.ExpenditureTitleID == Convert.ToInt32(cmbExpenditureTitle.SelectedValue))
                    {
                        MessageBox.Show("There is no change.");
                    }
                    else
                    {
                        detail.AmountSpent = Convert.ToDecimal(txtAmountSpent.Text);
                        detail.Summary = txtSummary.Text;
                        detail.Day = dateTimePickerSpentDate.Value.Day;
                        detail.MonthID = dateTimePickerSpentDate.Value.Month;
                        detail.Year = dateTimePickerSpentDate.Value.Year;
                        detail.ExpenditureDate = dateTimePickerSpentDate.Value;
                        detail.ExpenditureTitleID = Convert.ToInt32(cmbExpenditureTitle.SelectedValue);
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Expenditure was updated");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
