using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public interface IRepository
    {
        List<Employee> employee { get; set; }
        List<Employer> employer { get; set; }
        List<Grades> grades { get; set; }
        List<Invitation> invitations { get; set; }
        List<Specialization> specializations { get; set; }
        List<Vacancy> vacancies { get; set; }
        void SaveEmployee(string name, string login, string password, string education, Specialization specialization, Grades grade, DateTime birthdate);
        void SaveEmployer(string nameofcompany, string login, string password);
        void AddVacancy(Employer employer, string vacancyname, string salary, string adress, string number, string contactperson, Specialization sp);
        List<Grades> GetGrades();
        List<Specialization> GetSpecializations();
        List<Employee> GetEmployees();
        List<Invitation> GetInvitations(Employee employee);
        void ReadData();
        void ReadVacancies();
        void ReadEmployers();
        Resume AddResume(Employee employee, string commentary, Vacancy vacancy,Employer employer);
        void SendResume(Employer employer, Employee employee, Resume resume);
        void SendInvitation(Employee employee, Vacancy vacancy, string comment);
        List<Vacancy> GetVacancies();
    }
}
