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
    public partial class Form4 : Form
    {
        private Button button1;
        private Label label1;
        private ProgressBar progressBar1;
        private Timer timer1;
        private IContainer components;
        private Label label2;
        private PictureBox pictureBox1;
        private ImageList imageList1;
        private DateTimePicker dateTimePicker1;

        public Form4()
        {
            InitializeComponent();
            label1.Text = GameState.currentFile.fileName;

            timer1.Interval = GameState.tickTime;
            timer1.Start();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.dateTimePicker1.Location = new System.Drawing.Point(460, 310);
            this.dateTimePicker1.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(448, 45);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.button1.Location = new System.Drawing.Point(12, 636);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1321, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.label1.Location = new System.Drawing.Point(12, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "File";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(78, 69);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1189, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 20F);
            this.label2.Location = new System.Drawing.Point(104, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1125, 152);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RansomwareGame.Properties.Resources.image0;
            this.pictureBox1.Location = new System.Drawing.Point(556, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(499, 501);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(1345, 767);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form4";
            this.Text = "When did you make that file again?";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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

            if (progressBar1.Value == GameState.waitTime)
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
