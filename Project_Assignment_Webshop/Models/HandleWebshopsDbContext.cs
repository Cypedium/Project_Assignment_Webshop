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
        public DbSet<Product> Products { get; set; }
        //public DbSet<Product> Orders { get; set; }
        //public DbSet<Product> Customers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    base.OnModelCreating(modelbuilder);
        //}
    }
}
