using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeMen
{
    public partial class BoxForm : Form
    {
        public BoxForm()
        {
            InitializeComponent();
        }

        private void BoxForm_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void splashScreen()
        {
            timer1.Start();
        }
        private void BoxForm_MouseDown(object sender, MouseEventArgs e)
        {
            splashScreen();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            splashScreen();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.01)
            {
                this.Opacity -= 0.01;
            }
            else
            {
                timer1.Stop();
                this.Hide();
            }
        }
    }
}
