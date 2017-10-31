using PonosService;
using PonosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonosWeb.Controllers
{
    public class ProfilController : Controller
    {
        UserService US = null;
        CampanyService CS = null;

        public ProfilController()
        {
            US = new UserService();
            CS = new CampanyService();
        }
        // GET: Profil
        public ActionResult Index()
        {
            List<UserViewModel> list = new List<UserViewModel>();
            foreach (var item in US.GetAll())
            {
                UserViewModel UVM = new UserViewModel();
                UVM.firstnamePerson = item.firstnamePerson;
                UVM.lastnamePerson = item.lastnamePerson;
                UVM.solde = item.solde;
                list.Add(UVM);

            }
            return View(list);
        }



        public ActionResult ProfilCampany()
        {
            List<CampanyViewModel> list = new List<CampanyViewModel>();
            foreach (var item in CS.GetAll())
            {
                CampanyViewModel UVM = new CampanyViewModel();
                UVM.activitySector = item.activitySector;
             
                UVM.Solde = item.Solde;
                list.Add(UVM);

            }
            return View(list);
        }
        // GET: Profil/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profil/Create
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

        // GET: Profil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profil/Edit/5
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

        // GET: Profil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profil/Delete/5
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
