using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataConverter.Persistence.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    AircraftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    YearOfDelivery = table.Column<string>(type: "varchar(4)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OwnerAirline = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FirstClassSeats = table.Column<int>(type: "int", nullable: false),
                    BusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    PremiumEconomyClassSeats = table.Column<int>(type: "int", nullable: false),
                    EconomyClassSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.AircraftId);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AirportName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AirportCity = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AirportCountry = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsInternational = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportCode);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    AmenitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealsProvided = table.Column<bool>(type: "bit", nullable: false),
                    InFlightEntertainment = table.Column<bool>(type: "bit", nullable: false),
                    BaggageLimit = table.Column<int>(type: "int", nullable: false),
                    CancellationCharges = table.Column<double>(type: "float", nullable: false),
                    FlightChangeCharges = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.AmenitiesId);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    PilotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AirLine = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.PilotId);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FLightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightNumber = table.Column<string>(type: "varchar(8)", nullable: false),
                    AirLine = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Fare = table.Column<double>(type: "float", nullable: false),
                    DeptTime = table.Column<string>(type: "varchar(8)", nullable: false),
                    ArrivalTime = table.Column<string>(type: "varchar(8)", nullable: false),
                    SourceCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignatedAircraftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignatedPilotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvidedAmenitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceAirportCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DestinationAirportCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FLightId);
                    table.ForeignKey(
                        name: "FK_Flight_Aircraft_DesignatedAircraftId",
                        column: x => x.DesignatedAircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Airports_DestinationAirportCode",
                        column: x => x.DestinationAirportCode,
                        principalTable: "Airports",
                        principalColumn: "AirportCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airports_SourceAirportCode",
                        column: x => x.SourceAirportCode,
                        principalTable: "Airports",
                        principalColumn: "AirportCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Amenities_ProvidedAmenitiesId",
                        column: x => x.ProvidedAmenitiesId,
                        principalTable: "Amenities",
                        principalColumn: "AmenitiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Pilots_DesignatedPilotId",
                        column: x => x.DesignatedPilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DesignatedAircraftId",
                table: "Flight",
                column: "DesignatedAircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DesignatedPilotId",
                table: "Flight",
                column: "DesignatedPilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationAirportCode",
                table: "Flight",
                column: "DestinationAirportCode");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ProvidedAmenitiesId",
                table: "Flight",
                column: "ProvidedAmenitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_SourceAirportCode",
                table: "Flight",
                column: "SourceAirportCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Pilots");
        }
    }
}
