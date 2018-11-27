﻿using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace SDAnalyze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TreeViewNode> TreeViewItems { get; set; }
        public SeriesCollection ChartSeries { get; set; }

        private SplashScreen _SplashScreen = new SplashScreen();
        
        public MainWindow()
        {
            InitializeComponent();
            ChartSeries = new SeriesCollection();


            _SplashScreen.Show();                   
            this.Hide();

            BackgroundWorker directoryLoader = new BackgroundWorker();
            //Gather directories in separate thread so the UI thread isn't blocked (so the SplashScreen gif works)
            directoryLoader.DoWork += (s, e) => { GetDirectoryTree(); }; 

            //After worker is done, show the main window and update the tree view binding
            directoryLoader.RunWorkerCompleted += (s, e) => { tvView.GetBindingExpression(TreeView.ItemsSourceProperty).UpdateTarget(); _SplashScreen.Close(); this.ShowDialog(); }; 
            directoryLoader.RunWorkerAsync();                                              
        }

        /// <summary>
        /// Gets the directory tree from every detected drive
        /// </summary>
        private void GetDirectoryTree()
        {
            ObservableCollection<TreeViewNode> objItems = new ObservableCollection<TreeViewNode>();

            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                objItems.Add(new TreeViewNode { Title = drive.Name, ChildNodes = GetDirectories(drive.Name), DirectoryPath = drive.Name });
            }

            TreeViewItems = objItems;         
        }

        /// <summary>
        /// Gets all sub directories for a root directory
        /// </summary>
        /// <param name="RootDirectory"></param>
        /// <returns></returns>
        private ObservableCollection<TreeViewNode> GetDirectories(string RootDirectory)
        {           
            try
            {
                ObservableCollection<TreeViewNode> objDirectories = new ObservableCollection<TreeViewNode>();

                var directories = Directory.GetDirectories(RootDirectory);
                foreach (var directory in directories)
                {
                    objDirectories.Add(new TreeViewNode { Title = Path.GetFileName(directory), ChildNodes = GetDirectories(directory), DirectoryPath = directory });
                }

                if (objDirectories.Count > 0)
                {
                    return objDirectories;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception)
            {
                return null;
            }           
        }

        /// <summary>
        /// Analyzes the size of all sub directories
        /// </summary>
        /// <param name="RootDirectory"></param>
        private void AnalyzeSubDirectories(string RootDirectory)
        {
            Dictionary<string, long> subDirectories = new Dictionary<string, long>();

            var directories = Directory.GetDirectories(RootDirectory);
            foreach (var directory in directories)
            {
                subDirectories.Add(Path.GetFileName(directory), AnalyzeDirectorySize(new DirectoryInfo(directory)));
            }

        }

        /// <summary>
        /// Returns the size of a directory
        /// </summary>
        /// <param name="DirInfo"></param>
        /// <returns></returns>
        private long AnalyzeDirectorySize(DirectoryInfo DirInfo)
        {
            long size = 0;

            //Add the size of all files in current directory
            var files = DirInfo.GetFiles();
            foreach (var file in files)
            {
                size += file.Length;
            }

            //Add the size of all files in sub directories
            var subDirectories = DirInfo.GetDirectories();
            foreach (var directory in subDirectories)
            {
                size += AnalyzeDirectorySize(DirInfo);
            }
            return size;
        }

        /// <summary>
        /// Analyzes the in the chart selected directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="chartPoint"></param>
        private void Chart_OnDataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {
            //TODO: OnClick analyze clicked directory and select in TreeView
        }

        /// <summary>
        /// Starts the analysis of a selected directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            if (tvView.SelectedItem == null)
            {
                MessageBox.Show("Please select a path from the explorer first!");
            }
            else
            {
                TreeViewNode currentNode = sender as TreeViewNode;
                AnalyzeSubDirectories(currentNode.DirectoryPath);
            }
        }
    }
}
