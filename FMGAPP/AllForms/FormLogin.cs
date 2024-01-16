using FMGAPP.BLL;
using FMGAPP.DAL;
using FMGAPP.DAL.DTO;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        LoginBLL bll = new LoginBLL();
        private void linkLabelChangeLoginInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormChangeLoginInfo open = new FormChangeLoginInfo();
            this.Hide();
            open.ShowDialog();
            this.Visible = true;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int IParam);
        LoginDTO dto = new LoginDTO();
        private void FormLogin_Load(object sender, EventArgs e)
        {
            linkLabelChangeLoginInfo.Hide();            
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        LoginDetailDTO detail = new LoginDetailDTO();
        
        private void btnEnter_Click(object sender, EventArgs e)
        {
            //LoginDetailDTO detail = new LoginDetailDTO();
            //detail.Username = txtUsername.Text.Trim();
            //detail.Password = txtPassword.Text.Trim();
            //if (bll.Insert(detail))
            //{
            //    MessageBox.Show("Login added");
            //    txtUsername.Clear();
            //    txtPassword.Clear();
            //}
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Enter username and password");
            }
            else
            {
                List<LOGIN> userLogin = bll.CheckLoginInfo(txtPassword.Text, txtUsername.Text);
                if (userLogin.Count > 0)
                {
                    FormDashboard open = new FormDashboard();
                    this.Hide();
                    open.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect username and password");
                    linkLabelChangeLoginInfo.Visible = true;
                }
            }
        }
    }
}
