using Microsoft.EntityFrameworkCore;
using WebApiCSharp.Data.Map;
using WebApiCSharp.Models;

namespace WebApiCSharp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<EstoqueModel> Estoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            base.OnModelCreating(modelBuilder);
        }
    } 
}
