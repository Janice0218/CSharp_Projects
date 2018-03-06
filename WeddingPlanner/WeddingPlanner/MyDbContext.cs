using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
     
        public DbSet<Guest> Guests { get; set; }
    }
}