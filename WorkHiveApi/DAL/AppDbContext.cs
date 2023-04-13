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
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Profile> Profiles { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=tcp:server31056386.database.windows.net,1433;Initial Catalog=workhive;Persist Security Info=False;User ID=c1056386;Password=@Lucifer666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n");
            //optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=workhive5;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
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
            //modelbuilder.Entity<Review>()
            //.HasOne(r => r.Freelancer)
            //.WithMany(u => u.FreelancerReviews)
            //.HasForeignKey(r => r.FreelancerId)
            //.OnDelete(DeleteBehavior.Restrict);

            //modelbuilder.Entity<Review>()
            //    .HasOne(r => r.Client)
            //    .WithMany(u => u.ClientReviews)
            //    .HasForeignKey(r => r.ClientId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
