using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DAL
{
    public  class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        public AppDbContext()
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Profile> Profiles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string contentRoot = Environment.GetEnvironmentVariable("ASPNETCORE_CONTENTROOT");
            if (string.IsNullOrEmpty(contentRoot))
            {
             contentRoot = AppDomain.CurrentDomain.BaseDirectory;
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

         optionBuilder.UseSqlServer(configuration.GetConnectionString("DBConnection"));

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            //renaming the default tables
            modelbuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelbuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelbuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelbuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelbuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelbuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelbuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            
        }
    }
}
