using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unipam.TCC.Windows
{
    public partial class TrampoSingleton : Form
    {
        public TrampoSingleton()
        {
            InitializeComponent();
        }

        private void formularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSingleton formSingleton = FormSingleton.Mostrar();
            formSingleton.MdiParent = this;
            formSingleton.Show();
        }
    }
}
