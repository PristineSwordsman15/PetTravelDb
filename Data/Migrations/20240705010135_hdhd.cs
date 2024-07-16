using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetTravelDb.Data.Migrations
{
    /// <inheritdoc />
    public partial class hdhd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingProcess",
                table: "BookingProcess");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookingProcess",
                newName: "PetFlight");

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Flights",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BookingRefNo",
                table: "Flights",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AnimalName",
                table: "Flights",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AirlinesId",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Flights",
                type: "datetime2",
                maxLength: 10,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PetFlight",
                table: "BookingProcess",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BookingProcessID",
                table: "BookingProcess",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "BookingProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BookingProcesEmail",
                table: "BookingProcess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookingProcesPhone",
                table: "BookingProcess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookingProcessCard",
                table: "BookingProcess",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookingRefNo",
                table: "BookingProcess",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AirlinesName",
                table: "Airlines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AirlinesDescription",
                table: "Airlines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingProcess",
                table: "BookingProcess",
                column: "BookingProcessID");

            migrationBuilder.CreateTable(
                name: "PetFlights",
                columns: table => new
                {
                    PetFlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    FlightsId = table.Column<int>(type: "int", nullable: false),
                    PetID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingProcessID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetFlights", x => x.PetFlightId);
                    table.ForeignKey(
                        name: "FK_PetFlights_BookingProcess_BookingProcessID",
                        column: x => x.BookingProcessID,
                        principalTable: "BookingProcess",
                        principalColumn: "BookingProcessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetFlights_Flights_FlightsId",
                        column: x => x.FlightsId,
                        principalTable: "Flights",
                        principalColumn: "FlightsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetFlights_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_OwnerID",
                table: "Pet",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlinesId",
                table: "Flights",
                column: "AirlinesId");

            migrationBuilder.CreateIndex(
                name: "IX_PetFlights_BookingProcessID",
                table: "PetFlights",
                column: "BookingProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_PetFlights_FlightsId",
                table: "PetFlights",
                column: "FlightsId");

            migrationBuilder.CreateIndex(
                name: "IX_PetFlights_PetId",
                table: "PetFlights",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlinesId",
                table: "Flights",
                column: "AirlinesId",
                principalTable: "Airlines",
                principalColumn: "AirlinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Owner_OwnerID",
                table: "Pet",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlinesId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Owner_OwnerID",
                table: "Pet");

            migrationBuilder.DropTable(
                name: "PetFlights");

            migrationBuilder.DropIndex(
                name: "IX_Pet_OwnerID",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirlinesId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingProcess",
                table: "BookingProcess");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "AirlinesId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "BookingProcessID",
                table: "BookingProcess");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "BookingProcess");

            migrationBuilder.DropColumn(
                name: "BookingProcesEmail",
                table: "BookingProcess");

            migrationBuilder.DropColumn(
                name: "BookingProcesPhone",
                table: "BookingProcess");

            migrationBuilder.DropColumn(
                name: "BookingProcessCard",
                table: "BookingProcess");

            migrationBuilder.DropColumn(
                name: "BookingRefNo",
                table: "BookingProcess");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalAddress",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PetFlight",
                table: "BookingProcess",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<int>(
                name: "BookingRefNo",
                table: "Flights",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "AnimalName",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BookingProcess",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AirlinesName",
                table: "Airlines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AirlinesDescription",
                table: "Airlines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingProcess",
                table: "BookingProcess",
                column: "Id");
        }
    }
}
