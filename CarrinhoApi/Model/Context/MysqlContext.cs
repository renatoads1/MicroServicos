using Microsoft.EntityFrameworkCore;

namespace CarrinhoApi.Model.Context
{
    public class MysqlContext: DbContext
    {
        public MysqlContext()
        {
            
        } 
        public MysqlContext(DbContextOptions<MysqlContext> opt): base(opt)
        {            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CarrinhoCabeca> CarrinhoCabeca { get; set; }
        public DbSet<CarrinhoDetalhe> CarrinhoDetalhe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Faca de Açougueiro",
                Price = 10.00M,
                Description = "Faca de Açougueiro para churrasco",
                CategoryName = "Facas",
                ImageUrl = "https://facas/150.jpg"
            });
        }

    }
}
