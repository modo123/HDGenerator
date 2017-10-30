using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator.Models.Database
{
    class Lector
    {
        public int PESEL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department {get; set;}
        public string Language {get; set;}

        public Lector(int pesel, string firstName, string lastName, string department, string language)
        {
            this.PESEL = pesel;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Department = department;
            this.Language = language;
        }
    }
}
