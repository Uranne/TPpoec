namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.Produit")]
    public partial class Produit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            Avis = new HashSet<Avi>();
            DetailCommandes = new HashSet<DetailCommande>();
            Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nom { get; set; }

        public double Poids { get; set; }

        public decimal Prix { get; set; }

        public bool Status { get; set; }

        public long Hauteur { get; set; }

        public long Longueur { get; set; }

        public long Largeur { get; set; }

        public double Capacite { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Couleur { get; set; }

        public int IdFabricant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCommande> DetailCommandes { get; set; }

        public virtual Fabriquant Fabriquant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
