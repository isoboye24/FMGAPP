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
    public partial class FormOffering : Form
    {
        public FormOffering()
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
        OfferingBLL bll = new OfferingBLL();
        public OfferingsDetailDTO detail = new OfferingsDetailDTO();
        public bool isEdit = false;
        public bool isView = false;
        public string offeringStatusString;
        public string labelTitleString;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOffering.Text.Trim() == "")
            {
                MessageBox.Show("Enter offering");
            }            
            else
            {
                if (!isEdit)
                {
                    OfferingsDetailDTO offering = new OfferingsDetailDTO();
                    offering.Offering = Convert.ToDecimal(txtOffering.Text);
                    offering.Summary = txtSummary.Text;
                    if (offeringStatusString == "Offline")
                    {
                        offering.OfferingStatusID = 5;
                    }
                    else
                    {
                        offering.OfferingStatusID = 6;
                    }
                    offering.Day = dateTimePickerOfferingDate.Value.Day;
                    offering.MonthID = dateTimePickerOfferingDate.Value.Month;
                    offering.Year = dateTimePickerOfferingDate.Value.Year;
                    offering.OfferingDate = dateTimePickerOfferingDate.Value;
                    labelTitle.Text = labelTitleString;
                    labelOffeingStatus.Text = offeringStatusString;                    
                    if (bll.Insert(offering))
                    {
                        MessageBox.Show("Offering was added");
                        txtOffering.Clear();
                        txtSummary.Clear();
                        dateTimePickerOfferingDate.Value = DateTime.Today;
                    }
                }
                else if(isEdit)
                {
                    if (detail.Offering.ToString() == txtOffering.Text.Trim() && detail.Summary==txtSummary.Text.Trim() && detail.OfferingDate == dateTimePickerOfferingDate.Value)
                    {
                        MessageBox.Show("There is no change");
                    }
                    else
                    {
                        detail.Offering = Convert.ToDecimal(txtOffering.Text); 
                        detail.Summary = txtSummary.Text;
                        detail.OfferingStatusID = detail.OfferingStatusID;
                        detail.Day = dateTimePickerOfferingDate.Value.Day;
                        detail.MonthID = dateTimePickerOfferingDate.Value.Month;
                        detail.Year = dateTimePickerOfferingDate.Value.Year;
                        detail.OfferingDate = dateTimePickerOfferingDate.Value;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Offering was updated");
                            this.Close();
                        }
                    }
                }
            }
        }

        private void txtOffering_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = General.isNumber(e);
        }

        private void FormOffering_Load(object sender, EventArgs e)
        {
            labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            dateTimePickerOfferingDate.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtOffering.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            txtSummary.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            labelViewDate.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 12, FontStyle.Bold);            
            btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSave.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            labelTitle.Text = labelTitleString;
            labelOffeingStatus.Text = offeringStatusString.ToUpper();

            if (isEdit)
            {
                txtOffering.Text = detail.Offering.ToString();
                txtSummary.Text = detail.Summary;
                dateTimePickerOfferingDate.Value = detail.OfferingDate;
            }
            if (isView)
            {
                txtOffering.ReadOnly = true;
                txtOffering.Text = detail.Offering.ToString();
                txtSummary.ReadOnly = true;
                txtSummary.Text = detail.Summary;
                dateTimePickerOfferingDate.Hide();
                labelViewDate.Hide();
                labelTitle.Text = "Offering on "+ detail.Day + "." + detail.MonthID + "." + detail.Year;
            }
        }
    }
}
