using Services.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Task10.ViewModel
{
    class ViewNode : INotifyPropertyChanged
    {
        public FileNode File { get; set; }
        public string Type { get; set; }
        public double ParentPercentage { get; set; }
        public int Level { get; set; }
        public string MarginLeft { get; set; }
        public bool Expanded { get; set; }

        public ViewNode()
        {
            TextNameColor = Constants.TextNameOK;
            TextDataColor = Constants.TextDataOK;
        }

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

        private string textNameColor;
        public string TextNameColor
        {
            get { return textNameColor; }
            set
            {
                textNameColor = value;
                OnPropertyChanged();
            }
        }

        private string textDataColor;
        public string TextDataColor
        {
            get { return textDataColor; }
            set
            {
                textDataColor = value;
                OnPropertyChanged();
            }
        }

        private Visibility expButtonVisible;
        public Visibility ExpButtonVisible
        {
            get { return expButtonVisible; }
            set
            {
                expButtonVisible = value;
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
        CREATED_UP,
        CREATED_DOWN
    }
}
