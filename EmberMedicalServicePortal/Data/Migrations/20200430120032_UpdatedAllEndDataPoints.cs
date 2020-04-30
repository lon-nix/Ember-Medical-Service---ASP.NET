using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmberMedicalServicePortal.Data.Migrations
{
    public partial class UpdatedAllEndDataPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeVM",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListOfAppointmentVM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<string>(nullable: true),
                    PatientID1 = table.Column<int>(nullable: true),
                    ApptDate = table.Column<DateTime>(nullable: false),
                    ApptTime = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfAppointmentVM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListOfAppointmentVM_PatientInfoVM_PatientID1",
                        column: x => x.PatientID1,
                        principalTable: "PatientInfoVM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistoryVM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<string>(nullable: true),
                    PatientID1 = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Weight_lb = table.Column<float>(nullable: false),
                    Height_cm = table.Column<float>(nullable: false),
                    Blood_Sugar = table.Column<string>(nullable: true),
                    Blood_Pressure = table.Column<string>(nullable: true),
                    Symptoms = table.Column<string>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    Prescription = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistoryVM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalHistoryVM_PatientInfoVM_PatientID1",
                        column: x => x.PatientID1,
                        principalTable: "PatientInfoVM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfAppointmentVM_PatientID1",
                table: "ListOfAppointmentVM",
                column: "PatientID1");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryVM_PatientID1",
                table: "MedicalHistoryVM",
                column: "PatientID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVM");

            migrationBuilder.DropTable(
                name: "ListOfAppointmentVM");

            migrationBuilder.DropTable(
                name: "MedicalHistoryVM");
        }
    }
}
