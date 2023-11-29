using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IT481_M2.DataLayer {

    internal class NorthwindRepository {
        private NorthwindContext _context { get; set; }

        public bool Login(string username, string password, string server, string database) {
            var connectionString = $"Server={server};Database={database};User Id={username};Password={password};Encrypt=false;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionsBuilder.UseSqlServer(connectionString);
            _context = new NorthwindContext(optionsBuilder.Options);
            try {
                _context.Database.OpenConnection();
            } catch {
                return false;
            }
            return true;
        }

        public long? GetCustomerCount() {
            try {
                return _context.Customers.Count();
            } catch {
                return null;
            }
        }

        public List<string> GetCustomerNames() {
            try { 
                var customers = (from c in _context.Customers select c.ContactName).ToList();
                var lastNames = customers.Select(c => c.Split(" ").Last()).ToList();
                return lastNames;
            } catch {
                return null;
            }
        }

        internal long? GetEmployeeCount() {
            try {
                return _context.Employees.Count();
            } catch {
                return null;
            }
        }

        internal List<string> GetEmployeeNames() {
            try { 
                var employees = (from c in _context.Employees select c.LastName).ToList();
                return employees;
            } catch {
                return null;
            }

        }

        internal long? GetOrderCount() {
            try {
                return _context.Orders.Count();
            } catch {
                return null;
            }
        }

        internal List<string> GetOrderNames() {
            try {
                var orders = (from c in _context.Orders select c.ShipName).ToList();
                return orders;
            } catch {
                return null;
            }
;
        }
    }
}
