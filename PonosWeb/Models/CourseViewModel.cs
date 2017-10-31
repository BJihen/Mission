using PonosDomaine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PonosWeb.Models
{
    public class CourseViewModel
    {


        public int CourseId { get; set; }
        public string description { get; set; }

        public string titre { get; set; }
        public int nbPage { get; set; }
        public DateTime dateAjout { get; set; }
        //[DisplayName("Upload File")]
        //public string ImagePath { get; set; }


        //  public HttpPostedFileBase ImageFile { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }




        public int trainingonlineId { get; set; }
        [ForeignKey("trainingonlineId")]
        public string training { get; set; }


    }
}