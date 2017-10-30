using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator.Models.Database
{
    class Department
    {
        public string DepartmentNr { get; set; }
        public string Adress { get; set; }

        public Department (string departmentNr, string adress )
        {
            this.DepartmentNr = departmentNr;
            this.Adress = adress;
        }
    }
}
