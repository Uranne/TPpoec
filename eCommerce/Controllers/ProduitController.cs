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
    public class ProduitController : Controller
    {
        IRepository<Produit> RepProduit = new EFRepository<Produit>();

        // GET: Produit
        public ActionResult Index()
        {
            return View(RepProduit.Lister());
        }

        // GET: Produit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(Produit p)
        {
            try
            {
                // TODO: Add insert logic here
                RepProduit.Ajouter(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produit/Edit/5
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

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produit/Delete/5
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
