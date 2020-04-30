using Microsoft.EntityFrameworkCore.Migrations;

namespace EmberMedicalServicePortal.Data.Migrations
{
    public partial class UpdatedPatientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "PatientInfoVM",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "PatientInfoVM");
        }
    }
}
