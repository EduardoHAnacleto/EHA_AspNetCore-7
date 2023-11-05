using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Models.People;
using EHA_AspNetCore.Models.Sales;
using EHA_AspNetCore_Angular.Models.Base;
using EHA_AspNetCore_Angular.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace EHA_AspNetCore_Angular.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Instalment> Instalments { get; set; }
        public DbSet<PaymentCondition> PaymentConditions { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<ItemSale> ItemsSale { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(e => e.Brand);
            modelBuilder.Entity<Product>()
                .HasOne(e => e.Category);

            modelBuilder.Entity<Identification>().UseTpcMappingStrategy();
            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Identification>().HasKey("Id");

            modelBuilder.Entity<Brand>()
                .UseTpcMappingStrategy();
            modelBuilder.Entity<Product>()
                .UseTpcMappingStrategy();
            modelBuilder.Entity<Category>()
                .UseTpcMappingStrategy();
            //

            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            modelBuilder.Entity<Instalment>().ToTable("Instalments");
            modelBuilder.Entity<PaymentCondition>().ToTable("PaymentConditions");

            modelBuilder.Entity<PaymentMethod>()
                .UseTpcMappingStrategy();
            modelBuilder.Entity<PaymentCondition>()
                .UseTpcMappingStrategy();

            modelBuilder.Entity<Instalment>()
                .HasKey(e => new { e.PaymentConditionId, e.Number });
            modelBuilder.Entity<Instalment>()
                .HasOne(e => e.PaymentMethod);       
            modelBuilder.Entity<PaymentCondition>()
                .HasMany(e => e.InstalmentList);

            //

            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<Supplier>()
                .UseTpcMappingStrategy();
            modelBuilder.Entity<Customer>()
                .UseTpcMappingStrategy();

            modelBuilder.Entity<Customer>()
                .HasOne(e => e.PaymentCondition);
            modelBuilder.Entity<Supplier>()
                .HasOne(e => e.PaymentCondition);

            //

            modelBuilder.Entity<ItemSale>().ToTable("ItemsSale");
            modelBuilder.Entity<Sale>().ToTable("Sales");

            modelBuilder.Entity<Sale>()
                .UseTpcMappingStrategy();

            modelBuilder.Entity<ItemSale>()
                .HasKey(e => new { e.ItemSaleId, e.ProductId });

            modelBuilder.Entity<ItemSale>()
                .HasOne(e => e.Product);
            modelBuilder.Entity<Sale>()
                .HasMany(e => e.SaleItemsList);
            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Customer);



            //modelBuilder.Entity<Customer>()
            //    .HasOne(e => e.PreferredPayCondition);
            //modelBuilder.Entity<Supplier>()
            //    .HasOne(e => e.PreferredPayCondition);

            //modelBuilder.Entity<Sale>()
            //    .HasMany(e => e.SaleItemsList);
            //modelBuilder.Entity<Sale>()
            //    .HasOne(e => e.PaymentCondition);
            //modelBuilder.Entity<SaleItems>()
            //    .HasOne(e => e.Product);

            //modelBuilder.Entity<Purchase>()
            //    .HasOne(e => e.PaymentCondition);
            //modelBuilder.Entity<Purchase>()
            //    .HasOne(e => e.PurchaseItemsList);
            //modelBuilder.Entity<PurchaseItems>()
            //    .HasOne(e => e.Product);
        }

    }
}
