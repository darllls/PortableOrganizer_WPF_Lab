using Organizer.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Organizer.UI.Views
{
    /// <summary>
    /// Interaction logic for CustomersUserControl.xaml
    /// </summary>
    public partial class CustomersUserControl : UserControl
    {
        public static readonly DependencyProperty CustomersProperty =
        DependencyProperty.Register("Customers", typeof(ObservableCollection<CustomerViewModel>), typeof(CustomersUserControl));

        public ObservableCollection<CustomerViewModel> Customers
        {
            get { return (ObservableCollection<CustomerViewModel>)GetValue(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }

        public CustomersUserControl()
        {
            InitializeComponent();
        }
    }
}
