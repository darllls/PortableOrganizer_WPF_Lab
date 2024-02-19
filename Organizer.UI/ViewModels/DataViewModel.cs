using Organizer.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Organizer.UI.ViewModels
{
    public class DataViewModel : ViewModelBase
    {
        private readonly OrganizerDbContext dbContext = new OrganizerDbContext();

        public DataViewModel()
        {
            SetControlVisibility = new Command(ControlVisibility);
            CloseOrderCommand = new Command(CloseOrder);
            AddOrderCommand = new Command(AddOrder);
            UpdateOrderCommand = new Command(UpdateOrder);
            DeleteOrderCommand = new Command(DeleteOrder);
            AssignUniqueOrderNumbersCommand = new Command(AssignUniqueOrderNumbers);
        }
    
        private string _visibleControl = "Orders";
        public string VisibleControl
        {
            get { return _visibleControl; }
            set { _visibleControl = value; OnPropertyChanged("VisibleControl"); }
        }

        private OrderViewModel _selectedOrder;
        public OrderViewModel SelectedOrder
        {
            get { return _selectedOrder; }
            set { _selectedOrder = value; OnPropertyChanged("SelectedOrder"); }
        }

        public ICommand SetControlVisibility { get; set; }
        public void ControlVisibility(object args)
        {
            VisibleControl = args.ToString();
        }

        public ICommand CloseOrderCommand { get; set; }
        public void CloseOrder(object args)
        {
            if(SelectedOrder.Status == UI.OrderStatus.New)
                SelectedOrder.Status = UI.OrderStatus.InProgress;
            else if(SelectedOrder.Status == UI.OrderStatus.InProgress)
                SelectedOrder.Status = UI.OrderStatus.Closed;
            else if(SelectedOrder.Status == UI.OrderStatus.Closed)
                SelectedOrder.Status=UI.OrderStatus.New;
        }

        public ICommand AddOrderCommand { get; set; }
        public void AddOrder(object args)
        {
            if (SelectedOrder != null)
            {
                var existingOrderEntity = dbContext.Orders.Find(SelectedOrder.OrderId);

                if (existingOrderEntity == null)
                {
                    var orderEntity = new Order
                    {
                        OrderId = SelectedOrder.OrderId,
                        Number = SelectedOrder.Number,
                        Date = SelectedOrder.Date,
                        Status = SelectedOrder.Status
                    };

                    dbContext.Orders.Add(orderEntity);
                    dbContext.SaveChanges();

                    LoadOrders();
                }
            }
        }
        public ICommand UpdateOrderCommand { get; set; }
        public void UpdateOrder(object args)
        {
            if (SelectedOrder != null)
            {
                var orderEntity = dbContext.Orders.Find(SelectedOrder.OrderId);

                if (orderEntity != null)
                {
                    orderEntity.Number = SelectedOrder.Number;
                    orderEntity.Date = SelectedOrder.Date;
                    orderEntity.Status = SelectedOrder.Status;

                    dbContext.SaveChanges();

                    LoadOrders();
                }
            }
        }
        public ICommand DeleteOrderCommand { get; set; }
        public void DeleteOrder(object args)
        {
            if (SelectedOrder != null)
            {
                var orderEntity = dbContext.Orders.Find(SelectedOrder.OrderId);

                if (orderEntity != null)
                {
                    dbContext.Orders.Remove(orderEntity);
                    dbContext.SaveChanges();

                    LoadOrders();
                }
            }
        }
        private void LoadOrders()
        {
            Orders = new ObservableCollection<OrderViewModel>(dbContext.Orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                Number = o.Number,
                Date = o.Date,
                Status = o.Status
            }));
        }


        public ICommand AssignUniqueOrderNumbersCommand { get; set; }
        public void AssignUniqueOrderNumbers(object args)
        {
            var sortedOrders = Orders.OrderBy(order => order.Number).ToList();

            for (int i = 0; i < Customers.Count; i++)
            {
                // Assign the OrderNumber to each customer based on the sorted order
                if (i < sortedOrders.Count)
                {
                    Customers[i].OrderNumber = sortedOrders[i].Number;
                }
                else
                {
                    // Handle the case where there are more customers than orders
                    Customers[i].OrderNumber = 0; // Set a default value or handle as needed
                }
            }
        }

        private ObservableCollection<OrderViewModel> _Orders;
        public ObservableCollection<OrderViewModel> Orders 
        { 
            get { return _Orders; } 
            set { _Orders = value; OnPropertyChanged("Orders"); } 
        }

        private ObservableCollection<CustomerViewModel> _customers;
        public ObservableCollection<CustomerViewModel> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        private ObservableCollection<SupplierViewModel> _Suppliers;
        public ObservableCollection<SupplierViewModel> Suppliers
        {
            get { return _Suppliers; }
            set { _Suppliers = value; OnPropertyChanged("Suppliers"); }
        }
    }
}
