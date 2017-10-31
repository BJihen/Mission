using PonosData.Configuration;
using PonosData.CustumConvention;
using PonosDomaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosData
{
   public class PonosContext :DbContext
    {
        public PonosContext() : base("Name=ConnectionStringName")
        {

        }

        public DbSet<User> utilisateurs { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Campany> campanys { get; set; }
        public DbSet<Commentaire> Commentaire { get; set; }
        public DbSet<Trainingonline> trainingonline { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Conventions.Add(new DateTimeConvention() );
            modelBuilder.Configurations.Add(new FormationConfiguration());
        }



        

        }
}
