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
        public string projectBuild = "v.0.2";
        public string projectDate = "26/07/2022";

        public Form1()
        {
            InitializeComponent();
            this.Text = projectTitle + " - " + projectBuild + " - " + projectDate;
        }

        string source = "";
        string destination = "";


        public void newName(string name)
        {

        

            if (source.Length > 0)
            {
                textBox1.Text = name;
                label5.Text = name;
            }

            if (checkBox1.Checked)
            {
                label5.Text +="_"+ date;
            }

        }




        private void button4_Click(object sender, EventArgs e)
        {

            source = selectPath();
            label1.Text = source;

            string[] folders = source.Split('\\');
            string foldername = folders[folders.Length - 1];
           string newfoldername = foldername + "_copy";
            
            newName(newfoldername);


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
        string date = DateTime.Now.ToString("yyyy-MM-dd");


        private void button1_Click(object sender, EventArgs e)
        {

        
            string customName = textBox1.Text;
            string destination1;
            if (customName.Length > 0)
            {

                 destination1 = destination + "\\" + customName;

                if (checkBox1.Checked)
                {
                    destination1 += "_" + date;
                }
            }
            else
            {
                 destination1 = destination + "\\" + date;
            }



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


            log.WriteLine("#Software: Windows C# project to performance data backups");
            log.WriteLine("#Version: "+projectBuild);
            log.WriteLine("#Date: "+ DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            //      label4.Text = "0/" + counter.ToString();

            
            createBackup(source, destination1, progressBar1, log);

        }


        static bool copied = false;
        static bool directory = true;


        static int counter = 0;
        static int progress = 0;
       

        public void createBackup(string source, string destination, ProgressBar progressbar, StreamWriter log)
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
              //  label4.Text = progress.ToString() + "/" + counter.ToString();

            }



            foreach (DirectoryInfo subDir in allDirs)
            {



                string newDestination = Path.Combine(destination, subDir.Name);

                log.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "]. The folder " + subDir.Name + " has been copied");

                progress++;

                progressbar.Value = progress;
               // label4.Text = progress.ToString() + "/" + counter.ToString();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            newName(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            newName(textBox1.Text);



        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
