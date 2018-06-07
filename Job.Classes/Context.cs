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
    }
    public class Initializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            Repository rep = new Repository();

            for (int i = 0; i < rep.spez; i++)
                context.Routes.Add(rep.routes[i]);

            for (int j = 0; j < rep.stations.Count; j++)
                context.Stations.Add(rep.stations[j]);
            context.SaveChanges();

        }
    }
}