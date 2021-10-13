using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairRent
{
    public partial class MainForm : Form
    {
        private Clients singleton;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setTimer();
        }

        private void setTimer()
        {
            timerClock.Interval = 1000;
            timerClock.Enabled = true;
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelDisplay.Text = $"{DateTime.Now:dddd, MMMM d, yyyy   h:mm:ss tt}";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void customersDialog()
        {
            singleton = Clients.CreateForm(); // call static method to create instance
            singleton.Show();     // call show method
            singleton.Activate(); // makes this window the active window
        }

        private void ugyfelekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customersDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == "Ügyfelek")
                {
                    ratesToolStripMenuItem.Enabled = false;
                }
                else
                {
                    ratesToolStripMenuItem.Enabled = true;
                }
            }

        }

        private void ratesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RatesDialog dlg = new RatesDialog()) 
            {
                dlg.ShowDialog();
            }
        }
    }
}
