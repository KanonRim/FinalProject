using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ServiceHelper.Entities
{
    public class Person
    {
        string name;
        string phonNuber;
        string comment;

        public Person(string name, string phonNuber, string comment)
        {
            this.name = name;
            this.phonNuber = phonNuber;
            this.comment = comment;
        }
    }


    public class Employee : Person
    {
       
        public Employee(string name, string phonNuber, string comment) : base(name, phonNuber, comment)
        {
            
        }
    }

    public class Client : Person
    {
        public Client(string name, string phonNuber, string comment) : base(name, phonNuber, comment)
        {

        }
    }
}
