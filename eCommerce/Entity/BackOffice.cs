namespace eCommerce.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tab.BackOffice")]
    public partial class BackOffice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Identifiant { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(20)]
        public string role { get; set; }
    }
}
