using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Donations",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Donations",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Donations",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Disasters",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Disasters",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "disaster",
                table: "Disasters",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CategoryId",
                table: "Donations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Categories_CategoryId",
                table: "Donations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Categories_CategoryId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_CategoryId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Donations",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Donations",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Donations",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Disasters",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Disasters",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Disasters",
                newName: "disaster");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
