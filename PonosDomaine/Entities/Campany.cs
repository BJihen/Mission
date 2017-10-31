using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosDomaine.Entities
{
    public class Campany
    {
        public int campanyId { get; set; }
        public string status { get; set; }
        public string activitySector { get; set; }
        public string category { get; set; }
        public double Solde { get; set; }

        public virtual ICollection<Trainingonline> listeFormation { get; set; }

    }
}
