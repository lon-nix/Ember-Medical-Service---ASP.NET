using Microsoft.EntityFrameworkCore.Migrations;

namespace EmberMedicalServicePortal.Data.Migrations
{
    public partial class TableUpdateForDataPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfAppointmentVM_PatientInfoVM_PatientID1",
                table: "ListOfAppointmentVM");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryVM_PatientInfoVM_PatientID1",
                table: "MedicalHistoryVM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientInfoVM",
                table: "PatientInfoVM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistoryVM",
                table: "MedicalHistoryVM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListOfAppointmentVM",
                table: "ListOfAppointmentVM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeVM",
                table: "EmployeeVM");

            migrationBuilder.RenameTable(
                name: "PatientInfoVM",
                newName: "PatientInfo");

            migrationBuilder.RenameTable(
                name: "MedicalHistoryVM",
                newName: "MedicalHistory");

            migrationBuilder.RenameTable(
                name: "ListOfAppointmentVM",
                newName: "AppointmentList");

            migrationBuilder.RenameTable(
                name: "EmployeeVM",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistoryVM_PatientID1",
                table: "MedicalHistory",
                newName: "IX_MedicalHistory_PatientID1");

            migrationBuilder.RenameIndex(
                name: "IX_ListOfAppointmentVM_PatientID1",
                table: "AppointmentList",
                newName: "IX_AppointmentList_PatientID1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientInfo",
                table: "PatientInfo",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistory",
                table: "MedicalHistory",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentList",
                table: "AppointmentList",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentList_PatientInfo_PatientID1",
                table: "AppointmentList",
                column: "PatientID1",
                principalTable: "PatientInfo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistory_PatientInfo_PatientID1",
                table: "MedicalHistory",
                column: "PatientID1",
                principalTable: "PatientInfo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentList_PatientInfo_PatientID1",
                table: "AppointmentList");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistory_PatientInfo_PatientID1",
                table: "MedicalHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientInfo",
                table: "PatientInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistory",
                table: "MedicalHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentList",
                table: "AppointmentList");

            migrationBuilder.RenameTable(
                name: "PatientInfo",
                newName: "PatientInfoVM");

            migrationBuilder.RenameTable(
                name: "MedicalHistory",
                newName: "MedicalHistoryVM");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "EmployeeVM");

            migrationBuilder.RenameTable(
                name: "AppointmentList",
                newName: "ListOfAppointmentVM");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistory_PatientID1",
                table: "MedicalHistoryVM",
                newName: "IX_MedicalHistoryVM_PatientID1");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentList_PatientID1",
                table: "ListOfAppointmentVM",
                newName: "IX_ListOfAppointmentVM_PatientID1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientInfoVM",
                table: "PatientInfoVM",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistoryVM",
                table: "MedicalHistoryVM",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeVM",
                table: "EmployeeVM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListOfAppointmentVM",
                table: "ListOfAppointmentVM",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfAppointmentVM_PatientInfoVM_PatientID1",
                table: "ListOfAppointmentVM",
                column: "PatientID1",
                principalTable: "PatientInfoVM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryVM_PatientInfoVM_PatientID1",
                table: "MedicalHistoryVM",
                column: "PatientID1",
                principalTable: "PatientInfoVM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
