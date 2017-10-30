﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LangSystem_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        } 
       
        public static string T1Date;
        public static string T2Date;

        public static int numOfLectors;
        public static int numofDepartaments;
        public static int numOfBusiness;
        public static int numOfAudits;
        public static int numOfCourses;
        public static int numOfLanguages;

     
        public void Generate_Click(object sender, RoutedEventArgs e)
        {
            //int numberDataToGenerate = int.Parse(NumberDataToGenerate.Text);
            //string typeOfData = ToGenerate.Text;
            T1Date = T1.Text;
            T2Date = T2.Text;

            numOfAudits = int.Parse(NumOfAudits.Text);

            Generator.generateDataBase(false);
        }
    }
}
