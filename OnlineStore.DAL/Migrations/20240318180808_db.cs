using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_TypeProduct_TypeProductId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProduct",
                table: "TypeProduct");

            migrationBuilder.RenameTable(
                name: "TypeProduct",
                newName: "TypeProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_TypeProducts_TypeProductId",
                table: "product",
                column: "TypeProductId",
                principalTable: "TypeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_TypeProducts_TypeProductId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts");

            migrationBuilder.RenameTable(
                name: "TypeProducts",
                newName: "TypeProduct");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProduct",
                table: "TypeProduct",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "huntandfishdylo@gmail.com");

            migrationBuilder.AddForeignKey(
                name: "FK_product_TypeProduct_TypeProductId",
                table: "product",
                column: "TypeProductId",
                principalTable: "TypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
