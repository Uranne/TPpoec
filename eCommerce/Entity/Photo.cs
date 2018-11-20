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
        public byte[] Image { get; set; }

        [Required]
        public int IdProduit { get; set; }

        
        public string ImageType { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
