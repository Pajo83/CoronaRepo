using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Data.Migrations
{
    public partial class _4th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosisHistory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HistoryId",
                table: "Patients",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_History_HistoryId",
                table: "Patients",
                column: "HistoryId",
                principalTable: "History",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_History_HistoryId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HistoryId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Patients");
        }
    }
}
