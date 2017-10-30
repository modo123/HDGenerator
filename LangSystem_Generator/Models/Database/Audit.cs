using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator.Models.Database
{
    class Audit
    {
        public string AuditNr { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        
        public Audit (string auditNr, int price, string date, string type)
        {
            this.AuditNr = auditNr;
            this.Price = price;
            this.Date = date;
            this.Type = type;
        }
       
    }
}
