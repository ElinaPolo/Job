using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class DataBaseRepository : IRepository
    {
        //  public Employee Register(string login, string password, string name,string education, )
        public  void SaveEmployee(string name, string login, string password, string education, Specialization specialization, Grades grade)
        {
            using (var context = new Context())
            {
                Employee employee = new Employee()
                {
                    Name = name,
                    Login = login,
                    Password = GetHash(password),
                    Education =education ,
                    Specializations = context.Specializations_.FirstOrDefault(x => x.Id == specialization.Id),
                    Grade = context.Grade_.FirstOrDefault(m=> m.Id==grade.Id)
                };
                context.Employee_.Add(employee);
                context.SaveChanges();
            }
            
        }
        public  void SaveEmployer(string nameofcompany, string login, string password)
        {

            Employer employer = new Employer()
            {
                NameOfTheCompany = nameofcompany,
                Login = login,
                Password = GetHash(password)
            };
            using (var context = new Context())
            {
                context.Employer_.Add(employer);
                context.SaveChanges();
            }
        }
        public  void AddVacancy(Employer employer, string vacancyname, string salary, string adress, string number, string contactperson, Specialization sp)
        {
            using (var context = new Context())
            {
                var vacanc = new Vacancy()
                {
                    VacancyName = vacancyname,
                    Salary = salary,
                    Address = adress,
                    Number = number,
                    ContactPerson = contactperson,
                    Specialization = context.Specializations_.FirstOrDefault(x=>x.Id==sp.Id),
                    Employer = context.Employer_.FirstOrDefault(m => m.Login == employer.Login)
                };
                if (employer.Vacancies == null)
                {
                    context.Employer_.FirstOrDefault(x => x.Login == employer.Login).Vacancies = new List<Vacancy>();
                }
                context.Vacancy_.Add(vacanc);
                context.SaveChanges();
            }

        }
        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        
    }
}
