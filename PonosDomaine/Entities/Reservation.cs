using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosDomaine.Entities
{
   public class Reservation
    {
        [Key, Column(Order = 1)]
        public int trainingonline { get; set; }

        [Key, Column(Order = 2)]
        public int UserId { get; set; }

        [Key, Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reservationId { get; set; }

        public string etat { get; set; }

        public  virtual User utilisateur { get; set; }
        public virtual Trainingonline formation { get; set; }

        public DateTime dateReservation { get; set; }

    }
}
