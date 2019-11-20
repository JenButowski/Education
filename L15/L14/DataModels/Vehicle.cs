using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L15.DataModels
{
    public class Vehicle
    {
        [Key]
        public string Number { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime ProductionYear { get; set; }

        public DateTime DateofRegistration { get; set; }

        public CarOwner Owner { get; set; }
    }
}
