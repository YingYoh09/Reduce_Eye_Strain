using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20_20_20_Rule_Eyestrain
{
    public partial class Form1 : Form
    {
        private int Counter;
        private bool isBreak = false;
        private bool msgBoxShown = false, isExit = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (StartBtn.Text == "Start")
            {
                Counter = int.Parse(cycleTextBox.Text)*60;
            }
            else
            {
                StartBtn.Text = "Start";
            }


            timer1.Enabled = true;
            StartBtn.Enabled = false;
            PauseBtn.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Counter--;
            TimeLabel.Text = (Counter / 60).ToString() + " : " + (Counter % 60).ToString();
            if (Counter == 0)
            {
                if (!isBreak)
                {
                    Counter = int.Parse(BreakTimeTextBox.Text);
                    if (CycleCheckBox.Checked)
                    {
                        timer1.Enabled = false;
                        if (MessageBox.Show("Nghỉ em ei") == DialogResult.OK)
                            timer1.Enabled = true;
                        else timer1.Enabled = true;
                    }
                    
                }
                else
                {
                    if (BreakTimeCheckBox.Checked)
                    {
                        timer1.Enabled = false;
                        if (MessageBox.Show("Làm tiếp nào") == DialogResult.OK)
                            timer1.Enabled = true;
                        else timer1.Enabled = true;
                    }
                    StartBtn.PerformClick();
                }

                isBreak = !isBreak;
            }
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Text = "Resume";

            timer1.Enabled = false;
            StartBtn.Enabled = true;
            PauseBtn.Enabled = false;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                linkLabel1.LinkVisited = true;
                System.Diagnostics.Process.Start("https://www.facebook.com/YingYoh2k");
            }
            catch (Exception ex)
            {
                MessageBox.Show("https://www.facebook.com/YingYoh2k");
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Text = "Start";
            StartBtn.Enabled = true;
            PauseBtn.Enabled = false;
            timer1.Enabled = false;
            TimeLabel.Text = cycleTextBox.Text + " : " + BreakTimeTextBox.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
