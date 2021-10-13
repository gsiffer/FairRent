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
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }

        private void Message_Load(object sender, EventArgs e)
        {
            waitSomeTime(this);
        }

        private async void waitSomeTime(Form popUp)
        {
            await Task.Delay(2000);
            this.Close();
        }
    }
}
