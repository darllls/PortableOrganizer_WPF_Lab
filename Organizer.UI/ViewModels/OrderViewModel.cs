using System;

namespace Organizer.UI.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {

        private int _orderId;
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; OnPropertyChanged("Id"); }  
        }

        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged("Number"); }
        }

        private DateTime _date;

        public DateTime Date 
        { 
            get { return _date; } 
            set { _date = value; OnPropertyChanged("Date"); } 
        }

        private OrderStatus _status;

        public OrderStatus Status 
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }

    }
}
