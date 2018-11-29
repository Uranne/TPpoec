namespace eCommerce.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFModelTirelire : DbContext
    {
        public EFModelTirelire()
            : base("name=EFModelTirelire1")
        {
        }

        public virtual DbSet<AdresseClient> AdresseClients { get; set; }
        public virtual DbSet<AdresseFabricant> AdresseFabricants { get; set; }
        public virtual DbSet<Avi> Avis { get; set; }
        public virtual DbSet<BackOffice> BackOffices { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<DetailCommande> DetailCommandes { get; set; }
        public virtual DbSet<Fabriquant> Fabriquants { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdresseClient>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.AdresseClient)
                .HasForeignKey(e => e.IdAdresse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.AdresseClients)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Avis)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commande>()
                .HasMany(e => e.DetailCommandes)
                .WithRequired(e => e.Commande)
                .HasForeignKey(e => e.IdCommande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetailCommande>()
                .Property(e => e.PrixDiscount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Fabriquant>()
                .HasMany(e => e.AdresseFabricants)
                .WithRequired(e => e.Fabriquant)
                .HasForeignKey(e => e.IdFabricant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fabriquant>()
                .HasMany(e => e.Produits)
                .WithRequired(e => e.Fabriquant)
                .HasForeignKey(e => e.IdFabricant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Prix)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.Avis)
                .WithRequired(e => e.Produit)
                .HasForeignKey(e => e.IdProduit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.DetailCommandes)
                .WithRequired(e => e.Produit)
                .HasForeignKey(e => e.IdProduit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.Photos)
                .WithRequired(e => e.Produit)
                .HasForeignKey(e => e.IdProduit)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<eCommerce.ViewModel.ProduitImageViewModel> ProduitImageViewModels { get; set; }

        public System.Data.Entity.DbSet<eCommerce.ViewModel.PanierViewModele> PanierViewModeles { get; set; }
    }
}
