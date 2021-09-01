using EPAM.ServiceHelper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ServiceHelper.InterfaceBLL
{
    public interface IBLL
    {

        Person AddClient(string name, string phonNumber, string comment);

        //todo add Return_values       
        void AddOrder(Status status, Person client, DateTime dateCreation, string equipment, string comment, string device);

        // why not use a model (entity) for that? I'd write an example of what could happen if you leave everything in parameters, but you already have 7 of them. That's quite a lot!
        // It's a normal practice to create different entities for different scenarios, if they differ only by 1-2 properties: the difference can grow bigger + both of entities can have on parent
        // Or to use entities ignoring some properties like Id (which is set by DB on creation)
        Product AddProduct(int idOrder, int idEmployee, int price, string name, string comment, DateTime dateCreation, TimeSpan term); 

       

        IEnumerable<Product> GetProducts(int idOrder);

        TimeSpan GetWorkingHours(int idOrder);



        Person GetClient(int id);

        Employee GetEmployee(int id);

        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByName(string name);
        Employee AddEmployee(string name, string phoneNumber, string comment,Permissions perm, string passHash);
        string GetPassHash(int IdEmployee);

        int PriceOrder(int idOrder);

        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();

        IEnumerable<Order> GetOrders(Status[] status);

        IEnumerable<Order> GetOrders(int count);

        IEnumerable<Order> GetOrders(int from ,int count);

        IEnumerable<Order> GetOrders(DateTime fromDate, DateTime toDate);

        Order UpdateOrder(Order order);
        IEnumerable<Person> GetClients();




    }
}
