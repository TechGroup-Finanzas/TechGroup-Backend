using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Metadata;
using TechGroup.Infrastructure.TechGroup.Answers.Models;
using TechGroup.Infrastructure.TechGroup.Products.Models;
using TechGroup.Infrastructure.TechGroup.Questions.Models;
using TechGroup.Infrastructure.TechGroup.Users.Models;
using TechGroup.Infrastructure.TechGroup.Customers.Models;
using TechGroup.Infrastructure.TechGroup.Payplans.Models;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

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

        public DbSet<Customer> Customer {get;set;}
        public DbSet<Payplan> Payplan { get;set;}
        public DbSet<Purchase> Purchase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql("server=roundhouse.proxy.rlwy.net;port=45071;user=root;password=TLvElcYbTCBgaopJcuGHMXpHLWxccESh;database=railway", serverVersion);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Phone_number);
            modelBuilder.Entity<User>().Property(u => u.Country_code);
            modelBuilder.Entity<User>().HasOne(u => u.Profile).WithOne().HasForeignKey<Profile>(p => p.User_id).IsRequired();
            */

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Dni).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.CreatedAt).IsRequired().HasDefaultValue(DateOnly.FromDateTime(DateTime.UtcNow));
            modelBuilder.Entity<User>().Property(u => u.Birthday).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Phone).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Photo).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Mora).IsRequired();
            
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired().HasPrecision(2);
            modelBuilder.Entity<Product>().Property(p => p.Amount).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.CreatedAt).IsRequired().HasDefaultValue(DateOnly.FromDateTime(DateTime.UtcNow));

            
            modelBuilder.Entity<Question>().ToTable("question");
            modelBuilder.Entity<Question>().HasKey(q => q.Id);
            modelBuilder.Entity<Question>().Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Question>().Property(q => q.Title).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.Description).IsRequired();
            modelBuilder.Entity<Question>().HasOne(q => q.User)
                .WithMany()            
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Question>().Navigation(q => q.User).AutoInclude();
            modelBuilder.Entity<Question>().Property(q => q.CreatedAt).IsRequired().HasDefaultValue(DateOnly.FromDateTime(DateTime.UtcNow));
            
            modelBuilder.Entity<Answer>().ToTable("answer");
            modelBuilder.Entity<Answer>().HasKey(a => a.Id);
            modelBuilder.Entity<Answer>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Answer>().Property(a => a.Description).IsRequired();
            modelBuilder.Entity<Answer>().HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Answer>().Navigation(a => a.Question).AutoInclude();
            modelBuilder.Entity<Answer>().Property(a => a.CreatedAt).IsRequired().HasDefaultValue(DateOnly.FromDateTime(DateTime.UtcNow));

            modelBuilder.Entity<Customer>().ToTable("customers");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(c => c.User_id).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Lastname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Dni).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Birthdate).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Phone).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Rate_type).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Customer>().Property(c => c.Capitalization).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Rate).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Period).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Limit).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Status).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Payment_date).IsRequired();

            modelBuilder.Entity<Payplan>().ToTable("payplans");
            modelBuilder.Entity<Payplan>().HasKey(p => p.Id);
            modelBuilder.Entity<Payplan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Payplan>().Property(p => p.Id_customer).IsRequired();
            modelBuilder.Entity<Payplan>().Property(p => p.Amount).IsRequired();
            modelBuilder.Entity<Payplan>().Property(p => p.Monthlyrate).IsRequired();
            modelBuilder.Entity<Payplan>().Property(p => p.Number_of_payments).IsRequired();
            modelBuilder.Entity<Payplan>().Property(p => p.Grace_periods).IsRequired();
            modelBuilder.Entity<Payplan>().Property(p => p.Grace_type).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Payplan>().Property(p => p.Date_register).IsRequired();
            modelBuilder.Entity<Payplan>().Property(p => p.Status).IsRequired().HasMaxLength(100);


            modelBuilder.Entity<Purchase>().ToTable("purchases");
            modelBuilder.Entity<Purchase>().HasKey(p => p.Id);
            modelBuilder.Entity<Purchase>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Purchase>().Property(p => p.Id_customer).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.Product_name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Purchase>().Property(p => p.Price).IsRequired().HasPrecision(2);
            modelBuilder.Entity<Purchase>().Property(p => p.Amount).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.Date_register).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.Interest).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.Status).IsRequired().HasMaxLength(100); 


        }
    }
}
