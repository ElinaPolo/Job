using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Job.Classes
{
   public class Repository
    {
        public List<Specialization> spez { get; set; }
        public List<Grades> grade { get; set; }

        public Repository()
        {
            List<Grades> gr = new List<Grades>()
            {
                new Grades("Primary"),
                new Grades("Lower Secondary "),
                new Grades("Upper Secondary"),
                new Grades("Post-secondary"),
                new Grades("Bachelor"),
                new Grades("Master"),
                new Grades("Doctoral")
            };
            SaveList("grades.json",gr);
            List<Specialization> ss = new List<Specialization>()
           {
               new Specialization("It"),
               new Specialization("Hr"),
               new Specialization("Top Management"),
               new Specialization("Economics"),
               new Specialization("Design"),
               new Specialization("Mass Media"),
               new Specialization("Security"),
               new Specialization("Jurisprudence")
           };
            SaveList("spez.json", ss);
            spez = RestoreList<Specialization>("spez.json");
            grade = RestoreList<Grades>("grades.json");
        }

        public static void SaveList<T>(string fileName, List<T> list)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, list);
                }
            }
        }
        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        public static List<T> RestoreList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }
        public static void SaveEmployee(string name, string login, string password,string education, Specialization specialization , Grades grade )
        {
           
            Employee employee = new Employee()
            {
                Name = name,
                Login = login,
                Password = GetHash(password),
                Education=education,
                Specializations=specialization,
                Grade=grade
            };
            using (var context = new Context())
            {
                context.Employee_.Add(employee);
                context.SaveChanges();
            }           
        }
        public static void SaveEmployer(string nameofcompany, string login, string password)
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
        public static void AddVacancy(Employer employer, string vacancyname,string salary,string adress,string number,string contactperson,Specialization sp )
        {
            using (var context = new Context())
            {
                var vacanc = new Vacancy()
                {
                    VacancyName = vacancyname,
                    //Salary = salary,
                    Address = adress,
                    Number = number,
                    //ContactPerson = contactperson,
                    Specialization = sp,
                    Employer=context.Employer_.FirstOrDefault(m=>m.Login==employer.Login)
                };
                context.Vacancy_.Add(vacanc);
                context.SaveChanges();
            }
                
        }
    }
}
