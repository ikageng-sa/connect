using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAndAddTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Donations_DonationId",
                table: "Allocation");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.CreateTable(
                name: "GoodsDonations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Donor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAllocated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDonations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GoodsDonations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonetaryDonations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Donor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAllocated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonetaryDonations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonetaryDonations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsDonations_CategoryId",
                table: "GoodsDonations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MonetaryDonations_CategoryId",
                table: "MonetaryDonations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_GoodsDonations_DonationId",
                table: "Allocation",
                column: "DonationId",
                principalTable: "GoodsDonations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_GoodsDonations_DonationId",
                table: "Allocation");

            migrationBuilder.DropTable(
                name: "GoodsDonations");

            migrationBuilder.DropTable(
                name: "MonetaryDonations");

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAllocated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Donations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CategoryId",
                table: "Donations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Donations_DonationId",
                table: "Allocation",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
