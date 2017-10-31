using System;
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

        public static int numOfLectors2;
        public static int numofDepartaments2;
        public static int numOfBusiness2;
        public static int numOfAudits2;
        public static int numOfCourses2;
        public static int numOfLanguages2;

     
        public void Generate_Click(object sender, RoutedEventArgs e)
        {
            //int numberDataToGenerate = int.Parse(NumberDataToGenerate.Text);
            //string typeOfData = ToGenerate.Text;
            T1Date = T1.Text;
            T2Date = T2.Text;

            numOfAudits = int.Parse(NumOfAudits.Text);
            numOfAudits2 = int.Parse(NumOfAudits2.Text);

            numOfLectors = int.Parse(NumOfLectors.Text);
            numOfLectors2 = int.Parse(NumOfLectors2.Text);

            numofDepartaments = int.Parse(NumofDepartaments.Text);
            numofDepartaments2 = int.Parse(NumofDepartaments2.Text);

            numOfBusiness = int.Parse(NumOfBusiness.Text);
            numOfBusiness2 = int.Parse(NumOfBusiness2.Text);

            numOfCourses = int.Parse(NumOfCourses.Text);
            numOfCourses2 = int.Parse(NumOfCourses2.Text);

            numOfLanguages = int.Parse(NumOfLanguages.Text);
            numOfLanguages2 = int.Parse(NumOfLanguages2.Text);


            Generator.generateDataBase(false);
            Generator.generateDataBase(true);
        }
    }
}
