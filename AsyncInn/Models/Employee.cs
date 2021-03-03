using System;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Employee
    {
        public long Id { get; set; }

        public long Department_Id { get; set; }

        public Department Department { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        [Phone]
        public string PrimaryContactNumber { get; set; }

        [Phone]
        public string MobileNumber { get; set; }

        [Phone]
        public string EmergencyContactNumber { get; set; }


    }
}