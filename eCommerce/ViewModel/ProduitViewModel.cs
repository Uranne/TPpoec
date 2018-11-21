using eCommerce.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace eCommerce.ViewModel
{
    public class ProduitViewModel
    {
        public Produit produit { get; set; }
        public HttpPostedFileBase[] images { get; set; }
    }
}