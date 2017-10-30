using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator.Models.Database
{
    class CanAudit
    {
        public string DepartmentNr { get; set; }
        public string Name { get; set; }

        public CanAudit(string departmentNr, string name )
        {
            this.DepartmentNr = departmentNr;
            this.Name = name;
        }

    }
}
