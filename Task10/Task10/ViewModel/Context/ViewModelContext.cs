using Services.Model;
using Services.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace Task10.ViewModel
{
    class ViewModelContext : INotifyPropertyChanged
    {
        public ObservableCollection<ViewNode> Nodes { get; set; }
        public SizeFormat CurrentSizeFormat { get; set; }
        public SortAttribute CurrentSortDirect { get; set; }
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
            SelectNewPath(Constants.DefaultFolder);
        }

        public void SelectFolder()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath == null || folderBrowser.SelectedPath.Length < 1)
                return;
            SelectNewPath(folderBrowser.SelectedPath);
        }

        private void SelectNewPath(string path)
        {
            FileNode rootNode = null;
            Thread thread = new Thread(() => rootNode = Service.GetAllNodes(path));
            thread.Start();
            thread.Join();

            ViewNode view = new ViewNode();
            view.Level = 0;
            WriteViewNodeParams(view, rootNode);
            view.MarginLeft = Constants.LeftMarginFirstLevel + Constants.MarginListNodeSfx;
            view.ExpButtonVisible = Visibility.Visible;

            Nodes.Clear();
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
            Sorting(files);
            int index = Nodes.IndexOf(view);

            foreach (FileNode f in files)
            {
                ViewNode node = new ViewNode();
                node.Level = view.Level + 1;
                WriteViewNodeParams(node, f);
                node.ParentPercentage = 100.0 * f.Size / parentSize;
                Nodes.Insert(++index, node);
            }
            view.Expanded = true;
            view.Picture = "/Static/CollapseAll_16x.png";
        }

        public void CollapseItem(ViewNode view)
        {
            List<FileNode> files = view.File.SubNodes;
            foreach (FileNode f in files)
            {
                ViewNode node = Nodes.First(item => item.File == f);
                if (node.Expanded)
                    CollapseItem(node);
                Nodes.Remove(node);
            }
            view.Expanded = false;
            view.Picture = "/Static/ExpandAll_16x.png";
        }

        public void CollapseAll()
        {
            if (Nodes.Count > 0)
                CollapseItem(Nodes.First());
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

        public void Sorting(List<FileNode> nodes)
        {
            List<FileNode> folders = nodes.Where(item => !item.IsFile).ToList();
            List<FileNode> files = nodes.Where(item => item.IsFile).ToList();

            switch (CurrentSortDirect)
            {
                case SortAttribute.NAME_DOWN:
                    folders.Sort((x, y) => x.Name.CompareTo(y.Name) * (-1));
                    files.Sort((x, y) => x.Name.CompareTo(y.Name) * (-1));
                    break;
                case SortAttribute.SIZE_UP:
                    folders.Sort((x, y) => x.Size.CompareTo(y.Size));
                    files.Sort((x, y) => x.Size.CompareTo(y.Size));
                    break;
                case SortAttribute.SIZE_DOWN:
                    folders.Sort((x, y) => x.Size.CompareTo(y.Size) * (-1));
                    files.Sort((x, y) => x.Size.CompareTo(y.Size) * (-1));
                    break;
                case SortAttribute.ALLOCATED_UP:
                    folders.Sort((x, y) => x.Allocated.CompareTo(y.Allocated));
                    files.Sort((x, y) => x.Allocated.CompareTo(y.Allocated));
                    break;
                case SortAttribute.ALLOCATED_DOWN:
                    folders.Sort((x, y) => x.Allocated.CompareTo(y.Allocated) * (-1));
                    files.Sort((x, y) => x.Allocated.CompareTo(y.Allocated) * (-1));
                    break;
                case SortAttribute.CREATED_UP:
                    folders.Sort((x, y) => x.Created.CompareTo(y.Created));
                    files.Sort((x, y) => x.Created.CompareTo(y.Created));
                    break;
                case SortAttribute.CREATED_DOWN:
                    folders.Sort((x, y) => x.Created.CompareTo(y.Created) * (-1));
                    files.Sort((x, y) => x.Created.CompareTo(y.Created) * (-1));
                    break;

                case SortAttribute.NAME_UP:
                default:
                    folders.Sort((x, y) => x.Name.CompareTo(y.Name));
                    files.Sort((x, y) => x.Name.CompareTo(y.Name));
                    break;
            }

            nodes.Clear();
            nodes.AddRange(folders);
            nodes.AddRange(files);
        }

        public void ChangeSort(SortAttribute sort)
        {
            List<ViewNode> expandedNodes = Nodes.Where(item => item.Expanded).ToList();
            CollapseAll();
            CurrentSortDirect = sort;
            foreach (ViewNode node in expandedNodes)
            {
                ExpandItem(node);
            }
            ChangeColumnColor(sort);
        }

        private void ChangeColumnColor(SortAttribute sort)
        {
            VProperties.SetDefaultColumnBackground();
            switch (sort)
            {
                case SortAttribute.NAME_UP:
                case SortAttribute.NAME_DOWN: VProperties.BGColumnName = Constants.ColumnSelect; break;
                case SortAttribute.SIZE_UP:
                case SortAttribute.SIZE_DOWN: VProperties.BGColumnSize = Constants.ColumnSelect; break;
                case SortAttribute.ALLOCATED_UP:
                case SortAttribute.ALLOCATED_DOWN: VProperties.BGColumnAllocated = Constants.ColumnSelect; break;
                case SortAttribute.CREATED_UP:
                case SortAttribute.CREATED_DOWN: VProperties.BGColumnCreated = Constants.ColumnSelect; break;
            }
        }

        private void WriteViewNodeParams(ViewNode view, FileNode file)
        {
            view.File = file;
            view.Type = file.IsFile ? Utilities.GetFileType(file.Name.Substring(file.Name.LastIndexOf('.') + 1)) : "Folder";
            view.MarginLeft = view.Level * Constants.LeftMarginOffset + Constants.MarginListNodeSfx;
            view.Picture = file.IsFile ? null : "/Static/ExpandAll_16x.png";
            view.ExpButtonVisible = file.IsFile ? Visibility.Hidden : Visibility.Visible;
            view.DisplaySize = Utilities.DisplaySize(file.Size, CurrentSizeFormat);
            view.DisplayAllocated = Utilities.DisplaySize(file.Allocated, CurrentSizeFormat);
            if (file.AccessBanned)
            {
                view.TextNameColor = Constants.TextNameAccessBanned;
                view.TextDataColor = Constants.TextDataAccessBanned;
            }
        }
    }
}
