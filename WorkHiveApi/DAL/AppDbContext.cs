using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Freelancers> Freelancers { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Categories> Categories { get; set; }

        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<Proposals> Proposals { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Payments> Payments { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

           
        }
    }
}
