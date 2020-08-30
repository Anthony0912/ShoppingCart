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
    public partial class FrmSignUp : Form
    {
        private Point MouseLocation;
        private EUser eu;
        private UserBOL ubol;
        public FrmSignUp()
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

        private void linkLabelLogin_LinkClicked(object sender, MouseEventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                eu.Name = txtName.Text?.Trim();
                eu.Lastname = txtLastname.Text?.Trim();
                eu.Email = txtEmail.Text?.Trim();
                eu.Password = txtPassword.Text?.Trim();
                string RepeatPassword = txtRepeatPassword.Text?.Trim();

                if (!eu.Password.Equals(RepeatPassword))
                {
                    throw new Exception("Las contraseñas no son iguales.");
                }
                if (eu.Password.Length < 8 || RepeatPassword.Length < 8)
                {
                    throw new Exception("Tu contraseña debe tener más de ocho caracteres.");
                }

                ubol.SignUp(eu);
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
