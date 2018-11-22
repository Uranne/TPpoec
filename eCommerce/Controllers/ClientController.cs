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
    public class ClientController : Controller
    {

        IRepository<Client> RepClient = new EFRepository<Client>();

        // GET: Client
        public ActionResult Index()
        {
            return View(RepClient.Lister());
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
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

        //GET : Client/EditClient/identifiant
        public ActionResult EditClient(string identifiant)
        {
            Client c = RepClient.Lister().Where(cl => cl.Identifiant == identifiant).First();
            return View(c);
        }

        [HttpPost]
        public ActionResult EditClient(Client c)
        {
            try
            {
                // TODO: Add update logic here
                RepClient.Modifier(c.Id, c);
                return RedirectToAction("Index", "Manage");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            Client c = RepClient.Trouver(id);
            return View(c);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client c)
        {
            try
            {
                // TODO: Add update logic here
                RepClient.Modifier(id, c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
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
