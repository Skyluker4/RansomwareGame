﻿using System;
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
    public partial class Form4 : Form
    {
        private Button button1;
        private Label label1;
        private ProgressBar progressBar1;
        private Timer timer1;
        private IContainer components;
        private DateTimePicker dateTimePicker1;

        public Form4()
        {
            InitializeComponent();
            label1.Text = GameState.currentFile.fileName;

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.dateTimePicker1.Location = new System.Drawing.Point(311, 388);
            this.dateTimePicker1.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(228, 26);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.button1.Location = new System.Drawing.Point(12, 636);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(840, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15F);
            this.label1.Location = new System.Drawing.Point(6, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "File";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(78, 69);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(711, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(864, 767);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check if the user has entered the correct value for the Size in barScrolled
            //the correct value is GameState.CurrentFile.Size
            //if they have, run levelWin
            //if they have not, run levelLose
            bool win = false;

            int inputYear = dateTimePicker1.Value.Year;
            int inputMonth = dateTimePicker1.Value.Month;
            int inputDay = dateTimePicker1.Value.Day;

            if (inputYear == GameState.currentFile.created.year && inputMonth == GameState.currentFile.created.month && (Math.Abs(inputDay - GameState.currentFile.created.day) <= 7))
            {
                win = true;
            }

            if (win)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                GameState.levelLose();
                Hide();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
