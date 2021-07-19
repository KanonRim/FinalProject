using EPAM.ServiceHelper.Entities;
using System;
using System.Collections.Generic;

namespace EPAM.ServiceHelper.InterfaceDAO
{
    public interface IDAO
    {
        Person AddClient(string name, string phonNumber, string comment);
        void AddOrder(Status status, Person client, DateTime dateCreation, string equipment, string comment, string device);
        Product AddProduct(int idOrder, int idEmployee, int price, string name, string comment, DateTime dateCreation, TimeSpan term);
        string GetPassHash(int IdEmployee);

        Employee AddEmployee(string name, string phoneNumber,string comment,Permissions permissions, string passHash);

        Employee GetEmployee(int id);
        Employee GetEmployeeByName(string name);

        Person GetClient(int id);
        IEnumerable<Person> GetClients();
       
        IEnumerable<Employee> GetEmployees();
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrders(int fromId, int count);
        IEnumerable<Product> GetProducts(int idOrder);

    }
}