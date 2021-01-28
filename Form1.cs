using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public partial class Form1 : Form
    {
        string torrentname;
        string outputfromtorrent = "After searching links will appear here";
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = outputfromtorrent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

            //strCommand is path and file name of command to run
            pProcess.StartInfo.FileName = "cmd";

            //strCommandParameters are parameters to pass to program
            pProcess.StartInfo.Arguments = "/c node index " + torrentname;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.UseShellExecute = false;

            //Set output of program to be written to process output stream
            pProcess.StartInfo.RedirectStandardOutput = true;

            //Optional
            pProcess.StartInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory();

            //Start the process
            pProcess.Start();

            //Get program output
            string strOutput = pProcess.StandardOutput.ReadToEnd().ToString();
            
            richTextBox1.Text = strOutput;
            //Wait for process to finish
            pProcess.WaitForExit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            torrentname = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
