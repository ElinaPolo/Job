using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{

    public class Helper
    {
        public static List<Employee> Employees(Grades grade, Specialization specialization)
        {
            var emp = new List<Employee>();

            using (var context = new Context())
            {
                foreach (var c in context.Employee_.Include("Grade").Include("Specializations"))
                {
                    if (grade != null && specialization != null)
                    {
                        if (c.Grade.Id == grade.Id)
                            if (c.Specializations.Id == specialization.Id)
                                emp.Add(c);
                    }
                    else
                    if (grade != null)
                    {
                        if (c.Grade.Id == grade.Id)
                            emp.Add(c);
                    }
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
        public static List<Vacancy> Vacancies(Specialization specialization)
        {
            var vacancy = new List<Vacancy>();
            using (var context = new Context())
            {
                foreach (var m in context.Vacancy_.Include("Specialization").Include("Employer"))
                {
                    if (specialization != null)
                    {
                        if (m.Specialization.Id == specialization.Id)
                            vacancy.Add(m);
                    }                  
                }
            }
            return vacancy;
        }
        public static List<Invitation> EmployeeInvitations(Employee employee,List<Invitation> invitations)
        {
            var h = new List<Invitation>();
            foreach (var i in invitations)
            {
                if (i.Employee_.Login == employee.Login)
                    h.Add(i);
            }
            return h;
        }
      public static List<Vacancy> EmployerVacancies(Employer employer,List<Vacancy> vacancies)
        {
           var vac = new List<Vacancy>();
            foreach (var c in vacancies)
            {
                if (employer.Login == c.Employer.Login)
                    vac.Add(c);
            }
            return vac;
        }
    }  
}
