using FarmaciaPerformanceGo.Model;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaPerformanceGo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");

            modelBuilder.Entity<Produto>()
                        .HasOne(c => c.Categoria)
                        .WithMany(p => p.Produto)
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Produto> Produto { get; set; } = null!;
        public DbSet<Categoria> Categoria { get; set; } = null!;

    }
}