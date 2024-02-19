using AutoMapper;
using Organizer.UI.ViewModels;

namespace Organizer.UI.Base
{
    public class Mapping
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataModel, DataViewModel>();
                cfg.CreateMap<DataViewModel, DataModel>();

                cfg.CreateMap<Customer, CustomerViewModel>();
                cfg.CreateMap<CustomerViewModel, Customer>();

                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<OrderViewModel, Order>();

                cfg.CreateMap<Supplier, SupplierViewModel>();
                cfg.CreateMap<SupplierViewModel, Supplier>();
            });

            return config.CreateMapper();
        }
    }
}
