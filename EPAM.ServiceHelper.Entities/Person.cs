using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ServiceHelper.Entities
{
    public class Person
    {
        public int Id { get; }
        public string Name { get; set; }
        public string PhonNuber { get; set; } // 2 typos in PhoneNumber.
        public string Comment { get; set; }


        public Person(int id,string name, string phonNumber, string comment)
        {
            Id = id;
            Name = name;
            PhonNuber = phonNumber;
            Comment = comment;
        }

    }


}
