using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTravelDb.Migrations
{
    /// <inheritdoc />
    public partial class linkairlinesandflights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlinesId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Flights_FlightsId",
                table: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Owner_FlightsId",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "FlightsId",
                table: "Owner");

            migrationBuilder.AlterColumn<int>(
                name: "AirlinesId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlinesId",
                table: "Flights",
                column: "AirlinesId",
                principalTable: "Airlines",
                principalColumn: "AirlinesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlinesId",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "FlightsId",
                table: "Owner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AirlinesId",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_FlightsId",
                table: "Owner",
                column: "FlightsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlinesId",
                table: "Flights",
                column: "AirlinesId",
                principalTable: "Airlines",
                principalColumn: "AirlinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Flights_FlightsId",
                table: "Owner",
                column: "FlightsId",
                principalTable: "Flights",
                principalColumn: "FlightsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
