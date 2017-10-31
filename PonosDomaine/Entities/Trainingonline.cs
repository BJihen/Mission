using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosDomaine.Entities
{
    public class Trainingonline
    {
       [Key]
        public int trainingonlineId { get; set; }
        public string titre { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int nbReservation { get; set; }

        public virtual IEnumerable<Commentaire> listCommentaire { get; set; }



        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }


        public virtual ICollection<Reservation> listeReservation { get; set; }
        public virtual ICollection<Course> listeCourses { get; set; }

        //public int PersonId { get; set; }
        //[ForeignKey("PersonId")]
        //public Person person { get; set; }


        public int campanyId { get; set; }
        [ForeignKey("campanyId")]
        public Campany campany { get; set; }



    }
}
