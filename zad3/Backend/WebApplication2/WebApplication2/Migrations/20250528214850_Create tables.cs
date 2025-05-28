using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Createtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    idMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicament", x => x.idMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patient_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "IdPatient");
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicament", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_Prescription_Medicament_Medicament_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "idMedicament");
                    table.ForeignKey(
                        name: "FK_Prescription_Medicament_Prescriptions_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription");
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "bondjames@gmail.com", "James", "Bond" },
                    { 2, "dostoywskiisbad@gmail.com", "Vladimir", "Nabukov" },
                    { 3, "lolitaluv@gmail.com", "Humbert", "Humbert" },
                    { 4, "biliongazilion@gmail.com", "Dr", "Evil" },
                    { 5, "thebiggestthebestcriminal@gmail.com", "Donald", "Trump" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "idMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Antydepresant z grupy SSRI", "Sertralina", "Inhibitor wychwytu zwrotnego serotoniny" },
                    { 2, "Stosowany w leczeniu bólu i gorączki", "Paracetamol", "Przeciwbólowy i przeciwgorączkowy" },
                    { 3, "Antybiotyk penicylinowy", "Amoksycylina", "Antybiotyk" },
                    { 4, "Rozrzedza krew i zmniejsza stan zapalny", "Kwas acetylosalicylowy", "Przeciwbólowy i przeciwzapalny" },
                    { 5, "Łagodzi objawy alergii", "Loratadyna", "Antyalergiczny" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 28, 23, 48, 49, 623, DateTimeKind.Local).AddTicks(6634), "Tony", "Stark" },
                    { 2, new DateTime(2025, 5, 28, 23, 48, 49, 625, DateTimeKind.Local).AddTicks(3260), "Frank", "Sinatra" },
                    { 3, new DateTime(2025, 5, 28, 23, 48, 49, 625, DateTimeKind.Local).AddTicks(3277), "Joe", "Cocker" },
                    { 4, new DateTime(2025, 5, 28, 23, 48, 49, 625, DateTimeKind.Local).AddTicks(3280), "Rodion", "Raskolnikov" },
                    { 5, new DateTime(2025, 5, 28, 23, 48, 49, 625, DateTimeKind.Local).AddTicks(3282), "Jozef", "Pilsudski" }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 1, 3, "1x dziennie", 100 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(8632), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(8796), 1, 1 },
                    { 2, new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9052), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9054), 2, 2 },
                    { 4, new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9056), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9057), 1, 4 },
                    { 5, new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9059), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9060), 2, 5 },
                    { 6, new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9062), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9063), 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "1x dziennie", 10 },
                    { 1, 2, "2x dziennie", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
