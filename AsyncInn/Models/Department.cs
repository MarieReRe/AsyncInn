using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Department
    {
        public long Id { get;set;}

        public long Hotel_Id { get; set; }

        public Hotel Hotel { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string ExtensionNumber { get; set; }

        public string Responsibilities { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
