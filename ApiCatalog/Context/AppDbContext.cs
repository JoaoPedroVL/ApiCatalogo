using Microsoft.EntityFrameworkCore;
using ApiCatalog.Model;

namespace ApiCatalog.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
    {
    }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produtos>? Produtos { get; set; }


}
