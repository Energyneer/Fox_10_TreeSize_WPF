using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task10.Model;

namespace Task10.ViewModel
{
    class ViewNode : INotifyPropertyChanged
    {
        public FileNode File { get; set; }
        //public string DisplayName { get; set; }
        public string Type { get; set; }
        //public string Picture { get; set; }
        //public string DisplaySize { get; set; }
        //public string DisplayAllocated { get; set; }
        public double ParentPercentage { get; set; }
        public string ExpButtonVisible { get; set; }
        public int Level { get; set; }
        public string LLL { get; set; }
        public bool Expanded { get; set; }


        private string picture;
        public string Picture
        {
            get { return picture; }
            set
            {
                picture = value;
                OnPropertyChanged();
            }
        }

        private string displaySize;
        public string DisplaySize
        {
            get { return displaySize; }
            set
            {
                displaySize = value;
                OnPropertyChanged();
            }
        }

        private string displayAllocated;
        public string DisplayAllocated
        {
            get { return displayAllocated; }
            set
            {
                displayAllocated = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    enum SizeFormat
    {
        AUTO,
        KiB,
        MiB,
        GiB
    }

    enum SortAttribute
    {
        NAME_UP,
        NAME_DOWN,
        SIZE_UP,
        SIZE_DOWN,
        ALLOCATED_UP,
        ALLOCATED_DOWN,
        PERCENTAGE_UP,
        PERCENTAGE_DOWN
    }
}
