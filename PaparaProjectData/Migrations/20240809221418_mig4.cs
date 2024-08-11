using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaparaProjectData.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "UserCouponMap");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "UserCouponMap");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "ProductCategoryMap");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "ProductCategoryMap");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Basket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Wallet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Wallet",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "UserCouponMap",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "UserCouponMap",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "ProductCategoryMap",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "ProductCategoryMap",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "OrderDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Order",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Invoice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Coupon",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Coupon",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Category",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "BasketItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "BasketItem",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Basket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Basket",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
