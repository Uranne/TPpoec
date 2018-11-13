namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.AdresseFabricant")]
    public partial class AdresseFabricant
    {
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

        public int IdFabricant { get; set; }

        public virtual Fabriquant Fabriquant { get; set; }
    }
}
