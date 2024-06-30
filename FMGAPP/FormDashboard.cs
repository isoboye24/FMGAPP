using FMGAPP.AllForms;
using FMGAPP.BLL;
using FMGAPP.DAL.DTO;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FMGAPP
{
    public partial class FormDashboard : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        GraphBLL graphBLL = new GraphBLL();
        GraphDTO graphDTO = new GraphDTO();
        public FormDashboard()
        {
            InitializeComponent();
            CustomizieDropdowns(panelExpenditure);
            CustomizieDropdowns(panelExpenditure);
            CustomizieDropdowns(panelFinancialReport);
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(5, 40);
            panelSidebar.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }
        private void CustomizieDropdowns(Panel pan)
        {
            pan.Visible = false;
        }
        private void HideSubmenu(Panel pan)
        {
            if (pan.Visible == true) 
            { 
                pan.Visible = false; 
            }
        }
        private void ShowSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false) 
            { 
                HideSubmenu(subMenu); 
                subMenu.Visible = true; 
            } 
            else 
            { 
                subMenu.Visible = false; 
            }
        }

        private struct RBGColors
        {
            public static Color sidebarBackColor = Color.MediumSeaGreen;
            public static Color activeBtnTextColor = Color.White;
            public static Color normal = Color.YellowGreen;
        }
        private void ActivateButton(object senderBtn, Color color, Color borderColor)
        {
            if (senderBtn != null)
            {
                DisableButton();
                // Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.DarkGreen;
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // Left Border button
                leftBorderBtn.BackColor = borderColor;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.SeaGreen;
                currentBtn.ForeColor = Color.White;
                currentBtn.IconColor = Color.White; ;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        // Drag From
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int IParam);

        string queryOffline = "SELECT MONTH.monthName, SUM(OFFERING.offerings) \r\n" +
            "FROM OFFERING\r\n" +
            "JOIN MONTH ON OFFERING.monthID = MONTH.monthID\r\n" +
            "WHERE OFFERING.year = 2024 AND OFFERING.offeringStatusID = 5 AND OFFERING.isDeleted = 0\r\n" +
            "GROUP BY MONTH.monthName, OFFERING.monthID\r\n" +
            "ORDER BY OFFERING.monthID ASC";

        string queryOnline = "SELECT MONTH.monthName, SUM(OFFERING.offerings) \r\n" +
            "FROM OFFERING\r\n" +
            "JOIN MONTH ON OFFERING.monthID = MONTH.monthID\r\n" +
            "WHERE OFFERING.year = 2024 AND OFFERING.offeringStatusID = 6 AND OFFERING.isDeleted = 0\r\n" +
            "GROUP BY MONTH.monthName, OFFERING.monthID\r\n" +
            "ORDER BY OFFERING.monthID ASC";
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            labelTitleChildForm.Text = "Record Keeping App";
            General.CreateChart(chartMonOffOffline, queryOffline, SeriesChartType.Column, "Month", "");
            General.CreateChart(chartMonOffOnline, queryOnline, SeriesChartType.Column, "Month", "");
        }
        ExpenditureBLL bll = new ExpenditureBLL();
        OfferingBLL offeringBLL = new OfferingBLL();
        private void RefreshCards()
        {
            label3.Text = ("Expenditures " + General.ConventIntToMonth(DateTime.Today.Month)).ToUpper();
            labelTotalExpenditureThisMonthOff.Text = "€ " + bll.TotalExpensesThisMonth(DateTime.Today.Month);
            label8.Text = ("Expenditures " + DateTime.Today.Year).ToUpper();
            labelTotalExpenditureThisYearOff.Text = "€ " + bll.TotalExpensesThisYear(DateTime.Today.Year);
            label2.Text = (General.ConventIntToMonth(DateTime.Today.Month) + "'s Offerings").ToUpper();
            labelTotalOfferingThisMonthOff.Text = "€ " + offeringBLL.TotalOfferingsThisMonth(DateTime.Today.Month, 5);
            label5.Text = ("Offerings " + DateTime.Today.Year).ToUpper();
            labelTotalOfferingThisYearOff.Text = "€ " + offeringBLL.TotalOfferingsThisYear(DateTime.Today.Year, 5);
            label7.Text = (General.ConventIntToMonth(DateTime.Today.Month) + "'s Offerings").ToUpper();
            labelTotalOfferingThisMonthOn.Text = "€ " + offeringBLL.TotalOfferingsThisMonth(DateTime.Today.Month, 6);
            label10.Text = ("Offerings " + DateTime.Today.Year).ToUpper();
            labelTotalOfferingThisYearOn.Text = "€ " + offeringBLL.TotalOfferingsThisYear(DateTime.Today.Year, 6);
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            RefreshCards();
            this.ControlBox = false;
            btnLogout.Visible = false;
            panelExpenditure.Visible = false;
            ButtonLocation(btnFinancialReports, 1, 330);
            PanelLocation(panelFinancialReport, 1, 390);
            panelFinancialReport.Visible = false;
            ButtonLocation(btnDocuments, 1, 400);
            PanelLocation(panelDocumentDropdown, 1, 450);
            panelDocumentDropdown.Visible = false;

            graphDTO = graphBLL.GetMonthlyGraphDataWithStatus(5, DateTime.Today.Year);
            chartMonOffOffline.DataSource = graphDTO.GraphData;

            General.CreateChart(chartMonOffOffline, queryOffline, SeriesChartType.Column, "Month", "");
            General.CreateChart(chartMonOffOnline, queryOnline, SeriesChartType.Column, "Month", "");

            label16.Text = "OFFLINE MONTHLY OFFERING " + DateTime.Today.Year;
            label17.Text = "ONLINE MONTHLY OFFERING " + DateTime.Today.Year;
            label4.Text = "OFFLINE " + DateTime.Today.Year;
            label6.Text = "ONLINE " + DateTime.Today.Year;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitleChildForm.Text = childForm.Text;
        }
        private bool buttonWasClicked = false;
        private void iconMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void labelLogo_Click(object sender, EventArgs e)
        {
            if (buttonWasClicked)
            {
                currentChildForm.Close();
                Reset();
            }
            RefreshCards();
        }
        private void btnOffering_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;
            ActivateButton(sender, RBGColors.activeBtnTextColor, RBGColors.normal);
            OpenChildForm(new FormOfferingList());
            HideSubmenu(panelExpenditure);
            HideSubmenu(panelFinancialReport);
            HideSubmenu(panelDocumentDropdown);
        }
        
        private void btnExpenses_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelExpenditure);
            ActivateButton(sender, RBGColors.activeBtnTextColor, RBGColors.normal);
            HideSubmenu(panelFinancialReport);
            HideSubmenu(panelDocumentDropdown);
            if (panelExpenditure.Visible == false)
            {
                ExpensesClosed();
            }
            else
            {
                ExpensesOpened();
            }
        }

        private void btnExpenditure_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;
            OpenChildForm(new FormExpenditureList());
            HideSubmenu(panelExpenditure);
            if (panelExpenditure.Visible == false)
            {
                ExpensesClosed();
            }
            else
            {
                ExpensesOpened();
            }
        }
        private void btnExpenditureTitle_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;
            OpenChildForm(new FormSettingsList());
            HideSubmenu(panelExpenditure);
            if (panelExpenditure.Visible == false)
            {
                ExpensesClosed();
            }
            else
            {
                ExpensesOpened();
            }
        }

        private void btnFinancialReports_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelFinancialReport);
            ActivateButton(sender, RBGColors.activeBtnTextColor, RBGColors.normal);
            HideSubmenu(panelExpenditure);
            HideSubmenu(panelDocumentDropdown);
            if (panelFinancialReport.Visible == false)
            {
                FRClosed();
            }
            else
            {
                FROpened();
            }
        }
        private void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;            
            OpenChildForm(new FormMonthlyReports());
            HideSubmenu(panelFinancialReport);
            if (panelFinancialReport.Visible == false)
            {
                FRClosed();
            }
            else
            {
                FROpened();
            }
        }
        private void btnYearlyReport_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;            
            OpenChildForm(new FormViewYearlyReportList());
            HideSubmenu(panelFinancialReport);
            if (panelFinancialReport.Visible == false)
            {
                FRClosed();
            }
            else
            {
                FROpened();
            }
        }
        private void btnTotalBalance_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;            
            OpenChildForm(new FormViewTotalBalance());
            HideSubmenu(panelFinancialReport);
            if (panelFinancialReport.Visible == false)
            {
                FRClosed();
            }
            else
            {
                FROpened();
            }
        }
        private void btnDocuments_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelDocumentDropdown);
            ActivateButton(sender, RBGColors.activeBtnTextColor, RBGColors.normal);
            HideSubmenu(panelExpenditure);
            HideSubmenu(panelFinancialReport);            
        }
        private void btnImageDocument_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;
            OpenChildForm(new FormDocumentImageList());
            HideSubmenu(panelDocumentDropdown);
        }

        private void btnOtherDocuments_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;
            OpenChildForm(new FormDocumentOtherList());
            HideSubmenu(panelDocumentDropdown);
        }
        private void btnDeletedData_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;
            OpenChildForm(new FormDeletedData());
            HideSubmenu(panelDocumentDropdown);
            HideSubmenu(panelFinancialReport);
            HideSubmenu(panelExpenditure);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin open = new FormLogin();
            this.Hide();
            open.ShowDialog();
        }
        private void ButtonLocation(Button btn, int x, int y)
        {
            btn.Location = new Point(x, y);
        }
        private void PanelLocation(Panel pan, int x, int y)
        {
            pan.Location = new Point(x, y);
        }
        private void ExpensesOpened()
        {
            ButtonLocation(btnFinancialReports, 1, 480);
            PanelLocation(panelFinancialReport, 1, 520);
            ButtonLocation(btnDocuments, 1, 550);
            PanelLocation(panelDocumentDropdown, 1, 600);
        }
        private void ExpensesClosed()
        {
            ButtonLocation(btnFinancialReports, 1, 330);
            PanelLocation(panelFinancialReport, 1, 380);
            ButtonLocation(btnDocuments, 1, 400);
            PanelLocation(panelDocumentDropdown, 1, 450);
        }
        private void FROpened()
        {
            ButtonLocation(btnDocuments, 1, 620);
            PanelLocation(panelDocumentDropdown, 1, 660);
        }
        private void FRClosed()
        {
            ButtonLocation(btnDocuments, 1, 400);
            PanelLocation(panelDocumentDropdown, 1, 450);
        }        
    }
}
