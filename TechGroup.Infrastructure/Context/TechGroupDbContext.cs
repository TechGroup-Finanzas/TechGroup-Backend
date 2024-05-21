using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Metadata;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace RoleplayApp.Infrastructure.Context
{
    public class TechGroupDbContext : DbContext
    {
        public TechGroupDbContext() { }
        public TechGroupDbContext(DbContextOptions<TechGroupDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=admin;Database=TechGroupDb", serverVersion);
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


        }
    }
}
