using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Employer
    {
        public int Id { get; set; }
        public string NameOfTheCompany { get; set; }
       
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Employee> Employees_ { get; set; }
        public List<Vacancy> Vacancies { get; set; }
        public List<Resume> Resumes { get; set; }
        public static Employer Sign(string login, string password)
        {
            using (var context = new Context())
            {
                var sign = new Employer();
                sign = context.Employer_.FirstOrDefault(m => m.Login == login && m.Password ==password);
                return sign;
            }
        }       
    }
}
