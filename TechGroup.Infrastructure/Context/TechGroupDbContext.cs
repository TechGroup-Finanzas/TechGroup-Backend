using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Metadata;
using TechGroup.Infrastructure.TechGroup.Answers.Models;
using TechGroup.Infrastructure.TechGroup.Products.Models;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;
using TechGroup.Infrastructure.TechGroup.PurchasesProducts.Models;
using TechGroup.Infrastructure.TechGroup.Questions.Models;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.Infrastructure.Context
{
    public class TechGroupDbContext : DbContext
    {
        public TechGroupDbContext() { }
        public TechGroupDbContext(DbContextOptions<TechGroupDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchasesProducts> PurchaseProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=root1234;Database=TechGroupDb", serverVersion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureUser(modelBuilder);
            ConfigureProduct(modelBuilder);
            ConfigureQuestion(modelBuilder);
            ConfigureAnswer(modelBuilder);
            ConfigurePurchase(modelBuilder);
            ConfigurePurchaseProduct(modelBuilder);
        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("user")
                .HasKey(u => u.Id);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Dni)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }

        private void ConfigureProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("product")
                .HasKey(p => p.Id);
    
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
    
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
    
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired()
                .HasPrecision(2);
    
            modelBuilder.Entity<Product>()
                .Property(p => p.Amount)
                .IsRequired();
    
            modelBuilder.Entity<Product>()
                .Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            // Relación con PurchaseProduct
            modelBuilder.Entity<Product>()
                .HasMany(p => p.PurchaseProducts)
                .WithOne(pp => pp.Product)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }


        private void ConfigureQuestion(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .ToTable("question")
                .HasKey(q => q.Id);
            
            modelBuilder.Entity<Question>()
                .Property(q => q.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Question>()
                .Property(q => q.Title)
                .IsRequired();
            
            modelBuilder.Entity<Question>()
                .Property(q => q.Description)
                .IsRequired();
            
            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany()
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Question>()
                .Navigation(q => q.User)
                .AutoInclude();
            
            modelBuilder.Entity<Question>()
                .Property(q => q.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }

        private void ConfigureAnswer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .ToTable("answer")
                .HasKey(a => a.Id);
            
            modelBuilder.Entity<Answer>()
                .Property(a => a.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Answer>()
                .Property(a => a.Description)
                .IsRequired();
            
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Answer>()
                .Navigation(a => a.Question)
                .AutoInclude();
            
            modelBuilder.Entity<Answer>()
                .Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }

        private void ConfigurePurchase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
                .ToTable("purchase")
                .HasKey(p => p.Id);
            
            modelBuilder.Entity<Purchase>()
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Purchase>()
                .Property(p => p.UserId)
                .IsRequired();
            
            modelBuilder.Entity<Purchase>()
                .Property(p => p.Price)
                .IsRequired()
                .HasPrecision(2);
            
            modelBuilder.Entity<Purchase>()
                .Property(p => p.Amount)
                .IsRequired()
                .HasPrecision(2);
            
            modelBuilder.Entity<Purchase>()
                .Property(p => p.DateRegister)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
            
            modelBuilder.Entity<Purchase>()
                .Property(p => p.Interest)
                .IsRequired();
            
            modelBuilder.Entity<Purchase>()
                .Property(p => p.Status)
                .IsRequired();
            
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Purchase>()
                .HasMany(p => p.PurchaseProducts)
                .WithOne()
                .HasForeignKey(pp => pp.PurchaseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigurePurchaseProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchasesProducts>()
                .ToTable("purchaseproduct")
                .HasKey(pp => new { pp.PurchaseId, pp.ProductId });
            
            modelBuilder.Entity<PurchasesProducts>()
                .HasOne(pp => pp.Purchase)
                .WithMany(p => p.PurchaseProducts)
                .HasForeignKey(pp => pp.PurchaseId);
            
            modelBuilder.Entity<PurchasesProducts>()
                .HasOne(pp => pp.Product)
                .WithMany()
                .HasForeignKey(pp => pp.ProductId);
        }
    }
}
