using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoronaDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecoveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartCoronaDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoronaDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DetailVacsions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoronaDetailsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailVacsions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailVacsions_CoronaDetails_CoronaDetailsid",
                        column: x => x.CoronaDetailsid,
                        principalTable: "CoronaDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Patient = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_Home = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: true),
                    MobilePhone = table.Column<int>(type: "int", nullable: true),
                    CoronaDetailsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_CoronaDetails_CoronaDetailsid",
                        column: x => x.CoronaDetailsid,
                        principalTable: "CoronaDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailVacsions_CoronaDetailsid",
                table: "DetailVacsions",
                column: "CoronaDetailsid");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CoronaDetailsid",
                table: "Patients",
                column: "CoronaDetailsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailVacsions");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "CoronaDetails");
        }
    }
}
