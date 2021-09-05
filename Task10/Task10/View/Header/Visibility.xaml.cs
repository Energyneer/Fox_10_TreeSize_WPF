using System.Windows;
using System.Windows.Controls;
using Task10.ViewModel;

namespace Task10.View.Header
{
    public partial class Visibility : UserControl
    {
        private ViewModelContext Context
        {
            get
            {
                return this.DataContext as ViewModelContext;
            }
        }
        public Visibility()
        {
            InitializeComponent();

        }

        private void CheckBoxVisibleAllocated(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.IsChecked.HasValue)
            {
                if (box.IsChecked.Value)
                {
                    Context.SizeProperties.ColumnAllocatedWidth = Context.SizeProperties.ColumnAllocatedWidthOld;
                    Context.SizeProperties.ColumnAllocatedVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    Context.SizeProperties.ColumnAllocatedWidthOld = Context.SizeProperties.ColumnAllocatedWidth;
                    Context.SizeProperties.ColumnAllocatedWidth = 0;
                    Context.SizeProperties.ColumnAllocatedVisibility = System.Windows.Visibility.Collapsed;
                }
            }
        }

        private void CheckBoxVisibleSubFolders(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.IsChecked.HasValue)
            {
                if (box.IsChecked.Value)
                {
                    Context.SizeProperties.ColumnSubFoldersWidth = Context.SizeProperties.ColumnSubFoldersWidthOld;
                    Context.SizeProperties.ColumnSubFoldersVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    Context.SizeProperties.ColumnSubFoldersWidthOld = Context.SizeProperties.ColumnSubFoldersWidth;
                    Context.SizeProperties.ColumnSubFoldersWidth = 0;
                    Context.SizeProperties.ColumnSubFoldersVisibility = System.Windows.Visibility.Collapsed;
                }
            }
        }

        private void CheckBoxVisibleSubFiles(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.IsChecked.HasValue)
            {
                if (box.IsChecked.Value)
                {
                    Context.SizeProperties.ColumnSubFilesWidth = Context.SizeProperties.ColumnSubFilesWidthOld;
                    Context.SizeProperties.ColumnSubFilesVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    Context.SizeProperties.ColumnSubFilesWidthOld = Context.SizeProperties.ColumnSubFilesWidth;
                    Context.SizeProperties.ColumnSubFilesWidth = 0;
                    Context.SizeProperties.ColumnSubFilesVisibility = System.Windows.Visibility.Collapsed;
                }
            }
        }

        private void CheckBoxVisiblePercentParent(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.IsChecked.HasValue)
            {
                if (box.IsChecked.Value)
                {
                    Context.SizeProperties.ColumnPercentParentWidth = Context.SizeProperties.ColumnPercentParentWidthOld;
                    Context.SizeProperties.ColumnPercentParentVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    Context.SizeProperties.ColumnPercentParentWidthOld = Context.SizeProperties.ColumnPercentParentWidth;
                    Context.SizeProperties.ColumnPercentParentWidth = 0;
                    Context.SizeProperties.ColumnPercentParentVisibility = System.Windows.Visibility.Collapsed;
                }
            }
        }
    }
}
