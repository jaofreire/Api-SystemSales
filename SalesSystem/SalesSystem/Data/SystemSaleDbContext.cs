using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using SalesSystem.Data.Map;
using SalesSystem.Model;
using System.Reflection.Metadata;

namespace SalesSystem.Data
{
    public class SystemSaleDbContext : DbContext
    {
        public SystemSaleDbContext(DbContextOptions<SystemSaleDbContext> options) : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<RequestsFinaledsModel> RequestsFinaleds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new RequestsFinaledsMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
