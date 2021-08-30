using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task10.ViewModel
{
    class VisibleProperties : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string NoActiveSizeButtons;

        public VisibleProperties()
        {
            BGButtonSizeAuto = Constants.SizeButtonsSelected;
            //NoActiveSizeButtons = Brushes.Red.ToString();
            NoActiveSizeButtons = "AliceBlue";
            ResetColorAllSizeButtons();
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

        public double ColumnAllocatedOldWidth { get; set; }
        public double ColumnSubFoldersOldWidth { get; set; }
        public double ColumnSubFilesOldWidth { get; set; }
        public double ColumnPercentParentOldWidth { get; set; }

        public void ResetColorAllSizeButtons()
        {
            BGButtonSizeAuto = NoActiveSizeButtons;
            BGButtonSizeKiB = NoActiveSizeButtons;
            BGButtonSizeMiB = NoActiveSizeButtons;
            BGButtonSizeGiB = NoActiveSizeButtons;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
