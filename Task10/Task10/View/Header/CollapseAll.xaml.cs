using System.Windows;
using System.Windows.Controls;
using Task10.ViewModel;

namespace Task10.View.Header
{
    public partial class CollapseAll : UserControl
    {
        private ViewModelContext Context
        {
            get
            {
                return this.DataContext as ViewModelContext;
            }
        }

        public CollapseAll()
        {
            InitializeComponent();
        }

        private void COllapseAll_Click(object sender, RoutedEventArgs e)
        {
            Context.CollapseAll();
        }
    }
}
