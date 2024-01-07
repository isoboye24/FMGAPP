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
                    offering.Day = dateTimePickerOfferingDate.Value.Day;
                    offering.MonthID = dateTimePickerOfferingDate.Value.Month;
                    offering.Year = dateTimePickerOfferingDate.Value.Year;
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
                    if (detail.Offering.ToString() == txtOffering.Text.Trim() && detail.Summary==txtSummary.Text.Trim() && Convert.ToDateTime(detail.MonthID + "/" + detail.Day + "/" + detail.Year) == dateTimePickerOfferingDate.Value)
                    {
                        MessageBox.Show("There is no change");
                    }
                    else
                    {
                        detail.Offering = Convert.ToDecimal(txtOffering.Text); 
                        detail.Summary = txtSummary.Text;
                        detail.Day = dateTimePickerOfferingDate.Value.Day;
                        detail.MonthID = dateTimePickerOfferingDate.Value.Month;
                        detail.Year = dateTimePickerOfferingDate.Value.Year;
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
            if (isEdit)
            {
                txtOffering.Text = detail.Offering.ToString();
                txtSummary.Text = detail.Summary;
                dateTimePickerOfferingDate.Value = Convert.ToDateTime(detail.MonthID + "/" + detail.Day + "/" + detail.Year);
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
