using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataLayer.Modles;

namespace LIBRARY.DataLayer.Reositoris
{
    public interface ICustomersRepository
    {
        IEnumerable<CustomerTB> GetAllCustomer();
        CustomerTB GetCustomerByID(int CustomerID);
        IEnumerable<CustomerTB> GetCustomersByFilter(string Parameter);
        int GetCustomerIDByName(string name);
        string GetCustomerNameByID(int CustomerID);
        string GetCustomerpictourById(int CustomerID);

        bool InsertCustomers(CustomerTB customer);
        bool DeleteCustomer(CustomerTB customer);
        bool DeleteCustomer(int CustomerID);
        bool UpdateCustomer(CustomerTB customer);
    }
}
