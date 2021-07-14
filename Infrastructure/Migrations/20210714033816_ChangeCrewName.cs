using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeCrewName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrew_Crews88888_CrewId",
                table: "MovieCrew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crews88888",
                table: "Crews88888");

            migrationBuilder.RenameTable(
                name: "Crews88888",
                newName: "Crew");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crew",
                table: "Crew",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrew_Crew_CrewId",
                table: "MovieCrew",
                column: "CrewId",
                principalTable: "Crew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrew_Crew_CrewId",
                table: "MovieCrew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crew",
                table: "Crew");

            migrationBuilder.RenameTable(
                name: "Crew",
                newName: "Crews88888");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crews88888",
                table: "Crews88888",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrew_Crews88888_CrewId",
                table: "MovieCrew",
                column: "CrewId",
                principalTable: "Crews88888",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
