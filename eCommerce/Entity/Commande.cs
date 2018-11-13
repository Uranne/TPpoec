namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.Commande")]
    public partial class Commande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commande()
        {
            DetailCommandes = new HashSet<DetailCommande>();
        }

        public int Id { get; set; }

        public DateTime DateCommande { get; set; }

        public DateTime? DatePreparation { get; set; }

        public DateTime? DateEnvoi { get; set; }

        public int IdClient { get; set; }

        public int IdAdresse { get; set; }

        public virtual AdresseClient AdresseClient { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCommande> DetailCommandes { get; set; }
    }
}
