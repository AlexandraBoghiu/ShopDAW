using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using ShopDAW.Entities;
using ShopDAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class ShopContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //One to many
            modelBuilder.Entity<Client>().HasMany(c => c.orders).WithOne(u => u.Client);
            //One to one
            modelBuilder.Entity<Client>().HasOne(u => u.address).WithOne(adr => adr.Client);
            //Many to many
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.productId, op.orderId });
            modelBuilder.Entity<OrderProduct>().HasOne(op => op.Order).WithMany(o => o.orderProducts).HasForeignKey(op => op.orderId); //one to many intre Order si OrderProduct
            modelBuilder.Entity<OrderProduct>().HasOne(op => op.Product).WithMany(p => p.orderProducts).HasForeignKey(op => op.productId); //one to many intre Product si OrderProduct

            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(ar => ar.UserRoles).HasForeignKey(ur => ur.RoleId); //one to many intre Role si UserRole
            modelBuilder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(au => au.UserRoles).HasForeignKey(ur => ur.UserId); //one to many intre User si UserRole

        }
    }
}
