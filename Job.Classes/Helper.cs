using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
   public class Helper
    {
        public List<Employee> Employees (Grades grade, Specialization specialization)
        {
            var emp = new List<Employee>();

            using (var context = new Context())
            {
                foreach (var c in context.Employee_)
                {
                    if (grade != null && specialization != null)
                    {
                        if (c.Grade.Id == grade.Id)
                            if (c.Specializations.Id == specialization.Id)
                                emp.Add(c);
                    }
                    else
                    if (grade != null)
                        if (c.Grade.Id == grade.Id)
                            emp.Add(c);
                        else
                        if (specialization != null)
                            emp.Add(c);
                        else
                            emp.Add(c);
                   }

           }
            return emp;
        }
        //public int Age()
    }
}
