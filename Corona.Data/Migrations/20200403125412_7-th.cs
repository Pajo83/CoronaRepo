using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Data.Migrations
{
    public partial class _7th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Histories_HistoryId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HistoryId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Histories_HistoryId",
                table: "Patients",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Histories_HistoryId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "HistoryId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Histories_HistoryId",
                table: "Patients",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
