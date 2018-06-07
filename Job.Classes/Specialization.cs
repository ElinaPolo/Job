using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Specialization
    {
        static int _id = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialization(string name)
        {
            Id = _id++;
            Name = name;
        }

        public Specialization()
        {

        }
    }
}
