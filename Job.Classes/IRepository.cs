﻿using System;
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
        List<Specialization> specializations { get; set; }
        void SaveEmployee(string name, string login, string password, string education, Specialization specialization, Grades grade, DateTime birthdate);
        void SaveEmployer(string nameofcompany, string login, string password);
        void AddVacancy(Employer employer, string vacancyname, string salary, string adress, string number, string contactperson, Specialization sp);
        List<Grades> GetGrades();
        List<Specialization> GetSpecializations();
        void ReadData();
        Resume AddResume(Employee employee, string commentary);
        void SendResume(Employer employer, Employee employee, Resume resume);
    }
}
