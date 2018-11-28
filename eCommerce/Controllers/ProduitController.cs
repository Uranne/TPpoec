using eCommerce.DataAcccess;
using eCommerce.DataAccess;
using eCommerce.Entity;
using eCommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    // TODO: Penser à proposer une méthode de désactivation ou activation de produit multiple
    // TODO: Proposer des méthodes de tri pour les Produits : Nom, Id, Status, Fabriquants
    public class ProduitController : Controller
    {
        IRepository<Produit> RepProduit = new EFProduitRepository();
        IRepository<Fabriquant> RepFab = new EFRepository<Fabriquant>();
        IRepository<Photo> RepPhoto = new EFRepository<Photo>();

        // GET: Produit
        //Index des produits côté BackOffice
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Index()
        {
            return View(RepProduit.Lister());
        }

        // GET: Produit
        //Index des produits Vue Client
        public ActionResult NosProduits()
        {
            List<Produit> data = RepProduit.Lister().ToList().Where(p=>p.Status!=true).ToList();

            return View(data);
        }

        // GET: Produit/Details/5
        //Détail des produits côté BackOffice
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Details(int id)
        {
            return View(RepProduit.Trouver(id));
        }

        //GET: Produit/Fiche/...
        //Détail d'un produit Vue Client
        public ActionResult Fiche(int id)
        {
            return View(RepProduit.Trouver(id));
        }

        //GET: Vue partiel qui défini jusqu'à 4 éléments de couleur similaire à l'argument
        public PartialViewResult VoirAussi(string couleur, int banId)
        {
            IEnumerable<Produit> produits = RepProduit.Lister().Where(p => p.Couleur == couleur && p.Id!= banId).Take(4);
            return PartialView(produits);
        }

        // GET: Produit/Create
        //Création d'un produit : cette méthode ne peut être executé par un client
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
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
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Create(ProduitViewModel retour)
        {
            try
            {
                // TODO: Ajouter la mise en place de photo
                // TODO: AJouter un bouton cloner en plus de edit, détails et delete qui prérempli le formulaire (Emmene vers une vue détail avec l'option de cloner en plus)
                // TODO: Envoyer le nouveau fabriquant sans recharger la page et définir son ID dans la requête de sortie
                // TODO: Le catch de l'erreur
                Produit p = retour.produit;
                p = RepProduit.Ajouter(p);

                
                foreach (HttpPostedFileBase item in retour.images)
                {
                    MemoryStream fileData = new MemoryStream();
                    item.InputStream.CopyTo(fileData);
                    Photo ph = new Photo { Image = fileData.ToArray(), IdProduit = p.Id, ImageType = string.Format("data:{0};base64,", item.ContentType) };
                    RepPhoto.Ajouter(ph);
                    fileData.Dispose();
                }

                return RedirectToAction("Index");
                //Il serait aussi possible de renvoyer au détail de l'objet plutôt qu'à l'index en sortie de création d'objet
            }
            catch
            {
                InitialisationDropListFabriquant();
                return View();
            }
        }

        [HttpPost]
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Disable(FormCollection collection)//string elements)
        {
            #region Traitement avec $.post
            //string[] checke = elements.Split(',');
            //int id;
            //foreach (string item in checke)
            //{
            //    if (item!="")
            //    {
            //        item.Replace("disable", "");
            //        if (int.TryParse(item, out id))
            //        {
            //            Produit p = RepProduit.Trouver(id);
            //            p.Status = true;
            //            RepProduit.Modifier(id, p);
            //        }
            //        else
            //        {
            //            throw new Exception("Les résultats postés ne correspondent pas au schéma de donnée attendu");
            //        }

            //    }
            //} 
            #endregion
            var checkboxes = collection.AllKeys.Where(k => k.StartsWith("_"));

            
            foreach (var item in checkboxes)
            {
                if (collection[item] != "false")
                {
                    Produit p = RepProduit.Trouver(int.Parse(item.Substring(1, item.Length - 1)));
                    p.Status = !p.Status;
                    RepProduit.Modifier(p.Id, p);
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Produit/Edit/5
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Edit(int id)
        {
            InitialisationDropListFabriquant();
            return View(RepProduit.Trouver(id));
        }

        // POST: Produit/Edit/5
        [HttpPost]
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
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
