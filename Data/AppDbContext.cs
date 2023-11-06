using EHA_AspNetCore.Models.Bills;
using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Models.People;
using EHA_AspNetCore.Models.Purchases;
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

        public DbSet<ItemPurchase> ItemsPurchase { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<BillToReceive> BillsToReceive { get; set; }
        public DbSet<BillToPay> BillsToPay { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(e => e.Brand);
            modelBuilder.Entity<Product>()
                .HasOne(e => e.Category);

            modelBuilder.Entity<Product>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Brand>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Brand>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

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

            modelBuilder.Entity<PaymentMethod>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PaymentCondition>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<PaymentCondition>()
                .HasMany(e => e.InstalmentList);            
                
            modelBuilder.Entity<PaymentMethod>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<PaymentCondition>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

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

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Supplier>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .HasOne(e => e.PaymentCondition);
            modelBuilder.Entity<Supplier>()
                .HasOne(e => e.PaymentCondition);

            //

            modelBuilder.Entity<ItemSale>().ToTable("ItemsSale");
            modelBuilder.Entity<Sale>().ToTable("Sales");

            modelBuilder.Entity<Sale>()
                .UseTpcMappingStrategy();

            modelBuilder.Entity<Sale>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ItemSale>()
                .HasKey(e => new { e.ItemSaleId, e.ProductId });

            modelBuilder.Entity<ItemSale>()
                .HasOne(e => e.Product);
            modelBuilder.Entity<Sale>()
                .HasMany(e => e.SaleItemsList);
            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Customer);

            //

            modelBuilder.Entity<Purchase>().ToTable("Purchases");
            modelBuilder.Entity<ItemPurchase>().ToTable("ItemsPurchase");

            modelBuilder.Entity<Purchase>()
                .HasKey(e => new { e.BillModel, e.BillNumber, e.BillSeries, e.SupplierId });
            modelBuilder.Entity<ItemPurchase>()
                .HasKey(e => new { e.PurchaseBillModel, e.PurchaseBillNumber, e.PurchaseBillSeries, e.PurchaseSupplierId, e.ProductId });

            modelBuilder.Entity<ItemPurchase>()
                .HasOne(e => e.Product);

            modelBuilder.Entity<Purchase>()
                .HasOne(e => e.Supplier)
                .WithMany()
                .HasForeignKey(e => e.SupplierId);

            modelBuilder.Entity<Purchase>()
                .HasMany(p => p.ItemPurchaseList)
                .WithOne()
                .HasForeignKey( ip => new { ip.PurchaseBillModel, ip.PurchaseBillNumber, ip.PurchaseBillSeries, ip.PurchaseSupplierId});

            modelBuilder.Entity<Purchase>()
                .HasOne(e => e.PaymentCondition);

            //

            modelBuilder.Entity<BillToPay>().ToTable("BillsToPay");
            modelBuilder.Entity<BillToReceive>().ToTable("BillsToReceive");

            modelBuilder.Entity<BillToReceive>()
                .UseTpcMappingStrategy();

            modelBuilder.Entity<BillToReceive>()
                .HasOne(e => e.PaymentMethod);
            modelBuilder.Entity<BillToReceive>()
                .HasOne(e => e.Sale);
            modelBuilder.Entity<BillToReceive>()
                .HasOne(e => e.Customer);

            modelBuilder.Entity<BillToPay>()
                .HasOne(e => e.Purchase);
            modelBuilder.Entity<BillToPay>()
                .HasOne(e => e.Supplier);
            modelBuilder.Entity<BillToPay>()
                .HasOne(e => e.PaymentMethod);

            modelBuilder.Entity<BillToReceive>()
                .HasKey(e => new { e.InstalmentNumber, e.Id });
            modelBuilder.Entity<BillToPay>()
                .HasKey(e => new { e.BillModel, e.BillNumber, e.BillSeries, e.SupplierId, e.InstalmentNumber });

            modelBuilder.Entity<BillToReceive>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();



        }
    }
}
