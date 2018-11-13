namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.DetailCommande")]
    public partial class DetailCommande
    {
        public int Id { get; set; }

        public decimal? PrixDiscount { get; set; }

        public long Qty { get; set; }

        public int IdCommande { get; set; }

        public int IdProduit { get; set; }

        public virtual Commande Commande { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
