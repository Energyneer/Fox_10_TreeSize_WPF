using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Task10.Model;

namespace Task10.Services
{
    class DirectoryService : IDirectoryService
    {
        public FileNode GetAllNodes(string path)
        {
            if (path == null || path.Length < 1)
                throw new ArgumentException();

            DirectoryInfo dInfo = new DirectoryInfo(path);
            return GetSubDirectory(dInfo);
        }

        private FileNode GetSubDirectory(DirectoryInfo dInfo)
        {
            FileNode node = new FileNode();

            // directories
            AddSubDirectories(dInfo, node);

            // files
            AddSubFiles(dInfo, node);

            // calculating
            Calculating(dInfo, node);

            return node;
        }

        private void AddSubDirectories(DirectoryInfo source, FileNode dest)
        {
            dest.SubNodes ??= new List<FileNode>();

            foreach (DirectoryInfo directory in source.GetDirectories())
            {
                FileNode node = GetSubDirectory(directory);
                dest.SubNodes.Add(node);
                dest.Size += node.Size;
                dest.Allocated += node.Allocated;
                dest.SubFoldersCount += node.SubFoldersCount;
                dest.SubFilesCount += node.SubFilesCount;
                dest.SubFoldersCount++;
            }
        }

        private void AddSubFiles(DirectoryInfo sourse, FileNode dest)
        {
            dest.SubNodes ??= new List<FileNode>();

            foreach (FileInfo file in sourse.GetFiles())
            {
                FileNode node = GetFileNodeInformation(file);
                dest.SubNodes.Add(node);
                dest.Size += node.Size;
                dest.Allocated += node.Allocated;
                dest.SubFilesCount++;
            }
        }

        private FileNode GetFileNodeInformation(FileInfo fInfo)
        {
            FileNode node = new FileNode();
            node.Name = fInfo.Name;
            node.Size = fInfo.Length;
            node.Allocated = GetFileSizeOnDisk(fInfo.FullName);
            node.IsFile = true;

            return node;
        }


        private void Calculating(DirectoryInfo sourse, FileNode dest)
        {
            dest.Name = sourse.Name;
        }














        public static long GetFileSizeOnDisk(string file)
        {
            FileInfo info = new FileInfo(file);
            uint dummy, sectorsPerCluster, bytesPerSector;
            int result = GetDiskFreeSpaceW(info.Directory.Root.FullName, out sectorsPerCluster, out bytesPerSector, out dummy, out dummy);
            if (result == 0) throw new Win32Exception();
            uint clusterSize = sectorsPerCluster * bytesPerSector;
            uint hosize;
            uint losize = GetCompressedFileSizeW(file, out hosize);
            long size;
            size = (long)hosize << 32 | losize;
            return ((size + clusterSize - 1) / clusterSize) * clusterSize;
        }

        [DllImport("kernel32.dll")]
        static extern uint GetCompressedFileSizeW([In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
           [Out, MarshalAs(UnmanagedType.U4)] out uint lpFileSizeHigh);

        [DllImport("kernel32.dll", SetLastError = true, PreserveSig = true)]
        static extern int GetDiskFreeSpaceW([In, MarshalAs(UnmanagedType.LPWStr)] string lpRootPathName,
           out uint lpSectorsPerCluster, out uint lpBytesPerSector, out uint lpNumberOfFreeClusters,
           out uint lpTotalNumberOfClusters);
    }
}
