using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosDomaine.Entities
{
   public class Course
    {
       
        public int CourseId { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        [MaxLength(50)]
        public string titre { get; set; }
        public int nbPage { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateAjout { get; set; }

        public int trainingonlineId { get; set; }
        [ForeignKey("trainingonlineId")]
        public Trainingonline training { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }



        /*   public int PersonId { get; set; }
           [ForeignKey("PersonId")]
           public Person person{ get; set; }*/



    }
}
