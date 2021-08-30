using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10.Model
{
    class FileNode
    {
        public List<FileNode> SubNodes { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public long Allocated { get; set; }
        public int SubFoldersCount { get; set; }
        public int SubFilesCount { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modificated { get; set; }
        public bool IsFile { get; set; }
    }
}
