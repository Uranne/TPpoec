namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.Photo")]
    public partial class Photo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        public int IdProduit { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
