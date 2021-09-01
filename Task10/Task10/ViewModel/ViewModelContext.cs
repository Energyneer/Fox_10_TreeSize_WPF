using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10.Model;
using Task10.Services;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Task10.ViewModel
{
    class ViewModelContext : INotifyPropertyChanged
    {
        public ObservableCollection<ViewNode> Nodes { get; set; }
        public SizeFormat CurrentSizeFormat { get; set; }
        public VisibleProperties VProperties { get; set; }
        public ColumnSizeProperties SizeProperties { get; set; }
        private IDirectoryService Service { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModelContext()
        {
            Service = new DirectoryService();
            Nodes = new ObservableCollection<ViewNode>();
            VProperties = new VisibleProperties();
            SizeProperties = new ColumnSizeProperties();
            SelectNewPath(".");
        }

        public void SelectFolder()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath == null || folderBrowser.SelectedPath.Length < 1)
                return;
            VProperties.BusyIndicator = true;
            SelectNewPath(folderBrowser.SelectedPath);
            VProperties.BusyIndicator = false;
        }

        private void SelectNewPath(string path)
        {
            Nodes.Clear();
            //FileNode rootNode = service.GetAllNodes(path);
            FileNode rootNode = null;
            Thread thread = new Thread(() => rootNode = Service.GetAllNodes(path));
            thread.Start();
            thread.Join();


            ViewNode view = new ViewNode();
            view.File = rootNode;
            view.Type = "Folder";
            view.DisplaySize = Utilities.DisplaySize(rootNode.Size, CurrentSizeFormat);
            view.DisplayAllocated = Utilities.DisplaySize(rootNode.Allocated, CurrentSizeFormat);
            view.Level = 0;
            view.LLL = "0 0 0 0";
            view.Picture = "/Static/ExpandAll_16x.png";
            view.ExpButtonVisible = "Visible";
            Nodes.Add(view);

            ExpandItem(view);
        }

        public void ClickExpCollapseButton(ViewNode view)
        {
            if (!view.Expanded)
            {
                ExpandItem(view);
                view.Expanded = true;
            }
            else
            {
                CollapseItem(view);
                view.Expanded = false;
            }
        }

        public void ExpandItem(ViewNode view)
        {
            long parentSize = view.File.Size;
            List<FileNode> files = view.File.SubNodes;

            int index = Nodes.IndexOf(view);

            foreach (FileNode f in files)
            {
                ViewNode node = new ViewNode();
                node.File = f;
                node.Type = f.IsFile ? Utilities.GetFileType(f.Name.Substring(f.Name.LastIndexOf('.') + 1)) : "Folder";
                node.Level = view.Level + 1;
                node.LLL = node.Level * 10 + " 0 0 0";
                node.Picture = f.IsFile ? null : "/Static/ExpandAll_16x.png";
                node.ExpButtonVisible = f.IsFile ? "Hidden" : "Visible";
                node.ParentPercentage = 100.0 * f.Size / parentSize;
                node.DisplaySize = Utilities.DisplaySize(f.Size, CurrentSizeFormat);
                node.DisplayAllocated = Utilities.DisplaySize(f.Allocated, CurrentSizeFormat);
                Nodes.Insert(++index, node);
            }

            view.Picture = "/Static/CollapseAll_16x.png";
        }

        public void CollapseItem(ViewNode view)
        {
            List<FileNode> files = view.File.SubNodes;
            foreach (FileNode f in files)
            {
                Nodes.Remove(Nodes.First(item => item.File == f));
            }
            view.Picture = "/Static/ExpandAll_16x.png";
        }

        public void ChangeSizeFormat(SizeFormat format)
        {
            foreach (ViewNode node in Nodes)
            {
                node.DisplaySize = Utilities.DisplaySize(node.File.Size, format);
                node.DisplayAllocated = Utilities.DisplaySize(node.File.Allocated, format);
            }
            CurrentSizeFormat = format;
        }

        public void Sorting(SortAttribute sort)
        {
            //
        }
    }
}
