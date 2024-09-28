using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace st10102257_APPR6312_DIS3_Gr2_Part1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewgoodsPurchasedTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsPurchased",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsDonationsId = table.Column<int>(type: "int", nullable: false),
                    AmountUsed = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsPurchased", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GoodsPurchased_GoodsDonations_GoodsDonationsId",
                        column: x => x.GoodsDonationsId,
                        principalTable: "GoodsDonations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsPurchased_GoodsDonationsId",
                table: "GoodsPurchased",
                column: "GoodsDonationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsPurchased");
        }
    }
}
