using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_GoodsDonations_DonationId",
                table: "Allocation");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_DonationId",
                table: "Allocation");

            migrationBuilder.DropColumn(
                name: "DonationId",
                table: "Allocation");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Allocation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Allocation");

            migrationBuilder.AddColumn<int>(
                name: "DonationId",
                table: "Allocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_DonationId",
                table: "Allocation",
                column: "DonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_GoodsDonations_DonationId",
                table: "Allocation",
                column: "DonationId",
                principalTable: "GoodsDonations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
