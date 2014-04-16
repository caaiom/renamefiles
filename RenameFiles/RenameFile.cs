using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameFiles
{
    public class RenameFile
    {
        public String FilePath { get; set; }
        public String FilePart { get; set; }
        public String FileNewPart { get; set; }

        public enum InputStep
        { 
            Path = 0,
            Part = 1,
            NewPart = 2
        }
    }
}
