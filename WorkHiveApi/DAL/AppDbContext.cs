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
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

        }
    }
}
