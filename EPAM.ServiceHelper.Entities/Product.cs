using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ServiceHelper.Entities
{
     public class Product
     {
        public Product(int idOrder, int idEmployee, int price, string name, string comment, DateTime dateCreation, TimeSpan term)
        {
            IdOrder = idOrder;
            IdEmployee = idEmployee;
            Price = price;
            Name = name;
            Comment = comment;
            DateCreation = dateCreation;
            Term = term;
        }

        public int IdOrder { get; }
        public int IdEmployee { get;}
        public int Price { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreation { get; }
        public TimeSpan Term { get; set; } // TotalWorkTime would be clearer
    }

}
