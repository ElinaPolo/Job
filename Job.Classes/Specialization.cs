using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    [Table("Specialization")]
    public class Specialization
    {
        static int _num = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public Specialization(string name)
        {
            Id = _num++;
            Name = name;
        }

        public Specialization()
        {

        }
    }
}
