using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RansomwareGame
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Get current user's directory
            string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string csvPath = userDirectory + "\\WannaPiss\\system32.csv";

            Metadata.readCSV(csvPath);

            // Print all metadata
            foreach (var item in Metadata.files)
            {
                Console.WriteLine(item.path);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
