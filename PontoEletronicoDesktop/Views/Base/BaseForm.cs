using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronicoDesktop.Views.Base
{
    public partial class BaseForm : Form
    {
        public BaseForm() =>
            InitializeComponent();

        private void pnlBottom_Resize(object sender, EventArgs e)
        {
            int x = (pnlBottom.Size.Width - lblBottom.Width) / 2;
            int y = (pnlBottom.Size.Height - (lblBottom.Height)) / 2;

            lblBottom.Location = new Point(x, y);
        }
    }
}
