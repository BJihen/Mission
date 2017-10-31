using PonosDomaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PonosWeb.Models
{
    public class ReservationViewModel
    {
      
        public int reservationId { get; set; }
  
        public int trainingonlineId { get; set; }

        public int UserId { get; set; }

        public virtual User utilisateur { get; set; }
        public virtual Trainingonline formation { get; set; }

        public DateTime dateReservation { get; set; }
    }
}