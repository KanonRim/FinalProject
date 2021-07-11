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
        Order GetOrder(int id);

        IEnumerable<Order> GetOrders(Status[] status);

        IEnumerable<Order> GetOrders(int count);

        IEnumerable<Order> GetOrders(DateTime fromDate, DateTime toDate);

        Person GetClient(int id);

        IEnumerable<Person> GetClients();

    }
}
