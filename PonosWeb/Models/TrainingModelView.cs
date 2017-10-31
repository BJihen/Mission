using PonosDomaine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PonosWeb.Models
{
    public class TrainingModelView
    {
        public int trainingonlineId { get; set; }
        public string titre { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int nbReservation { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }


        public virtual ICollection<Reservation> listeReservation { get; set; }
        public virtual IEnumerable<Course> listeCourse { get; set; }
        public virtual IEnumerable<Trainingonline> TopTraining { get; set; }

    }
}