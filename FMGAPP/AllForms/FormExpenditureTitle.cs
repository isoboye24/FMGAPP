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
    public partial class FormExpenditureTitle : Form
    {
        public FormExpenditureTitle()
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
        ExpenditureTitleBLL bll = new ExpenditureTitleBLL();
        public ExpenditureTitleDetailDTO detail = new ExpenditureTitleDetailDTO();
        public bool isEdit = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtExpenditureTitle.Text.Trim()=="")
            {
                MessageBox.Show("Expenditure title is empty");
            }
            else
            {
                if (!isEdit)
                {
                    ExpenditureTitleDetailDTO title = new ExpenditureTitleDetailDTO();
                    title.ExpenditureTitle = txtExpenditureTitle.Text;
                    if (bll.Insert(title))
                    {
                        MessageBox.Show("Expenditure title was added");
                        txtExpenditureTitle.Clear();
                    }
                }
                else
                {
                    if (detail.ExpenditureTitle == txtExpenditureTitle.Text.Trim())
                    {
                        MessageBox.Show("There is no change.");
                    }
                    else
                    {
                        detail.ExpenditureTitle = txtExpenditureTitle.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Expenditure title was updated");
                            this.Close();
                        };
                    }
                }
            }
        }

        private void FormExpenditureTitle_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                txtExpenditureTitle.Text = detail.ExpenditureTitle;
            }
        }
    }
}
