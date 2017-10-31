using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosDomaine.Entities
{
   public class Commentaire
    {
        public int CommentaireId { get; set; }
        public string description { get; set; }

        public int trainingonlineId { get; set; }
        [ForeignKey("trainingonlineId")]
        public Trainingonline training { get; set; }
    }
}
