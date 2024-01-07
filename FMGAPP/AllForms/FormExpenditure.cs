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
            dto = bll.Select();
            cmbExpenditureTitle.DataSource = dto.ExpenditureTitles;
            General.ComboBoxProps(cmbExpenditureTitle, "ExpenditureTitle", "ExpenditureTitleID");

            if (isEdit)
            {
                txtAmountSpent.Text = detail.AmountSpent.ToString();
                txtSummary.Text = detail.Summary;
                dateTimePickerSpentDate.Value = Convert.ToDateTime(detail.MonthID + "/" + detail.Day + "/" + detail.Year);
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
                    if (Convert.ToDateTime(detail.MonthID + "/" + detail.Day + "/" + detail.Year) == dateTimePickerSpentDate.Value &&
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
