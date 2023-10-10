using FarmaciaPerformanceGo.Model;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().ToTable("tb_produtos");
        modelBuilder.Entity<Categoria>().ToTable("tb_categorias");

    }
    public DbSet<Produto> Produtos { get; set; } = null!;
    public DbSet<Categoria> Categorias { get; set; } = null!;

}
