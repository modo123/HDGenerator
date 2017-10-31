using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LangSystem_Generator.Models.Database;

namespace LangSystem_Generator
{
    class Generator
    {
        private static readonly string FirstNames = Path.GetDirectoryName(Application.ResourceAssembly.Location) + @"\listaimion.txt";
        private static readonly string LastNames = Path.GetDirectoryName(Application.ResourceAssembly.Location) + @"\listanazwisk.txt";
        private static readonly string BuisnessNames = Path.GetDirectoryName(Application.ResourceAssembly.Location) + @"\listanazwfirm.txt";
        private static readonly string TradehNames = Path.GetDirectoryName(Application.ResourceAssembly.Location) + @"\branze.txt";
        private static readonly string Cities = Path.GetDirectoryName(Application.ResourceAssembly.Location) + @"\listamiast.txt";
        private static readonly string Streets = Path.GetDirectoryName(Application.ResourceAssembly.Location) + @"\ulice.txt";
        private static readonly List<string> Languages = new List<string>
        {
            "Angielski",
            "Niemiecki",
            "Włoski",
            "Norweski",
            "Hiszpański",
            "Francuski",
            "Rosyjski"
        };

        private static readonly List<string> Departments = new List<string>
        {
            "Warszawa 01-464",
            "Gdańsk 80-761",
            "Łódź  90-001",
            "Kraków 31-403",
            "Lublin 20-218",
            "Szczucin 70-004",
            "Poznań  60-967",
            "Wrocław 51-416"
        };

        private static readonly List<string> IDOfDepartment = new List<string>
        {
            "WAW",
            "GDA",
            "LDZ",
            "KRK",
            "LBL",
            "SZC",
            "POZ",
            "WRO"
        };

        private static readonly List<string> IDLanguages = new List<string>
        {
            "ANG",
            "NMC",
            "WLO",
            "NOR",
            "HSP",
            "FRA",
            "ROS"
        };

        private static readonly List<string> Type = new List<string>
        {
            "Ogolny",
            "Profilowany"
        };

        private static readonly List<string> Status = new List<string>
        {
            "Sprzedany",
            "Niesprzedany"
        };

        private static readonly string DataBaseBulkPath = System.IO.Path.GetDirectoryName(Application.ResourceAssembly.Location);

        private static List<Department> departments = new List<Department>();
        private static List<CanAudit> canAudits = new List<CanAudit>();
        private static List<Audit> audits = new List<Audit>();
        private static List<Lector> lectors = new List<Lector>();
        private static List<Course> courses = new List<Course>();
        private static List<Buisness> buisnesses = new List<Buisness>();

