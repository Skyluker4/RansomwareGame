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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            // Decrypt
            var userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var exePath = userDirectory + "\\WannaPiss\\Ransomwarer.exe";
            System.Diagnostics.Process.Start(exePath, "d '*'");
        }
    }
}
