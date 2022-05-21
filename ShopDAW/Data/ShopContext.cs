using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using ShopDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many
            modelBuilder.Entity<User>().HasMany(c => c.orders).WithOne(u => u.User);
            //One to one
            modelBuilder.Entity<User>().HasOne(u => u.address).WithOne(adr => adr.User);
            //Many to many
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.productId, op.orderId });
            modelBuilder.Entity<OrderProduct>().HasOne(op => op.Order).WithMany(o => o.orderProducts).HasForeignKey(op => op.orderId); //one to many intre Order si OrderProduct
            modelBuilder.Entity<OrderProduct>().HasOne(op => op.Product).WithMany(p => p.orderProducts).HasForeignKey(op => op.productId); //one to many intre Product si OrderProduct

        }
    }
}
