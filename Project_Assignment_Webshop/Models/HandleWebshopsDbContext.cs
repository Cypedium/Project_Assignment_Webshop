using System;
using System.Collections.Generic;
using System.Text;
using Project_Assignment_Webshop;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Project_Assignment_Webshop.Models
{
    public class HandleWebshopsDbContext : IdentityDbContext
    {
        public HandleWebshopsDbContext(DbContextOptions<HandleWebshopsDbContext> options) : base(options)
        { }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        //--Only needed with many to many database realtionships-------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<OrderRow>()
                .HasOne(p => p.Product)
                .WithOne(o => o.OrderRow)
                .HasForeignKey<Product>(p => p.OrderRowForeignKey);
        }
    }
}
