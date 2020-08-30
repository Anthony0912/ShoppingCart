using ShoppingCartBOL;
using ShoppingCartEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCartGUI
{
    public partial class FrmLogin : Form
    {
        private Point MouseLocation;
        private EUser eu;
        private UserBOL ubol;

        public FrmLogin()
        {
            InitializeComponent();
            eu = new EUser();
            ubol = new UserBOL();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point(-e.X, -e.Y);
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(MouseLocation.X, MouseLocation.Y);
                Location = mousePos;
            }
        }

        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmSignUp().Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                eu.Email = txtEmail.Text?.Trim();
                eu.Password = txtPassword.Text?.Trim();
                eu = ubol.Login(eu);
                new Main { eu = eu }.ShowDialog();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
