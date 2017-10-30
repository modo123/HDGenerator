using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangSystem_Generator.Models.Database
{
    class Course
    {
        public string ID { get; set; }
        public string Language { get; set; }
        public int NrOfStudents { get; set; }
        public string Status { get; set; }

        public Course (string id, string language, int nrOfStudents, string status)
        {
            this.ID = id;
            this.Language = language;
            this.NrOfStudents = nrOfStudents;
            this.Status = status; 
        }
    }
}
