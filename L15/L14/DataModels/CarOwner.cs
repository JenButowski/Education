using L15.DataModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace L15.DataModels
{
    public class CarOwner
    {
        [Key]
        public string DriversLicenseCode { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public List<Violation> Violations { get; set; }
    }
}