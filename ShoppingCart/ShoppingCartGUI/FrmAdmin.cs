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
    public partial class FrmAdmin : Form
    {
        public EAccount ea { set; get; }
        public FrmAdmin()
        {
            InitializeComponent();
        }
    }
}
