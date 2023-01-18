
using STIVE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace STIVE_API.Helpers
{
    public class STIVE_Context : DbContext
    {
        public DbSet<Article> articles { get; set; }

     

        public DbSet<CommandeClient> commandeClients { get; set; }  

        public DbSet<Utilisateur> utilisateurs { get; set; }

        public DbSet<Domaine> domaines { get; set; }
        public DbSet<Tva> tvas { get; set; }

        public DbSet<Famille> familles { get; set; }

        public DbSet<Fonction> fonctions { get; set; }

        public DbSet<LigneCommandeClient> ligneCommandeClients { get; set; }

        public DbSet<CommandeDomaine> commandeDomaines { get; set; }

        public DbSet<LigneCommandeDomaine> ligneCommandeDomaines { get; set; }
        public DbSet<EtatCommande> etatCommandes { get; set; }
        public DbSet<Coef> coefs { get; set; }


        public STIVE_Context() { }
        public STIVE_Context(DbContextOptions<STIVE_Context> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;database=Stive", ServerVersion.Parse("8.0.31-mysql"));
            }
        }

    }
}