        public static void generateDataBase(bool update)
        {
            Random _rand = new Random(new System.DateTime().Millisecond);

            int dayT1 = int.Parse(MainWindow.T1Date.Substring(0, 2));
            int monthT1 = int.Parse(MainWindow.T1Date.Substring(3, 2));
            int yearT1 = int.Parse(MainWindow.T1Date.Substring(6, 4));

            int dayT2 = int.Parse(MainWindow.T2Date.Substring(0, 2));
            int monthT2 = int.Parse(MainWindow.T2Date.Substring(3, 2));
            int yearT2 = int.Parse(MainWindow.T2Date.Substring(6, 4));

            Tuple<int, int, int> date0 = Tuple.Create(2003, 1, 1);
            Tuple<int, int, int> date1 = Tuple.Create(yearT1, monthT1, dayT1);
            Tuple<int, int, int> date2 = Tuple.Create(yearT2, monthT2, dayT2);

            List<string> streets = File.ReadAllLines(Streets).ToList();
            List<string> cities = File.ReadAllLines(Cities).ToList();
            List<string> buisnessNames = File.ReadAllLines(BuisnessNames).ToList();
            List<string> tradehNames = File.ReadAllLines(TradehNames).ToList();
            List<string> firstNames = File.ReadAllLines(FirstNames).ToList();
            List<string> lastNames = File.ReadAllLines(LastNames).ToList();

            int auditCounter = 0;

            #region T1
            if (!update)
            {
                #region GenerowanieFilii
                // Na podstawie tych dwóch list będziemy tworzyć adres XD
                

                int counter = 1;

                foreach (string department in Departments)
                {
                    string ID = IDOfDepartment[counter - 1].ToString() + "_" + counter.ToString();
                    string adress = Departments[counter - 1].ToString() + ", " + streets[_rand.Next(0, streets.Count())].ToString() + " " + _rand.Next(1, 513).ToString();

                    departments.Add(new Department(ID, adress));

                    counter++;
                }
                #endregion

                #region GenerowanieMożeAudyt

                for (int i = 0; i < departments.Count(); i++)
                {
                    int nrOfLanguages = _rand.Next(0, 7);

                    for (int j = 0; j < nrOfLanguages; j++)
                        canAudits.Add(new CanAudit(departments[i].DepartmentNr, Languages[j]));

                }

                #endregion

                // Smuteczek generowanie daty nie działa poprawnie :( 
                #region GenerowanieAudytu

                for (int i = 0; i < MainWindow.numOfAudits; i++)
                {
                    var date = Utilities.GeneratedDate(date0, date1);
                    string dateS = date.Item1.ToString() + "." + date.Item2.ToString() + "." + date.Item3.ToString();
                    string auditID = departments[_rand.Next(0,departments.Count())].DepartmentNr + "_AUD_" + auditCounter++.ToString();
                    int price = _rand.Next(500, 10000);
                    string type = Type[_rand.Next() % 2];
                    audits.Add(new Audit(auditID, price, dateS, type));
                }


                #endregion
                // Pesel nie działa
                #region GenerowanieLektora
                for (int i = 0; i < MainWindow.numOfLectors; i++ )
                {
                    long PESEL = Utilities.PESELGenerator();
                    string firstName = firstNames[_rand.Next(0, firstNames.Count())];
                    string lastName = lastNames[_rand.Next(0, lastNames.Count())];
                    string department = IDOfDepartment[_rand.Next(0, IDOfDepartment.Count())];
                    string language = Languages[_rand.Next(0, Languages.Count())];

                    lectors.Add(new Lector(PESEL, firstName, lastName, department, language));

                }


                #endregion
                // NIP nie działa
                #region GenerowanieFirm

                for(int i=0; i < MainWindow.numOfBusiness; i++)
                {  
                    string NIP = Utilities.NIPGenerator();
                    string name = buisnessNames[_rand.Next(0, buisnessNames.Count())];
                    string adress = cities[_rand.Next(0, cities.Count())].ToString() + ", " + streets[_rand.Next(0, streets.Count())].ToString() + " " + _rand.Next(1, 513).ToString();
                    string trade = tradehNames[_rand.Next(0, tradehNames.Count())];
                    int numOfWorkers = _rand.Next(5, 1000);

                    buisnesses.Add(new Buisness(NIP, name, adress, trade, numOfWorkers));
                   
                }



                #endregion


                #region GenerowanieKursów

                foreach (Audit audit in audits)
                {
                    if (MainWindow.numOfCourses == 0)
                        break;
                    counter = _rand.Next() % 4;
                    bool end = false;

                    for(int i = 0 ; i < counter; i++)
                    {
                        string courseID = audit.AuditNr + "_K" + i+1.ToString();
                        string language = Languages[_rand.Next(0, Languages.Count())];
                        int numOfStudents = _rand.Next(5, 550);
                        string status = Status[_rand.Next() % 2];

                        courses.Add(new Course(courseID, language, numOfStudents, status));

                        MainWindow.numOfCourses--;
                        if(MainWindow.numOfCourses == 0)
                        {
                            end = true;
                            break;
                        }

                        if(end)
                            break;
                    }
                }

                #endregion

                writeDataBase(false);

            }
            #endregion

            #region T2
            else
            {
                // Smuteczek generowanie daty nie działa poprawnie :( 
                #region GenerowanieAudytu2               

                for (int i = 0; i < MainWindow.numOfAudits; i++)
                {                   
                    var date = Utilities.GeneratedDate(date1, date2);
                    string dateS = date.Item1.ToString() + "." + date.Item2.ToString() + "." + date.Item3.ToString();
                    string auditID = departments[_rand.Next(0, departments.Count())].DepartmentNr + "_AUD_" + auditCounter++.ToString();
                    int price = _rand.Next(500, 10000);
                    string type = Type[_rand.Next() % 2];
                    audits.Add(new Audit(auditID, price, dateS, type));
                }


                #endregion
                //Pesel nie działa
                #region GenerowanieLektora2
                for (int i = 0; i < MainWindow.numOfLectors2; i++)
                {
                    long PESEL = Utilities.PESELGenerator();
                    string firstName = firstNames[_rand.Next(0, firstNames.Count())];
                    string lastName = lastNames[_rand.Next(0, lastNames.Count())];
                    string department = IDOfDepartment[_rand.Next(0, IDOfDepartment.Count())];
                    string language = Languages[_rand.Next(0, Languages.Count())];

                    lectors.Add(new Lector(PESEL, firstName, lastName, department, language));

                }


                #endregion
                // NIP nie działa 
                #region GenerowanieFirm2

                for (int i = 0; i < MainWindow.numOfBusiness2; i++)
                {
                    string NIP = Utilities.NIPGenerator();
                    string name = buisnessNames[_rand.Next(0, buisnessNames.Count())];
                    string adress = cities[_rand.Next(0, cities.Count())].ToString() + ", " + streets[_rand.Next(0, streets.Count())].ToString() + " " + _rand.Next(1, 513).ToString();
                    string trade = tradehNames[_rand.Next(0, tradehNames.Count())];
                    int numOfWorkers = _rand.Next(5, 1000);

                    buisnesses.Add(new Buisness(NIP, name, adress, trade, numOfWorkers));

                }



                #endregion

                #region GenerowanieKursów

                foreach (Audit audit in audits)
                {
                    if (MainWindow.numOfCourses2 == 0)
                        break;
                    int counter = _rand.Next() % 4;
                    bool end = false;

                    for (int i = 0; i < counter; i++)
                    {
                        string courseID = audit.AuditNr + "_K" + i+1.ToString();
                        string language = Languages[_rand.Next(0, Languages.Count())];
                        int numOfStudents = _rand.Next(5, 550);
                        string status = Status[_rand.Next() % 2];

                        courses.Add(new Course(courseID, language, numOfStudents, status));

                        MainWindow.numOfCourses2--;
                        if (MainWindow.numOfCourses2 == 0)
                        {
                            end = true;
                            break;
                        }

                        if (end)
                            break;
                    }

                }
                #endregion


                writeDataBase(true);
            }

            #endregion
         
        }

