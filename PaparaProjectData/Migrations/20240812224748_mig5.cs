using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaparaProjectData.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CouponPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CouponCode",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CouponPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Order",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Point",
                table: "Order",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
