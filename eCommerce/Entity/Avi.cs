namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.Avis")]
    public partial class Avi
    {
        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Message { get; set; }

        public int IdModerateur { get; set; }

        public int IdProduit { get; set; }

        public int IdClient { get; set; }

        public short Note { get; set; }

        public DateTime Date { get; set; }

        public virtual Client Client { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
