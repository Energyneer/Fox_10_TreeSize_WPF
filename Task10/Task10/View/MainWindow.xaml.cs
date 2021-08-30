using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task10.ViewModel;

namespace Task10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModelContext context;

        public MainWindow()
        {
            InitializeComponent();
            context = new ViewModelContext();
            DataContext = context;
            context.VProperties.BGButtonSizeAuto = Constants.SizeButtonsSelected;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            context.ClickExpCollapseButton(button.DataContext as ViewNode); 
        }

        private void Button_Size_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SizeFormat reqFormat = ConvertStringToEnum(button.Name);
            if (reqFormat == context.CurrentSizeFormat)
                return;

            context.VProperties.ResetColorAllSizeButtons();
            context.ChangeSizeFormat(reqFormat);
            context.CurrentSizeFormat = reqFormat;
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
                case SizeFormat.AUTO: context.VProperties.BGButtonSizeAuto = Constants.SizeButtonsSelected; break;
                case SizeFormat.KiB: context.VProperties.BGButtonSizeKiB = Constants.SizeButtonsSelected; break;
                case SizeFormat.MiB: context.VProperties.BGButtonSizeMiB = Constants.SizeButtonsSelected; break;
                case SizeFormat.GiB: context.VProperties.BGButtonSizeGiB = Constants.SizeButtonsSelected; break;
            }
        }

        private void OpenFile_Click_1(object sender, RoutedEventArgs e)
        {
            context.SelectFolder();
        }

        // ----------

        private void CheckBoxVisibleAllocated(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.IsChecked.HasValue)
            {
                if (box.IsChecked.Value)
                {
                    ColumnAllocated.Width = context.VProperties.ColumnAllocatedOldWidth;
                    HeaderAllocated.Visibility = Visibility.Visible;
                }
                else
                {
                    context.VProperties.ColumnAllocatedOldWidth = ColumnAllocated.Width;
                    ColumnAllocated.Width = 0;
                    HeaderAllocated.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void HeaderClickAllocated(object sender, RoutedEventArgs e)
        {

        }

        // ----------

        private void CheckBoxVisibleSubFolders(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.IsChecked.HasValue)
            {
                if (box.IsChecked.Value)
                {
                    ColumnSubFolders.Width = context.VProperties.ColumnSubFoldersOldWidth;
                    HeaderSubFolders.Visibility = Visibility.Visible;
                }
                else
                {
                    context.VProperties.ColumnSubFoldersOldWidth = ColumnSubFolders.Width;
                    ColumnSubFolders.Width = 0;
                    HeaderSubFolders.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void HeaderClickSubFolders(object sender, RoutedEventArgs e)
        {

        }

        // ----------

        private void CheckBoxVisibleSubFiles(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.IsChecked.HasValue)
            {
                if (box.IsChecked.Value)
                {
                    ColumnSubFiles.Width = context.VProperties.ColumnSubFilesOldWidth;
                    HeaderSubFiles.Visibility = Visibility.Visible;
                }
                else
                {
                    context.VProperties.ColumnSubFilesOldWidth = ColumnSubFiles.Width;
                    ColumnSubFiles.Width = 0;
                    HeaderSubFiles.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void HeaderClickSubFiles(object sender, RoutedEventArgs e)
        {

        }

        // ----------

        private void CheckBoxVisiblePercentParent(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.IsChecked.HasValue)
            {
                if (box.IsChecked.Value)
                {
                    ColumnPercentParent.Width = context.VProperties.ColumnPercentParentOldWidth;
                    HeaderPercentParent.Visibility = Visibility.Visible;
                }
                else
                {
                    context.VProperties.ColumnPercentParentOldWidth = ColumnPercentParent.Width;
                    ColumnPercentParent.Width = 0;
                    HeaderPercentParent.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void HeaderClickPercentParent(object sender, RoutedEventArgs e)
        {

        }
    }
}
