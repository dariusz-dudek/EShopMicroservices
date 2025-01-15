using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon {Id = 1, ProductName = "IPhone X", Description = "Iphone X discount description", Amount = 150},
            new Coupon {Id = 2, ProductName = "Samsung 10", Description = "Samsung 10 discount description", Amount = 100}
            );
    }
}