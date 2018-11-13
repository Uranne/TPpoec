namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            AdresseClients = new HashSet<AdresseClient>();
            Avis = new HashSet<Avi>();
            Commandes = new HashSet<Commande>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nom { get; set; }

        [Required]
        [StringLength(20)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(10)]
        public string Skin { get; set; }

        public DateTime DateNaissance { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(13)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(512)]
        public string Identifiant { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdresseClient> AdresseClients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
