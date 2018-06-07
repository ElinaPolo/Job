using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
   public class Vacancy
    {
        public int Id { get; set; }
        public Employer Employer { get; set; }
        public string VacancyName { get; set; }
        public Specialization Specialization { get; set; }
        public decimal Salary { get; set; }
        public string Schedule { get; set; }
        public string Address { get; set; }
        public string ContactMan { get; set; }
        public string Number { get; set; }
    }
}
