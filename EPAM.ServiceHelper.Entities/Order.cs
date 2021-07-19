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
        public int Id { get; }
        public Status Status { get; set; }
        public Person Client { get; }
        public DateTime DateCreation { get; }
        public string Device { get; set; }
        public string Equipment { get; set; }

        public Order(int id, Status status, Person client, DateTime dateCreation, string device)
        {
            Id = id;
            Status = status;
            Client = client;
            DateCreation = dateCreation;
            Device = device;
        }

      
    }
}
