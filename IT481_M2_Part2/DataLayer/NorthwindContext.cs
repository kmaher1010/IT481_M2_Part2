using Microsoft.EntityFrameworkCore;
using System;

namespace IT481_M2.DataLayer {
    internal class NorthwindContext : DbContext {
        public NorthwindContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

    }

    public class Customer {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
    }
    public class Employee {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Title { get; set; }
        public DateTime? HireDate { get; set; }
    }

    public class Order {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public string? ShipName { get; set; }
    }
}



