 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Resume
    {
        public Employee employee { get; set; }
        public int Age { get; set; }
        public string Commentary { get; set; }

        public int GetAge(Employee employee)
        {
            var currentDate = DateTime.Now;

            int age = currentDate.Year - employee.BirthDate.Year;
            if (currentDate.Month < employee.BirthDate.Month ||
                (currentDate.Month == employee.BirthDate.Month && currentDate.Day < employee.BirthDate.Day))
                age--;
            return age;
        }
    }
}
