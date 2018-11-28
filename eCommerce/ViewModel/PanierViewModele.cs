using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.ViewModel
{
    public class PanierViewModele
    {
        //Nom et Nombre de produits dans le panier, calcul du prix, frais de livraison lié au poids
        [Key]
        public string nom { get; set; }
        public long Nbre { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int idProduit { get; set; }
    }
}