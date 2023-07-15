using Mango.Services.CoupanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CoupanAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }
        public DbSet<Coupon> Coupons {get; set;} // this will become the name of Table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId=1,
                CouponCode="100FF",
                DiscountAmount=10,
                MiniAmount=20
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "200FF",
                DiscountAmount = 20,
                MiniAmount = 40
            });
        }
    }
}
