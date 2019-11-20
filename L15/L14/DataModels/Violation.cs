using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L15.DataModels
{
    public class Violation
    {
        [Key]
        public string Code { get; set; }

        public DateTime Date { get; set; }

        public string District { get; set; }

        public bool IsPaid { get; set; }

        public string InspectorNumber { get; set; }

        public CarOwner CarOwner { get; set; }

        public ViolationType Type { get; set; }
    }
}
