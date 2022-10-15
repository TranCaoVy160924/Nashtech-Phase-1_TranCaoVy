using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public ApplicationDbContext() { }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<OnlineShop> OnlineShops { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // UserAccount
            builder.Entity<UserAccount>()
                .HasOne<OnlineShop>(ua => ua.OnlineShop)
                .WithOne(os => os.Owner)
                .HasForeignKey<OnlineShop>(os => os.OwnerId);

            // Online Good
            //builder.Entity<Good>()
            //    .HasOne<OnlineShop>(g => g.OnlineShop)
            //    .WithMany(os => os.Goods)
            //    .HasForeignKey(g => g.OnlineShopId);

            //// Receipt
            //builder.Entity<Receipt>()
            //    .HasOne<UserAccount>(r => r.Buyer)
            //    .WithMany(ua => ua.Receipts)
            //    .HasForeignKey(r => r.BuyerId);

            //builder.Entity<Receipt>()
            //    .HasOne<Good>(r => r.Good)
            //    .WithMany(g => g.Receipts)
            //    .HasForeignKey(r => r.GoodId);
        }
    }
}
