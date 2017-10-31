using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PonosWeb.Models
{
    public class CampanyViewModel
    {
        public int campanyId { get; set; }
        public string status { get; set; }
        public string activitySector { get; set; }
        public string category { get; set; }
        public double Solde { get; set; }

    }
}