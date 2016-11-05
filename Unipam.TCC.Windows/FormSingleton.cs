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
    public partial class FormSingleton : Form
    {
        private static FormSingleton instancia = null;

        public FormSingleton()
        {
            InitializeComponent();
        }

        public static FormSingleton Mostrar()
        {
            if (instancia == null)
            {
                instancia = new FormSingleton();
            }

            return instancia;
        }

        private void FormSingleton_Load(object sender, EventArgs e)
        {

        }

        private void FormSingleton_FormClosed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
    }
}
