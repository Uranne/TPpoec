using eCommerce.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.ViewModel
{
    public class ProduitImageViewModel
    {
        [Key]
        public int id { get; set; }
        public Produit produit { get; set; }
        public Photo photo { get; set; }
    }
}