﻿using System;
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
        public List<Vacancy> Vacancies { get; set; }
        public static Employer Sign(string login, string password)
        {
            //Users = Repository.RestoreList<User>("../../users.json");
            using (var context = new Context())
            {
                var sing = new Employer();
                sing = context.Employer_.FirstOrDefault(m => m.Login == login && m.Password == password);
                return sing;
            }
        }

        
    }
}
