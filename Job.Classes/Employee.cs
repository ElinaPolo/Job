using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Ubiversity { get; set; }
        public string Faculty { get; set; }
        public string Login { get; set; }
        public List<Specialization> sp { get; set; }
        public string Password { get; set; }
    }
}
