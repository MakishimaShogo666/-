using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_main
{
    public partial class Common : Form
    {
        SimpleNumbersForm simplenumbers = new SimpleNumbersForm();
        Form3 matrix = new Form3();
        XML_form XML = new XML_form();
        DataBaseTask Data = new DataBaseTask();
        public Common()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            XML.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            simplenumbers.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            matrix.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Data.ShowDialog();
        }
    }
}