        private static void writeDataBase(bool update)
        {
            // Tabela języki - działa :D
            using (var jezyk = new StreamWriter(DataBaseBulkPath + @"\Jezyki" + ".bulk"))
                foreach (string language in Languages)
                    jezyk.WriteLine(language);

            // Tabela filie - działa pięknie :D
            using (var filia = new StreamWriter(DataBaseBulkPath + @"\Filie" + ".bulk"))
                foreach (Department department in departments)
                    filia.WriteLine(department.DepartmentNr.ToString() + " | " + department.Adress.ToString());

            //Tabela możeAudyt - 
            using (var mozeAudyt = new StreamWriter(DataBaseBulkPath + @"\MozeAudyt" + ".bulk"))
                foreach (CanAudit canAudit in canAudits)
                    mozeAudyt.WriteLine(canAudit.DepartmentNr.ToString() + " | " + canAudit.Name.ToString());
            //Tabela Audyt
            using (var audyt = new StreamWriter(DataBaseBulkPath + @"\Audyt" + (update ? "Update" : "") + ".bulk"))
                foreach (Audit audit in audits)
                    audyt.WriteLine(audit.AuditNr.ToString() + " | " + audit.Date.ToString() + " | " + audit.Price.ToString() + " | " + audit.Type.ToString());
            //Tabela Firma
            using (var firma = new StreamWriter(DataBaseBulkPath + @"\Firma" + (update ? "Update" : "") + ".bulk"))
                foreach (Buisness business in buisnesses)
                    firma.WriteLine(business.NIP.ToString() + " | " + business.Name.ToString() + " | " + business.Adress.ToString() + " | " + business.Trade.ToString() + " | " + business.WorkersNumber.ToString());
            //Tabela Lektor
            using (var lektor = new StreamWriter(DataBaseBulkPath + @"\Lektor" + (update ? "Update" : "") + ".bulk"))
                foreach (Lector lector in lectors)
                    lektor.WriteLine(lector.PESEL.ToString() + " | " + lector.FirstName.ToString() + " | " + lector.LastName.ToString() + " | " + lector.Department.ToString() + " | " + lector.Language.ToString());
            //Tabela Kurs
            using (var kurs = new StreamWriter(DataBaseBulkPath + @"\Kurs" + (update ? "Update" : "") + ".bulk"))
                foreach (Course course in courses)
                    kurs.WriteLine(course.ID.ToString() + " | " + course.Language.ToString() + " | " + course.NrOfStudents.ToString() + " | " + course.Status.ToString());
        }




    }
}
