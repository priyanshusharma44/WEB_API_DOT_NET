using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_API_DOT_NET.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeyreference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VilaID",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VilaID",
                table: "VillaNumbers",
                column: "VilaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VilaID",
                table: "VillaNumbers",
                column: "VilaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VilaID",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VilaID",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VilaID",
                table: "VillaNumbers");
        }
    }
}
