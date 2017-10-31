using PonosDomaine.Entities;
using PonosService;
using PonosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonosWeb.Controllers
{
    public class ReservationController : Controller
    {
        ReservationService RS = null;

        public ReservationController()
        {
            RS = new ReservationService();
        }

        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Create(ReservationViewModel RVM)
        {
            TrainingService ts = new TrainingService();
            Trainingonline t = new Trainingonline();
            //PersonService ps = new PersonService();
            String id = Request.Url.AbsolutePath.Split('/').Last();
            int x = Int32.Parse(id);
            t=  ts.GetById(x);
            Reservation R = new Reservation();
            R.UserId = 1;
            R.trainingonline = x;
            R.dateReservation = DateTime.Now;
            //////////////////////interdire 2 reservation 
            IEnumerable<Reservation> jj = RS.getReservationIdUserId(R.trainingonline, R.UserId);
            if (jj.Any()== false)
            {
                if (RS.Paiement(t))
                {
                    t.nbReservation++;
                    ts.Update(t);
                    ts.Commit();

                    RS.Add(R);
                    RS.Commit();

                    return RedirectToAction("DetailsForSimpleUser", "Training", new { id = R.trainingonline });
                }
                else
                {
                    ViewBag.MessageErreur = " vous n'avez plus de solde";
                }
            }
            else
            {
                ViewBag.MessageErreur = " Vous avez déja reserver";
                return View();
            }
            return View();
            //if (RS.Paiement(t)) {
            //    R.etat="Payer";
            //}

            //t.nbReservation++;
            //ts.Update(t);
            //ts.Commit();

            //RS.Add(R);
            //RS.Commit();
            //return View();
            // return RedirectToAction("DetailsForSimpleUser", "Training", new { id = R.trainingonline });

        }


        



        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
