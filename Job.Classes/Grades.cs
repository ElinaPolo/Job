using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Grades
    {
        static int _id = 0;
        public int Id { get; set; }
        public string Grade { get; set; }
        public Grades(string grade)
        {
            Id = _id++;
            Grade = grade;
        }
        public Grades()
        {

        }
    }
}
