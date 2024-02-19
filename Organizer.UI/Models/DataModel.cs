using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using Organizer.UI.ViewModels;
using Organizer.UI;

namespace Organizer.UI
{
    public class DataModel
    {
        private static readonly OrganizerDbContext dbContext = new OrganizerDbContext();

        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public ObservableCollection<CustomerViewModel> Customers { get; set; }
        public ObservableCollection<SupplierViewModel> Suppliers { get; set; }

        public DataModel()
        {
            Orders = new ObservableCollection<OrderViewModel>(dbContext.Orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                Number = o.Number,
                Date = o.Date,
                Status = o.Status
            }));

            Customers = new ObservableCollection<CustomerViewModel>(dbContext.Customers.Select(c => new CustomerViewModel
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Phone = c.Phone,
                OrderNumber = c.OrderNumber
            }));

            Suppliers = new ObservableCollection<SupplierViewModel>(dbContext.Suppliers.Select(s => new SupplierViewModel
            {
                SupplierId = s.SupplierId,
                Name = s.Name,
                Email = s.Email
            }));
        }


        public void Save()
        {
            foreach (var customerViewModel in Customers)
            {
                var existingCustomer = dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerViewModel.CustomerId);

                if (existingCustomer != null)
                {
                    existingCustomer.Name = customerViewModel.Name;
                    existingCustomer.Phone = customerViewModel.Phone;
                }
                else
                {
                    var newCustomer = new Customer
                    {
                        Name = customerViewModel.Name,
                        Phone = customerViewModel.Phone,
                        OrderNumber = customerViewModel.OrderNumber
                    };
                    dbContext.Customers.Add(newCustomer);
                }
            }

            foreach (var orderViewModel in Orders)
            {
                var existingOrder = dbContext.Orders.FirstOrDefault(o => o.OrderId == orderViewModel.OrderId);

                if (existingOrder != null)
                {
                    existingOrder.Date = orderViewModel.Date;
                    existingOrder.Status = orderViewModel.Status;
                }
                else
                {
                    var newOrder = new Order
                    {
                        Number = orderViewModel.Number,
                        Date = orderViewModel.Date,
                        Status = orderViewModel.Status
                    };
                    dbContext.Orders.Add(newOrder);
                }
            }

            foreach (var supplierViewModel in Suppliers)
            {
                var existingSupplier = dbContext.Suppliers.FirstOrDefault(s => s.SupplierId == supplierViewModel.SupplierId);

                if (existingSupplier != null)
                {
                    existingSupplier.Name = supplierViewModel.Name;
                    existingSupplier.Email = supplierViewModel.Email;
                }
                else
                {
                    var newSupplier = new Supplier
                    {
                        Name = supplierViewModel.Name,
                        Email = supplierViewModel.Email
                        
                    };
                    dbContext.Suppliers.Add(newSupplier);
                }
            }


            dbContext.SaveChanges();
        }

        public static DataModel Load()
        {
            var dataModel = new DataModel();
            dataModel.Customers = new ObservableCollection<CustomerViewModel>(dbContext.Customers.Select(c => new CustomerViewModel
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Phone = c.Phone,
                OrderNumber = c.OrderNumber
            }));

            dataModel.Orders = new ObservableCollection<OrderViewModel>(dbContext.Orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                Number = o.Number,
                Date = o.Date,
                Status = (OrderStatus)o.Status
            }));

            dataModel.Suppliers = new ObservableCollection<SupplierViewModel>(dbContext.Suppliers.Select(s => new SupplierViewModel
            {
                SupplierId = s.SupplierId,
                Name = s.Name,
                Email = s.Email
            }));


            return dataModel;
        }
    }
}
