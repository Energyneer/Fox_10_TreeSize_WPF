using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Task10.ViewModel
{
    class VisibleProperties : INotifyPropertyChanged
    {
        public VisibleProperties()
        {
            ResetColorAllSizeButtons();
            SetDefaultColumnBackground();
            BGButtonSizeAuto = Constants.SizeButtonsSelected;
        }

        private string bgButtonSizeAuto;
        public string BGButtonSizeAuto
        {
            get { return bgButtonSizeAuto; }
            set
            {
                bgButtonSizeAuto = value;
                OnPropertyChanged();
            }
        }

        private string bgButtonSizeKiB;
        public string BGButtonSizeKiB
        {
            get { return bgButtonSizeKiB; }
            set
            {
                bgButtonSizeKiB = value;
                OnPropertyChanged();
            }
        }

        private string bgButtonSizeMiB;
        public string BGButtonSizeMiB
        {
            get { return bgButtonSizeMiB; }
            set
            {
                bgButtonSizeMiB = value;
                OnPropertyChanged();
            }
        }

        private string bgButtonSizeGiB;
        public string BGButtonSizeGiB
        {
            get { return bgButtonSizeGiB; }
            set
            {
                bgButtonSizeGiB = value;
                OnPropertyChanged();
            }
        }

        private string bgColumnName;
        public string BGColumnName
        {
            get { return bgColumnName; }
            set
            {
                bgColumnName = value;
                OnPropertyChanged();
            }
        }

        private string bgColumnSize;
        public string BGColumnSize
        {
            get { return bgColumnSize; }
            set
            {
                bgColumnSize = value;
                OnPropertyChanged();
            }
        }

        private string bgColumnAllocated;
        public string BGColumnAllocated
        {
            get { return bgColumnAllocated; }
            set
            {
                bgColumnAllocated = value;
                OnPropertyChanged();
            }
        }

        private string bgColumnCreated;
        public string BGColumnCreated
        {
            get { return bgColumnCreated; }
            set
            {
                bgColumnCreated = value;
                OnPropertyChanged();
            }
        }

        private bool busyIndicator;
        public bool BusyIndicator
        {
            get { return busyIndicator; }
            set
            {
                busyIndicator = value;
                OnPropertyChanged();
            }
        }

        public void ResetColorAllSizeButtons()
        {
            BGButtonSizeAuto = Constants.SizeButtonsUnSelect;
            BGButtonSizeKiB = Constants.SizeButtonsUnSelect;
            BGButtonSizeMiB = Constants.SizeButtonsUnSelect;
            BGButtonSizeGiB = Constants.SizeButtonsUnSelect;
        }

        public void SetDefaultColumnBackground()
        {
            BGColumnName = Constants.ColumnUnSelect;
            BGColumnSize = Constants.ColumnUnSelect;
            BGColumnAllocated = Constants.ColumnUnSelect;
            BGColumnCreated = Constants.ColumnUnSelect;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
