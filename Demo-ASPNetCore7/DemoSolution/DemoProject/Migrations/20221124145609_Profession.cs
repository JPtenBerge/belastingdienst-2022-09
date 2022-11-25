using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoProject.Migrations
{
    /// <inheritdoc />
    public partial class Profession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Professions",
                column: "Title",
                values: new object[] { "CEO", "Software developer", "Brandweervrouw" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfessionId",
                value: 2);
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfessionId",
                value: 2);
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfessionId",
                value: 1);
            
            migrationBuilder.CreateIndex(
                name: "IX_Persons_ProfessionId",
                table: "Persons",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Professions_ProfessionId",
                table: "Persons",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // all data that I've added will be automatically removed when all columns/tables are removed
            
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Professions_ProfessionId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ProfessionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "Persons");
        }
    }
}
