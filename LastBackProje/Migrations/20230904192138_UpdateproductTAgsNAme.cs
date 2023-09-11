using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastBackProje.Migrations
{
    public partial class UpdateproductTAgsNAme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "ProductTags");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "ProductTags",
                newName: "TagID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                newName: "IX_ProductTags_TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagID",
                table: "ProductTags",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagID",
                table: "ProductTags");

            migrationBuilder.RenameColumn(
                name: "TagID",
                table: "ProductTags",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagID",
                table: "ProductTags",
                newName: "IX_ProductTags_TagId");

            migrationBuilder.AddColumn<int>(
                name: "Tags",
                table: "ProductTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
