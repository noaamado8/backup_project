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
using System.Diagnostics;


namespace backup_project
{
    public partial class Form1 : Form
    {
        public string projectTitle = "Backup Project";
        public string projectBuild = "v.0.4";
        public string projectDate = "26/07/2022";

        string source = "";
        string destination = "";

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        static bool copied = false;
        static bool directory = true;
        static bool exception = false;
        string logPath = "";
        static int counter = 0;
        static int progress = 0;
        StreamWriter log;
        ProgressBar progressBar1 = new ProgressBar();
        

        public Form1()
        {
            InitializeComponent();
            this.Text = projectTitle + " - " + projectBuild + " - " + projectDate;
        }

        public void newName(string name)
        {

            if (source.Length > 0)
            {
                input_folder_name.Text = name;
                folder_name_label.Text = name;
                if (add_date_button.Checked)
                {
                    folder_name_label.Text += "_" + date;
                }
            }
        }


        private void source_button_Click(object sender, EventArgs e)
        {

            source = selectPath();
            source_label.Text = source;

            string[] folders = source.Split('\\');
            string foldername = folders[folders.Length - 1];
            string newfoldername = foldername + "_copy";

            newName(newfoldername);

        }

        private void destination_button_Click(object sender, EventArgs e)
        {
            destination = selectPath();
            destination_label.Text = destination;
        }

        private string selectPath()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            string path = folderDialog.SelectedPath;
            return path;
        }


        private void backup_button_Click(object sender, EventArgs e)
        {
            string customName = input_folder_name.Text;
            string destination1;

            if (customName.Length > 0)
            {
                destination1 = "";
                if (destination.Length > 0)
                {
                    if (empty_destination.Checked)
                    {
                        emptyFolder(destination);
                        MessageBox.Show("Destination folder emptied correctly");
                    }
                    destination1 = destination + "\\" + customName;
                    DirectoryInfo copy = new DirectoryInfo(destination1);
                    Directory.CreateDirectory(destination1);

                    logPath = destination1 + "\\log.txt";

                    log = new StreamWriter(logPath);
                    if (log.Equals(StreamWriter.Null))
                    {
                        log = new StreamWriter(logPath);

                    }
                    log.WriteLine("#Software: Windows C# project to performance data backups");
                    log.WriteLine("#Version: " + projectBuild);
                    log.WriteLine("#Date: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                    if (add_date_button.Checked)
                    {
                        destination1 += "_" + date;
                    }

                }
                else
                {
                    destination1 = destination + "\\" + date;
                }
              
                progressBar1.Dock = DockStyle.Bottom;

                Controls.Add(progressBar1);
                progressBar1.Minimum = 0;
                progressBar1.Maximum = counter;

                if (source.Length > 0 && destination.Length>0 && destination1.Length > 0 )
                {
                    countFiles(source);
                    createBackup(source, destination1);
                    if (!exception)
                    {
                        MessageBox.Show("Backup created correctly. \n  (" + counter + " files copied)");
                    }
               }
                else
                {
                    MessageBox.Show("Source folder or destination folder not be selected");
                }

            }
       
            if (shutdown.Checked)
            {
                Process.Start("shutdown", "/s /t 0");
            }
                        
        }
        
        public void createBackup(string source, string dest)
        {
            var sourceDir = new DirectoryInfo(source);

            DirectoryInfo[] allDirs = sourceDir.GetDirectories();
               
            if (!directory)
            {
                try
                {
                    Directory.CreateDirectory(dest);
                }catch(Exception e) {
                    string error = "The directory "+ dest+ " couldn't been created\n"+ e.ToString();
                    MessageBox.Show(error);
                    log.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "][ERROR] Error:" + error);
                    exception = true;
                }

            }
            else
            {
                directory = false;
            }
            foreach (FileInfo file in sourceDir.GetFiles())
            {
                string destinationPath = Path.Combine(dest, file.Name);

                try
                {
                    file.CopyTo(destinationPath);
                    log.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "] The file " + file.Name + " has been copied from " + source + " to " + destination);

                }
                catch (Exception e)
                {
                    string error = "\nNo se ha podido copiar el fichero " + file.FullName + "\n" + e.ToString();
                    MessageBox.Show(error);
                    log.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "][ERROR] The file " + file.Name + " couldn't be copied from " + source + " to " + destination+". Error: "+error);
                    exception = true;
                }
                               
                progress++;
                if (progress > progressBar1.Maximum && progress < progressBar1.Minimum)
                {
                    progressBar1.Value = progress;
                }

            }
            
            foreach (DirectoryInfo subDir in allDirs)
            {
                string newDestination = Path.Combine(dest, subDir.Name);

                log.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "]. The folder " + subDir.Name + " has been copied");

                progress++;
                if (progress < progressBar1.Maximum && progress > progressBar1.Minimum)
                {
                    progressBar1.Value = progress;
                }
                createBackup(subDir.FullName, newDestination);
            }
            if (!copied)
            {
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

        void emptyFolder(string dirDel)
        {
            DirectoryInfo delDir = new DirectoryInfo(dirDel);
            
            DirectoryInfo[] allDirs = delDir.GetDirectories();

            foreach (FileInfo file in delDir.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception e)
                {
                    string error = "The file "+ file.ToString() +"\n" + e.ToString();
                    MessageBox.Show(error);
                    log.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "][ERROR] Error:" + error);
                    exception = true;
                }

            }

            if (log != null && !log.Equals(StreamWriter.Null))
            {
                log.Close();
            }

            foreach (DirectoryInfo subDir in allDirs)
            {       
                    subDir.Delete(true);
            }
        }




        private void add_date_CheckedChanged(object sender, EventArgs e)
        {
            newName(input_folder_name.Text);
        }

        private void input_folder_name_TextChanged(object sender, EventArgs e)
        {

            newName(input_folder_name.Text);



        }


    }
}
