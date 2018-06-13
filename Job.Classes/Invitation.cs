using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Invitation
    {
        public int Id { get; set; }
        public Employee Employee_ { get; set; }
        public Vacancy Vacancy { get; set; }
        public string Interview { get; set; }
    }
}
