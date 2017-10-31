using PonosDomaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosData.Configuration
{
   public class FormationConfiguration : EntityTypeConfiguration<Reservation>
    {
        public FormationConfiguration()
        {

            HasRequired(t => t.utilisateur).WithMany(t => t.listeReservation).HasForeignKey(p => p.UserId)
                .WillCascadeOnDelete(false);


            HasRequired(t => t.formation).WithMany(t => t.listeReservation).HasForeignKey(p => p.trainingonline)
                .WillCascadeOnDelete(false);
        }
    }
}
