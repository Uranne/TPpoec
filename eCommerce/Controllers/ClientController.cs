using eCommerce.DataAcccess;
using eCommerce.DataAccess;
using eCommerce.Entity;
using Microsoft.AspNet.Identity;
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
        IRepository<AdresseClient> RepAdresse = new EFRepository<AdresseClient>();

        // GET: Client
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Index()
        {
            return View(RepClient.Lister());
        }

        //GET : Client/EditClient/identifiant
        [Authorize(Roles = CustomRoles.Client)]
        public ActionResult EditClient(string identifiant)
        {
            Client c = RepClient.Lister().Where(cl => cl.Identifiant == identifiant).First();
            List<SelectListItem> skins = new List<SelectListItem>();
            skins.Add(new SelectListItem { Value = Skins.Default, Text=Skins.Default });
            skins.Add(new SelectListItem { Value = Skins.Black, Text = Skins.Black });
            skins.Add(new SelectListItem { Value = Skins.Pink, Text = Skins.Pink });
            ViewBag.skins = skins;
            return View(c);
        }

        [HttpPost]
        [Authorize(Roles = CustomRoles.Client)]
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
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
        public ActionResult Edit(int id)
        {
            Client c = RepClient.Trouver(id);
            return View(c);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [Authorize(Roles = CustomRoles.AdminOrAssistant)]
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

        // GET: Client/Detail/id
        public PartialViewResult Detail(string identifiant)
        {
            Client client = RepClient.Lister().Where(c => c.Identifiant == identifiant).First();
            return PartialView(client);
        }

        public ActionResult Adresses(string identifiant)
        {
            List<SelectListItem> dataLivraison = new List<SelectListItem>();
            List<SelectListItem> dataPaiement = new List<SelectListItem>();

            foreach (AdresseClient item in RepClient.Lister().Where(c => c.Identifiant == identifiant).First().AdresseClients)
            {
                dataLivraison.Add(new SelectListItem {
                    Value = item.Id.ToString(),
                    Text = string.Format("{5} {0} {1} {2} {3} {4}", item.numero, item.Voie, item.codePostal, item.Ville, item.Pays, item.InfoSup),
                    Selected = item.LivraisonDefaut
                });
                dataPaiement.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = string.Format("{5} {0} {1} {2} {3} {4}", item.numero, item.Voie, item.codePostal, item.Ville, item.Pays, item.InfoSup),
                    Selected = item.PaiementDefaut
                });
            }
            ViewBag.Livraison = dataLivraison;
            ViewBag.Paiement = dataPaiement;
            return View();
        }

        [HttpPost]
        public ActionResult Adresses(int idLivraison, int idPaiement)
        {
            if (idLivraison!=RepAdresse.Lister().Where(a=>a.LivraisonDefaut).First().Id)
            {
                foreach (AdresseClient item in RepAdresse.Lister().Where(a => a.LivraisonDefaut))
                {
                    item.LivraisonDefaut = false;
                    RepAdresse.Modifier(item.Id, item);
                }
                AdresseClient ajout = RepAdresse.Trouver(idLivraison);
                ajout.LivraisonDefaut = true;
                RepAdresse.Modifier(idLivraison, ajout);                
            }
            if (idPaiement != RepAdresse.Lister().Where(a => a.PaiementDefaut).First().Id)
            {
                foreach (AdresseClient item in RepAdresse.Lister().Where(a => a.PaiementDefaut))
                {
                    item.PaiementDefaut = false;
                    RepAdresse.Modifier(item.Id, item);
                }
                AdresseClient ajout = RepAdresse.Trouver(idPaiement);
                ajout.PaiementDefaut = true;
                RepAdresse.Modifier(idPaiement, ajout);
            }
            return RedirectToAction("Adresses", new{identifiant = User.Identity.GetUserId()});
        }

        public ActionResult CreerAdresse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerAdresse(AdresseClient adresse)
        {

            try
            {
                int idClient = RepClient.Lister().Where(c => c.Identifiant == User.Identity.GetUserId()).First().Id;
                adresse.IdClient = idClient;
                if (adresse.LivraisonDefaut)
                {
                    foreach (AdresseClient item in RepAdresse.Lister().Where(a => a.LivraisonDefaut))
                    {
                        item.LivraisonDefaut = false;
                        RepAdresse.Modifier(item.Id, item);
                    }
                }
                if (adresse.PaiementDefaut)
                {
                    foreach (AdresseClient item in RepAdresse.Lister().Where(a => a.PaiementDefaut))
                    {
                        item.PaiementDefaut = false;
                        RepAdresse.Modifier(item.Id, item);
                    }
                }
                RepAdresse.Ajouter(adresse);
                return RedirectToAction("Adresses", new { identifiant =  User.Identity.GetUserId() });
            }
            catch (Exception)
            {
                return RedirectToAction("CreerAdresse");                
            }
            
        }
    }
}
