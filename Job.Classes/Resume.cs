 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Resume
    {       
        public int Id { get; set; }
        public bool Sd { get; set; }
        public Employee Employee { get; set; }
        public int Age { get; set; }
        public string Commentary { get; set; }  
        public Employer Employer { get; set; }
    }
}
