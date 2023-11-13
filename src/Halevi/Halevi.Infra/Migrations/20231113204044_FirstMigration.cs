using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halevi.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    InStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CATEGORY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTVARIATION",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: true),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTVARIATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCTVARIATION_PRODUCT_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CATEGORY",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "Name" },
                values: new object[] { new Guid("e1e7e405-4690-42e8-8423-dd9ecd389bc7"), true, 1, new DateOnly(2023, 11, 13), "Categoria 1" });

            migrationBuilder.InsertData(
                table: "PRODUCT",
                columns: new[] { "Id", "Active", "CategoryId", "Code", "CreatedAt", "Description", "InStock", "Name", "Price" },
                values: new object[] { new Guid("a4679709-46fc-4fe4-92bc-b227354abaa7"), true, new Guid("e1e7e405-4690-42e8-8423-dd9ecd389bc7"), 1, new DateOnly(2023, 11, 13), "É o Produto 1", true, "Produto 1", 20.5 });

            migrationBuilder.InsertData(
                table: "PRODUCTVARIATION",
                columns: new[] { "Id", "Active", "Code", "CreatedAt", "Image", "Name", "ProductId" },
                values: new object[] { new Guid("48250a1e-4b9b-4360-be12-c41ec66219ea"), true, 1, new DateOnly(2023, 11, 13), null, "Variação do Produto 1", new Guid("a4679709-46fc-4fe4-92bc-b227354abaa7") });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_Code",
                table: "CATEGORY",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_CategoryId",
                table: "PRODUCT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_Code",
                table: "PRODUCT",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTVARIATION_Code",
                table: "PRODUCTVARIATION",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTVARIATION_ProductId",
                table: "PRODUCTVARIATION",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTVARIATION");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "CATEGORY");
        }
    }
}
