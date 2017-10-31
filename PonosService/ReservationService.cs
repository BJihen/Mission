using PonosData.Infrastructure;
using PonosDomaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosService
{
    public class ReservationService : Service<Reservation>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        

        public ReservationService() : base(ut)
        {





                
        }


        public IEnumerable<Reservation> getReservationIdUserId(int id1, int id2)
        {
            var res = from req in ut.getRepository<Reservation>().GetAll()
                      where (req.trainingonline == id1 && req.UserId == id2)
                      select req;

            return res;
        }




        public bool Paiement(Trainingonline t)
        {
            Reservation R = new Reservation();
            UserService us = new UserService();
            User u = us.GetById(1);
            CampanyService CS = new CampanyService();
            Campany c = CS.GetById(1);
            if (t.price < u.solde)
            {

                c.Solde = c.Solde + t.price;
                CS.Update(c);
                CS.Commit();
                u.solde = u.solde - t.price;
                us.Update(u);
                us.Commit();
                


            return true;
            }

            else return false;

        }

       


        public IEnumerable<Reservation> getEtatPayer()
        {
            var res = from req in ut.getRepository<Reservation>().GetAll()
                      where (req.etat=="Payer")
                      select req;
            return res;
        }

       
        public bool openUserFormation(int iduser, int trId)
        {
           
            IEnumerable<Reservation> lst = new List<Reservation>();
            lst=ut.getRepository<Reservation>().GetMany(x =>
           
                x.etat == "Payer"&&x.UserId==iduser&&x.trainingonline==trId

            );
            if (lst.Count() != 0)
            {
                return true;
            }
            else return false;

        }

    }
}
