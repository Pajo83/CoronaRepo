using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Data.Migrations
{
    public partial class _8th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Histories_HistoryId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HistoryId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Patients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HistoryId",
                table: "Patients",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Histories_HistoryId",
                table: "Patients",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
