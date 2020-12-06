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
    public partial class NotificationForm : Form
    {
    public NotificationForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.AutoSize = true;
            textBox1.Text = Notification.Value;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
