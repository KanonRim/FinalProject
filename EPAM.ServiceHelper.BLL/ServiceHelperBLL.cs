using EPAM.ServiceHelper.Entities;
using EPAM.ServiceHelper.InterfaceBLL;
using EPAM.ServiceHelper.InterfaceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ServiceHelper.BLL
{
    public class ServiceHelperBLL : IBLL
    {
        private static IDAO _DAO;
        public ServiceHelperBLL(IDAO dAO)
        {
            _DAO = dAO;
        }

        #region Client
        public Person AddClient(string name, string phonNumber, string comment)
        {
            return _DAO.AddClient(name, phonNumber, comment);
        }

        public void AddOrder(Status status, Person client, DateTime dateCreation, string equipment, string comment, string device)
        {
            _DAO.AddOrder(status, client, dateCreation, equipment, comment, device);
        }

        public Person GetClient(int id)
        {
            return _DAO.GetClient(id);
        }


        public IEnumerable<Person> GetClients()
        {
            return _DAO.GetClients();
        }
        #endregion

        #region Employee
        public Employee AddEmployee(string name, string phoneNumber, string comment, Permissions perm, string passHash)
        {
            return _DAO.AddEmployee(name, phoneNumber, comment, perm, passHash);
        }

        public Employee GetEmployee(int id)
        {
            return _DAO.GetEmployee(id);
        }
        public Employee GetEmployeeByName(string name)
        {
            return _DAO.GetEmployeeByName(name);
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _DAO.GetEmployees();
        }
        public string GetPassHash(int IdEmployee)
        {
            return _DAO.GetPassHash(IdEmployee);
        }
        #endregion

        #region Oreder


        public int PriceOrder(int idOrder)
        {
            int price = 0;
            foreach (var item in GetProducts(idOrder))
            {                
                price += item.Price;
            }
            return price;
        }
        public TimeSpan GetWorkingHours(int idOrder)
        {
            var works = GetProducts(idOrder);
            TimeSpan time = new TimeSpan();
            foreach (var item in works)
            {
                time += item.Term;
            }
            return time;
        }

        public  IEnumerable<Product> GetProducts(int idOrder)
        {
            return _DAO.GetProducts(idOrder);
        }

        public Order GetOrder(int id)
        {
            return _DAO.GetOrder(id);
        }
        public IEnumerable<Order> GetOrder(Status[] status)
        {
            return _DAO.GetOrders();
        }

        public IEnumerable<Order> GetOrders(Status[] status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders(int from, int count)
        {
            return _DAO.GetOrders(from,count);
        }

        public IEnumerable<Order> GetOrders(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _DAO.GetOrders();
        }


        #endregion

        #region Product

        public Product AddProduct(int idOrder, int idEmployee, int price, string name, string comment, DateTime dateCreation, TimeSpan term)
        {
            return _DAO.AddProduct(idOrder, idEmployee,price,name, comment,dateCreation, term);

        }

    
        #endregion
    }
}
