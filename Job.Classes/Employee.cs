using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Employee
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public bool Work { get; set; }
        public DateTime BirthDate { get; set; }
        public bool StayOnline { get; set; }
        public Grades Grade { get; set; }
        public Specialization Specializations { get; set; }
        public List<Resume> Resumes { get; set; }
        public static Employee Sign(string login, string password)
        {
            using (var context = new Context())
            {

                var sign = new Employee();
                sign = context.Employee_.FirstOrDefault(m => m.Login == login && m.Password == password);
                return sign;
            }
        }
    }
}
