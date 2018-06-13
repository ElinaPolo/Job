﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class DataBaseRepository : IRepository
    {
        public List<Employee> employee { get; set; }
        public List<Employer> employer { get; set; }
        public List<Grades> grades { get; set; }
        public List<Vacancy> vacancies { get; set; }
        public List<Specialization> specializations { get; set; }
        public List<Invitation> invitations { get; set; }
        public DataBaseRepository() { }
        public void ReadData()
        {
            grades = GetGrades();
            specializations = GetSpecializations();
         
        }
        public List<Employee> GetEmployees()
        {
            using (var context = new Context())
            {
                employee = context.Employee_.ToList();
                return employee;
             }       
        }
        public void ReadEmployers()
        {
            employer = GetEmployers();
        }
        public void ReadVacancies()
        {
            vacancies = GetVacancies();
        }

        public void SaveEmployee(string name, string login, string password, string education, Specialization specialization, Grades grade, DateTime birthdate)
        {
            using (var context = new Context())
            {

                Employee employee = new Employee()
                {
                    Name = name,
                    Login = login,
                    Password = GetHash(password),
                    Education = education,
                    BirthDate = birthdate,
                    Specializations = context.Specializations_.FirstOrDefault(x => x.Id == specialization.Id),
                    Grade = context.Grade_.FirstOrDefault(m => m.Id == grade.Id)
                };
                context.Employee_.Add(employee);
                context.SaveChanges();
            }

        }
        public void SaveEmployer(string nameofcompany, string login, string password)
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
        public void AddVacancy(Employer employer, string vacancyname, string salary, string adress, string number, string contactperson, Specialization sp)
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
                    Specialization = context.Specializations_.FirstOrDefault(x => x.Id == sp.Id),
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
        public Resume AddResume(Employee employee, string commentary,Vacancy vacancy, Employer employer)
        {
            using (var context = new Context())
            {
                var resume = new Resume()
                {
                    Employee = context.Employee_.FirstOrDefault(x => x.Login == employee.Login),
                    Age = GetAge(employee),
                    Commentary = commentary,
                    Vacancy=context.Vacancy_.FirstOrDefault(x=>x.Id==vacancy.Id)
                };
                if (employer.Resumes == null)
                    context.Employer_.FirstOrDefault(x => x.Login == employer.Login).Resumes = new List<Resume>();
                context.Employer_.FirstOrDefault(x => x.Login == employer.Login).Resumes.Add(resume);
                context.SaveChanges();
                return resume;
            }
        }
        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        public int GetAge(Employee employee)
        {
            var currentDate = DateTime.Now;

            int age = currentDate.Year - employee.BirthDate.Year;
            if (currentDate.Month < employee.BirthDate.Month ||
                (currentDate.Month == employee.BirthDate.Month && currentDate.Day < employee.BirthDate.Day))
                age--;
            return age;
        }
        public List<Employer> GetEmployers()
        {

            using (var context = new Context())
            {
                return context.Employer_.Include("Resumes.Vacancy").Include("Resumes.Employee.Grade").Include("Resumes.Employee.Specializations").ToList();
            }
        }
        public List<Grades> GetGrades()
        {
            using (var context = new Context())
            {
                return context.Grade_.ToList();
            }
        }
        public List<Vacancy> GetVacancies()
        {
            using (var context = new Context())
            {
                return context.Vacancy_.Include("Employer").ToList();
            }
        }
        public List<Specialization> GetSpecializations()
        {
            using (var context = new Context())
            {
                return context.Specializations_.ToList();
            }
        }
        public void SendResume(Employer employer, Employee employee, Resume resume)
        {
            using (var context = new Context())
            {
                if (employer.Resumes == null)
                    context.Employer_.FirstOrDefault(x => x.Login == employer.Login).Resumes = new List<Resume>();
                context.Employer_.FirstOrDefault(x => x.Login == employer.Login).Resumes.Add(resume);
                context.SaveChanges();
            }
        }
        
        
        public List<Employee> Employees(Employer employer)
        {
            using (var context=new Context())
            {
                return context.Employer_.FirstOrDefault(x => x.Login == employer.Login).Employees_.ToList();
            }

        }

        public void SendInvitation(Employee employee, Vacancy vacancy,string comment)
        {
            using (var context = new Context())
            {
                var invitation = new Invitation()
                {
                    Employee_ = context.Employee_.FirstOrDefault(x => x.Login == employee.Login),
                    Vacancy = context.Vacancy_.FirstOrDefault(m => m.Id == vacancy.Id),
                    Interview = comment
                };
                if (employee.Invitations == null)
                    context.Employee_.FirstOrDefault(x => x.Login == employee.Login).Invitations = new List<Invitation>();
                context.Employee_.FirstOrDefault(x => x.Login == employee.Login).Invitations.Add(invitation);
                context.SaveChanges();
            }
        }
        public List<Invitation> GetInvitations(Employee employee)
        {
            using (var context = new Context())
            {
                var u = context.Invitations_.Include("Employee_").Include("Vacancy").ToList();
                invitations = u;
                return invitations;
            }
        }
            
    }
}

