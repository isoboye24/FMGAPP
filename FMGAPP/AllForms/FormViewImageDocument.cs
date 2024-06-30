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
    public partial class FormViewImageDocument : Form
    {
        public FormViewImageDocument()
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
        public ImageDocumentDetailDTO detail = new ImageDocumentDetailDTO();
        private void FormViewImageDocument_Load(object sender, EventArgs e)
        {
            labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);            
            txtSummary.Font = new Font("Segoe UI", 18, FontStyle.Regular);            
            labelDate.Font = new Font("Segoe UI", 10, FontStyle.Bold);            
            btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            txtSummary.Text = detail.Summary;
            labelTitle.Text = detail.DocumentName;
            labelDate.Text = detail.Day + "." + detail.MonthID + "." + detail.Year;
            string imagePath = Application.StartupPath + "\\documents\\" + detail.ImagePath;
            picImage.ImageLocation = imagePath;
        }
    }
}
