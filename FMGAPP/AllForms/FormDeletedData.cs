using FMGAPP.BLL;
using FMGAPP.DAL.DTO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FMGAPP.AllForms
{
    public partial class FormDeletedData : Form
    {
        public FormDeletedData()
        {
            InitializeComponent();
        }
        OfferingBLL offeringBLL = new OfferingBLL();
        OfferingsDTO offeringDTO = new OfferingsDTO();
        ExpenditureTitleBLL expTitleBLL = new ExpenditureTitleBLL();
        ExpenditureTitleDTO expTitleDTO = new ExpenditureTitleDTO();
        ExpenditureBLL expBLL = new ExpenditureBLL();
        ExpenditureDTO expDTO = new ExpenditureDTO();
        ImageDocumentBLL imageBLL = new ImageDocumentBLL();
        ImageDocumentDTO imageDTO = new ImageDocumentDTO();
        OtherDocumentsBLL otherDocBLL = new OtherDocumentsBLL();
        OtherDocumentDTO otherDocDTO = new OtherDocumentDTO();
        OfferingStatusBLL offeringStatusBLL = new OfferingStatusBLL();
        OfferingStatusDTO offeringStatusDTO = new OfferingStatusDTO();
        DeletedDataBLL bll = new DeletedDataBLL();
        DeletedDataDTO dto = new DeletedDataDTO();
        private void FormDeletedData_Load(object sender, EventArgs e)
        {
            cmbDeletedData.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            label1.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            btnDeletePermanently.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnRetrieve.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            cmbDeletedData.Items.Add("Offerings");
            cmbDeletedData.Items.Add("Expenditure Titles");
            cmbDeletedData.Items.Add("Expenditures");
            cmbDeletedData.Items.Add("Image Documents");
            cmbDeletedData.Items.Add("Other Documents");
            cmbDeletedData.Items.Add("Offering Status");

            dto = bll.Select(true);
            dataGridView1.DataSource = dto.Offerings;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Offerings";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Day";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Month";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].HeaderText = "Year";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
        }

        private void cmbDeletedData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                dataGridView1.DataSource = dto.Offerings;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Offerings";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].HeaderText = "Day";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Month";
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[7].HeaderText = "Year";
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                dataGridView1.DataSource = dto.ExpenditureTitles;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Expenditure Titles";
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                dataGridView1.DataSource = dto.Expenditures;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Amount Spent";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].HeaderText = "Expenditure Title";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].HeaderText = "Day";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Month";
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[7].HeaderText = "Year";
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
            }
            else if (cmbDeletedData.SelectedIndex == 3)
            {
                dataGridView1.DataSource = dto.ImageDocuments;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Document Name";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].HeaderText = "Day";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Month";
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[7].HeaderText = "Year";
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else if (cmbDeletedData.SelectedIndex == 4)
            {
                dataGridView1.DataSource = dto.OtherDocuments;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Doc Name";
                dataGridView1.Columns[2].HeaderText = "Doc Type";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].HeaderText = "Day";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Month";
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[7].HeaderText = "Year";
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else if (cmbDeletedData.SelectedIndex == 5)
            {
                dataGridView1.DataSource = dto.OfferingStatuses;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Offering Status";
            }
        }
        OfferingsDetailDTO offeringDetail = new OfferingsDetailDTO();
        ExpenditureTitleDetailDTO expTitleDetail = new ExpenditureTitleDetailDTO();
        ExpenditureDetailDTO expDetail = new ExpenditureDetailDTO();
        ImageDocumentDetailDTO imageDocDetail = new ImageDocumentDetailDTO();
        OtherDocumentsDetailDTO otherDocDetail = new OtherDocumentsDetailDTO();
        OfferingStatusDetailDTO offeringStatusDetail = new OfferingStatusDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0 || cmbDeletedData.SelectedIndex == -1)
            {
                offeringDetail = new OfferingsDetailDTO();
                offeringDetail.OfferingID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                offeringDetail.Offering = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                offeringDetail.OfferingWithCurrency = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                offeringDetail.Summary = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                offeringDetail.Day = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                offeringDetail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                offeringDetail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                offeringDetail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                offeringDetail.OfferingDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                expTitleDetail = new ExpenditureTitleDetailDTO();
                expTitleDetail.ExpenditureTitleID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                expTitleDetail.ExpenditureTitle = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                expDetail = new ExpenditureDetailDTO();
                expDetail.ExpenditureID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                expDetail.AmountSpent = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                expDetail.ExpenditureTitle = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                expDetail.Summary = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                expDetail.Day = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                expDetail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                expDetail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                expDetail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                expDetail.ExpenditureTitleID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
                expDetail.ExpenditureDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
                expDetail.isExpenditureTitleDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            }
            else if (cmbDeletedData.SelectedIndex == 3)
            {
                imageDocDetail = new ImageDocumentDetailDTO();
                imageDocDetail.DocumentImageID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                imageDocDetail.ImagePath = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                imageDocDetail.DocumentName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                imageDocDetail.Summary = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                imageDocDetail.Day = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                imageDocDetail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                imageDocDetail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                imageDocDetail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            }
            else if (cmbDeletedData.SelectedIndex == 4)
            {
                otherDocDetail = new OtherDocumentsDetailDTO();
                otherDocDetail.DocumentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                otherDocDetail.DocumentName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                otherDocDetail.DocumentPath = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                otherDocDetail.DocumentType = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                otherDocDetail.Day = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                otherDocDetail.MonthID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                otherDocDetail.MonthName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                otherDocDetail.Year = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            }
            else if (cmbDeletedData.SelectedIndex == 5)
            {
                offeringStatusDetail = new OfferingStatusDetailDTO();
                offeringStatusDetail.OfferingStatusID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                offeringStatusDetail.OfferingStatus = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("There is no such document");
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == -1 || cmbDeletedData.SelectedIndex == 0)
            {
                if (offeringDetail.OfferingID == 0)
                {
                    MessageBox.Show("Please select offering from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to retrieve this data?","Warning",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (offeringBLL.GetBack(offeringDetail))
                        {
                            MessageBox.Show("Offering was retrieved successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.Offerings;
                        }
                    }                    
                }
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                if (expTitleDetail.ExpenditureTitleID == 0)
                {
                    MessageBox.Show("Please select expenditure title from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to retrieve this data?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (expTitleBLL.GetBack(expTitleDetail))
                        {
                            MessageBox.Show("Expenditure title was retrieved successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.ExpenditureTitles;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                if (expDetail.ExpenditureTitleID == 0)
                {
                    MessageBox.Show("Please select expenditure from the table.");
                }
                else if (expDetail.isExpenditureTitleDeleted)
                {
                    MessageBox.Show("Expenditure title was deleted. Retrieve the expenditure title first.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to retrieve this data?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (expBLL.GetBack(expDetail))
                        {
                            MessageBox.Show("Expenditure was retrieved successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.Expenditures;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 3)
            {
                if (imageDocDetail.DocumentImageID == 0)
                {
                    MessageBox.Show("Please select document from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to retrieve this data?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (imageBLL.GetBack(imageDocDetail))
                        {
                            MessageBox.Show("Document was retrieved successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.ImageDocuments;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 4)
            {
                if (otherDocDetail.DocumentID == 0)
                {
                    MessageBox.Show("Please select document from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to retrieve this data?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (otherDocBLL.GetBack(otherDocDetail))
                        {
                            MessageBox.Show("Document was retrieved successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.OtherDocuments;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 5)
            {
                if (offeringStatusDetail.OfferingStatusID == 0)
                {
                    MessageBox.Show("Please select offering status from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to retrieve this data?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (offeringStatusBLL.GetBack(offeringStatusDetail))
                        {
                            MessageBox.Show("Offering Status was retrieved successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.OfferingStatuses;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no document retrieved");
            }
        }

        private void btnDeletePermanently_Click(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == -1 || cmbDeletedData.SelectedIndex == 0)
            {
                if (offeringDetail.OfferingID == 0)
                {
                    MessageBox.Show("Please select offering from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this data permanently?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (offeringBLL.DeletePermanently(offeringDetail))
                        {
                            MessageBox.Show("Offering was deleted successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.Offerings;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                if (expTitleDetail.ExpenditureTitleID == 0)
                {
                    MessageBox.Show("Please select expenditure title from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this data permanently?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (expTitleBLL.DeletePermanently(expTitleDetail))
                        {
                            MessageBox.Show("Expenditure title was deleted successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.ExpenditureTitles;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                if (expDetail.ExpenditureTitleID == 0)
                {
                    MessageBox.Show("Please select expenditure from the table.");
                }                
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this data permanently?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (expBLL.DeletePermanently(expDetail))
                        {
                            MessageBox.Show("Expenditure was deleted successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.Expenditures;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 3)
            {
                if (imageDocDetail.DocumentImageID == 0)
                {
                    MessageBox.Show("Please select document from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this data permanently?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (imageBLL.DeletePermanently(imageDocDetail))
                        {
                            MessageBox.Show("Document was deleted successfully");
                            if (File.Exists(@"documents\\" + imageDocDetail.ImagePath))
                            {
                                File.Delete(@"documents\\" + imageDocDetail.ImagePath);
                            }
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.ImageDocuments;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 4)
            {
                if (otherDocDetail.DocumentID == 0)
                {
                    MessageBox.Show("Please select document from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this data permanently?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (otherDocBLL.DeletePermanently(otherDocDetail))
                        {
                            MessageBox.Show("Document was deleted successfully");
                            if (File.Exists(@"documents\\" + otherDocDetail.DocumentPath))
                            {
                                File.Delete(@"documents\\" + otherDocDetail.DocumentPath);
                            }
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.OtherDocuments;
                        }
                    }
                }
            }
            else if (cmbDeletedData.SelectedIndex == 5)
            {
                if (offeringStatusDetail.OfferingStatusID == 0)
                {
                    MessageBox.Show("Please select offering status from the table.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to delete this data permanently?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (offeringStatusBLL.DeletePermanently(offeringStatusDetail))
                        {
                            MessageBox.Show("offering status was deleted successfully");
                            dto = bll.Select(true);
                            dataGridView1.DataSource = dto.OfferingStatuses;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no data to delete");
            }
        }
    }
}
