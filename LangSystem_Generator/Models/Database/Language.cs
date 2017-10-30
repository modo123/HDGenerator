using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator.Models.Database
{
    class Language
    {
        string Name { get; set; }
        
        public Language (string name)
        {
            this.Name = name;
        }
    }
}
