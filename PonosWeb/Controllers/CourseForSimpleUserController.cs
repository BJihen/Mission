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
    public class CourseForSimpleUserController : Controller
    {
        CourseService CS = null;

        public CourseForSimpleUserController()
        {
            CS = new CourseService();
        }

        // GET: CourseForSimpleUser
        public ActionResult Index()
        {
            List<CourseViewModel> list = new List<CourseViewModel>();
            foreach (var item in CS.GetAll())
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
           // CVM.ImagePath = c.ImagePath;

            return View(CVM);
        }


        // GET: CourseForSimpleUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseForSimpleUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseForSimpleUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseForSimpleUser/Edit/5
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

        // GET: CourseForSimpleUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseForSimpleUser/Delete/5
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
