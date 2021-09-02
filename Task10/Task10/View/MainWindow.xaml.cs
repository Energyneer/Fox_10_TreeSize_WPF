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
    public partial class MainWindow : Window
    {
        private ViewModelContext Context
        {
            get
            {
                return this.DataContext as ViewModelContext;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Context.VProperties.BGColumnName = Constants.ColumnSelect;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Context.ClickExpCollapseButton(button.DataContext as ViewNode); 
        }

        private void HeaderClickName(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortDirect == SortAttribute.NAME_UP)
            {
                Context.ChangeSort(SortAttribute.NAME_DOWN);
            }
            else if (Context.CurrentSortDirect == SortAttribute.NAME_DOWN || Context.CurrentSortDirect != SortAttribute.NAME_UP)
            {
                Context.ChangeSort(SortAttribute.NAME_UP);
            }
        }

        private void HeaderClickSize(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortDirect == SortAttribute.SIZE_UP)
            {
                Context.ChangeSort(SortAttribute.SIZE_DOWN);
            }
            else if (Context.CurrentSortDirect == SortAttribute.SIZE_DOWN || Context.CurrentSortDirect != SortAttribute.SIZE_UP)
            {
                Context.ChangeSort(SortAttribute.SIZE_UP);
            }
        }

        private void HeaderClickAllocated(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortDirect == SortAttribute.ALLOCATED_UP)
            {
                Context.ChangeSort(SortAttribute.ALLOCATED_DOWN);
            }
            else if (Context.CurrentSortDirect == SortAttribute.ALLOCATED_DOWN || Context.CurrentSortDirect != SortAttribute.ALLOCATED_UP)
            {
                Context.ChangeSort(SortAttribute.ALLOCATED_UP);
            }
        }

        private void HeaderClickCreated(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortDirect == SortAttribute.CREATED_UP)
            {
                Context.ChangeSort(SortAttribute.CREATED_DOWN);
            }
            else if (Context.CurrentSortDirect == SortAttribute.CREATED_DOWN || Context.CurrentSortDirect != SortAttribute.CREATED_UP)
            {
                Context.ChangeSort(SortAttribute.CREATED_UP);
            }
        }
    }
}
