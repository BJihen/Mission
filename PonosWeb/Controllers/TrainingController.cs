using PonosDomaine.Entities;
using PonosService;
using PonosWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonosWeb.Controllers
{
    public class TrainingController : Controller
    {
        TrainingService TS = null;
        public TrainingController()
        {
            TS = new TrainingService();
        }

        // GET: Training
        public ActionResult Index()
        {
            List<TrainingModelView> list = new List<TrainingModelView>();
            foreach (var item in TS.GetAll())
            {
                TrainingModelView TMV = new TrainingModelView();

                TMV.titre = item.titre;
                TMV.price = item.price;
                TMV.description = item.description;
                TMV.trainingonlineId = item.trainingonlineId;
                TMV.ImageUrl = item.ImageUrl;
                list.Add(TMV);

            }
            return View(list);
        }

        /// <summary>
        ///  IEnumerable<Course> lst = new List<Course>();
    ///    lst = TS.GetCoursesByTrainingId(id);
        /// </summary>
        /// <returns></returns>

        // GET: Training
        //public ActionResult TopFormation()
        //{
        //    List<TrainingModelView> list = new List<TrainingModelView>();
        //    //foreach (var item in TS.GetTopTraining())
        //    //{
        //        TrainingModelView TMV = new TrainingModelView();

        //    //    TMV.titre = item.titre;
        //    //    TMV.price = item.price;
        //    //    TMV.description = item.description;
        //    //    TMV.trainingonlineId = item.trainingonlineId;
        //    //    TMV.ImageUrl = item.ImageUrl;
        //    //    list.Add(TMV);

        //    //}
        //    IEnumerable<Trainingonline> lst = new List<Trainingonline>();
        //    lst = TS.GetTopTraining();
        //    foreach (var item in lst)
        //    {
                

        //        TMV.titre = item.titre;
        //        TMV.price = item.price;
        //        TMV.description = item.description;
        //        TMV.trainingonlineId = item.trainingonlineId;
        //        TMV.ImageUrl = item.ImageUrl;
        //        TMV.TopTraining = lst;
        //        list.Add(TMV);
        //          ViewBag.data = lst;
        //    }
            

          
        //    return View(lst);
        //}





        // GET: Training
        public ActionResult TrainingForSimpleUser()
        {
            IEnumerable<Trainingonline> lst = new List<Trainingonline>();
            lst = TS.GetTopTraining();

            List<TrainingModelView> list = new List<TrainingModelView>();
            foreach (var item in TS.GetAll())
            {
                TrainingModelView TMV = new TrainingModelView();
                
                TMV.titre = item.titre;
                TMV.price = item.price;
                TMV.description = item.description;
                TMV.trainingonlineId = item.trainingonlineId;
                TMV.ImageUrl = item.ImageUrl;
                TMV.TopTraining = lst;
                list.Add(TMV);
               
            }


            ViewBag.data = lst;
            return View(list);
        }



        // GET: Training/Details/5
        public ActionResult DetailsForSimpleUser(int id)


        {
            Reservation R = new Reservation();
            ReservationService RS = new ReservationService();
           // R = RS.GetById(id);
           // R = RS.GetMany(res => res.trainingonline == 2 && res.UserId == 1 && res.reservationId == 4).First();
            IEnumerable<Reservation> jj = RS.getReservationIdUserId(id, 1);

            //bool isPayed = RS.openUserFormation(2, id);
           int x = 10;
            if (jj.Any() == true)
            {
                ViewBag.isPayed = x;
            }


            //    if (isPayed)
            //{
            //    ViewBag.isPayed = x;
            //}

            Trainingonline t = new Trainingonline();
            t = TS.GetById(id);
            TrainingModelView CVM = new TrainingModelView();
            IEnumerable<Course> lst = new List<Course>();
            lst = TS.GetCoursesByTrainingId(id);
            CVM.trainingonlineId = t.trainingonlineId;
            CVM.description = t.description;
            CVM.titre = t.titre;
            CVM.price = t.price;
            CVM.ImageUrl = t.ImageUrl;
            CVM.listeCourse = lst;
            
            ViewBag.data = lst;
            return View(CVM);
        }


        // GET: Training/Details/5
        public ActionResult Details(int id)


        {
            Trainingonline t = new Trainingonline();
            t = TS.GetById(id);
            TrainingModelView CVM = new TrainingModelView();
            IEnumerable<Course> lst = new List<Course>();
            lst = TS.GetCoursesByTrainingId(id);
           CVM.trainingonlineId = t.trainingonlineId;
            CVM.description = t.description;
            CVM.titre = t.titre;
            CVM.price = t.price;
            CVM.listeCourse = lst;
           
            ViewBag.data = lst;
            return View(CVM);
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Training/Create
        [HttpPost]
        public ActionResult Create(TrainingModelView TMV  ,HttpPostedFileBase Image)
        {
            Trainingonline t = new Trainingonline();
           t.campanyId = 1;
            t.titre = TMV.titre;
            t.price = TMV.price;
            t.description = TMV.description;

            TMV.ImageUrl = Image.FileName;
            t.ImageUrl = TMV.ImageUrl;


            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);

            TS.Add(t);
            TS.Commit();
            return RedirectToAction("Index");
            //  return RedirectToAction("Create","Course");



        }

        // GET: Training/Edit/5
        public ActionResult Edit(int id)
        {
            TrainingModelView CVM = new TrainingModelView();
            Trainingonline c = TS.GetById(id);
            CVM.trainingonlineId = c.trainingonlineId;
            CVM.titre = c.titre;
            CVM.description = c.description;
            CVM.price = c.price;


            return View(CVM);
        }

        // POST: Training/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TrainingModelView CVM)
        {

            Trainingonline c = TS.GetById(id);
            c.description = CVM.description;
            c.titre = CVM.titre;
            c.description = CVM.description;
            c.price = CVM.price;
           
            TS.Update(c);
            TS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int id)
        {
            TrainingModelView CVM = new TrainingModelView();
            Trainingonline c = TS.GetById(id);
            CVM.trainingonlineId = c.trainingonlineId;
            CVM.titre = c.titre;
            CVM.description = c.description;
            CVM.price = c.price;

            return View(CVM);
        }

        // POST: Training/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TrainingModelView CVM)
        {
            Trainingonline c = TS.GetById(id);
            c.description = CVM.description;
            c.titre = CVM.titre;
            c.description = CVM.description;
            c.price = CVM.price;

            TS.Delete(c);
            TS.Commit();
            return RedirectToAction("Index");
        }
    }
}
