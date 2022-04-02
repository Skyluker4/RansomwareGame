using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RansomwareGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = @"C:\Users\Malware host\sweating.mp4";
        }
        
        

        //Send the user to the next form when the timer gets to zero
        private void timer_Tick(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }


        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"C:\Users\Malware host\sweating.mp4";
        }
    }
}
