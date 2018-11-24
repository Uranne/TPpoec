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
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Index()
        {
            return View(RepFab.Lister());
        }

        // GET: Fabriquant/Details/5
        public ActionResult Details(int id)
        {
            return View(RepFab.Trouver(id));
        }

        // GET: Fabriquant/Create
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabriquant/Create
        //La création est uniquement disponible pour le backoffice  
        [HttpPost]
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
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
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Edit(int id)
        {
            return View(RepFab.Trouver(id));
        }

        // POST: Fabriquant/Edit/5
        [HttpPost]
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
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
        
        // TODO: Permettre de désactiver un Fabriquant -> cela implique une désactivation des produits liés -> Demander confirmation.
    }
}
