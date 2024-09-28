using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllocationsTableToAddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Allocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_CategoryId",
                table: "Allocation",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Categories_CategoryId",
                table: "Allocation",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Categories_CategoryId",
                table: "Allocation");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_CategoryId",
                table: "Allocation");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Allocation");
        }
    }
}
