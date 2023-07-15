using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.CoupanAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CouponCode",
                table: "Coupons",
                newName: "CouponCode");

            migrationBuilder.RenameColumn(
                name: "CouponId",
                table: "Coupons",
                newName: "CouponId");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponCode", "DiscountAmount", "MiniAmount" },
                values: new object[,]
                {
                    { 1, "100FF", 10.0, 20 },
                    { 2, "200FF", 20.0, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "CouponCode",
                table: "Coupons",
                newName: "CoupanCode");

            migrationBuilder.RenameColumn(
                name: "CouponId",
                table: "Coupons",
                newName: "CouponId");
        }
    }
}
