using FMGAPP.BLL;
using FMGAPP.DAL.DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FMGAPP.AllForms
{
    public partial class FormDocumentOther : Form
    {
        public FormDocumentOther()
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
        public OtherDocumentsDetailDTO detail = new OtherDocumentsDetailDTO();
        public bool isEdit = false;
        System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        string fileName;
        string fileExtension;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Word Documents|*.docx|Excel Spreadsheets|*.xlsx|Text Files|*.txt|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDocumentPath.Text = openFileDialog1.FileName;
                fileExtension = Path.GetExtension(txtDocumentPath.Text);
                string unique = Guid.NewGuid().ToString();
                fileName += unique + openFileDialog1.SafeFileName;
                picDocument.Visible = true;
                txtDocumentType.Text = General.GetDocumentType(fileExtension);
            }
        }
        OtherDocumentsBLL bll = new OtherDocumentsBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDocumentName.Text.Trim() == "")
            {
                MessageBox.Show("Document name is empty.");
            }
            else if (txtDocumentPath.Text.Trim() == "")
            {
                MessageBox.Show("Document path is empty.");
            }
            else if (txtDocumentType.Text.Trim() == "")
            {
                MessageBox.Show("Document type is empty.");
            }
            else
            {
                if (!isEdit)
                {
                    OtherDocumentsDetailDTO document = new OtherDocumentsDetailDTO();
                    document.DocumentName = txtDocumentName.Text.Trim();
                    document.DocumentPath = fileName;
                    document.DocumentType = General.GetDocumentType(fileExtension);
                    document.Day = DateTime.Today.Day;
                    document.MonthID = DateTime.Today.Month;
                    document.Year = DateTime.Today.Year;
                    if (bll.Insert(document))
                    {
                        try
                        {
                            File.Copy(txtDocumentPath.Text, @"documents\\" + fileName);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot find the path to this document");
                        }
                        MessageBox.Show("Document was added.");
                        txtDocumentName.Clear();
                        txtDocumentPath.Clear();
                        txtDocumentType.Clear();
                        picDocument.Image = null;
                    }
                }
                else if(isEdit)
                {
                    if (detail.DocumentType == txtDocumentType.Text.Trim() && detail.DocumentName == txtDocumentName.Text.Trim() &&
                        detail.DocumentPath == txtDocumentPath.Text.Trim())
                    {
                        MessageBox.Show("There is no change.");
                    }
                    else
                    {
                        if (txtDocumentPath.Text != detail.DocumentPath)
                        {
                            if (File.Exists(@"documents\\" + detail.DocumentPath))
                            {
                                File.Delete(@"documents\\" + detail.DocumentPath);
                            }
                            File.Copy(txtDocumentPath.Text, @"documents\\" + fileName);
                            detail.DocumentPath = fileName;
                            detail.DocumentType = General.GetDocumentType(fileExtension);
                        }
                        else if (txtDocumentPath.Text == detail.DocumentPath)
                        {
                            detail.DocumentPath = detail.DocumentPath;
                            detail.DocumentType = detail.DocumentType;
                        }
                        detail.DocumentName = txtDocumentName.Text.Trim();
                        detail.Day = detail.Day;
                        detail.MonthID = detail.MonthID;
                        detail.Year = detail.Year;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Document was updated");
                            this.Close();
                        }
                    }
                }
            }
        }

        private void FormDocumentOther_Load(object sender, EventArgs e)
        {
            picDocument.Hide();
            if (isEdit)
            {
                txtDocumentName.Text = detail.DocumentName;
                txtDocumentPath.Text = detail.DocumentPath;
                txtDocumentType.Text = detail.DocumentType;
                picDocument.Visible = true;
            }
        }
    }
}
