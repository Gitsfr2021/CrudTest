using Mc2.Application.Common.Interfaces;
using Mc2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Persistence.Data
{
    public class AppDBContext : DbContext, IDataBaseContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<Customer>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
