using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task10.ViewModel
{
    class VisibleProperties : INotifyPropertyChanged
    {
        public VisibleProperties()
        {
            ResetColorAllSizeButtons();
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
