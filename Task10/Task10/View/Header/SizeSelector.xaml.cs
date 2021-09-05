using System.Windows;
using System.Windows.Controls;
using Task10.ViewModel;

namespace Task10.View.Header
{
    public partial class SizeSelector : UserControl
    {
        private ViewModelContext Context
        {
            get
            {
                return this.DataContext as ViewModelContext;
            }
        }

        public SizeSelector()
        {
            InitializeComponent();
        }

        private void Button_Size_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SizeFormat reqFormat = ConvertStringToEnum(button.Name);
            if (reqFormat == Context.CurrentSizeFormat)
                return;

            Context.VProperties.ResetColorAllSizeButtons();
            Context.ChangeSizeFormat(reqFormat);
            Context.CurrentSizeFormat = reqFormat;
            ChangeButtonColor(reqFormat);
        }

        private SizeFormat ConvertStringToEnum(string buttonName)
        {
            switch (buttonName)
            {
                case "ButtonSizeKB": return SizeFormat.KiB;
                case "ButtonSizeMB": return SizeFormat.MiB;
                case "ButtonSizeGB": return SizeFormat.GiB;
                default: return SizeFormat.AUTO;
            }
        }

        private void ChangeButtonColor(SizeFormat format)
        {
            switch (format)
            {
                case SizeFormat.AUTO: Context.VProperties.BGButtonSizeAuto = Constants.SizeButtonsSelected; break;
                case SizeFormat.KiB: Context.VProperties.BGButtonSizeKiB = Constants.SizeButtonsSelected; break;
                case SizeFormat.MiB: Context.VProperties.BGButtonSizeMiB = Constants.SizeButtonsSelected; break;
                case SizeFormat.GiB: Context.VProperties.BGButtonSizeGiB = Constants.SizeButtonsSelected; break;
            }
        }
    }
}
