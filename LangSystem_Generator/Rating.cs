using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator
{
    class Rating
    {
        public string AuditID { get; set; }
        public string zaklocaniePracy { get; set; }
        public string wyjasnienieZadania { get; set; }
        public string wyjasnieniaWatpliwosci { get; set; }
        public string obiektywizm {get; set;}
        public string profesjonalizm {get; set;}
        public string komunikatywnosc { get; set;}
        public string znajomoscDzialanosci {get; set;}
    
         public Rating(string auditID,string zaklocanie, string wyjasnienieZ, string wyjasnienieW, string obiektywizm, string profesjonalizm, string komunikatywnosc, string znajomosc )
        {
            this.AuditID = auditID;
            this.zaklocaniePracy = zaklocanie;
            this.wyjasnienieZadania = wyjasnienieZ;
            this.wyjasnieniaWatpliwosci = wyjasnienieW;
            this.obiektywizm = obiektywizm;
            this.profesjonalizm = profesjonalizm;
            this.komunikatywnosc = komunikatywnosc;
            this.znajomoscDzialanosci = znajomosc;
        }
    
    }

        
    
}
