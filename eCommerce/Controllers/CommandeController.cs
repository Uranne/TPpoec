using eCommerce.DataAcccess;
using eCommerce.DataAccess;
using eCommerce.Entity;
using eCommerce.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class CommandeController : Controller
    {

        IRepository<Client> RepClient = new EFRepository<Client>();
        IRepository<Produit> RepProduit = new EFProduitRepository();
        IRepository<AdresseClient> RepAdresse = new EFRepository<AdresseClient>();
        IRepository<Commande> RepCommande = new EFRepository<Commande>();

        // GET: Ajouter Au Panier
        public ActionResult Ajouter(int id)
        {

            try
            {
                if (((Commande)Session["Panier"]).DetailCommandes.Where(d => d.IdProduit == id).Any())
                {
                    ((Commande)Session["Panier"]).DetailCommandes.Where(d => d.IdProduit == id).First().Qty += 1;
                }
                else
                {
                    DetailCommande UnProduit = new DetailCommande();
                    UnProduit.IdProduit = id;
                    UnProduit.Qty = 1;
                    ((Commande)Session["Panier"]).DetailCommandes.Add(UnProduit);
                }
                return RedirectToAction("Fiche", "Produit", new { id });
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        // GET: Commande
        public ActionResult Index()
        {
            //Créer un objet représentant les éléments à afficher dans le panier : Nom et Nombre de produits dans le panier, calcul du prix, frais de livraison lié au poids
            //Passer par un viewModel
            List<PanierViewModele> data = ConstructionPanier((Commande)Session["Panier"]);
            return View(data);
        }

        private List<PanierViewModele> ConstructionPanier(Commande commande)
        {
            List<PanierViewModele> data = new List<PanierViewModele>();
            double poids = 0;
            decimal prixTotal = 0;
            ViewBag.Port = 0;
            foreach (DetailCommande item in (commande.DetailCommandes))
            {
                data.Add(new PanierViewModele { nom = RepProduit.Trouver(item.IdProduit).Nom, Nbre = item.Qty, PrixUnitaire = RepProduit.Trouver(item.IdProduit).Prix, idProduit = item.IdProduit });
                poids = item.Qty * RepProduit.Trouver(item.IdProduit).Poids;
                prixTotal += RepProduit.Trouver(item.IdProduit).Prix * item.Qty;
            }
            if (poids > 1500)
            {
                ViewBag.Port = 3;
            }
            ViewBag.Total = prixTotal;
            return data;
        }

        public ActionResult Plus(int id)
        {
            ((Commande)Session["Panier"]).DetailCommandes.Where(co => co.IdProduit == id).First().Qty += 1;
            return RedirectToAction("Index");
        }

        public ActionResult Moins(int id)
        {
            if (((Commande)Session["Panier"]).DetailCommandes.Where(co => co.IdProduit == id).First().Qty == 1)
            {
                Delete(id);
            }
            else
            {
                ((Commande)Session["Panier"]).DetailCommandes.Where(co => co.IdProduit == id).First().Qty -= 1;
            }
            return RedirectToAction("Index");
        }

        // GET: Commande/Delete/5
        public ActionResult Delete(int id)
        {
            ((Commande)Session["Panier"]).DetailCommandes = ((Commande)Session["Panier"]).DetailCommandes.Where(co => co.IdProduit != id).ToList();
            return RedirectToAction("Index");
        }

        public ActionResult Commander()
        {
            if (Request.IsAuthenticated)
            {
                List<SelectListItem> dataLivraison = new List<SelectListItem>();
                List<SelectListItem> dataPaiement = new List<SelectListItem>();

                foreach (AdresseClient item in RepClient.Lister().Where(c => c.Identifiant == User.Identity.GetUserId()).First().AdresseClients)
                {
                    dataLivraison.Add(new SelectListItem
                    {
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
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Commander(int idLivraison, int idPaiement)
        {
            Commande Cmd = (Commande)Session["Panier"];
            Cmd.DateCommande = DateTime.Today;
            Cmd.IdClient = RepClient.Lister().Where(c => c.Identifiant == User.Identity.GetUserId()).First().Id;
            Cmd.IdAdresse = idLivraison;
            RepCommande.Ajouter(Cmd);
            Session["Panier"] = new Commande();
            return RedirectToAction("NosProduit", "Produit");
        }

        public ActionResult ListerCommande()
        {
            return View(RepCommande.Lister().Where(c => c.IdClient == RepClient.Lister().Where(cl => cl.Identifiant == User.Identity.GetUserId()).First().Id));
        }

        public ActionResult Details(int id)
        {
            //Le détail se compose de la liste des produits + prix + total, et de l'adresse d'envoie
            List<PanierViewModele> details = ConstructionPanier(RepCommande.Trouver(id));
            AdresseClient livraison = RepCommande.Trouver(id).AdresseClient;
            ViewBag.Adresse = string.Format("{5} {0} {1} {2} {3} {4}", livraison.numero, livraison.Voie, livraison.codePostal, livraison.Ville, livraison.Pays, livraison.InfoSup);
            return View(details);
        }

    }
}
