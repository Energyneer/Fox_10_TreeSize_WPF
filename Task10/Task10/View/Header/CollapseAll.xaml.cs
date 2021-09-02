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
