using PonosDomaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosData.Configuration
{
    class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            /* HasRequired(t => t.person).WithMany(t => t.listeCourses).HasForeignKey(p => p.PersonId)
                 .WillCascadeOnDelete(false);*/

            HasRequired(t => t.training).WithMany(t => t.listeCourses).HasForeignKey(p => p.trainingonlineId)
                .WillCascadeOnDelete(false);
        }
    }
}
