using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Classes
{
    public class Context : DbContext
    {
        static Context()
        {
            Database.SetInitializer(new Initializer());
            
        }
        public Context() : base("DefaultConnection") { }
        public DbSet<Employee> Employee_ { get; set; }
        public DbSet<Employer> Employer_ { get; set; }
        public DbSet<Specialization> Specializations_ { get; set; }
        public DbSet<Vacancy> Vacancy_ { get; set; }
        public DbSet<Grades> Grade_ { get; set; }
        public DbSet<Resume> Resumes { get; set; }
    }
    public class Initializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            Repository rep = new Repository();

            for (int i = 0; i < rep.spez.Count; i++)
                context.Specializations_.Add(rep.spez[i]);

            for (int j = 0; j < rep.grade.Count; j++)
                context.Grade_.Add(rep.grade[j]);
            context.SaveChanges();
        }
    }
}