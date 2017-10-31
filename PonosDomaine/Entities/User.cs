﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosDomaine.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string firstnamePerson { get; set; }
        public string lastnamePerson { get; set; }
        public string AdressPerson { get; set; }
        public string EmailPerson { get; set; }
        public int TelephonPerson { get; set; }
        public double solde { get; set; }
        public string PasswordPerson { get; set; }



        public virtual ICollection<Reservation> listeReservation { get; set; }

    }
}
