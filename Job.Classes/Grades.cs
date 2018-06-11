using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    [Table("Grade")]
    public class Grades
    {
        static int _name = 0;
        public int Id { get; set; }
        public string Grade { get; set; }
        public Grades(string grade)
        {
            Id = _name++;
            Grade = grade;
        }
        public Grades()
        {

        }
    }
}
