using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraDynamo
{
    public partial class FormContentNotice : Form
    {
        public FormContentNotice()
        {
            InitializeComponent();
        }

        private void checkDisplayStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HideContentNotice = !checkDisplayStartup.Checked;
            Properties.Settings.Default.Save();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AcceptContentNotice = true;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AcceptContentNotice = false;
            Properties.Settings.Default.HideContentNotice = false;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void FormContentNotice_Load(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;

            checkDisplayStartup.Checked = !Properties.Settings.Default.HideContentNotice;
        }
    }
}
