using IT481_M2.DataLayer;
using System.Collections.Generic;

namespace IT481_M2.BusinessLayer {


    public class NorthwindService {
        private NorthwindRepository _northwindRepository { get; set; }
        public NorthwindService(  ) {
            _northwindRepository = new NorthwindRepository( );
        }

        public long? GetCustomerCount() {
            return _northwindRepository.GetCustomerCount();
        }

        public List<string> GetCustomerNames() {
            return _northwindRepository.GetCustomerNames();
        }

        public long? GetEmployeeCount() {
            return _northwindRepository.GetEmployeeCount();
        }

        public List<string> GetEmployeeNames() {
            return _northwindRepository.GetEmployeeNames();
        }

        public long? GetOrderCount() {
            return _northwindRepository.GetOrderCount();
        }   

        public List<string> GetOrderNames() {
            return _northwindRepository.GetOrderNames();
        }

        public bool Login(string username, string password, string server, string database) {
            return _northwindRepository.Login(username, password, server, database);
        }   
    }
}
