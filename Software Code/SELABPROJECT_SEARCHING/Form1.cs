﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SELABPROJECT_SEARCHING
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string[] dirs = Directory.GetDirectories(@"E:\Fifth Semester Material\AI Lab\Python\Assignment\Assignment 2 Solving Problem by Searching", "*", SearchOption.TopDirectoryOnly);
                //MessageBox.Show("The number of directories starting with p is {0}.", dirs.Length.ToString());
                //foreach (string dir in dirs)
                //{
                //    MessageBox.Show(dir);
                //}

                //To search within a file
                //string[] dirs = (string[])Directory
                //.EnumerateFiles(@"E:\Upwork Projects Clients\Marcello\WebOffice Tool\src\app\main\pages\profile", "*.jsx")              // all txt files (put the right wildcard)
                //.Where(file => File
                //.ReadLines(file)                            // with at least one line
                //.Any(line => line.Contains("Select the user about which you want to set permissions for pages")))  // which contains stringToFind
                //.ToArray();
                //MessageBox.Show(dirs[0].ToString());


                //string rootdir = @"E:\Upwork Projects Clients\Marcello\WebOffice Tool\src\app\main\pages\profile";
                //string[] files = Directory.GetFileSystemEntries(rootdir, "*", SearchOption.AllDirectories);
                //MessageBox.Show(String.Join(Environment.NewLine, files));

                var textBoxText = textBox1.Text;

                string rootdir = @textBoxText;

                //// print list of files in the root directory and all its subdirectories
                //var files = Directory.EnumerateFiles(rootdir, "*", SearchOption.AllDirectories);
                //MessageBox.Show(String.Join(Environment.NewLine, files));

                //The text to be searched
                string txtToSearch = textBox2.Text;

                //File extension which files to search
                string fileExtension = "*."+textBox3.Text;

                if(textBoxText == "" || txtToSearch == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Please fill all the fields to search");
                    return;
                }

                // print list of directories and subdirectories
                var dirs = Directory.EnumerateDirectories(rootdir, "*", SearchOption.AllDirectories);
 //             MessageBox.Show(dirs.GetType().Name);
                for (int i = 0; i < dirs.Count(); i++)
                {
                    string str1 = dirs.ElementAt(i);
                    //MessageBox.Show("The string is at: "+str1);
                    string[] dirs2 = (string[])Directory
                    .EnumerateFiles(@str1, fileExtension)              // all txt files (put the right wildcard)
                    .Where(file => File
                    .ReadLines(file)                            // with at least one line
                    .Any(line => line.Contains(txtToSearch)))  // which contains stringToFind
                    .ToArray();
                    foreach (string dir in dirs2)
                    {
                        MessageBox.Show("Congrats! The File is found in directory "+"\n"+dir);
                    }
                    // do your stuff   
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Text Not Found or no file found with entered extension.", E.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}