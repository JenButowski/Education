using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L15.DataModels
{
    public class ViolationType
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public double PenaltySumm { get; set; }

        public DateTime DrivingDeprivationDate { get; set; }

        public List<Violation> Violations { get; set; }
    }
}
