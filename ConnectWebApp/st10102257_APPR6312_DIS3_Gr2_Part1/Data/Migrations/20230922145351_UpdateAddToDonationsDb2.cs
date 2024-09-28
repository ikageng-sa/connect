using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddToDonationsDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recordedby",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "Donor",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "Donor",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "recordedby",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
