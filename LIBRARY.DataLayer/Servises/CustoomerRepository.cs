using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LIBRARY.DataLayer.Modles;
using LIBRARY.DataLayer.Reositoris;

namespace LIBRARY.DataLayer.Servises
{
    public class CustoomerRepository : ICustomersRepository
    {
        private Library_DBEntities _db;

        public CustoomerRepository(Library_DBEntities Context)
        {
            _db = Context;
        }
        public IEnumerable<CustomerTB> GetAllCustomer()
        {
            return _db.CustomerTB.ToList();
        }

        public CustomerTB GetCustomerByID(int CustomerID)
        {
            return _db.CustomerTB.Find(CustomerID);
        }

        public IEnumerable<CustomerTB> GetCustomersByFilter(string Parameter)
        {
            return _db.CustomerTB.Where(Search =>
                    Search.FullName.Contains(Parameter) || Search.Phone.Contains(Parameter) ||
                    Search.Email.Contains(Parameter) || Search.Address.Contains(Parameter)).OrderBy(c => c.CustomerID)
                .ToList();
        }

        public bool InsertCustomers(CustomerTB customer)
        {
            try
            {
                _db.CustomerTB.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(CustomerTB customer)
        {
            try
            {
                _db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int CustomerID)
        {
            try
            {
                var resualt = GetCustomerByID(CustomerID);
                DeleteCustomer(resualt);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(CustomerTB customer)
        {
            try
            {
                _db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetCustomerIDByName(string name)
        {
            return _db.CustomerTB.First(c => c.FullName == name).CustomerID;
        }

        public string GetCustomerNameByID(int CustomerID)
        {
            return _db.CustomerTB.Find(CustomerID).FullName;
        }

        public string GetCustomerpictourById(int CustomerID)
        {
            return _db.CustomerTB.FirstOrDefault(c=> c.CustomerID == CustomerID).CustomerIMG;
        }
    }
}
