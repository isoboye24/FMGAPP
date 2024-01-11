using FMGAPP.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FMGAPP.AllForms
{
    public partial class FormViewOtherDocument : Form
    {
        public FormViewOtherDocument()
        {
            InitializeComponent();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public OtherDocumentsDetailDTO detail = new OtherDocumentsDetailDTO();

        private void FormViewOtherDocument_Load(object sender, EventArgs e)
        {
            txtDocumentContent.Multiline = true;
            txtDocumentContent.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtDocumentContent.SelectionAlignment = HorizontalAlignment.Left;

            labelWordsCount.Hide();
            this.Text = detail.DocumentName + " (" + detail.Day + "." + detail.MonthID + "." + detail.Year + ")";
            string filePath = Application.StartupPath + "\\documents\\" + detail.DocumentPath;
            if (detail.DocumentType == "Word Document")
            {
                ReadFiles.ReadWord(filePath, txtDocumentContent);
                string[] words = txtDocumentContent.Text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                labelWordsCount.Text = words.Length.ToString();
                labelWordsCount.Visible = true;
            }
        }
    }
}
