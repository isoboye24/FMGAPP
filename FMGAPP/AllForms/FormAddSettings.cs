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
    public partial class FormAddSettings : Form
    {
        public FormAddSettings()
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
        ExpenditureTitleBLL ExpTitleBLL = new ExpenditureTitleBLL();
        public ExpenditureTitleDetailDTO expTitleDetail = new ExpenditureTitleDetailDTO();
        OfferingStatusBLL offStatusBLL = new OfferingStatusBLL();
        public OfferingStatusDetailDTO offStatusDetail = new OfferingStatusDetailDTO();
        public bool isEditExpTitle = false;
        public bool isEditOffStatus = false;
        public string titleString;
        public string labelSettingsString;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (titleString == "Add Expenditure Title" || titleString == "Edit Expenditure Title")
            {
                if (txtSettingsText.Text.Trim() == "")
                {
                    MessageBox.Show("Expenditure title is empty");
                }
                else
                {
                    if (!isEditExpTitle)
                    {
                        ExpenditureTitleDetailDTO title = new ExpenditureTitleDetailDTO();
                        title.ExpenditureTitle = txtSettingsText.Text.Trim();
                        if (ExpTitleBLL.Insert(title))
                        {
                            MessageBox.Show("Expenditure title was added");
                            txtSettingsText.Clear();
                        }
                    }
                    else
                    {
                        if (expTitleDetail.ExpenditureTitle == txtSettingsText.Text.Trim())
                        {
                            MessageBox.Show("There is no change.");
                        }
                        else
                        {
                            expTitleDetail.ExpenditureTitle = txtSettingsText.Text;
                            if (ExpTitleBLL.Update(expTitleDetail))
                            {
                                MessageBox.Show("Expenditure title was updated");
                                this.Close();
                            };
                        }
                    }
                }
            }
            else if (titleString == "Add Offering Status" || titleString == "Edit Offering Status")
            {
                if (txtSettingsText.Text.Trim() == "")
                {
                    MessageBox.Show("Offering status is empty");
                }
                else
                {
                    if (!isEditOffStatus)
                    {
                        OfferingStatusDetailDTO offStatus = new OfferingStatusDetailDTO();
                        offStatus.OfferingStatus = txtSettingsText.Text;
                        if (offStatusBLL.Insert(offStatus))
                        {
                            MessageBox.Show("Offering status was added");
                            txtSettingsText.Clear();
                        }
                    }
                    else
                    {
                        if (offStatusDetail.OfferingStatus == txtSettingsText.Text.Trim())
                        {
                            MessageBox.Show("There is no change.");
                        }
                        else
                        {
                            offStatusDetail.OfferingStatus = txtSettingsText.Text;
                            if (offStatusBLL.Update(offStatusDetail))
                            {
                                MessageBox.Show("Offering Status was updated");
                                this.Close();
                            };
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Unknown action");
            }
        }        
        private void FormExpenditureTitle_Load(object sender, EventArgs e)
        {            
            title.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            txtSettingsText.Font = new Font("Segoe UI", 18, FontStyle.Regular);            
            labelSettings.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnSave.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.Text = titleString;
            labelSettings.Text = labelSettingsString;
            if (isEditExpTitle)
            {
                txtSettingsText.Text = expTitleDetail.ExpenditureTitle;
            }
        }
    }
}
