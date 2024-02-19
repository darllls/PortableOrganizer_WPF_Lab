using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.ViewModels
{
    public class SupplierViewModel : ViewModelBase
    {
        private int _SupplierId;
        public int SupplierId
        {
            get { return _SupplierId; }
            set { _SupplierId = value; OnPropertyChanged("Id"); }

        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged("Name"); }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged("Email"); }
        }
    }
}
