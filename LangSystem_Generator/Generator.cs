using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


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
            "Warszawa",
            "Gdańsk",
            "Łódź",
            "Kraków",
            "Lublin",
            "Szczecin",
            "Poznań",
            "Wrocław"
        };

        //private static void

    }
}
