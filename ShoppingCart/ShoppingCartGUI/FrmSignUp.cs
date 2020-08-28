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
    public partial class FrmSignUp : Form
    {
        private Point MouseLocation;
        public FrmSignUp()
        {
            InitializeComponent();
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

        private void linkLabelLogin_LinkClicked(object sender, MouseEventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }
    }
}
