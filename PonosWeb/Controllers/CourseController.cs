using PonosDomaine.Entities;
using PonosService;
using PonosWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace PonosWeb.Controllers
{

    public class CourseController : Controller
    {
        CourseService CS = null;

        

        public CourseController()
        {
            CS = new CourseService();
           
        }

        // GET: Course
        public ActionResult Index()
        {
            List<CourseViewModel> list = new List<CourseViewModel>();

            IEnumerable<Course> cc = CS.GetCourseTrier();
            foreach (var item in cc)
            {

                CourseViewModel CVM = new CourseViewModel();

                CVM.CourseId = item.CourseId;
                CVM.titre = item.titre;
                CVM.description = item.description;
                CVM.dateAjout = item.dateAjout;
                CVM.nbPage = item.nbPage;

                CVM.ImageUrl = item.ImageUrl;
                list.Add(CVM);

            }
            return View(list);
        }

     

        // GET: Course/Details/5
        public ActionResult Details([Bind(Include = "CourseId,titre,description,dateAjout,PersonId")] int id)
        {
            CourseViewModel CVM = new CourseViewModel();
            Course c = CS.GetById(id);
            CVM.CourseId = c.CourseId;
            CVM.titre = c.titre;
            CVM.description = c.description;
            CVM.dateAjout = c.dateAjout;
            CVM.nbPage = c.nbPage;
          //  CVM.ImagePath = c.ImagePath;

            return View(CVM);
        }




      

        // GET: Course/Create
        public ActionResult Create()
        {
            TrainingService TS = new TrainingService();
            IEnumerable<Trainingonline> trainings = TS.GetAll();
            List<SelectListItem> ls = new List<SelectListItem>();
            foreach (var temp in trainings)
            {
                ls.Add(new SelectListItem() { Text = temp.titre, Value = temp.trainingonlineId.ToString() });
            }
            ViewData["Training"] = ls;
            ViewBag.Training = ls;

            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseViewModel CVM , HttpPostedFileBase Image) 
        {
            
                Course c = new Course();

            
            c.trainingonlineId = int.Parse(CVM.training);


            // c.PersonId = 2;
         //   c.trainingonlineId = 2;
                c.description = CVM.description;
                c.titre = CVM.titre;
                c.nbPage = CVM.nbPage;
            CVM.ImageUrl = Image.FileName;
            c.dateAjout = DateTime.Now;

       
            c.ImageUrl = CVM.ImageUrl;
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);


            CS.Add(c);
            CS.Commit();
                                 return RedirectToAction("Index");
           
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            CourseViewModel CVM = new CourseViewModel();
            Course c = CS.GetById(id);
            CVM.CourseId = c.CourseId;
            CVM.titre = c.titre;
            CVM.description = c.description;
            CVM.dateAjout = c.dateAjout;
            CVM.nbPage = c.nbPage;

            return View(CVM);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel CVM)
        {
            Course c = CS.GetById(id);
            c.description = CVM.description;
            c.titre = CVM.titre;
            c.nbPage = CVM.nbPage;
            c.dateAjout = CVM.dateAjout;
            CS.Update(c);
            CS.Commit();
            return RedirectToAction("Index");

        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            CourseViewModel CVM = new CourseViewModel();
            Course c = CS.GetById(id);
            CVM.CourseId = c.CourseId;
            CVM.titre = c.titre;
            CVM.dateAjout = c.dateAjout;
            CVM.description = c.description;
            CVM.nbPage = c.nbPage;

            return View(CVM);

        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CourseViewModel CVM)
        {
            Course c = CS.GetById(id);
            c.description = CVM.description;
            c.titre = CVM.titre;
            c.nbPage = CVM.nbPage;
            c.dateAjout = CVM.dateAjout;
            CS.Delete(c);
            CS.Commit();
            return RedirectToAction("Index"); 

        }
    }
}
