using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccounts.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
