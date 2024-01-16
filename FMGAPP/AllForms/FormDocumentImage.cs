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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMGAPP.AllForms
{
    public partial class FormDocumentImage : Form
    {
        public FormDocumentImage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ImageDocumentBLL bll = new ImageDocumentBLL();
        public ImageDocumentDetailDTO detail = new ImageDocumentDetailDTO();
        public bool isEdit = false;
        string fileName;
        System.Windows.Forms.OpenFileDialog OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picImage.Load(OpenFileDialog1.FileName);
                txtImagePath.Text = OpenFileDialog1.FileName;
                string unique = Guid.NewGuid().ToString();
                fileName += unique + OpenFileDialog1.SafeFileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtImagePath.Text.Trim() == "")
            {
                MessageBox.Show("Please upload the image of the document.");
            }
            else if (txtDocumentName.Text.Trim() == "")
            {
                MessageBox.Show("Document name is empty.");
            }
            else
            {
                if (!isEdit)
                {
                    ImageDocumentDetailDTO document = new ImageDocumentDetailDTO();
                    document.ImagePath = fileName;
                    document.Summary = txtSummary.Text.Trim();
                    document.DocumentName = txtDocumentName.Text;
                    document.Day = DateTime.Today.Day;
                    document.MonthID = DateTime.Today.Month;
                    document.Year = DateTime.Today.Year;
                    if (bll.Insert(document))
                    {
                        MessageBox.Show("Image was added");
                        try
                        {
                            File.Copy(txtImagePath.Text, @"documents\\" + fileName);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot find the path to this picture");
                        }
                        txtDocumentName.Clear();
                        txtImagePath.Clear();
                        txtSummary.Clear();
                        picImage.Image = null;
                    }
                }
                else if(isEdit)
                {
                    if (detail.Summary == txtSummary.Text.Trim() && detail.DocumentName == txtDocumentName.Text.Trim() &&
                        detail.ImagePath == txtImagePath.Text)
                    {
                        MessageBox.Show("There is no change.");
                    }
                    else
                    {
                        if (txtImagePath.Text != detail.ImagePath)
                        {
                            if (File.Exists(@"documents\\" + detail.ImagePath))
                            {
                                File.Delete(@"documents\\" + detail.ImagePath);
                            }
                            File.Copy(txtImagePath.Text, @"documents\\" + fileName);
                            detail.ImagePath = fileName;
                        }
                        else if (txtImagePath.Text == detail.ImagePath)
                        {
                            detail.ImagePath = txtImagePath.Text;
                        }
                        detail.Summary = txtSummary.Text.Trim();
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

        private void FormDocumentImage_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                txtDocumentName.Text = detail.DocumentName;
                txtImagePath.Text = detail.ImagePath;
                txtSummary.Text = detail.Summary;
                string imagePath = Application.StartupPath + "\\documents\\" + detail.ImagePath;
                picImage.ImageLocation = imagePath;                
            }
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
