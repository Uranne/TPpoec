namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.Fabriquant")]
    public partial class Fabriquant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fabriquant()
        {
            AdresseFabricants = new HashSet<AdresseFabricant>();
            Produits = new HashSet<Produit>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nom { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdresseFabricant> AdresseFabricants { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
