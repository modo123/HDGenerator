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
            if (!StartupCheck())
            {
                InfoLabel.FontSize = 14;
                InfoLabel.Content = "Wystąpił błąd :( Problem z podanymi danymi";
                return;
            }
            InfoLabel.FontSize = 26;
            Task.Run(() =>
            {
                Dispatcher.Invoke(
                    () =>
                    {
                        NumOfAudits.IsEnabled = false;
                        NumOfAudits2.IsEnabled = false;
                        NumOfBusiness.IsEnabled = false;
                        NumOfBusiness2.IsEnabled = false;
                        NumOfLectors.IsEnabled = false;
                        NumOfLectors2.IsEnabled = false;
                        NumofDepartaments.IsEnabled = false;
                        NumofDepartaments2.IsEnabled = false;
                        NumOfLanguages.IsEnabled = false;
                        NumOfLanguages2.IsEnabled = false;
                        generate.IsEnabled = false;
                        T1.IsEnabled = false;
                        T2.IsEnabled = false;

                        InfoLabel.Content = "Proszę czekać";
                    });
               
                Generator.generateDataBase(false);
                Generator.generateDataBase(true);
          
                Dispatcher.Invoke(
                    () =>
                    {
                        NumOfAudits.IsEnabled = true;
                        NumOfAudits2.IsEnabled = true;
                        NumOfBusiness.IsEnabled = true;
                        NumOfBusiness2.IsEnabled = true;
                        NumOfLectors.IsEnabled = true;
                        NumOfLectors2.IsEnabled = true;
                        NumofDepartaments.IsEnabled = true;
                        NumofDepartaments2.IsEnabled = true;
                        NumOfLanguages.IsEnabled = true;
                        NumOfLanguages2.IsEnabled = true;
                        generate.IsEnabled = true;
                        T1.IsEnabled = true;
                        T2.IsEnabled = true;
                        
                        InfoLabel.Content = "Zrobione";
                    });
            });

            
        }

        public bool StartupCheck()
        {
            if (!int.TryParse(NumOfAudits.Text, out numOfAudits))
                return false;
            if (!int.TryParse(NumOfAudits2.Text, out numOfAudits2))
                return false;
            if (!int.TryParse(NumOfBusiness.Text, out numOfBusiness))
                return false;
            if (!int.TryParse(NumOfBusiness2.Text, out numOfBusiness2))
                return false;
            if (!int.TryParse(NumOfLectors.Text, out numOfLectors))
                return false;
            if (!int.TryParse(NumOfLectors2.Text, out numOfLectors2))
                return false;
            if (!int.TryParse(NumofDepartaments.Text, out numofDepartaments))
                return false;
            if (!int.TryParse(NumofDepartaments2.Text, out numofDepartaments2))
                return false;
            if (!int.TryParse(NumOfLanguages.Text, out numOfLanguages))
                return false;
            if (!int.TryParse(NumOfLanguages2.Text, out numOfLanguages2))
                return false;
            
            T1Date = T1.Text;
            T2Date = T2.Text;

            return true;
        }

    
    }
}
