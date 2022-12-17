using CustomerManagmentSysytem.Data.Mdoels;
using CustomerManagmentSysytem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Service>()
                .HasOne(c => c.Customers)
                .WithMany(b => b.Customer_Service)
                .HasForeignKey(k => k.CustomerId);

            modelBuilder.Entity<Customer_Service>()
                .HasOne(c => c.ServiceTypes)
                .WithMany(b => b.Customer_Service)
                .HasForeignKey(k => k.ServiceId);

            modelBuilder.Entity<ServiceTypes>().HasAlternateKey(c => c.ServiceName);


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Customers> Customers { get; set; }
        //public DbSet<Dependencies> Dependencies { get; set; }
        public DbSet<Analytical> analytical { get; set; }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<ServiceTypes> ServiceTypes { get; set; }

        public DbSet<Customer_Service> Customer_Service { get; set; }
        public DbSet<projectSpace> projectSpaces { get; set; }

    }
}
