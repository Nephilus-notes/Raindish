using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raindish.Models


{
    public class FileClass
    {
        public int FileId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public List<FileClass> Files { get; set; } = new List<FileClass>();


    }
}