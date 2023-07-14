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
    }
}
