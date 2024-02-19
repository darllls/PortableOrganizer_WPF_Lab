using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private int _CustomerId;
        public int CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; OnPropertyChanged("Id"); }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged("Name"); }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; OnPropertyChanged("Phone"); }
        }

        private int _orderNumber;
        public int OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; OnPropertyChanged("OrderNumber"); }
        }
    }
}
