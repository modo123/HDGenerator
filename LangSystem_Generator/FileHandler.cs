using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloGenerator
{
    public class FileHandler
    {
        private string _filePath;
        private string _defaultFile = "default.txt";

        public FileHandler(string filePath)
        {
            this._filePath = filePath;
        }

        public void WriteToFile(List<object> elobrekoObjects, string fileName = null)
        {
            using (var writer = new StreamWriter(this._filePath + (fileName ?? this._defaultFile)))
            {
                //elobrekoObjects writer.WriteLine();
            }
        }
    }
}
