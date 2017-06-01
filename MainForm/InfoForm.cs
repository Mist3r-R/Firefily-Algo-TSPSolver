using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class InfoForm : Form
    {
        public InfoForm(string path)
        {
            InitializeComponent();
            string[] strarr = path.Split('-', '>');
            foreach (string s in strarr)
                if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s)) path_list.Items.Add(s);
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
