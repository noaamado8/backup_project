using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace backup_project
{
    public partial class Form1 : Form
    {
        public string projectTitle = "Backup Project";
        public string projectBuild = "v.0.1";
        public string projectDate = "25/07/2022";

        public Form1()
        {
            InitializeComponent();
            this.Text = projectTitle + " - " + projectBuild + " - " + projectDate;
        }

        string source = "";
        string destination = "";




        private void button4_Click(object sender, EventArgs e)
        {

            source = selectPath();
            label1.Text = source;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            destination = selectPath();
            label2.Text = destination;
        }

        private string selectPath()
        {

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();


            DialogResult result = folderDialog.ShowDialog();


            string path = folderDialog.SelectedPath;

            return path;


        }


        private void button1_Click(object sender, EventArgs e)
        {

        

            //string source1 = source;

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string destination1 = destination + "\\" + date;

            Directory.CreateDirectory(destination1);

  

            ProgressBar progressBar1 = new ProgressBar();
            countFiles(source);

            /*
                   progressBar1.Location = new System.Drawing.Point(20, 20);
                   progressBar1.Name = "Progress Bar";

                   progressBar1.Width = 200;
                   progressBar1.Height = 30;*/

            progressBar1.Dock = DockStyle.Bottom;

            Controls.Add(progressBar1);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = counter;

            //label3.Text = "Copying " + counter + " files";

            StreamWriter log= new StreamWriter(destination1 + "\\log.txt");

            log.WriteLine("Iago&Noa. ~#Periko");

            createBackup(source, destination1, progressBar1, log);

        }




        static bool copied = false;
        static bool directory = true;


        static int counter = 0;
        static int progress = 0;

        static void createBackup(string source, string destination, ProgressBar progressbar, StreamWriter log)
        {


            var sourceDir = new DirectoryInfo(source);

            DirectoryInfo[] allDirs = sourceDir.GetDirectories();

            if (!directory) {
                Directory.CreateDirectory(destination);

            }
            else
            {
                directory = false;
            }

         


            foreach (FileInfo file in sourceDir.GetFiles())
            {
                string destinationPath = Path.Combine(destination, file.Name);

                file.CopyTo(destinationPath);

            

                log.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "].The file " + file.Name + " has been copied");

                progress++;
                      
                progressbar.Value = progress;

                              


            }






            foreach (DirectoryInfo subDir in allDirs)
            {



                string newDestination = Path.Combine(destination, subDir.Name);

                log.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "]. The folder " + subDir.Name + " has been copied");

                progress++;

                progressbar.Value = progress;
                createBackup(subDir.FullName, newDestination, progressbar, log);

              




            }




            if (!copied)
            {
                MessageBox.Show("Backup created correctly. \n ("+ counter+ " files copied)" );
                copied = true;

                log.Close();

               
            }



        }



        static void countFiles(string source)
        {

            var sourceDir = new DirectoryInfo(source);

            DirectoryInfo[] allDirs = sourceDir.GetDirectories();

            foreach (FileInfo file in sourceDir.GetFiles())
            {
                counter++;
            }


            foreach (DirectoryInfo subDir in allDirs)
            {
                countFiles(subDir.FullName);
                counter++;
            }



        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
