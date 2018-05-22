namespace Crud_LuisMoraes.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Estabelecimentos> Estabelecimentos { get; set; }
        public virtual DbSet<Uf> Uf { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>()
                .HasMany(e => e.Estabelecimentos)
                .WithRequired(e => e.Categorias)
                .HasForeignKey(e => e.categoriaId)
                .WillCascadeOnDelete(false);
        }
    }
}
