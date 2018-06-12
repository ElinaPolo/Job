using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Helper
    {
        public List<Employee> Employees(Grades grade, Specialization specialization)
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
                        {
                            if (c.Specializations.Id == specialization.Id)
                                emp.Add(c);
                        }
                        else
                            emp.Add(c);
                }

            }
            return emp;
        }
        public List<Vacancy> Vacancies(Specialization specialization)
        {
            var vacancy = new List<Vacancy>();
            using (var context = new Context())
            {
                foreach (var m in context.Vacancy_)
                {
                    if (specialization != null)
                    {
                        if (m.Specialization.Id == specialization.Id)
                            vacancy.Add(m);
                    }
                    else vacancy.Add(m);
                }
            }
            return vacancy;
        }
    }  
}
