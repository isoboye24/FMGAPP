using FMGAPP.AllForms;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMGAPP
{
    public partial class FormDashboard : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
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

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            labelTitleChildForm.Text = "Record Keeping App";
        }
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            btnLogout.Visible = false;
            panelExpenditure.Visible = false;
            ButtonLocation(btnFinancialReports, 1, 219);
            PanelLocation(panelFinancialReport, 1, 260);
            panelFinancialReport.Visible = false;
            ButtonLocation(btnDocuments, 1, 264);
            PanelLocation(panelDocumentDropdown, 1, 303);
            panelDocumentDropdown.Visible = false;
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
            tableLayoutPanelBoard.Controls.Add(childForm);
            tableLayoutPanelBoard.Tag = childForm;
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
            OpenChildForm(new FormExpenditureTitleList());
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
            OpenChildForm(new FormFinancialReportList());
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
            ButtonLocation(btnFinancialReports, 1, 314);
            PanelLocation(panelFinancialReport, 1, 355);
            ButtonLocation(btnDocuments, 1, 360);
            PanelLocation(panelDocumentDropdown, 1, 400);
        }
        private void ExpensesClosed()
        {
            ButtonLocation(btnFinancialReports, 1, 219);
            PanelLocation(panelFinancialReport, 1, 260);
            ButtonLocation(btnDocuments, 1, 264);
            PanelLocation(panelDocumentDropdown, 1, 303);
        }
        private void FROpened()
        {
            ButtonLocation(btnDocuments, 1, 409);
            PanelLocation(panelDocumentDropdown, 1, 448);
        }
        private void FRClosed()
        {
            ButtonLocation(btnDocuments, 1, 264);
            PanelLocation(panelDocumentDropdown, 1, 303);
        }

        
    }
}
