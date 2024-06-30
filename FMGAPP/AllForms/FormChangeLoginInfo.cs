using FMGAPP.BLL;
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

namespace FMGAPP.AllForms
{
    public partial class FormChangeLoginInfo : Form
    {
        public FormChangeLoginInfo()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int IParam);

        LoginBLL bll = new LoginBLL();
        private void FormChangeLoginInfo_Load(object sender, EventArgs e)
        {
            txtCurrentPassword.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtCurrentUsername.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtNewPassword.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtNewUsername.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label4.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEnter.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
