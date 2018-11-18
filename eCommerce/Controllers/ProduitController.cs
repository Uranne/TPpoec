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
    // TODO: Penser à proposer une méthode de désactivation ou activation de produit multiple
    // TODO: Proposer des méthodes de tri pour les Produits : Nom, Id, Status, Fabriquants
    public class ProduitController : Controller
    {
        IRepository<Produit> RepProduit = new EFRepository<Produit>();
        IRepository<Fabriquant> RepFab = new EFRepository<Fabriquant>();

        // GET: Produit
        //Index des produits côté BackOffice
        public ActionResult Index()
        {
            return View(RepProduit.Lister());
        }

        // GET: Produit/Details/5
        //Détail des produits côté BackOffice
        public ActionResult Details(int id)
        {
            return View(RepProduit.Trouver(id));
        }

        // GET: Produit/Create
        //Création d'un produit : cette méthode ne peut être executé par un client
        public ActionResult Create()
        {
            InitialisationDropListFabriquant();
            return View();
        }

        private void InitialisationDropListFabriquant()
        {
            ViewBag.IDFabriquants = RepFab.Lister().Select(f => new SelectListItem { Text = f.Nom, Value = f.Id.ToString() });
        }

        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(Produit p)
        {
            try
            {
                // TODO: Ajouter la mise en place de photo
                // TODO: Proposer une vue partielle pour créer le fabriquant dans cette vue
                // TODO: Permettre de mettre des prix décimaux
                // TODO: AJouter un bouton cloner en plus de edit, détails et delete qui prérempli le formulaire (Emmene vers une vue détail avec l'option de cloner en plus)
                // TODO: Le catch de l'erreur
                RepProduit.Ajouter(p);
                return RedirectToAction("Index");
                //Il serait aussi possible de renvoyer au détail de l'objet plutôt qu'à l'index en sortie de création d'objet
            }
            catch
            {
                return View();
            }
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            InitialisationDropListFabriquant();
            return View(RepProduit.Trouver(id));
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produit p)
        {
            try
            {
                // TODO: Le catch de l'erreur
                RepProduit.Modifier(id, p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
