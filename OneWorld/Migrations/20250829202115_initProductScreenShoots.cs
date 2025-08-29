using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneWorld.Migrations
{
    /// <inheritdoc />
    public partial class initProductScreenShoots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductScreenShoots",
                columns: table => new
                {
                    ScreenShootId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductScreenShoots", x => x.ScreenShootId);
                    table.ForeignKey(
                        name: "FK_ProductScreenShoots_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductScreenShoots_ProductId",
                table: "ProductScreenShoots",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductScreenShoots");
        }
    }
}
