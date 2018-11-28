using eCommerce.DataAcccess;
using eCommerce.Entity;
using eCommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class CommandeController : Controller
    {
        IRepository<Produit> RepProduit = new EFProduitRepository();
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
            List<PanierViewModele> data = new List<PanierViewModele>();
            double poids = 0;
            decimal prixTotal=0;
            ViewBag.Port = 0;
            foreach (DetailCommande item in ((Commande)Session["Panier"]).DetailCommandes)
            {
                data.Add(new PanierViewModele { nom = RepProduit.Trouver(item.IdProduit).Nom, Nbre = item.Qty, PrixUnitaire = RepProduit.Trouver(item.IdProduit).Prix, idProduit=item.IdProduit });
                poids = item.Qty * RepProduit.Trouver(item.IdProduit).Poids;
                prixTotal += RepProduit.Trouver(item.IdProduit).Prix*item.Qty;
            }
            if (poids>1500)
            {
                ViewBag.Port = 3;
            }
            ViewBag.Total = prixTotal;
            return View(data);
        }

        public ActionResult Plus(int id)
        {
            ((Commande)Session["Panier"]).DetailCommandes.Where(co => co.IdProduit == id).First().Qty += 1;
            return RedirectToAction("Index");
        }

        public ActionResult Moins(int id)
        {
            if (((Commande)Session["Panier"]).DetailCommandes.Where(co => co.IdProduit == id).First().Qty==1)
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
    }
}
