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
    public partial class Form3 : Form
    {
        enum DataUnits {
            Nibbles,
            Kibbibytes,
            Megabytes,
            Gibbibytes
        }

        public Form3()
        {
            InitializeComponent();
            
            label2.Text = GameState.currentFile.fileName;
            unitLabelText = "nibbles";
            
            timer1.Interval = 1000;
            timer1.Start();
        }

        int guessedBytes = 0;
        float units = 1;
        string unitLabelText;

        private void barScrolled(object sender, ScrollEventArgs e)
        {
            //set the value of the label to the value of the scrollbar
            int niceBytes = (int)(((float)hScrollBar1.Value / (float)hScrollBar1.Maximum) * 2048);
            label1.Text = niceBytes + " " + unitLabelText;
            guessedBytes = (int) (niceBytes * units);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //set the progress bar to the current value
            progressBar1.Value++;

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                GameState.levelLose();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check if the user has entered the correct value for the Size in barScrolled
            //the correct value is GameState.CurrentFile.Size
            //if they have, run levelWin
            //if they have not, run levelLose

            // If the guessed size is +- 20% of the actual size

            if (guessedBytes >= GameState.currentFile.size - (GameState.currentFile.size * GameState.winFactorThreshold) && guessedBytes <= GameState.currentFile.size + (GameState.currentFile.size * GameState.winFactorThreshold))
            {
                GameState.levelWin();
                Hide();
            }
            else
            {
                GameState.levelLose();
                Hide();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // KiB
            units = 1024;
            unitLabelText = "KiB";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // MB
            units = 1000;
            unitLabelText = "MB";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // GiB
            units = 1024 * 1024 * 1024;
            unitLabelText = "GiB";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            // nibbles
            units = 0.5f;
            unitLabelText = "nibbles";
        }
    }
}
