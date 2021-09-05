using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Task10.ViewModel
{
    class ColumnSizeProperties : INotifyPropertyChanged
    {
        public ColumnSizeProperties()
        {
            ColumnAllocatedWidth = Constants.MediumColumnWidth;
            ColumnSubFoldersWidth = Constants.SmallColumnWidth;
            ColumnSubFilesWidth = Constants.SmallColumnWidth;
            ColumnPercentParentWidth = Constants.MediumColumnWidth;
            ColumnAllocatedVisibility = Visibility.Visible;
            ColumnSubFoldersVisibility = Visibility.Visible;
            ColumnSubFilesVisibility = Visibility.Visible;
            ColumnPercentParentVisibility = Visibility.Visible;
        }

        private Visibility columnAllocatedVisibility;
        public Visibility ColumnAllocatedVisibility
        {
            get { return columnAllocatedVisibility; }
            set
            {
                columnAllocatedVisibility = value;
                OnPropertyChanged();
            }
        }

        private double columnAllocatedWidth;
        public double ColumnAllocatedWidth
        {
            get { return columnAllocatedWidth; }
            set
            {
                columnAllocatedWidth = value;
                OnPropertyChanged();
            }
        }

        private Visibility columnSubFoldersVisibility;
        public Visibility ColumnSubFoldersVisibility
        {
            get { return columnSubFoldersVisibility; }
            set
            {
                columnSubFoldersVisibility = value;
                OnPropertyChanged();
            }
        }

        private double columnSubFoldersWidth;
        public double ColumnSubFoldersWidth
        {
            get { return columnSubFoldersWidth; }
            set
            {
                columnSubFoldersWidth = value;
                OnPropertyChanged();
            }
        }

        private Visibility columnSubFilesVisibility;
        public Visibility ColumnSubFilesVisibility
        {
            get { return columnSubFilesVisibility; }
            set
            {
                columnSubFilesVisibility = value;
                OnPropertyChanged();
            }
        }

        private double columnSubFilesWidth;
        public double ColumnSubFilesWidth
        {
            get { return columnSubFilesWidth; }
            set
            {
                columnSubFilesWidth = value;
                OnPropertyChanged();
            }
        }

        private Visibility columnPercentParentVisibility;
        public Visibility ColumnPercentParentVisibility
        {
            get { return columnPercentParentVisibility; }
            set
            {
                columnPercentParentVisibility = value;
                OnPropertyChanged();
            }
        }

        private double columnPercentParentWidth;
        public double ColumnPercentParentWidth
        {
            get { return columnPercentParentWidth; }
            set
            {
                columnPercentParentWidth = value;
                OnPropertyChanged();
            }
        }

        public double ColumnAllocatedWidthOld { get; set; }
        public double ColumnSubFoldersWidthOld { get; set; }
        public double ColumnSubFilesWidthOld { get; set; }
        public double ColumnPercentParentWidthOld { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
