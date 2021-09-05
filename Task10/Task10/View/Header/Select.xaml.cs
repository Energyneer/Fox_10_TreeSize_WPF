using System.Windows;
using System.Windows.Controls;
using Task10.ViewModel;

namespace Task10.View.Header
{
    public partial class Select : UserControl
    {
        private ViewModelContext Context
        {
            get
            {
                return this.DataContext as ViewModelContext;
            }
        }

        public Select()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Context.VProperties.BusyIndicator = true;
            Context.SelectFolder();
            Context.VProperties.BusyIndicator = false;
        }
    }
}
