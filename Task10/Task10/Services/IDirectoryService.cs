using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10.Model;

namespace Task10.Services
{
    interface IDirectoryService
    {
        FileNode GetAllNodes(string path);
    }
}
