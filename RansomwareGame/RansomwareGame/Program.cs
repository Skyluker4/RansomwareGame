using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

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

            //open system32.csv and write random data to it the same length as the original file
            Random rnd = new Random();

            // Overwrite csv file with random data
            byte[] data = System.IO.File.ReadAllBytes(csvPath);
            byte[] dataNew = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dataNew[i] = (byte)rnd.Next(0, 255);
            }
            System.IO.File.WriteAllBytes(csvPath, dataNew);

            // Delete csv file
            System.IO.File.Delete(csvPath);

            // Start actual program
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
