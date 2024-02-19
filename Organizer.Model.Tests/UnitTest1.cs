using Microsoft.VisualStudio.TestTools.UnitTesting;
using Organizer.Model.Serialization;
using System;
using System.Collections.Generic;

namespace Organizer.Model.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSerialize()
        {
            var model = new DataModel();
            model.Orders = new List<Order>() { new Order() { Number = 1000, Date = new DateTime(1988, 10, 11) } };

            model.Customers = new List<Customer> { new Customer() { Name = "Підготовка ВІС", OrderNumber = 1 } };
            model.Suppliers = new List<Supplier> { new Supplier() { Name = "Підготовка лабораторної" }, new Supplier() { Name = "Hello world" } };
            DataSerializer.SerializeData(@"D:\organizer.dat", model);
        }

        [TestMethod]
        public void TestMethodDeSerialize()
        {
            var model = DataSerializer.DeserializeItem(@"D:\organizer.dat");
        }
    }

}
