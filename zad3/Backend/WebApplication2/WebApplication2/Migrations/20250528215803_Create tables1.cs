using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Createtables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 58, 3, 362, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 58, 3, 363, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 58, 3, 363, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 58, 3, 363, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 58, 3, 363, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(6652), new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(7165), new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(7167) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(7169), new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 5,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(7172), new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(7174) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 6,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(7176), new DateTime(2025, 5, 28, 23, 58, 3, 367, DateTimeKind.Local).AddTicks(7177) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 48, 49, 623, DateTimeKind.Local).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 48, 49, 625, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 48, 49, 625, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 48, 49, 625, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2025, 5, 28, 23, 48, 49, 625, DateTimeKind.Local).AddTicks(3282));

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(8632), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(8796) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9052), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9054) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9056), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 5,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9059), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 6,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9062), new DateTime(2025, 5, 28, 23, 48, 49, 628, DateTimeKind.Local).AddTicks(9063) });
        }
    }
}
