using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Categories_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_PublishingHouses_PublishingHouseId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Book_BookId",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCarts_Book_ISBN",
                table: "ShopingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_Book_PublishingHouseId",
                table: "Books",
                newName: "IX_Books_PublishingHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CategoryId",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_BookId",
                table: "BookAuthors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCarts_Books_ISBN",
                table: "ShopingCarts",
                column: "ISBN",
                principalTable: "Books",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_BookId",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_PublishingHouses_PublishingHouseId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCarts_Books_ISBN",
                table: "ShopingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PublishingHouseId",
                table: "Book",
                newName: "IX_Book_PublishingHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "Book",
                newName: "IX_Book_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Categories_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_PublishingHouses_PublishingHouseId",
                table: "Book",
                column: "PublishingHouseId",
                principalTable: "PublishingHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Book_BookId",
                table: "BookAuthors",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCarts_Book_ISBN",
                table: "ShopingCarts",
                column: "ISBN",
                principalTable: "Book",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
