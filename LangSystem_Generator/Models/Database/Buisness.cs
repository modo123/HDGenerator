using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator.Models.Database
{
    class Buisness
    {
        public string NIP { get; set; }
        public string Name { get; set; }
        public string Adress { get; set;}
        public string Trade { get; set; }
        public int WorkersNumber { get; set; }

        public Buisness(string nip, string name, string adress, string trade, int workersNumber)
        {
            this.NIP = nip;
            this.Name = name;
            this.Adress = adress;
            this.Trade = trade;
            this.WorkersNumber = workersNumber;
        }
    }
}
