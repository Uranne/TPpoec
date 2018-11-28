namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.AdresseClient")]
    public partial class AdresseClient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdresseClient()
        {
            Commandes = new HashSet<Commande>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Voie { get; set; }

        [Required]
        [StringLength(10)]
        public string numero { get; set; }

        [Required]
        [StringLength(10)]
        public string codePostal { get; set; }

        [Required]
        [StringLength(20)]
        public string Ville { get; set; }

        [StringLength(20)]
        public string Pays { get; set; }

        [StringLength(10)]
        public string InfoSup { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        public int IdClient { get; set; }

        public bool PaiementDefaut { get; set; }

        public bool LivraisonDefaut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commande> Commandes { get; set; }

        public virtual Client Client { get; set; }
    }
}
