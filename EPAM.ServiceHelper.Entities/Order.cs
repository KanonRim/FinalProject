using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ServiceHelper.Entities
{

    public enum Status
    {
        notProcessed,//поступил
        inWork,//в работе 
        waiting,//ожижат
        forApproval,//согласование 
        ready,//готов 
        closed//закрыт
    }

    public class Order
    {
        int id;
        Status status;
        Person client;
        DateTime dateCreation;
        string device;
        string equipment;

        public Order(int id, Status status, Person client, DateTime dateCreation, string device)
        {
            this.id = id;
            this.status = status;
            this.client = client;
            this.dateCreation = dateCreation;
            this.device = device;
        }
    }
}
