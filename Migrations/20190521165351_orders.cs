using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ShopingCarts_ShoppingCartId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShopingCarts_ShoppingCartId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopingCarts",
                table: "ShopingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShoppingCartId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Books_ShoppingCartId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShopingCarts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShopingCarts");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "ISBN",
                table: "ShopingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShopingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopingCarts",
                table: "ShopingCarts",
                columns: new[] { "ISBN", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCarts_OrderId",
                table: "ShopingCarts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCarts_Books_ISBN",
                table: "ShopingCarts",
                column: "ISBN",
                principalTable: "Books",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCarts_Orders_OrderId",
                table: "ShopingCarts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCarts_Books_ISBN",
                table: "ShopingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCarts_Orders_OrderId",
                table: "ShopingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopingCarts",
                table: "ShopingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShopingCarts_OrderId",
                table: "ShopingCarts");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "ShopingCarts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShopingCarts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShopingCarts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "ShopingCarts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopingCarts",
                table: "ShopingCarts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShoppingCartId",
                table: "Books",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ShopingCarts_ShoppingCartId",
                table: "Books",
                column: "ShoppingCartId",
                principalTable: "ShopingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShopingCarts_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId",
                principalTable: "ShopingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
