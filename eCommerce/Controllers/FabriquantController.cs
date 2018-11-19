using eCommerce.DataAcccess;
using eCommerce.DataAccess;
using eCommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class FabriquantController : Controller
    {
        IRepository<Fabriquant> RepFab = new EFRepository<Fabriquant>();

        // GET: Fabriquant
        //Version BackOffice de l'index
        public ActionResult Index()
        {
            return View(RepFab.Lister());
        }

        // GET: Fabriquant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fabriquant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabriquant/Create
        //La création est uniquement disponible pour le backoffice  
        [HttpPost]
        public ActionResult Create(Fabriquant f)
        {
            try
            {
                // TODO: Gérer le catch ici
                RepFab.Ajouter(f);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fabriquant/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RepFab.Trouver(id));
        }

        // POST: Fabriquant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Fabriquant f)
        {
            try
            {
                // TODO: Faire le catch ici
                RepFab.Modifier(id, f);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fabriquant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fabriquant/Delete/5
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
