using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Organizer.UI
{
    public class OrganizerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierEntityConfiguration());
            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasColumnType("INT");

            SeedData(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=KPZ;Integrated Security=True;TrustServerCertificate=True");
        }

        private void SeedData(ModelBuilder modelBuilder)
        {

            var orders = new List<Order>
            {
                new Order { OrderId = 1, Number = 1001, Date = DateTime.Today, Status = OrderStatus.New },
                new Order { OrderId = 2, Number = 1002, Date = DateTime.Today, Status = OrderStatus.New },
                new Order { OrderId = 3, Number = 1003, Date = DateTime.Today, Status = OrderStatus.New },
                new Order { OrderId = 4, Number = 1004, Date = DateTime.Today, Status = OrderStatus.New },
                new Order { OrderId = 5, Number = 1005, Date = DateTime.Today, Status = OrderStatus.New },
            };

            modelBuilder.Entity<Order>().HasData(orders);

            var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "Customer1", Phone = "123456789", OrderNumber = 1001 },
                new Customer { CustomerId = 2,  Name = "Customer2", Phone = "987654321", OrderNumber = 1002 },
                new Customer { CustomerId = 3,  Name = "Customer3", Phone = "111223344", OrderNumber = 1003 },
                new Customer { CustomerId = 4,  Name = "Customer4", Phone = "555666777", OrderNumber = 1004 },
                new Customer { CustomerId = 5,  Name = "Customer5", Phone = "999888777", OrderNumber = 1005 },
            };

            modelBuilder.Entity<Customer>().HasData(customers);

            var suppliers = new List<Supplier>
            {
                new Supplier { SupplierId = 1, Name = "Supplier1", Email = "supplier1@example.com" },
                new Supplier { SupplierId = 2, Name = "Supplier2", Email = "supplier2@example.com" },
                new Supplier { SupplierId = 3, Name = "Supplier3", Email = "supplier3@example.com" },

            };

            modelBuilder.Entity<Supplier>().HasData(suppliers);
        }
    }
}
